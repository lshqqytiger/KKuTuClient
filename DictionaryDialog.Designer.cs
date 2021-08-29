
namespace BFKKuTuClient
{
    partial class DictionaryDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DictionaryDialog));
            this.placeHolderTextBox1 = new BFKKuTuClient.PlaceHolderTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.searchBtn = new System.Windows.Forms.Button();
            this.requestBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // placeHolderTextBox1
            // 
            this.placeHolderTextBox1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Italic);
            this.placeHolderTextBox1.ForeColor = System.Drawing.Color.Gray;
            this.placeHolderTextBox1.Location = new System.Drawing.Point(59, 9);
            this.placeHolderTextBox1.Name = "placeHolderTextBox1";
            this.placeHolderTextBox1.PlaceHolderText = "여기에 입력";
            this.placeHolderTextBox1.Size = new System.Drawing.Size(447, 21);
            this.placeHolderTextBox1.TabIndex = 0;
            this.placeHolderTextBox1.Text = "여기에 입력";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "검색어";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(494, 189);
            this.label2.TabIndex = 2;
            this.label2.Text = "검색 결과";
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(391, 241);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(115, 32);
            this.searchBtn.TabIndex = 3;
            this.searchBtn.Text = "검색";
            this.searchBtn.UseVisualStyleBackColor = true;
            // 
            // requestBtn
            // 
            this.requestBtn.Location = new System.Drawing.Point(270, 241);
            this.requestBtn.Name = "requestBtn";
            this.requestBtn.Size = new System.Drawing.Size(115, 32);
            this.requestBtn.TabIndex = 4;
            this.requestBtn.Text = "단어 추가 요청";
            this.requestBtn.UseVisualStyleBackColor = true;
            this.requestBtn.Click += new System.EventHandler(this.requestBtn_Click);
            // 
            // DictionaryDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 285);
            this.Controls.Add(this.requestBtn);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.placeHolderTextBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DictionaryDialog";
            this.Text = "사전";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PlaceHolderTextBox placeHolderTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Button requestBtn;
    }
}