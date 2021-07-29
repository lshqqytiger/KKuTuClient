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
using System.Text.RegularExpressions;
using Jurassic.Library;
using System.Threading;

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
            public bool preQuick = false;
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
        public static ImprovedButton helpBtn = new ImprovedButton("help", "도움말");
        public static ImprovedButton settingsBtn = new ImprovedButton("settings", "설정");
        public static ImprovedButton friendsBtn = new ImprovedButton("friends", "친구 목록");
        public static ImprovedButton inquireBtn = new ImprovedButton("inquire", "문의");
        public static ImprovedButton rankingBtn = new ImprovedButton("ranking", "랭킹");
        public static ImprovedButton newRoomBtn = new ImprovedButton("newRoom", "방 만들기");
        public static ImprovedButton quickBtn = new ImprovedButton("quick", "빠른 입장");
        public static ImprovedButton shopBtn = new ImprovedButton("shop", "상점");
        public static ImprovedButton dictionaryBtn = new ImprovedButton("dictionary", "사전");
        public static ImprovedButton replayBtn = new ImprovedButton("replay", "리플레이");
        public static ImprovedButton clanBtn = new ImprovedButton("clan", "클랜");
        public static ImprovedButton reloadBtn = new ImprovedButton("reload", "새로고침");
        public static ImprovedButton spectateBtn = new ImprovedButton("spectate", "관전");
        public static ImprovedButton setRoomBtn = new ImprovedButton("setRoom", "방 설정");
        public static ImprovedButton inviteBtn = new ImprovedButton("invite", "초대");
        public static ImprovedButton practiceBtn = new ImprovedButton("practice", "연습");
        public static ImprovedButton startBtn = new ImprovedButton("start", "시작");
        public static ImprovedButton readyBtn = new ImprovedButton("ready", "준비");
        public ImprovedButton[] menuButtonsForLobby = new ImprovedButton[] { helpBtn, settingsBtn, friendsBtn, inquireBtn, rankingBtn, newRoomBtn, quickBtn, shopBtn, dictionaryBtn, replayBtn, clanBtn, reloadBtn };
        public ImprovedButton[] menuButtonsForMaster = new ImprovedButton[] { helpBtn, settingsBtn, friendsBtn, inquireBtn, spectateBtn, setRoomBtn, dictionaryBtn, inviteBtn, practiceBtn, startBtn };
        public ImprovedButton[] menuButtonsForNormal = new ImprovedButton[] { helpBtn, settingsBtn, friendsBtn, inquireBtn, spectateBtn, dictionaryBtn, practiceBtn, readyBtn };
        public ImprovedButton[] menuButtonsForGaming = new ImprovedButton[] { helpBtn, settingsBtn, friendsBtn, inquireBtn, dictionaryBtn };
        public bool isRelay = false;
        public Thread wrongWordAlert = new Thread(() => { });

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
            chatBox.BackgroundImage = Image.FromFile(@"resources\ui\558_225.png");

            userListBox.AutoScroll = false;
            userListBox.HorizontalScroll.Enabled = false;
            userListBox.HorizontalScroll.Visible = false;
            userListBox.HorizontalScroll.Maximum = 0;
            userListBox.AutoScroll = true;
            userListBox.BackgroundImage = Image.FromFile(@"resources\ui\227_360.png");

            roomListBox.Parent = this;
            roomListBox.BackgroundImage = Image.FromFile(@"resources\ui\558_360.png");
            roomUsersBox.Parent = roomBox;
            roomBox.Parent = this;
            roomBox.BackgroundImage = Image.FromFile(@"resources\ui\571_360.png");
            roomBox.Visible = false;
            gameBox.Parent = this;
            gameBox.BackgroundImage = Image.FromFile(@"resources\ui\571_360.png");
            gameBox.Visible = false;

            moremiBox.BackgroundImage = Image.FromFile(@"resources\ui\227_274.png");
            myMoremiPictureBox.BackgroundImage = Image.FromFile(@"resources\ui\120_120.png");

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

            dynamic[] moremiBoxChildren = new dynamic[] { myLevelImage, myNicknameLabel, myGlobalWinLabel, myPingLabel, myRankLabel, myLevelLabel };
            dynamic moremiBoxParent = moremiBox;
            foreach (var i in moremiBoxChildren)
            {
                i.Location = moremiBoxParent.PointToClient(i.Parent.PointToScreen(i.Location));
                i.Parent = moremiBoxParent;
                i.BackColor = Color.Transparent;
            }

            dynamic[] roomBoxChildren = new dynamic[] { roomTeamBox, roomUsersBox, roomTitleLabel, roomInfoLabel };
            dynamic roomBoxParent = roomBox;
            foreach (var i in roomBoxChildren)
            {
                i.Location = roomBoxParent.PointToClient(i.Parent.PointToScreen(i.Location));
                i.Parent = roomBoxParent;
                i.BackColor = Color.Transparent;
            }

            dynamic[] gameBoxChildren = new dynamic[] { givenCharLabel, startingWordLabel, gamingUsersBox };
            dynamic gameBoxParent = gameBox;
            foreach (var i in roomBoxChildren)
            {
                i.Location = roomBoxParent.PointToClient(i.Parent.PointToScreen(i.Location));
                i.Parent = roomBoxParent;
                i.BackColor = Color.Transparent;
            }

            foreach (ImprovedButton i in menuButtonsForLobby)
            {
                i.Click += (se, ev) =>
                {
                    menuButtonClicked(i.id);
                };
            }
            foreach (ImprovedButton i in menuButtonsForMaster)
            {
                i.Click += (se, ev) =>
                {
                    menuButtonClicked(i.id);
                };
            }
            foreach (ImprovedButton i in menuButtonsForGaming)
            {
                i.Click += (se, ev) =>
                {
                    menuButtonClicked(i.id);
                };
            }
            foreach (ImprovedButton i in menuButtonsForNormal)
            {
                i.Click += (se, ev) =>
                {
                    menuButtonClicked(i.id);
                };
            }
        }

        public class ImprovedButton : Button
        {
            public string id;
            public ImprovedButton(string id, string text)
            {
                this.id = id;
                Name = id + "Btn";
                Text = text;
            }
        }

        private void menuButtonClicked(string type) {
            switch (type)
            {
                case "newRoom":
                    CreateRoomDialogForm.Close();
                    CreateRoomDialogForm = new CreateRoomDialog(MODE, JObject.Parse(Const["RULE"].ToString()), JObject.Parse(Const["OPTIONS"].ToString()), Lang, data);
                    CreateRoomDialogForm.Owner = this;
                    CreateRoomDialogForm.Show();
                    break;
                case "reload":
                    send("reloadData");
                    break;
                case "ready":
                    send("ready");
                    break;
                case "start":
                    send("start");
                    break;
                default:
                    MessageBox.Show("there's no event listener for button "+type);
                    break;
            }
        }

        private void setupMenuButtons()
        {
            Clear(menuBarPanel);
            int count = 0;
            void appendButton(ImprovedButton i) {
                SetLocation(i, new Point(count * 75, 5));
                AppendDynamic(menuBarPanel, i);
                count++;
            }
            if (joinedRoom == 0)
            {
                foreach (ImprovedButton i in menuButtonsForLobby)
                {
                    appendButton(i);
                }
            }else if (data.gaming)
            {
                foreach (ImprovedButton i in menuButtonsForGaming)
                {
                    appendButton(i);
                }
            }else if (data.rooms[joinedRoom.ToString()]["master"].ToString() == data.id)
            {
                foreach (ImprovedButton i in menuButtonsForMaster)
                {
                    appendButton(i);
                }
            }
            else
            {
                foreach (ImprovedButton i in menuButtonsForNormal)
                {
                    appendButton(i);
                }
            }
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

        private void send(string type, dynamic obj = null)
        {
            var target = joinedRoom == 0 ? ws : (rws.ReadyState == WebSocketState.Open ? rws : ws);

            if(obj is string)
            {
                obj = JObject.Parse(obj);
            }
            if (obj is null) obj = new JObject();
            obj["type"] = type;
            obj = obj.ToString();
            try
            {
                JObject checkError = JObject.Parse(obj);
            }
            catch (Newtonsoft.Json.JsonReaderException e)
            {
                MessageBox.Show("웹소켓 데이터를 전송하려고 준비하는 중 문제가 발생했습니다: " + e.Message);
                return;
            }

            target.Send(obj);
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
                    if(joinedRoom == 0) data.users = JObject.Parse(res["users"].ToString());
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
                    if (joinedRoom == Int16.Parse(res["room"]["id"].ToString()))
                    {
                        SetText(roomTitleLabel, "[" + res["room"]["id"].ToString() + "] " + res["room"]["title"].ToString());
                        data.rooms[res["room"]["id"].ToString()] = res["room"];
                        Show(roomBox);
                        Hide(roomListBox);
                        setupMenuButtons();
                        updateRoom();
                    }
                    break;
                case "connRoom":
                    if(data.preQuick)
                    {
                        // handle quick succeeded
                    }
                    if (data.rooms[joinedRoom.ToString()] != null) {
                        setUser(res["user"]);
                        updateRoom();
                    }
                    break;
                case "user":
                    setUser(res);
                    if(joinedRoom != 0) updateRoom();
                    break;
                case "starting":
                    int count = 0;
                    JToken room = data.rooms[res["target"].ToString()];
                    Clear(gamingUsersBox);
                    foreach (JToken i in room["players"])
                    {
                        JToken user = data.users[i.ToString()];
                        Panel panel = new Panel();
                        Label nicknameLabel = new Label();
                        Label scoreLabel = new Label();
                        PictureBox moremi = new PictureBox();
                        PictureBox levelImage = new PictureBox();
                        panel.Name = "gamingUserPanel" + user["id"].ToString();
                        panel.Size = new Size(120, 163);
                        panel.Location = new Point(165 * count, 0);
                        nicknameLabel.Name = "gamingUserNicknameLabel" + count;
                        nicknameLabel.Location = new Point(40, 120);
                        nicknameLabel.Text = user["nickname"].ToString();
                        scoreLabel.Name = "gamingUserScore" + user["id"].ToString();
                        scoreLabel.Location = new Point(40, 140);
                        scoreLabel.Text = "00000";
                        moremi.Name = "gamingUserMoremiPictureBox" + count;
                        moremi.Image = renderMoremi(user["equip"]);
                        moremi.Location = new Point(0, 1);
                        moremi.Size = new Size(120, 120);
                        levelImage.Image = Image.FromFile(@"resources\kkutu\lv\lv" + getLevel(user["data"]["score"].ToObject<int>()).ToString().PadLeft(4, '0') + ".png");
                        levelImage.Location = new Point(0, 120);
                        levelImage.Size = new Size(40, 40);
                        moremi.Parent = panel;
                        levelImage.Parent = panel;
                        nicknameLabel.Parent = panel;
                        scoreLabel.Parent = panel;
                        AppendPanel(gamingUsersBox, panel);
                        count++;
                    }
                    Show(gameBox);
                    Hide(roomBox);
                    break;
                case "roundReady":
                    SetText(startingWordLabel, new string(data.rooms[joinedRoom.ToString()]["game"]["title"].ToString().ToCharArray().SelectMany(ch => new[] { ch, ' ' }).ToArray()));
                    break;
                case "turnStart":
                    SetText(givenCharLabel, res["subChar"] == null ? res["char"].ToString() : res["char"].ToString()+"("+res["subChar"].ToString()+")");
                    isRelay = data.rooms[joinedRoom.ToString()]["game"]["seq"][int.Parse(res["turn"].ToString())].ToString() == data.id;
                    break;
                case "turnEnd":
                    Label scoreLabel_ = gamingUsersBox.Controls["gamingUserPanel" + res["profile"]["id"]].Controls["gamingUserScore" + res["profile"]["id"]] as Label;
                    SetText(givenCharLabel, res["value"].ToString());
                    SetText(scoreLabel_, (Int16.Parse(scoreLabel_.Text) + Int16.Parse(res["score"].ToString())).ToString().PadLeft(5, '0'));
                    isRelay = false;
                    break;
                case "turnError":
                    MessageBox.Show(res.ToString());
                    /*if (res["ok"].ToString() == "False")
                    {
                        givenCharLabel.ForeColor = Color.Red;
                        wrongWordAlert = new Thread(() =>
                        {
                            Thread.Sleep(1000);
                            givenCharLabel.ForeColor = Color.Black;
                            SetText(givenCharLabel, "" + res["value"].ToString().ToArray()[0]);
                        });
                        wrongWordAlert.Start();
                    }*/
                    break;
                case "roomStuck":
                    MessageBox.Show("roomStuck");
                    break;
                case "error":
                    MessageBox.Show("오류 발생!: " + res.ToString());
                    break;
                default:
                    MessageBox.Show("Unhandled WebSocket Message "+ res["type"].ToString() + ": " + res.ToString());
                    break;
            }
        }

        private void setUser(dynamic user = null) {
            if(user != null)
            {
                data.users[user["id"].ToString()] = user;
            }
        }

        private void AppendChat(string id, string nickname, string text)
        {
            Label titleLabel = new Label();
            Label chatLabel = new Label();
            Panel panel = new Panel();

            titleLabel.Name = "chat_"+id+"_title";
            titleLabel.Text = nickname;
            titleLabel.Size = new Size(150, 20);
            titleLabel.Parent = panel;
            titleLabel.BackColor = Color.Transparent;
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            chatLabel.Name = "chat_"+id+"_text";
            chatLabel.Text = text;
            chatLabel.Parent = panel;
            chatLabel.BackColor = Color.Transparent;
            chatLabel.Size = new Size(872, 20);
            chatLabel.Location = new Point(150, 0);
            chatLabel.TextAlign = ContentAlignment.MiddleLeft;
            panel.Size = new Size(872, 20);
            panel.Location = new Point(0, 20 * chatCount);
            panel.BackColor = Color.Transparent;
            AppendPanel(chatBox, panel);
            chatCount++;
        }

        private void notice(string text)
        {
            AppendChat("notice", "알림", text);
        }

        private void updateUI() {
            if (rws.ReadyState == WebSocketState.Closed || rws.ReadyState == WebSocketState.Closing)
            {
                Show(roomListBox);
                Hide(roomBox);
                Hide(gameBox);
            }
            loadShop(); // temp
            Clear(userListBox);
            Clear(roomUsersBox);
            Clear(roomListBox);
            if (joinedRoom != 0) updateRoom();
            updateUserList();
            updateRoomList();
            myMoremiPictureBox.Image = renderMoremi(data.users[data.id]["equip"]);
            updateMe();
            setupMenuButtons();
        }

        private void updateRoom() {
            if (joinedRoom == 0) {
                Show(roomListBox);
                Hide(roomBox);
                Hide(gameBox);
                return;
            }
            Clear(roomUsersBox);
            JToken room = data.rooms[joinedRoom.ToString()];
            string[] opts = new string[] { };
            int count = 0;
            foreach(JProperty i in room["opts"])
            {
                if (i.Value.ToString() == "True") {
                    Array.Resize(ref opts, opts.Length + 1);
                    opts[opts.GetUpperBound(0)] = Lang[i.Name].ToString();
                }
            }
            SetText(roomInfoLabel, Lang["mode"+MODE[Int16.Parse(room["mode"].ToString())]].ToString() + " / " + string.Join(" / ", opts) +"  참여자 "+room["players"].ToObject<string[]>().Length+" / "+room["limit"].ToString()+"  라운드 "+room["round"].ToString()+"  "+room["time"].ToString()+"초");
            foreach (JToken i in room["players"]) {
                JToken user = data.users[i.ToString()];
                Panel panel = new Panel();
                Label nicknameLabel = new Label();
                Label statusLabel = new Label();
                PictureBox moremi = new PictureBox();
                PictureBox levelImage = new PictureBox();
                panel.Name = "userPanel" + count;
                panel.Size = new Size(165, 180);
                panel.Location = new Point(165 * count, 180*(int)Math.Round((double)(count / 4)));
                nicknameLabel.Name = "userNicknameLabel" + count;
                nicknameLabel.Location = new Point(40, 120);
                nicknameLabel.Text = user["nickname"].ToString();
                statusLabel.Name = "userStatusLabel" + count;
                statusLabel.Location = new Point(120, 180 * (int)Math.Round((double)(count / 4)));
                statusLabel.Text = room["master"].ToString() == user["id"].ToString() ? "방장" : (user["game"]["ready"].ToString() == "True" ? "준비" : "대기");
                moremi.Name = "userMoremiPictureBox" + count;
                moremi.Image = renderMoremi(user["equip"]);
                moremi.Location = new Point(0, 1);
                moremi.Size = new Size(120, 120);
                levelImage.Image = Image.FromFile(@"resources\kkutu\lv\lv"+ getLevel(user["data"]["score"].ToObject<int>()).ToString().PadLeft(4, '0') +".png");
                levelImage.Location = new Point(0, 120);
                levelImage.Size = new Size(40, 40);
                moremi.Parent = panel;
                statusLabel.Parent = panel;
                levelImage.Parent = panel;
                nicknameLabel.Parent = panel;
                AppendPanel(roomUsersBox, panel);
                count++;
            }
            SetText(roomTitleLabel, "[" + joinedRoom.ToString() + "] " + room["title"].ToString());
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
            SetText(myPingLabel, Int16.Parse(me["money"].ToString()).ToString("N0") + "핑");
            SetText(myRankLabel, rank + "  " + Int16.Parse(me["data"]["rankPoint"].ToString()).ToString("N0") + "점");
            SetText(myLevelProgressLabel, Int32.Parse(me["data"]["score"].ToString()).ToString("N0") + " / " + Int32.Parse(EXP[level - 1].ToString()).ToString("N0") + "점");
            SetText(myOkgLabel, prettyTime(double.Parse(data._playTime)));
            SetProgressBarValue(myLevelProgressBar, engine.CallGlobalFunction<int>("calcProgress", new object[] { me.ToString() }));
            SetProgressBarValue(myOkgProgressBar, Int32.Parse(data._playTime) % 600000 / 6000);
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
                user.BackColor = Color.Transparent;
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
            userListTitle.BackColor = Color.Transparent;
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
                roomTitle.BackColor = Color.Transparent;
                AppendLabel(room, roomTitle);

                room.Name = "room" + i.Key;
                room.AutoSize = true;
                room.MaximumSize = new Size(272, 60);
                room.Size = new Size(272, 60);
                room.Location = new Point(1+272*(roomCount%2), 20+60 * (int)Math.Round((double)(roomCount / 2)));
                room.BorderStyle = BorderStyle.Fixed3D;
                room.BackgroundImage = Image.FromFile(@"resources\ui\room\cover\"+ (i.Value["gaming"].ToString() == "False" ? "waiting" : "gaming") + ".png");
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
            roomListTitle.BackColor = Color.Transparent;
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

        private Bitmap renderMoremi(JToken equip) {
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
            return moremiBitmap;
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
                    ? @"resources\kkutu\moremi\" + (obj["group"].ToString().Substring(1) == "heco" ? "head" : obj["group"].ToString().Substring(1)) + @"\" + obj["_id"] + extension
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
            connectToRoom(Int16.Parse(roomData.Key));

            JObject json = new JObject();
            json["id"] = roomData.Key;
            if ((string)roomData.Value["password"] == "True") {
                PromptForm = new Prompt(roomData.Key + "방에 입장하려면 비밀번호를 입력해야 합니다.");
                PromptForm.Owner = this;
                PromptForm.ShowDialog();
                json["password"] = promptResult;
            }
            send("enter", json);
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
            send("reloadData");
        }

        private void promptConfirmed(string text) {
            promptResult = text;
        }

        private void sendChat(object sender, EventArgs e)
        {
            if (chatinput.Text == "") return;
            if (!wsConnected) {
                MessageBox.Show("서버와 연결되어 있지 않습니다.");
                return;
            }
            string json = @"{""relay"":" + (isRelay ? "true" : "false") + @",""value"":"+"\""+chatinput.Text+"\""+"}";
            send("talk", json);
            SetText(chatinput, "");
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
            toLogin.Location = new Point(1253 - data[1].Length*6, 11);
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
                toLogin.Location = new Point(1253, 11);
                toLogin.Click += toLoginForm;
                toLogin.Click -= logout;
            }
        }

        private void disconnect() {
            if (wsConnected) ws.Close();
            if (rws.ReadyState != WebSocketState.Closed && rws.ReadyState != WebSocketState.Closing) rws.Close();
            Clear(userListBox);
            Clear(roomListBox);
            Clear(chatBox);
            Hide(menuBarPanel);
            data = new ClientData();
        }

        private void Chat(string _profile, string value, string from, string timestamp) {
            JObject profile = JObject.Parse(_profile);
            AppendChat(timestamp, profile["name"].ToString(), value);
        }

        private void leaveRoomBtn_Click(object sender, EventArgs e)
        {
            if (rws.ReadyState != WebSocketState.Closed && rws.ReadyState != WebSocketState.Closing) rws.Close();
            if (joinedRoom != 0) joinedRoom = 0;
            updateUI();
        }

        private void createRoomHandler(Dictionary<string, string> roomData) {
            JObject json = new JObject();
            json["title"] = roomData["title"];
            json["password"] = roomData["password"];
            json["limit"] = roomData["playerLimit"];
            json["mode"] = roomData["mode"];
            json["round"] = roomData["round"];
            json["wordLimit"] = "3"; // TEMPORARY
            json["time"] = roomData["roundTime"];
            json["opts"] = JObject.Parse(roomData["opts"]);
            send("enter", json);
        }

        private void roomTeamBtn_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            JObject value = new JObject();
            value["value"] = clickedButton.Name.Substring(12);
            send("team", value);
        }

        private void chatinput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) sendChat(sender, new EventArgs());
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
        delegate void SetLocationCallback(dynamic element, Point location);

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

        private void SetLocation(dynamic element, Point location)
        {
            if (element.InvokeRequired)
            {
                SetLocationCallback d = new SetLocationCallback(SetLocation);
                this.Invoke(d, new object[] { element, location });
            }
            else
            {
                element.Location = location;
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
