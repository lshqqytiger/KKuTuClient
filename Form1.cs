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
    public delegate void CreateRoomEventHandler(Dictionary<string, string> roomData);

    public partial class Form1 : Form
    {
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
            public JObject robots = new JObject();
            public JObject rooms;
            public JObject friends;
            public JObject _friends = new JObject();
            public String _playTime;
            public String _okg;
            public Boolean _cF;
            public Boolean gaming = false;
            public JObject box;
            public JObject shop;
        }

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
        CreateRoomDialog CreateRoomDialogForm = new CreateRoomDialog(new string[] { }, new JObject(), new JObject(), new JObject(), new ClientData());
        Login LoginForm = new Login();
        Prompt PromptForm = new Prompt("");
        public Jurassic.ScriptEngine engine = new Jurassic.ScriptEngine();
        public JObject Const = new JObject();
        public JObject Lang = new JObject();
        public string path = Directory.GetCurrentDirectory();
        public string[] MODE;

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
            CreateRoomDialog.CreateRoomEvent += new CreateRoomEventHandler(this.createRoomHandler);

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
            engine.Evaluate(@"function getLevel(score){
                var i, l = EXP.length;
	
                for(i=0; i<l; i++) if(score < EXP[i]) break;
                return i+1;
            }");
            EXP[0] = getRequiredScore(1);
            for (int i = 2; i < MAX_LEVEL; i++)
            {
                EXP[i] = EXP[i - 2] + getRequiredScore(i);
            }
            EXP[MAX_LEVEL - 1] = int.MaxValue;
            EXP[MAX_LEVEL] = int.MaxValue;
            Const = JObject.Parse(get("https://bfkkutu.kr/client/loadgame"));
            Lang = JObject.Parse(Const["lang"].ToString());
            Const.Remove("lang");
            MODE = Const["MODE"].ToObject<string[]>();
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
                    Show(menuBarPanel);
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
                case "preRoom":
                    connectToRoom(Int16.Parse(res["id"].ToString()));
                    break;
                case "room":
                    Show(roomBox);
                    Hide(roomListBox);
                    SetText(roomTitleLabel, "[" + res["room"]["id"].ToString() + "] " + res["room"]["title"].ToString());
                    updateUI();
                    break;
                default:
                    break;
            }
        }

        private void updateUI() {
            loadShop(); // temp
            Clear(userListBox);
            Clear(roomListBox);
            updateUserList();
            updateRoomList();
            renderMoremi(myMoremiPanel, data.users[data.id]["equip"]);
            updateMe();
        }

        private void updateMe() {
            JToken me = data.users[data.id];
            int globalWin = 0;
            int rankPoint = Int16.Parse(me["data"]["rankPoint"].ToString());
            int level = getLevel(Int32.Parse(me["data"]["score"].ToString()));
            string rank = rankPoint < 5000 ? getRank(rankPoint) : getRankerRank(rankPoint, data.id);

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
            Label userListTitle = new Label();
            userListTitle.Name = "userListTitle";
            userListTitle.Text = "접속 중인 유저 "+(userCount - 1)+"명";
            userListTitle.AutoSize = true;
            userListTitle.MaximumSize = new Size(166, 20);
            userListTitle.Size = new Size(166, 20);
            userListTitle.Location = new Point(0, 0);
            AppendLabel(userListBox, userListTitle);
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
                    connectToRoomThroughList(i);
                };
                AppendPanel(roomListBox, room);
                roomCount++;
            }
            Label roomListTitle = new Label();
            roomListTitle.Name = "roomListTitle";
            roomListTitle.Text = "방 " + roomCount + "개";
            roomListTitle.AutoSize = true;
            roomListTitle.MaximumSize = new Size(186, 20);
            roomListTitle.Size = new Size(186, 20);
            roomListTitle.Location = new Point(0, 0);
            AppendLabel(roomListBox, roomListTitle);
        }

        private int getLevel(int score) {
            /*int b;
            int c = EXP.Length;
            for (b = 0; b < c && !(a < EXP[b]); b++);
            return b + 1;*/
            return engine.CallGlobalFunction<int>("getLevel", score);
        }

        private int getRequiredScore(int level)
        {
            return engine.CallGlobalFunction<int>("getRequiredScore", level);
        }

        private void renderMoremi(Panel target, JToken equip) {
            Bitmap moremiBitmap = new Bitmap(120, 120);
            Graphics g = Graphics.FromImage(moremiBitmap);
            JObject LR = JObject.Parse("{ 'Mlhand': 'Mhand', 'Mrhand': 'Mhand' }");

            Image body = Bitmap.FromFile(Path.Combine(path, @"resources\kkutu\moremi\body.png"));
            g.DrawImage(body, 0, 0, moremiBitmap.Width, moremiBitmap.Height);
            foreach (string i in Const["MOREMI_PART"])
            {
                string key = "M" + i;
                Image img = Bitmap.FromFile(Path.Combine(path, iImage(equip[key] == null ? @"resources\kkutu\moremi\" + key + @"\def.png" : equip[key].ToString(), LR[key] == null ? key : LR[key].ToString())));
                g.DrawImage(img, 0, 0, moremiBitmap.Width, moremiBitmap.Height);
            }
            moremi0.Image = moremiBitmap;
        }

        private string iImage(string key, dynamic sObj)
        {
            JObject obj;
            string extension;

            if (key[0] == '$')
            {
                return iDynImage(key.Substring(1, 3), key.Substring(4));
            }
            if (data.shop[key] != null) {
                obj = JObject.Parse(data.shop[key].ToString());
                extension = obj["options"]["gif"] == null ? ".png" : ".gif";
                if (obj["group"].ToString().Substring(0, 3) == "BDG") return @"resources\kkutu\moremi\badge\" + obj["_id"] + extension;
                return (obj["group"].ToString()[0] == 'M')
                    ? @"resources\kkutu\moremi\" + obj["group"].ToString().Substring(1) + "/" + obj["_id"] + extension
                    : @"resources\kkutu\shop\" + obj["_id"] + ".png";
            }
            else {
                extension = ".png";
                if (sObj.Substring(0, 3) == "BDG") return @"resources\kkutu\moremi\badge\def" + extension;
                return (sObj[0] == 'M')
                    ? (sObj.IndexOf("heco") != -1 ? @"resources\kkutu\moremi\head\def" + extension : @"resources\kkutu\moremi\" + sObj.Substring(1) + @"\def" + extension)
                    : @"resources\kkutu\shop\def" + ".png";
            };
        }

        private string iDynImage(string group, string data)
        {
            // let's think about how to handle WordPieces
            return "";
        }

        private void loadShop() {
            processShop();
        }

        private void processShop()
        {
            JObject res = JObject.Parse(get("https://bfkkutu.kr/shop"));
            data.shop = new JObject();
            foreach (JToken i in res["goods"])
            {
                data.shop[i["_id"].ToString()] = i;
            }
        }

        public void connectToRoomThroughList(KeyValuePair<string, JToken> roomData) {
            JObject json = new JObject();
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

        private void connectToRoom(int roomNumber) {
            using (rws = new WebSocket("wss://ws.bfkkutu.kr/g10416/" + sessionId + "&1&" + roomNumber))
            {
                rws.OnOpen += (se, ev) =>
                {
                    Show(roomBox);
                    Hide(roomListBox);
                    joinedRoom = roomNumber;
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
            Clear(userListBox);
            Clear(roomListBox);
            Clear(chatBox);
            Hide(menuBarPanel);
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
            Show(roomListBox);
            Hide(roomBox);
            Hide(leaveRoomBtn);
            updateUI();
        }

        private void createRoomBtn_Click(object sender, EventArgs e)
        {
            CreateRoomDialogForm.Close();
            CreateRoomDialogForm = new CreateRoomDialog(MODE, JObject.Parse(Const["RULE"].ToString()), JObject.Parse(Const["OPTIONS"].ToString()), Lang, data);
            CreateRoomDialogForm.Owner = this;
            CreateRoomDialogForm.Show();
        }

        private void createRoomHandler(Dictionary<string, string> roomData) {
            JObject json = new JObject();
            json["type"] = "enter";
            json["title"] = roomData["title"];
            json["password"] = roomData["password"];
            json["limit"] = roomData["playerLimit"];
            json["mode"] = roomData["mode"];
            json["round"] = roomData["round"];
            json["wordLimit"] = "3"; // TEMPORARY
            json["time"] = roomData["roundTime"];
            json["opts"] = JObject.Parse(roomData["opts"]);
            ws.Send(json.ToString());
        }

        delegate void SetTextCallback(dynamic label, string text);
        delegate void AppendPanelCallback(Panel target, Panel element);
        delegate void AppendLabelCallback(Panel panel, Label label);
        delegate void AppendDynamicCallback(dynamic target, dynamic element);
        delegate void AddControlCallback(Panel target, dynamic element);
        delegate void SetProgressBarValueCallback(ProgressBar progressbar, int value);
        delegate void ClearPanelCallback(Panel panel);
        delegate void DynamicShowCallback(dynamic element);
        delegate void DynamicHideCallback(dynamic element);

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
                AppendPanelCallback d = new AppendPanelCallback(AppendPanel);
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
                AppendLabelCallback d = new AppendLabelCallback(AppendLabel);
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
                AppendDynamicCallback d = new AppendDynamicCallback(AppendDynamic);
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
                DynamicShowCallback d = new DynamicShowCallback(Show);
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
                DynamicHideCallback d = new DynamicHideCallback(Hide);
                this.Invoke(d, new object[] { element });
            }
            else
            {
                element.Visible = false;
            }
        }

        private void Clear(Panel panel)
        {
            if (panel.InvokeRequired)
            {
                ClearPanelCallback d = new ClearPanelCallback(Clear);
                this.Invoke(d, new object[] { panel });
            }
            else
            {
                panel.Controls.Clear();
            }
        }

        private void AddControl(Panel target, dynamic element)
        {
            if (target.InvokeRequired)
            {
                AddControlCallback d = new AddControlCallback(AddControl);
                this.Invoke(d, new object[] { target, element });
            }
            else
            {
                target.Controls.Add(element);
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (wsConnected)
            {
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

    public class PlaceHolderTextBox : TextBox
    {

        bool isPlaceHolder = true;
        string _placeHolderText;
        public string PlaceHolderText
        {
            get { return _placeHolderText; }
            set
            {
                _placeHolderText = value;
                setPlaceholder();
            }
        }

        public new string Text
        {
            get => isPlaceHolder ? string.Empty : base.Text;
            set => base.Text = value;
        }

        //when the control loses focus, the placeholder is shown
        private void setPlaceholder()
        {
            if (string.IsNullOrEmpty(base.Text))
            {
                base.Text = PlaceHolderText;
                this.ForeColor = Color.Gray;
                this.Font = new Font(this.Font, FontStyle.Italic);
                isPlaceHolder = true;
            }
        }

        //when the control is focused, the placeholder is removed
        private void removePlaceHolder()
        {

            if (isPlaceHolder)
            {
                base.Text = "";
                this.ForeColor = System.Drawing.SystemColors.WindowText;
                this.Font = new Font(this.Font, FontStyle.Regular);
                isPlaceHolder = false;
            }
        }
        public PlaceHolderTextBox()
        {
            GotFocus += removePlaceHolder;
            LostFocus += setPlaceholder;
        }

        private void setPlaceholder(object sender, EventArgs e)
        {
            setPlaceholder();
        }

        private void removePlaceHolder(object sender, EventArgs e)
        {
            removePlaceHolder();
        }
    }

}
