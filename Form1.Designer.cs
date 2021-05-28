
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
            this.label1 = new System.Windows.Forms.Label();
            this.sendChatBtn = new System.Windows.Forms.Button();
            this.chatinput = new System.Windows.Forms.TextBox();
            this.connectBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.chatBox = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.toLogin = new System.Windows.Forms.Label();
            this.moremiBox = new System.Windows.Forms.PictureBox();
            this.userListBox = new System.Windows.Forms.Panel();
            this.roomListBox = new System.Windows.Forms.Panel();
            this.roomBox = new System.Windows.Forms.Panel();
            this.leaveRoomBtn = new System.Windows.Forms.Button();
            this.roomTitleLabel = new System.Windows.Forms.Label();
            this.moremi0 = new System.Windows.Forms.PictureBox();
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
            this.chatBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moremiBox)).BeginInit();
            this.roomListBox.SuspendLayout();
            this.roomBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moremi0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myLevelImage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(247, 685);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chat";
            // 
            // sendChatBtn
            // 
            this.sendChatBtn.Location = new System.Drawing.Point(732, 701);
            this.sendChatBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sendChatBtn.Name = "sendChatBtn";
            this.sendChatBtn.Size = new System.Drawing.Size(75, 29);
            this.sendChatBtn.TabIndex = 1;
            this.sendChatBtn.Text = "Send";
            this.sendChatBtn.UseVisualStyleBackColor = true;
            this.sendChatBtn.Click += new System.EventHandler(this.sendChat);
            // 
            // chatinput
            // 
            this.chatinput.Location = new System.Drawing.Point(249, 704);
            this.chatinput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chatinput.Name = "chatinput";
            this.chatinput.Size = new System.Drawing.Size(477, 23);
            this.chatinput.TabIndex = 2;
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
            // chatBox
            // 
            this.chatBox.Controls.Add(this.progressBar1);
            this.chatBox.Location = new System.Drawing.Point(249, 456);
            this.chatBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chatBox.Name = "chatBox";
            this.chatBox.Size = new System.Drawing.Size(558, 225);
            this.chatBox.TabIndex = 5;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(-102, 155);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(86, 23);
            this.progressBar1.TabIndex = 25;
            // 
            // toLogin
            // 
            this.toLogin.AutoSize = true;
            this.toLogin.Location = new System.Drawing.Point(1055, 11);
            this.toLogin.Name = "toLogin";
            this.toLogin.Size = new System.Drawing.Size(43, 15);
            this.toLogin.TabIndex = 11;
            this.toLogin.Text = "로그인";
            this.toLogin.Click += new System.EventHandler(this.toLoginForm);
            // 
            // moremiBox
            // 
            this.moremiBox.Location = new System.Drawing.Point(14, 456);
            this.moremiBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.moremiBox.Name = "moremiBox";
            this.moremiBox.Size = new System.Drawing.Size(227, 274);
            this.moremiBox.TabIndex = 12;
            this.moremiBox.TabStop = false;
            // 
            // userListBox
            // 
            this.userListBox.Location = new System.Drawing.Point(14, 88);
            this.userListBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userListBox.Name = "userListBox";
            this.userListBox.Size = new System.Drawing.Size(227, 360);
            this.userListBox.TabIndex = 13;
            // 
            // roomListBox
            // 
            this.roomListBox.Controls.Add(this.roomBox);
            this.roomListBox.Location = new System.Drawing.Point(249, 88);
            this.roomListBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.roomListBox.Name = "roomListBox";
            this.roomListBox.Size = new System.Drawing.Size(558, 360);
            this.roomListBox.TabIndex = 14;
            // 
            // roomBox
            // 
            this.roomBox.Controls.Add(this.leaveRoomBtn);
            this.roomBox.Controls.Add(this.roomTitleLabel);
            this.roomBox.Location = new System.Drawing.Point(1, 0);
            this.roomBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.roomBox.Name = "roomBox";
            this.roomBox.Size = new System.Drawing.Size(557, 360);
            this.roomBox.TabIndex = 15;
            // 
            // leaveRoomBtn
            // 
            this.leaveRoomBtn.Location = new System.Drawing.Point(469, 12);
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
            this.roomTitleLabel.Location = new System.Drawing.Point(14, 12);
            this.roomTitleLabel.Name = "roomTitleLabel";
            this.roomTitleLabel.Size = new System.Drawing.Size(84, 15);
            this.roomTitleLabel.TabIndex = 15;
            this.roomTitleLabel.Text = "　Default Text";
            // 
            // moremi0
            // 
            this.moremi0.ImageLocation = "https://bfkkutu.kr/img/kkutu/moremi/body.png";
            this.moremi0.InitialImage = ((System.Drawing.Image)(resources.GetObject("moremi0.InitialImage")));
            this.moremi0.Location = new System.Drawing.Point(15, 535);
            this.moremi0.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.moremi0.Name = "moremi0";
            this.moremi0.Size = new System.Drawing.Size(120, 120);
            this.moremi0.TabIndex = 16;
            this.moremi0.TabStop = false;
            // 
            // myNicknameLabel
            // 
            this.myNicknameLabel.AutoSize = true;
            this.myNicknameLabel.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.myNicknameLabel.Location = new System.Drawing.Point(120, 471);
            this.myNicknameLabel.Name = "myNicknameLabel";
            this.myNicknameLabel.Size = new System.Drawing.Size(58, 21);
            this.myNicknameLabel.TabIndex = 17;
            this.myNicknameLabel.Text = "닉네임";
            // 
            // myLevelLabel
            // 
            this.myLevelLabel.AutoSize = true;
            this.myLevelLabel.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.myLevelLabel.Location = new System.Drawing.Point(99, 672);
            this.myLevelLabel.Name = "myLevelLabel";
            this.myLevelLabel.Size = new System.Drawing.Size(57, 21);
            this.myLevelLabel.TabIndex = 18;
            this.myLevelLabel.Text = "레벨 n";
            // 
            // myLevelImage
            // 
            this.myLevelImage.ImageLocation = "https://bfkkutu.kr/img/kkutu/lv/lv0001.png";
            this.myLevelImage.Location = new System.Drawing.Point(30, 471);
            this.myLevelImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.myLevelImage.Name = "myLevelImage";
            this.myLevelImage.Size = new System.Drawing.Size(40, 40);
            this.myLevelImage.TabIndex = 19;
            this.myLevelImage.TabStop = false;
            // 
            // myGlobalWinLabel
            // 
            this.myGlobalWinLabel.AutoSize = true;
            this.myGlobalWinLabel.Location = new System.Drawing.Point(121, 507);
            this.myGlobalWinLabel.Name = "myGlobalWinLabel";
            this.myGlobalWinLabel.Size = new System.Drawing.Size(54, 15);
            this.myGlobalWinLabel.TabIndex = 20;
            this.myGlobalWinLabel.Text = "통산 n승";
            // 
            // myLevelProgressBar
            // 
            this.myLevelProgressBar.Location = new System.Drawing.Point(14, 701);
            this.myLevelProgressBar.Name = "myLevelProgressBar";
            this.myLevelProgressBar.Size = new System.Drawing.Size(227, 23);
            this.myLevelProgressBar.TabIndex = 21;
            // 
            // myLevelProgressLabel
            // 
            this.myLevelProgressLabel.AutoSize = true;
            this.myLevelProgressLabel.Location = new System.Drawing.Point(112, 704);
            this.myLevelProgressLabel.Name = "myLevelProgressLabel";
            this.myLevelProgressLabel.Size = new System.Drawing.Size(34, 15);
            this.myLevelProgressLabel.TabIndex = 22;
            this.myLevelProgressLabel.Text = "0 / 0";
            // 
            // myPingLabel
            // 
            this.myPingLabel.AutoSize = true;
            this.myPingLabel.Location = new System.Drawing.Point(141, 538);
            this.myPingLabel.Name = "myPingLabel";
            this.myPingLabel.Size = new System.Drawing.Size(26, 15);
            this.myPingLabel.TabIndex = 23;
            this.myPingLabel.Text = "n핑";
            // 
            // myRankLabel
            // 
            this.myRankLabel.AutoSize = true;
            this.myRankLabel.Location = new System.Drawing.Point(140, 562);
            this.myRankLabel.Name = "myRankLabel";
            this.myRankLabel.Size = new System.Drawing.Size(90, 15);
            this.myRankLabel.TabIndex = 24;
            this.myRankLabel.Text = "배치 안 됨  n점";
            // 
            // myOkgLabel
            // 
            this.myOkgLabel.AutoSize = true;
            this.myOkgLabel.Location = new System.Drawing.Point(172, 640);
            this.myOkgLabel.Name = "myOkgLabel";
            this.myOkgLabel.Size = new System.Drawing.Size(26, 15);
            this.myOkgLabel.TabIndex = 26;
            this.myOkgLabel.Text = "n초";
            // 
            // myOkgProgressBar
            // 
            this.myOkgProgressBar.Location = new System.Drawing.Point(141, 635);
            this.myOkgProgressBar.Name = "myOkgProgressBar";
            this.myOkgProgressBar.Size = new System.Drawing.Size(89, 23);
            this.myOkgProgressBar.TabIndex = 25;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 745);
            this.Controls.Add(this.myOkgLabel);
            this.Controls.Add(this.myOkgProgressBar);
            this.Controls.Add(this.myRankLabel);
            this.Controls.Add(this.myPingLabel);
            this.Controls.Add(this.myLevelProgressLabel);
            this.Controls.Add(this.myLevelProgressBar);
            this.Controls.Add(this.myGlobalWinLabel);
            this.Controls.Add(this.myLevelImage);
            this.Controls.Add(this.myLevelLabel);
            this.Controls.Add(this.myNicknameLabel);
            this.Controls.Add(this.moremi0);
            this.Controls.Add(this.roomListBox);
            this.Controls.Add(this.userListBox);
            this.Controls.Add(this.toLogin);
            this.Controls.Add(this.chatBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.chatinput);
            this.Controls.Add(this.sendChatBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.moremiBox);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "KKuTuClient";
            this.chatBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.moremiBox)).EndInit();
            this.roomListBox.ResumeLayout(false);
            this.roomBox.ResumeLayout(false);
            this.roomBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moremi0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myLevelImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button sendChatBtn;
        private System.Windows.Forms.TextBox chatinput;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel chatBox;
        private System.Windows.Forms.Label toLogin;
        private System.Windows.Forms.PictureBox moremiBox;
        private System.Windows.Forms.Panel userListBox;
        private System.Windows.Forms.Panel roomListBox;
        private System.Windows.Forms.Label roomTitleLabel;
        private System.Windows.Forms.Panel roomBox;
        private System.Windows.Forms.Button leaveRoomBtn;
        private System.Windows.Forms.PictureBox moremi0;
        private System.Windows.Forms.Label myNicknameLabel;
        private System.Windows.Forms.Label myLevelLabel;
        private System.Windows.Forms.PictureBox myLevelImage;
        private System.Windows.Forms.Label myGlobalWinLabel;
        private System.Windows.Forms.ProgressBar myLevelProgressBar;
        private System.Windows.Forms.Label myLevelProgressLabel;
        private System.Windows.Forms.Label myPingLabel;
        private System.Windows.Forms.Label myRankLabel;
        private System.Windows.Forms.Label myOkgLabel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar myOkgProgressBar;
    }
}

