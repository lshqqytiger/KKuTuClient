using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WebSocketSharp;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using Jurassic.Library;

namespace BFKKuTuClient
{
    public delegate void LoginGetEventHandler(string _id, string _pw, string[] data);
    public delegate void PromptGetEventHandler(string text);

    public partial class Form1 : Form
    {
        public WebSocket ws = new WebSocket("wss://ws.bfkkutu.kr/g10000/");
        public WebSocket rws = new WebSocket("wss://ws.bfkkutu.kr/g10000/");
        public String sessionId = "";
        public ClientData data = new ClientData();
        public int chatCount = 0;
        public String nickname;
        public String id = String.Empty, pw = String.Empty;
        public Boolean wsConnected = false;
        public int joinedRoom = 0;
        public string promptResult = String.Empty;
        public int[] EXP = new int[361];
        public int MAX_LEVEL = 360;
        Login LoginForm = new Login();
        Prompt PromptForm = new Prompt("");
        public Jurassic.ScriptEngine engine = new Jurassic.ScriptEngine();

        public class ClientData
        {
            public String id;
            public Boolean admin;
            public String careful;
            public int soundLoadCount = 0;
            public int place = 0;
            public String nickname;
            public String exordial;
            public JObject users;
            public JObject robots = JObject.Parse("{}");
            public JObject rooms;
            public JObject friends;
            public JObject _friends = JObject.Parse("{}");
            public String _playTime;
            public String _okg;
            public Boolean _cF;
            public Boolean gaming = false;
            public JObject box;
        }

        private enum SSLProtocolHack
        {
            TLS = 192,
            TLSv11 = 768,
            TLSv12 = 3072
        }

        public Form1()
        {
            InitializeComponent();

            Login.LoginGetEvent += new LoginGetEventHandler(this.loginProcess);
            Prompt.PromptGetEvent += new PromptGetEventHandler(this.promptConfirmed);

            chatBox.AutoScroll = false;
            chatBox.HorizontalScroll.Enabled = false;
            chatBox.HorizontalScroll.Visible = false;
            chatBox.HorizontalScroll.Maximum = 0;
            chatBox.AutoScroll = true;

            userListBox.AutoScroll = false;
            userListBox.HorizontalScroll.Enabled = false;
            userListBox.HorizontalScroll.Visible = false;
            userListBox.HorizontalScroll.Maximum = 0;
            userListBox.AutoScroll = true;

            roomListBox.Parent = this;
            roomBox.Parent = this;
            roomBox.Visible = false;

            engine.Evaluate(@"function getRequiredScore(lv){
                return Math.round(
                    (!(lv%5)*0.3 + 1) * (!(lv%15)*0.4 + 1) * (!(lv%45)*0.5 + 1) * (
                        120 + Math.floor(lv/5)*60 + Math.floor(lv*lv/225)*120 + Math.floor(lv*lv/2025)*180
                    )
                );
            }");
            EXP[0] = getRequiredScore(1);
            for (int i = 2; i < MAX_LEVEL; i++)
            {
                EXP[i] = EXP[i - 2] + getRequiredScore(i);
            }
            EXP[MAX_LEVEL - 1] = int.MaxValue;
            EXP[MAX_LEVEL] = int.MaxValue;
        }

        private dynamic get(string url) {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();
            var responseReader = new StreamReader(webStream);
            var response = responseReader.ReadToEnd();
            responseReader.Close();
            return response;
        }

        private void connect_Click(object sender, EventArgs e)
        {
            if (wsConnected)
            {
                var confirmResult = MessageBox.Show("접속을 종료할까요?", "BF끄투 - 접속 종료", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    disconnect();
                    return;
                }
                else return;
            }
            if (id == String.Empty || pw == String.Empty) {
                MessageBox.Show("로그인하지 않았습니다.");
                return;
            }

            sessionId = get("https://bfkkutu.kr/client/session?id=" + id + "&pw=" + pw);
            using (ws = new WebSocket("wss://ws.bfkkutu.kr/g10000/"+sessionId))
            {
                ws.OnOpen += (se, ev) =>
                {
                    wsConnected = true;
                    SetText(connectBtn, "Disconnect");
                    SetText(label2, "Connected");
                };
                ws.OnClose += (se, ev) =>
                {
                    wsConnected = false;
                    disconnect();
                    SetText(connectBtn, "Connect");
                    SetText(label2, "Closed");
                };
                ws.OnError += (se, ev) =>
                {
                    wsConnected = false;
                    disconnect();
                    SetText(connectBtn, "Connect");
                    SetText(label2, "Error");
                };
                ws.OnMessage += (se, ev) =>
                {
                    wsOnMessage(JObject.Parse(ev.Data));
                };
            };
            var sslProtocolHack = (System.Security.Authentication.SslProtocols)(SSLProtocolHack.TLSv12 | SSLProtocolHack.TLSv11 | SSLProtocolHack.TLS);

            ws.SslConfiguration.EnabledSslProtocols = sslProtocolHack;
            ws.Connect();
        }

