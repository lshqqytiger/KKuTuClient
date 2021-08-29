
namespace BFKKuTuClient
{
    partial class QuickDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuickDialog));
            this.findBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gameTypeComboBox = new System.Windows.Forms.ComboBox();
            this.roundTimeComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // findBtn
            // 
            this.findBtn.Location = new System.Drawing.Point(235, 390);
            this.findBtn.Name = "findBtn";
            this.findBtn.Size = new System.Drawing.Size(115, 32);
            this.findBtn.TabIndex = 3;
            this.findBtn.Text = "찾기";
            this.findBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "게임 유형";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "라운드 시간";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "특수 규칙";
            // 
            // gameTypeComboBox
            // 
            this.gameTypeComboBox.FormattingEnabled = true;
            this.gameTypeComboBox.Location = new System.Drawing.Point(99, 13);
            this.gameTypeComboBox.Name = "gameTypeComboBox";
            this.gameTypeComboBox.Size = new System.Drawing.Size(251, 20);
            this.gameTypeComboBox.TabIndex = 7;
            // 
            // roundTimeComboBox
            // 
            this.roundTimeComboBox.FormattingEnabled = true;
            this.roundTimeComboBox.Location = new System.Drawing.Point(99, 45);
            this.roundTimeComboBox.Name = "roundTimeComboBox";
            this.roundTimeComboBox.Size = new System.Drawing.Size(251, 20);
            this.roundTimeComboBox.TabIndex = 8;
            // 
            // QuickDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 434);
            this.Controls.Add(this.roundTimeComboBox);
            this.Controls.Add(this.gameTypeComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.findBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QuickDialog";
            this.Text = "빠른 입장";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button findBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox gameTypeComboBox;
        private System.Windows.Forms.ComboBox roundTimeComboBox;
    }
}