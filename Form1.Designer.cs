
namespace BFKKuTuClient
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.sendChatBtn = new System.Windows.Forms.Button();
            this.connectBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.toLogin = new System.Windows.Forms.Label();
            this.userListBox = new System.Windows.Forms.Panel();
            this.roomListBox = new System.Windows.Forms.Panel();
            this.roomBox = new System.Windows.Forms.Panel();
            this.roomTeamBox = new System.Windows.Forms.Panel();
            this.roomTeamBtn_4 = new System.Windows.Forms.Button();
            this.roomTeamBtn_3 = new System.Windows.Forms.Button();
            this.roomTeamBtn_2 = new System.Windows.Forms.Button();
            this.roomTeamBtn_1 = new System.Windows.Forms.Button();
            this.roomTeamBtn_0 = new System.Windows.Forms.Button();
            this.roomInfoLabel = new System.Windows.Forms.Label();
            this.roomUsersBox = new System.Windows.Forms.Panel();
            this.leaveRoomBtn = new System.Windows.Forms.Button();
            this.roomTitleLabel = new System.Windows.Forms.Label();
            this.myMoremiPictureBox = new System.Windows.Forms.PictureBox();
            this.myNicknameLabel = new System.Windows.Forms.Label();
            this.myLevelLabel = new System.Windows.Forms.Label();
            this.myLevelImage = new System.Windows.Forms.PictureBox();
            this.myGlobalWinLabel = new System.Windows.Forms.Label();
            this.myLevelProgressBar = new System.Windows.Forms.ProgressBar();
            this.myLevelProgressLabel = new System.Windows.Forms.Label();
            this.myPingLabel = new System.Windows.Forms.Label();
            this.myRankLabel = new System.Windows.Forms.Label();
            this.myOkgLabel = new System.Windows.Forms.Label();
            this.myOkgProgressBar = new System.Windows.Forms.ProgressBar();
            this.myMoremiPanel = new System.Windows.Forms.Panel();
            this.menuBarPanel = new System.Windows.Forms.Panel();
            this.moremiBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chatinput = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.chatBox = new System.Windows.Forms.Panel();
            this.gameBox = new System.Windows.Forms.Panel();
            this.gamingUsersBox = new System.Windows.Forms.Panel();
            this.startingWordLabel = new System.Windows.Forms.Label();
            this.givenCharLabel = new System.Windows.Forms.Label();
            this.roomBox.SuspendLayout();
            this.roomTeamBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myMoremiPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myLevelImage)).BeginInit();
            this.myMoremiPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moremiBox)).BeginInit();
            this.chatBox.SuspendLayout();
            this.gameBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // sendChatBtn
            // 
            this.sendChatBtn.Location = new System.Drawing.Point(1221, 733);
            this.sendChatBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sendChatBtn.Name = "sendChatBtn";
            this.sendChatBtn.Size = new System.Drawing.Size(75, 29);
            this.sendChatBtn.TabIndex = 1;
            this.sendChatBtn.Text = "Send";
            this.sendChatBtn.UseVisualStyleBackColor = true;
            this.sendChatBtn.Click += new System.EventHandler(this.sendChat);
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(12, 11);
            this.connectBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(166, 66);
            this.connectBtn.TabIndex = 3;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "status";
            // 
            // toLogin
            // 
            this.toLogin.AutoSize = true;
            this.toLogin.Location = new System.Drawing.Point(1253, 11);
            this.toLogin.Name = "toLogin";
            this.toLogin.Size = new System.Drawing.Size(43, 15);
            this.toLogin.TabIndex = 11;
            this.toLogin.Text = "로그인";
            this.toLogin.Click += new System.EventHandler(this.toLoginForm);
            // 
            // userListBox
            // 
            this.userListBox.Location = new System.Drawing.Point(14, 88);
            this.userListBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userListBox.Name = "userListBox";
            this.userListBox.Size = new System.Drawing.Size(261, 395);
            this.userListBox.TabIndex = 13;
            // 
            // roomListBox
            // 
            this.roomListBox.Location = new System.Drawing.Point(281, 88);
            this.roomListBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.roomListBox.Name = "roomListBox";
            this.roomListBox.Size = new System.Drawing.Size(1015, 395);
            this.roomListBox.TabIndex = 14;
            // 
            // roomBox
            // 
            this.roomBox.Controls.Add(this.roomTeamBox);
            this.roomBox.Controls.Add(this.roomInfoLabel);
            this.roomBox.Controls.Add(this.roomUsersBox);
            this.roomBox.Controls.Add(this.leaveRoomBtn);
            this.roomBox.Controls.Add(this.roomTitleLabel);
            this.roomBox.Location = new System.Drawing.Point(281, 88);
            this.roomBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.roomBox.Name = "roomBox";
            this.roomBox.Size = new System.Drawing.Size(1015, 395);
            this.roomBox.TabIndex = 15;
            // 
            // roomTeamBox
            // 
            this.roomTeamBox.Controls.Add(this.roomTeamBtn_4);
            this.roomTeamBox.Controls.Add(this.roomTeamBtn_3);
            this.roomTeamBox.Controls.Add(this.roomTeamBtn_2);
            this.roomTeamBox.Controls.Add(this.roomTeamBtn_1);
            this.roomTeamBox.Controls.Add(this.roomTeamBtn_0);
            this.roomTeamBox.Location = new System.Drawing.Point(19, 44);
            this.roomTeamBox.Name = "roomTeamBox";
            this.roomTeamBox.Size = new System.Drawing.Size(54, 334);
            this.roomTeamBox.TabIndex = 18;
            // 
            // roomTeamBtn_4
            // 
            this.roomTeamBtn_4.Location = new System.Drawing.Point(7, 227);
            this.roomTeamBtn_4.Name = "roomTeamBtn_4";
            this.roomTeamBtn_4.Size = new System.Drawing.Size(41, 50);
            this.roomTeamBtn_4.TabIndex = 4;
            this.roomTeamBtn_4.Text = "D";
            this.roomTeamBtn_4.UseVisualStyleBackColor = true;
            this.roomTeamBtn_4.Click += new System.EventHandler(this.roomTeamBtn_Click);
            // 
            // roomTeamBtn_3
            // 
            this.roomTeamBtn_3.Location = new System.Drawing.Point(7, 171);
            this.roomTeamBtn_3.Name = "roomTeamBtn_3";
            this.roomTeamBtn_3.Size = new System.Drawing.Size(41, 50);
            this.roomTeamBtn_3.TabIndex = 3;
            this.roomTeamBtn_3.Text = "C";
            this.roomTeamBtn_3.UseVisualStyleBackColor = true;
            this.roomTeamBtn_3.Click += new System.EventHandler(this.roomTeamBtn_Click);
            // 
            // roomTeamBtn_2
            // 
            this.roomTeamBtn_2.Location = new System.Drawing.Point(7, 115);
            this.roomTeamBtn_2.Name = "roomTeamBtn_2";
            this.roomTeamBtn_2.Size = new System.Drawing.Size(41, 50);
            this.roomTeamBtn_2.TabIndex = 2;
            this.roomTeamBtn_2.Text = "B";
            this.roomTeamBtn_2.UseVisualStyleBackColor = true;
            this.roomTeamBtn_2.Click += new System.EventHandler(this.roomTeamBtn_Click);
            // 
            // roomTeamBtn_1
            // 
            this.roomTeamBtn_1.Location = new System.Drawing.Point(7, 59);
            this.roomTeamBtn_1.Name = "roomTeamBtn_1";
            this.roomTeamBtn_1.Size = new System.Drawing.Size(41, 50);
            this.roomTeamBtn_1.TabIndex = 1;
            this.roomTeamBtn_1.Text = "A";
            this.roomTeamBtn_1.UseVisualStyleBackColor = true;
            this.roomTeamBtn_1.Click += new System.EventHandler(this.roomTeamBtn_Click);
            // 
            // roomTeamBtn_0
            // 
            this.roomTeamBtn_0.Location = new System.Drawing.Point(7, 3);
            this.roomTeamBtn_0.Name = "roomTeamBtn_0";
            this.roomTeamBtn_0.Size = new System.Drawing.Size(41, 50);
            this.roomTeamBtn_0.TabIndex = 0;
            this.roomTeamBtn_0.Text = "개인";
            this.roomTeamBtn_0.UseVisualStyleBackColor = true;
            this.roomTeamBtn_0.Click += new System.EventHandler(this.roomTeamBtn_Click);
            // 
            // roomInfoLabel
            // 
            this.roomInfoLabel.Location = new System.Drawing.Point(153, 15);
            this.roomInfoLabel.Name = "roomInfoLabel";
            this.roomInfoLabel.Size = new System.Drawing.Size(626, 22);
            this.roomInfoLabel.TabIndex = 0;
            this.roomInfoLabel.Text = "방 정보";
            this.roomInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // roomUsersBox
            // 
            this.roomUsersBox.Location = new System.Drawing.Point(79, 44);
            this.roomUsersBox.Name = "roomUsersBox";
            this.roomUsersBox.Size = new System.Drawing.Size(720, 334);
            this.roomUsersBox.TabIndex = 17;
            // 
            // leaveRoomBtn
            // 
            this.leaveRoomBtn.Location = new System.Drawing.Point(785, 8);
            this.leaveRoomBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.leaveRoomBtn.Name = "leaveRoomBtn";
            this.leaveRoomBtn.Size = new System.Drawing.Size(75, 29);
            this.leaveRoomBtn.TabIndex = 16;
            this.leaveRoomBtn.Text = "방 나가기";
            this.leaveRoomBtn.UseVisualStyleBackColor = true;
            this.leaveRoomBtn.Click += new System.EventHandler(this.leaveRoomBtn_Click);
            // 
            // roomTitleLabel
            // 
            this.roomTitleLabel.AutoSize = true;
            this.roomTitleLabel.Location = new System.Drawing.Point(16, 15);
            this.roomTitleLabel.Name = "roomTitleLabel";
            this.roomTitleLabel.Size = new System.Drawing.Size(47, 15);
            this.roomTitleLabel.TabIndex = 15;
            this.roomTitleLabel.Text = "방 제목";
            // 
            // myMoremiPictureBox
            // 
            this.myMoremiPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.myMoremiPictureBox.ImageLocation = "https://bfkkutu.kr/img/kkutu/moremi/body.png";
            this.myMoremiPictureBox.InitialImage = null;
            this.myMoremiPictureBox.Location = new System.Drawing.Point(0, 0);
            this.myMoremiPictureBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.myMoremiPictureBox.Name = "myMoremiPictureBox";
            this.myMoremiPictureBox.Size = new System.Drawing.Size(120, 120);
            this.myMoremiPictureBox.TabIndex = 16;
            this.myMoremiPictureBox.TabStop = false;
            // 
            // myNicknameLabel
            // 
            this.myNicknameLabel.AutoSize = true;
            this.myNicknameLabel.BackColor = System.Drawing.Color.Transparent;
            this.myNicknameLabel.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.myNicknameLabel.Location = new System.Drawing.Point(134, 506);
            this.myNicknameLabel.Name = "myNicknameLabel";
            this.myNicknameLabel.Size = new System.Drawing.Size(58, 21);
            this.myNicknameLabel.TabIndex = 17;
            this.myNicknameLabel.Text = "닉네임";
            // 
            // myLevelLabel
            // 
            this.myLevelLabel.AutoSize = true;
            this.myLevelLabel.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.myLevelLabel.Location = new System.Drawing.Point(111, 705);
            this.myLevelLabel.Name = "myLevelLabel";
            this.myLevelLabel.Size = new System.Drawing.Size(57, 21);
            this.myLevelLabel.TabIndex = 18;
            this.myLevelLabel.Text = "레벨 n";
            // 
            // myLevelImage
            // 
            this.myLevelImage.ImageLocation = "https://bfkkutu.kr/img/kkutu/lv/lv0001.png";
            this.myLevelImage.Location = new System.Drawing.Point(30, 506);
            this.myLevelImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.myLevelImage.Name = "myLevelImage";
            this.myLevelImage.Size = new System.Drawing.Size(40, 40);
            this.myLevelImage.TabIndex = 19;
            this.myLevelImage.TabStop = false;
            // 
            // myGlobalWinLabel
            // 
            this.myGlobalWinLabel.AutoSize = true;
            this.myGlobalWinLabel.Location = new System.Drawing.Point(138, 542);
            this.myGlobalWinLabel.Name = "myGlobalWinLabel";
            this.myGlobalWinLabel.Size = new System.Drawing.Size(54, 15);
            this.myGlobalWinLabel.TabIndex = 20;
            this.myGlobalWinLabel.Text = "통산 n승";
            // 
            // myLevelProgressBar
            // 
            this.myLevelProgressBar.Location = new System.Drawing.Point(14, 736);
            this.myLevelProgressBar.Name = "myLevelProgressBar";
            this.myLevelProgressBar.Size = new System.Drawing.Size(261, 23);
            this.myLevelProgressBar.TabIndex = 21;
            // 
            // myLevelProgressLabel
            // 
            this.myLevelProgressLabel.AutoSize = true;
            this.myLevelProgressLabel.Location = new System.Drawing.Point(134, 739);
            this.myLevelProgressLabel.Name = "myLevelProgressLabel";
            this.myLevelProgressLabel.Size = new System.Drawing.Size(34, 15);
            this.myLevelProgressLabel.TabIndex = 22;
            this.myLevelProgressLabel.Text = "0 / 0";
            // 
            // myPingLabel
            // 
            this.myPingLabel.AutoSize = true;
            this.myPingLabel.Location = new System.Drawing.Point(151, 570);
            this.myPingLabel.Name = "myPingLabel";
            this.myPingLabel.Size = new System.Drawing.Size(26, 15);
            this.myPingLabel.TabIndex = 23;
            this.myPingLabel.Text = "n핑";
            // 
            // myRankLabel
            // 
            this.myRankLabel.AutoSize = true;
            this.myRankLabel.Location = new System.Drawing.Point(151, 597);
            this.myRankLabel.Name = "myRankLabel";
            this.myRankLabel.Size = new System.Drawing.Size(90, 15);
            this.myRankLabel.TabIndex = 24;
            this.myRankLabel.Text = "배치 안 됨  n점";
            // 
            // myOkgLabel
            // 
            this.myOkgLabel.AutoSize = true;
            this.myOkgLabel.Location = new System.Drawing.Point(183, 675);
            this.myOkgLabel.Name = "myOkgLabel";
            this.myOkgLabel.Size = new System.Drawing.Size(26, 15);
            this.myOkgLabel.TabIndex = 26;
            this.myOkgLabel.Text = "n초";
            // 
            // myOkgProgressBar
            // 
            this.myOkgProgressBar.Location = new System.Drawing.Point(141, 670);
            this.myOkgProgressBar.Name = "myOkgProgressBar";
            this.myOkgProgressBar.Size = new System.Drawing.Size(119, 23);
            this.myOkgProgressBar.TabIndex = 25;
            // 
            // myMoremiPanel
            // 
            this.myMoremiPanel.BackColor = System.Drawing.Color.Transparent;
            this.myMoremiPanel.Controls.Add(this.myMoremiPictureBox);
            this.myMoremiPanel.Location = new System.Drawing.Point(14, 573);
            this.myMoremiPanel.Name = "myMoremiPanel";
            this.myMoremiPanel.Size = new System.Drawing.Size(120, 120);
            this.myMoremiPanel.TabIndex = 27;
            // 
            // menuBarPanel
            // 
            this.menuBarPanel.Location = new System.Drawing.Point(281, 49);
            this.menuBarPanel.Name = "menuBarPanel";
            this.menuBarPanel.Size = new System.Drawing.Size(1015, 28);
            this.menuBarPanel.TabIndex = 35;
            this.menuBarPanel.Visible = false;
            // 
            // moremiBox
            // 
            this.moremiBox.Location = new System.Drawing.Point(14, 491);
            this.moremiBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.moremiBox.Name = "moremiBox";
            this.moremiBox.Size = new System.Drawing.Size(261, 274);
            this.moremiBox.TabIndex = 12;
            this.moremiBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(279, 720);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chat";
            // 
            // chatinput
            // 
            this.chatinput.Location = new System.Drawing.Point(281, 739);
            this.chatinput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chatinput.Name = "chatinput";
            this.chatinput.Size = new System.Drawing.Size(934, 23);
            this.chatinput.TabIndex = 2;
            this.chatinput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chatinput_KeyDown);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(-102, 155);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(86, 23);
            this.progressBar1.TabIndex = 25;
            // 
            // chatBox
            // 
            this.chatBox.Controls.Add(this.progressBar1);
            this.chatBox.Location = new System.Drawing.Point(281, 491);
            this.chatBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chatBox.Name = "chatBox";
            this.chatBox.Size = new System.Drawing.Size(1015, 225);
            this.chatBox.TabIndex = 5;
            // 
            // gameBox
            // 
            this.gameBox.Controls.Add(this.gamingUsersBox);
            this.gameBox.Controls.Add(this.startingWordLabel);
            this.gameBox.Controls.Add(this.givenCharLabel);
            this.gameBox.Location = new System.Drawing.Point(281, 88);
            this.gameBox.Name = "gameBox";
            this.gameBox.Size = new System.Drawing.Size(1015, 395);
            this.gameBox.TabIndex = 19;
            // 
            // gamingUsersBox
            // 
            this.gamingUsersBox.Location = new System.Drawing.Point(19, 215);
            this.gamingUsersBox.Name = "gamingUsersBox";
            this.gamingUsersBox.Size = new System.Drawing.Size(978, 163);
            this.gamingUsersBox.TabIndex = 2;
            // 
            // startingWordLabel
            // 
            this.startingWordLabel.Font = new System.Drawing.Font("맑은 고딕", 15F);
            this.startingWordLabel.Location = new System.Drawing.Point(0, 26);
            this.startingWordLabel.Name = "startingWordLabel";
            this.startingWordLabel.Size = new System.Drawing.Size(1015, 34);
            this.startingWordLabel.TabIndex = 1;
            this.startingWordLabel.Text = "게임 시작 단어";
            this.startingWordLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // givenCharLabel
            // 
            this.givenCharLabel.Font = new System.Drawing.Font("맑은 고딕", 20F);
            this.givenCharLabel.Location = new System.Drawing.Point(0, 60);
            this.givenCharLabel.Name = "givenCharLabel";
            this.givenCharLabel.Size = new System.Drawing.Size(1015, 37);
            this.givenCharLabel.TabIndex = 0;
            this.givenCharLabel.Text = "주어진 글자";
            this.givenCharLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1308, 777);
            this.Controls.Add(this.myNicknameLabel);
            this.Controls.Add(this.menuBarPanel);
            this.Controls.Add(this.myMoremiPanel);
            this.Controls.Add(this.myOkgLabel);
            this.Controls.Add(this.myOkgProgressBar);
            this.Controls.Add(this.myRankLabel);
            this.Controls.Add(this.myPingLabel);
            this.Controls.Add(this.myLevelProgressLabel);
            this.Controls.Add(this.myLevelProgressBar);
            this.Controls.Add(this.myGlobalWinLabel);
            this.Controls.Add(this.myLevelImage);
            this.Controls.Add(this.myLevelLabel);
            this.Controls.Add(this.userListBox);
            this.Controls.Add(this.toLogin);
            this.Controls.Add(this.chatBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.chatinput);
            this.Controls.Add(this.sendChatBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.moremiBox);
            this.Controls.Add(this.gameBox);
            this.Controls.Add(this.roomBox);
            this.Controls.Add(this.roomListBox);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "KKuTuClient";
            this.roomBox.ResumeLayout(false);
            this.roomBox.PerformLayout();
            this.roomTeamBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myMoremiPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myLevelImage)).EndInit();
            this.myMoremiPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.moremiBox)).EndInit();
            this.chatBox.ResumeLayout(false);
            this.gameBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button sendChatBtn;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label toLogin;
        private System.Windows.Forms.Panel userListBox;
        private System.Windows.Forms.Panel roomListBox;
        private System.Windows.Forms.Label roomTitleLabel;
        private System.Windows.Forms.Panel roomBox;
        private System.Windows.Forms.Button leaveRoomBtn;
        private System.Windows.Forms.PictureBox myMoremiPictureBox;
        private System.Windows.Forms.Label myNicknameLabel;
        private System.Windows.Forms.Label myLevelLabel;
        private System.Windows.Forms.PictureBox myLevelImage;
        private System.Windows.Forms.Label myGlobalWinLabel;
        private System.Windows.Forms.ProgressBar myLevelProgressBar;
        private System.Windows.Forms.Label myLevelProgressLabel;
        private System.Windows.Forms.Label myPingLabel;
        private System.Windows.Forms.Label myRankLabel;
        private System.Windows.Forms.Label myOkgLabel;
        private System.Windows.Forms.ProgressBar myOkgProgressBar;
        private System.Windows.Forms.Panel myMoremiPanel;
        private System.Windows.Forms.Panel menuBarPanel;
        private System.Windows.Forms.Panel roomUsersBox;
        private System.Windows.Forms.Label roomInfoLabel;
        private System.Windows.Forms.Panel roomTeamBox;
        private System.Windows.Forms.Button roomTeamBtn_3;
        private System.Windows.Forms.Button roomTeamBtn_2;
        private System.Windows.Forms.Button roomTeamBtn_1;
        private System.Windows.Forms.Button roomTeamBtn_0;
        private System.Windows.Forms.PictureBox moremiBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox chatinput;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel chatBox;
        private System.Windows.Forms.Button roomTeamBtn_4;
        private System.Windows.Forms.Panel gameBox;
        private System.Windows.Forms.Label givenCharLabel;
        private System.Windows.Forms.Label startingWordLabel;
        private System.Windows.Forms.Panel gamingUsersBox;
    }
}