        private void wsOnMessage(JObject res)
        {
            switch (res["type"].ToString())
            {
                case "welcome":
                    data.id = res["id"].ToString();
                    data.admin = res["admin"].ToString() == "true";
                    data.careful = res["careful"].ToString();
                    data.nickname = res["nickname"].ToString();
                    data.exordial = res["exordial"].ToString();
                    data.users = JObject.Parse(res["users"].ToString());
                    data.rooms = JObject.Parse(res["rooms"].ToString());
                    data.friends = JObject.Parse(res["friends"].ToString());
                    data._playTime = res["playTime"].ToString();
                    data._okg = res["okg"].ToString();
                    data._cF = res["chatFreeze"].ToString() == "true";
                    data.box = JObject.Parse(res["box"].ToString());
                    updateUI();
                    //updateUI(void 0, !0), welcome(), a.caj && checkAge(), updateCommunity();
                    break;
                case "conn":
				    // TODO
                    break;
                case "disconn":
                    // TODO
                    break;
                case "chat":
                    if (!data.admin) {
                        if (!data._cF)
                        {
                            Chat(res["profile"].ToString(), res["value"].ToString(), "", "");
                        }
                        else
                        {
                            // TODO
                        }
                    }
                    else
                    {
                        Chat(res["profile"].ToString(), res["value"].ToString(), "", "");
                        //res["notice"] ? notice(L["error_" + a.code]) : Chat(res["profile"].ToString(), res["value"].ToString(), res["from"].ToString(), res["timestamp"].ToString());
                    }
                    break;
                case "reloadData":
                    data.id = res["id"].ToString();
                    data.admin = res["admin"].ToString() == "true";
                    data.careful = res["careful"].ToString();
                    data.nickname = res["nickname"].ToString();
                    data.exordial = res["exordial"].ToString();
                    if(!data.gaming) data.users = JObject.Parse(res["users"].ToString());
                    data.rooms = JObject.Parse(res["rooms"].ToString());
                    data.friends = JObject.Parse(res["friends"].ToString());
                    data._playTime = res["playTime"].ToString();
                    data._okg = res["okg"].ToString();
                    data._cF = res["chatFreeze"].ToString() == "true";
                    data.box = JObject.Parse(res["box"].ToString());
                    updateUI();
                    break;
                default:
                    break;
            }
        }

        private void updateUI() {
            updateUserList();
            updateRoomList();
            renderMoremi();
            updateMe();
        }

