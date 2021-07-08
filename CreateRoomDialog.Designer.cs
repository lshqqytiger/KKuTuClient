
namespace BFKKuTuClient
{
    partial class CreateRoomDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateRoomDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.playerLimitTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.modeComboBox = new System.Windows.Forms.ComboBox();
            this.roundTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.optsPanel = new System.Windows.Forms.Panel();
            this.confirmBtn = new System.Windows.Forms.Button();
            this.roundTimeComboBox = new System.Windows.Forms.ComboBox();
            this.passwordTextBox = new BFKKuTuClient.PlaceHolderTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "방 제목";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(63, 12);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(322, 21);
            this.titleTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "비밀번호";
            // 
            // playerLimitTextBox
            // 
            this.playerLimitTextBox.Location = new System.Drawing.Point(87, 66);
            this.playerLimitTextBox.Name = "playerLimitTextBox";
            this.playerLimitTextBox.Size = new System.Drawing.Size(298, 21);
            this.playerLimitTextBox.TabIndex = 5;
            this.playerLimitTextBox.Text = "8";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "플레이어 수";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "게임 유형";
            // 
            // modeComboBox
            // 
            this.modeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modeComboBox.FormattingEnabled = true;
            this.modeComboBox.Location = new System.Drawing.Point(71, 93);
            this.modeComboBox.Name = "modeComboBox";
            this.modeComboBox.Size = new System.Drawing.Size(314, 20);
            this.modeComboBox.TabIndex = 0;
            this.modeComboBox.SelectedIndexChanged += new System.EventHandler(this.modeComboBox_SelectedIndexChanged);
            // 
            // roundTextBox
            // 
            this.roundTextBox.Location = new System.Drawing.Point(71, 119);
            this.roundTextBox.Name = "roundTextBox";
            this.roundTextBox.Size = new System.Drawing.Size(314, 21);
            this.roundTextBox.TabIndex = 8;
            this.roundTextBox.Text = "5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "라운드 수";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "라운드 시간";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "특수 규칙";
            // 
            // optsPanel
            // 
            this.optsPanel.Location = new System.Drawing.Point(76, 178);
            this.optsPanel.Name = "optsPanel";
            this.optsPanel.Size = new System.Drawing.Size(309, 173);
            this.optsPanel.TabIndex = 12;
            // 
            // confirmBtn
            // 
            this.confirmBtn.Location = new System.Drawing.Point(296, 357);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(89, 23);
            this.confirmBtn.TabIndex = 13;
            this.confirmBtn.Text = "확인";
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // roundTimeComboBox
            // 
            this.roundTimeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roundTimeComboBox.FormattingEnabled = true;
            this.roundTimeComboBox.Items.AddRange(new object[] {
            "5초",
            "10초",
            "30초",
            "60초",
            "90초",
            "120초",
            "150초",
            "200초",
            "300초"});
            this.roundTimeComboBox.Location = new System.Drawing.Point(87, 146);
            this.roundTimeComboBox.Name = "roundTimeComboBox";
            this.roundTimeComboBox.Size = new System.Drawing.Size(298, 20);
            this.roundTimeComboBox.TabIndex = 15;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Italic);
            this.passwordTextBox.ForeColor = System.Drawing.Color.Gray;
            this.passwordTextBox.Location = new System.Drawing.Point(72, 40);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PlaceHolderText = "비밀번호";
            this.passwordTextBox.Size = new System.Drawing.Size(313, 21);
            this.passwordTextBox.TabIndex = 14;
            this.passwordTextBox.Text = "비밀번호";
            // 
            // CreateRoomDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 391);
            this.Controls.Add(this.roundTimeComboBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.confirmBtn);
            this.Controls.Add(this.optsPanel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.roundTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.modeComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.playerLimitTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateRoomDialog";
            this.Text = "방 만들기";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox playerLimitTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox modeComboBox;
        private System.Windows.Forms.TextBox roundTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel optsPanel;
        private System.Windows.Forms.Button confirmBtn;
        private PlaceHolderTextBox passwordTextBox;
        private System.Windows.Forms.ComboBox roundTimeComboBox;
    }
}