
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
            this.toLogin = new System.Windows.Forms.Label();
            this.moremiBox = new System.Windows.Forms.PictureBox();
            this.userListBox = new System.Windows.Forms.Panel();
            this.roomListBox = new System.Windows.Forms.Panel();
            this.roomTitleLabel = new System.Windows.Forms.Label();
            this.roomBox = new System.Windows.Forms.Panel();
            this.leaveRoomBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.moremiBox)).BeginInit();
            this.roomBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(186, 484);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chat";
            // 
            // sendChatBtn
            // 
            this.sendChatBtn.Location = new System.Drawing.Point(669, 497);
            this.sendChatBtn.Name = "sendChatBtn";
            this.sendChatBtn.Size = new System.Drawing.Size(75, 23);
            this.sendChatBtn.TabIndex = 1;
            this.sendChatBtn.Text = "Send";
            this.sendChatBtn.UseVisualStyleBackColor = true;
            this.sendChatBtn.Click += new System.EventHandler(this.sendChat);
            // 
            // chatinput
            // 
            this.chatinput.Location = new System.Drawing.Point(186, 499);
            this.chatinput.Name = "chatinput";
            this.chatinput.Size = new System.Drawing.Size(477, 21);
            this.chatinput.TabIndex = 2;
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(14, 25);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(166, 53);
            this.connectBtn.TabIndex = 3;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "status";
            // 
            // chatBox
            // 
            this.chatBox.Location = new System.Drawing.Point(186, 384);
            this.chatBox.Name = "chatBox";
            this.chatBox.Size = new System.Drawing.Size(558, 97);
            this.chatBox.TabIndex = 5;
            // 
            // toLogin
            // 
            this.toLogin.AutoSize = true;
            this.toLogin.Location = new System.Drawing.Point(1055, 9);
            this.toLogin.Name = "toLogin";
            this.toLogin.Size = new System.Drawing.Size(41, 12);
            this.toLogin.TabIndex = 11;
            this.toLogin.Text = "로그인";
            this.toLogin.Click += new System.EventHandler(this.toLoginForm);
            // 
            // moremiBox
            // 
            this.moremiBox.Location = new System.Drawing.Point(14, 384);
            this.moremiBox.Name = "moremiBox";
            this.moremiBox.Size = new System.Drawing.Size(166, 136);
            this.moremiBox.TabIndex = 12;
            this.moremiBox.TabStop = false;
            // 
            // userListBox
            // 
            this.userListBox.Location = new System.Drawing.Point(14, 85);
            this.userListBox.Name = "userListBox";
            this.userListBox.Size = new System.Drawing.Size(166, 293);
            this.userListBox.TabIndex = 13;
            // 
            // roomListBox
            // 
            this.roomListBox.Location = new System.Drawing.Point(186, 85);
            this.roomListBox.Name = "roomListBox";
            this.roomListBox.Size = new System.Drawing.Size(558, 293);
            this.roomListBox.TabIndex = 14;
            // 
            // roomTitleLabel
            // 
            this.roomTitleLabel.AutoSize = true;
            this.roomTitleLabel.Location = new System.Drawing.Point(14, 10);
            this.roomTitleLabel.Name = "roomTitleLabel";
            this.roomTitleLabel.Size = new System.Drawing.Size(84, 12);
            this.roomTitleLabel.TabIndex = 15;
            this.roomTitleLabel.Text = "　Default Text";
            // 
            // roomBox
            // 
            this.roomBox.Controls.Add(this.leaveRoomBtn);
            this.roomBox.Controls.Add(this.roomTitleLabel);
            this.roomBox.Location = new System.Drawing.Point(186, 85);
            this.roomBox.Name = "roomBox";
            this.roomBox.Size = new System.Drawing.Size(558, 293);
            this.roomBox.TabIndex = 15;
            // 
            // leaveRoomBtn
            // 
            this.leaveRoomBtn.Location = new System.Drawing.Point(469, 10);
            this.leaveRoomBtn.Name = "leaveRoomBtn";
            this.leaveRoomBtn.Size = new System.Drawing.Size(75, 23);
            this.leaveRoomBtn.TabIndex = 16;
            this.leaveRoomBtn.Text = "방 나가기";
            this.leaveRoomBtn.UseVisualStyleBackColor = true;
            this.leaveRoomBtn.Click += new System.EventHandler(this.leaveRoomBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 532);
            this.Controls.Add(this.roomBox);
            this.Controls.Add(this.roomListBox);
            this.Controls.Add(this.userListBox);
            this.Controls.Add(this.moremiBox);
            this.Controls.Add(this.toLogin);
            this.Controls.Add(this.chatBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.chatinput);
            this.Controls.Add(this.sendChatBtn);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "KKuTuClient";
            ((System.ComponentModel.ISupportInitialize)(this.moremiBox)).EndInit();
            this.roomBox.ResumeLayout(false);
            this.roomBox.PerformLayout();
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
    }
}