        private void updateMe() {
            JToken me = data.users[data.id];
            int globalWin = 0;
            int rankPoint = Int16.Parse(me["data"]["rankPoint"].ToString());
            int level = getLevel(me["data"]["score"]);
            string rank = rankPoint < 5000 ? getRank(rankPoint) : getRankerRank(rankPoint, data.id);
            engine.Evaluate(@"function calcProgress(e){
                var l = EXP.length;
                e = JSON.parse(e);

	            for(var i=0; i<l; i++) if(e.data.score < EXP[i]) break;
                return Math.floor((e.data.score - (EXP[i - 1] || 0)) / ((EXP[i]) - (EXP[i - 1] || 0)) * 100);
            }");
            engine.SetGlobalValue("MAX_LEVEL", 360);
            engine.SetGlobalValue("EXP", NewArray(new int[] { }));
            engine.Execute(@"EXP.push(getRequiredScore(1));
                for(i=2; i<MAX_LEVEL; i++){
                    EXP.push(EXP[i-2] + getRequiredScore(i));
                }
                EXP[MAX_LEVEL - 1] = Infinity;
                EXP.push(Infinity);
            ");

            foreach (JProperty i in me["data"]["record"])
            {
                globalWin += Int16.Parse(i.Value[1].ToString());
            }
            SetText(myNicknameLabel, data.nickname);
            SetText(myLevelLabel, "레벨 " + level.ToString());
            myLevelImage.ImageLocation = @"resources\kkutu\lv\lv" + level.ToString("D4") + ".png";
            SetText(myGlobalWinLabel, "통산 " + globalWin + "승");
            SetText(myPingLabel, Int32.Parse(me["money"].ToString()).ToString("N0") + "핑");
            SetText(myRankLabel, rank + "  " + Int32.Parse(me["data"]["rankPoint"].ToString()).ToString("N0") + "점");
            SetText(myLevelProgressLabel, Int32.Parse(me["data"]["score"].ToString()).ToString("N0") + " / " + Int32.Parse(EXP[level - 1].ToString()).ToString("N0") + "점");
            SetText(myOkgLabel, prettyTime(double.Parse(data._playTime)));
            SetProgressBarValue(myLevelProgressBar, engine.CallGlobalFunction<int>("calcProgress", new object[] { me.ToString() }));
            SetProgressBarValue(myOkgProgressBar, Int32.Parse((double.Parse(data._playTime) % 600000 / 6000).ToString()));
        }

        private string getRank(int rankPoint) {
            string rank = "배치 안 됨";

            if (rankPoint >= 50 && rankPoint < 1000)
            {
                rank = "브론즈";
            }
            else if (rankPoint >= 1000 && rankPoint < 2000)
            {
                rank = "실버";
            }
            else if (rankPoint >= 2000 && rankPoint < 3000)
            {
                rank = "골드";
            }
            else if (rankPoint >= 3000 && rankPoint < 4000)
            {
                rank = "플래티넘";
            }
            else if (rankPoint >= 4000 && rankPoint < 5000)
            {
                rank = "다이아몬드";
            }

            return rank;
        }

        private string getRankerRank(int rankPoint, string id) {
            string rank = "마스터";
            JToken ranking = JObject.Parse(get("https://bfkkutu.kr/ranking"))["data"];

            if (ranking[0]["id"].ToString() == id) rank = "챔피언";
            if (ranking[1]["id"].ToString() == id || ranking[1]["id"].ToString() == id) rank = "챌린저";

            return rankPoint < 5000 ? getRank(rankPoint) : rank;
        }

        private string prettyTime(double time)
        {
            double min = Math.Floor(time / 60000) % 60;
            double sec = Math.Floor(time * 0.001) % 60;
            double hour = Math.Floor(time / 3600000);
            string[] txt = new string[] { "", "", "" };

            if (hour != 0) txt[0] = hour + "시";
            if (min != 0) txt[1] = min + "분";
            if (hour == 0) txt[2] = sec + "초";
            return String.Join(" ", txt);
        }

        private void updateUserList() {
            int userCount = 1;
            foreach(var i in data.users)
            {
                Label user = new Label();
                user.Name = "user" + i.Key;
                user.Text = (string)i.Value["nickname"];
                user.AutoSize = true;
                user.MaximumSize = new Size(166, 20);
                user.Size = new Size(166, 20);
                user.Location = new Point(0, 20 * userCount);
                AppendLabel(userListBox, user);
                userCount++;
            }
            Label title = new Label();
            title.Name = "userListTitle";
            title.Text = "접속 중인 유저 "+(userCount - 1)+"명";
            title.AutoSize = true;
            title.MaximumSize = new Size(166, 20);
            title.Size = new Size(166, 20);
            title.Location = new Point(0, 0);
            AppendLabel(userListBox, title);
        }

        private void updateRoomList() {
            int roomCount = 0;
            foreach (var i in data.rooms)
            {
                Panel room = new Panel();
                Label roomTitle = new Label();
                
                roomTitle.Text = (string)i.Value["title"];
                roomTitle.AutoSize = true;
                roomTitle.Location = new Point(0, 0);
                AppendLabel(room, roomTitle);

                room.Name = "room" + i.Key;
                room.AutoSize = true;
                room.MaximumSize = new Size(272, 60);
                room.Size = new Size(272, 60);
                room.Location = new Point(1+272*(roomCount%2), 20+60 * roomCount);
                room.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                room.Click += (se, ev) =>
                {
                    connectToRoom(i);
                };
                AppendPanel(roomListBox, room);
                roomCount++;
            }
            Label title = new Label();
            title.Name = "roomListTitle";
            title.Text = "방 " + roomCount + "개";
            title.AutoSize = true;
            title.MaximumSize = new Size(186, 20);
            title.Size = new Size(186, 20);
            title.Location = new Point(0, 0);
            AppendLabel(roomListBox, title);
        }

        private int getLevel(dynamic a) {
            int b;
            int c = EXP.Length;
            for (b = 0; b < c && !(a < EXP[b]); b++);
            return b + 1;
        }

        private int getRequiredScore(int level)
        {
            return engine.CallGlobalFunction<int>("getRequiredScore", level);
        }

        private void renderMoremi() {
            //
        }

        public void connectToRoom(KeyValuePair<string, JToken> roomData) {
            JObject json = JObject.Parse("{}");
            json["type"] = "enter";
            json["id"] = roomData.Key;
            if ((string)roomData.Value["password"] == "True") {
                PromptForm = new Prompt(roomData.Key + "방에 입장하려면 비밀번호를 입력해야 합니다.");
                PromptForm.Owner = this;
                PromptForm.ShowDialog();
                json["password"] = promptResult;
            }
            ws.Send(json.ToString());
            using (rws = new WebSocket("wss://ws.bfkkutu.kr/g10416/" + sessionId + "&1&" + roomData.Key))
            {
                rws.OnOpen += (se, ev) =>
                {
                    Show(roomBox);
                    Hide(roomListBox);
                    SetText(roomTitleLabel, "[" + roomData.Key + "] " + roomData.Value["title"]);
                    joinedRoom = Int16.Parse(roomData.Key);
                };
                rws.OnClose += (se, ev) =>
                {
                    Show(roomListBox);
                    Hide(roomBox);
                    joinedRoom = 0;
                };
                rws.OnError += (se, ev) =>
                {
                    MessageBox.Show("방 웹소켓에서 에러 발생!");
                    Show(roomListBox);
                    Hide(roomBox);
                    joinedRoom = 0;
                };
                rws.OnMessage += (se, ev) =>
                {
                    wsOnMessage(JObject.Parse(ev.Data));
                };
            };
            var sslProtocolHack = (System.Security.Authentication.SslProtocols)(SSLProtocolHack.TLSv12 | SSLProtocolHack.TLSv11 | SSLProtocolHack.TLS);

            rws.SslConfiguration.EnabledSslProtocols = sslProtocolHack;
            rws.Connect();
        }

        private void promptConfirmed(string text) {
            promptResult = text;
        }

        private void rwsOnMessage(JObject res) {
            // TEMPORARY
            switch (res["type"].ToString()) {
                case "chat":
                    if (!data.admin)
                    {
                        if (!data._cF)
                        {
                            Chat(res["profile"].ToString(), res["value"].ToString(), "", "");
                        }
                        else
                        {
                            // TODO
                        }
                    }
                    else
                    {
                        Chat(res["profile"].ToString(), res["value"].ToString(), "", "");
                        //res["notice"] ? notice(L["error_" + a.code]) : Chat(res["profile"].ToString(), res["value"].ToString(), res["from"].ToString(), res["timestamp"].ToString());
                    }
                    break;
                default:
                    break;
            }
        }

        private void sendChat(object sender, EventArgs e)
        {
            if (!wsConnected) {
                MessageBox.Show("서버와 연결되어 있지 않습니다.");
                return;
            }
            String json = @"{""type"":""talk"",""relay"":false,""value"":"+"\""+chatinput.Text+"\""+"}";
            if (joinedRoom == 0) ws.Send(json);
            else rws.Send(json);
        }

        private void toLoginForm(object sender, EventArgs e) {
            LoginForm.Owner = this;
            LoginForm.ShowDialog();
        }

        private void loginProcess(string _id, string _pw, string[] data) {
            id = _id;
            pw = _pw;
            sessionId = data[0];
            toLogin.Text = data[1];
            toLogin.Location = new Point(1055 - data[1].Length*6, 9);
            toLogin.Click -= toLoginForm;
            toLogin.Click += logout;
        }

        private void logout(object sender, EventArgs e) {
            var confirmResult = MessageBox.Show("로그아웃 하시겠습니까?\n접속 중인 경우 접속이 종료됩니다.", "BF끄투 - 로그아웃", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes) {
                disconnect();
                id = String.Empty;
                pw = String.Empty;
                sessionId = String.Empty;
                toLogin.Text = "로그인";
                toLogin.Location = new Point(1055, 9);
                toLogin.Click += toLoginForm;
                toLogin.Click -= logout;
            }
        }

        private void disconnect() {
            if (wsConnected) ws.Close();
            if (rws.ReadyState != WebSocketState.Closed || rws.ReadyState != WebSocketState.Closing) rws.Close();
            userListBox.Controls.Clear();
            roomListBox.Controls.Clear();
            chatBox.Controls.Clear();
        }

        private void Chat(String _profile, String value, String from, String timestamp) {
            JObject profile = JObject.Parse(_profile);
            Label chat = new Label();
            Panel panel = new Panel();

            SetText(chatinput, "");
            chat.Name = "chat"+timestamp;
            chat.Text = profile["name"]+": "+value;
            chat.AutoSize = true;
            chat.Parent = panel;
            panel.MaximumSize = new Size(384, 20);
            panel.Size = new Size(384, 20);
            panel.Location = new Point(0, 20*chatCount);
            AppendPanel(chatBox, panel);
            chatCount++;
        }

        private void leaveRoomBtn_Click(object sender, EventArgs e)
        {
            if (rws.ReadyState != WebSocketState.Closed || rws.ReadyState != WebSocketState.Closing) rws.Close();
        }

        delegate void SetTextCallback(dynamic label, string text);
        delegate void SetAppendPanelCallback(Panel target, Panel element);
        delegate void SetAppendLabelCallback(Panel panel, Label label);
        delegate void SetAppendDynamicCallback(dynamic target, dynamic element);
        delegate void SetProgressBarValueCallback(ProgressBar progressbar, int value);
        delegate void SetDynamicShowCallback(dynamic element);
        delegate void SetDynamicHideCallback(dynamic element);

        private void SetText(dynamic label, string text)
        {
            if (label.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { label, text });
            }
            else
            {
                label.Text = text;
            }
        }

        private void AppendPanel(Panel target, Panel element)
        {
            if (target.InvokeRequired)
            {
                SetAppendPanelCallback d = new SetAppendPanelCallback(AppendPanel);
                this.Invoke(d, new object[] { target, element });
            }
            else
            {
                element.Parent = target;
            }
        }

        private void AppendLabel(Panel panel, Label label)
        {
            if (panel.InvokeRequired)
            {
                SetAppendLabelCallback d = new SetAppendLabelCallback(AppendLabel);
                this.Invoke(d, new object[] { panel, label });
            }
            else
            {
                label.Parent = panel;
            }
        }

        private void AppendDynamic(dynamic target, dynamic element) {
            if (target.InvokeRequired)
            {
                SetAppendDynamicCallback d = new SetAppendDynamicCallback(AppendDynamic);
                this.Invoke(d, new object[] { target, element });
            }
            else
            {
                element.Parent = target;
            }
        }

        private void SetProgressBarValue(ProgressBar progressbar, int value) {
            if (progressbar.InvokeRequired)
            {
                SetProgressBarValueCallback d = new SetProgressBarValueCallback(SetProgressBarValue);
                this.Invoke(d, new object[] { progressbar, value });
            }
            else
            {
                progressbar.Value = value;
            }
        }

        private void Show(dynamic element) {
            if (element.InvokeRequired)
            {
                SetDynamicShowCallback d = new SetDynamicShowCallback(Show);
                this.Invoke(d, new object[] { element });
            }
            else
            {
                element.Visible = true;
            }
        }

        private void Hide(dynamic element)
        {
            if (element.InvokeRequired)
            {
                SetDynamicHideCallback d = new SetDynamicHideCallback(Hide);
                this.Invoke(d, new object[] { element });
            }
            else
            {
                element.Visible = false;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (wsConnected) {
                var confirmResult = MessageBox.Show("서버에 연결되어 있습니다.\n접속을 종료하고 클라이언트를 닫으시겠습니까?", "BF끄투 - 종료", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    disconnect();
                }
                else e.Cancel = true;
            }
            base.OnClosing(e);
        }
        private ArrayInstance NewArray<T>(IEnumerable<T> data)
        {
            return engine.Array.New(data.Cast<object>().ToArray());
        }
    }
}
