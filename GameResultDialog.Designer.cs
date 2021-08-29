
namespace BFKKuTuClient
{
    partial class GameResultDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameResultDialog));
            this.saveGameBtn = new System.Windows.Forms.Button();
            this.confirmBtn = new System.Windows.Forms.Button();
            this.rankingPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gainedExpLabel = new System.Windows.Forms.Label();
            this.gainedMoneyLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.levelLabel = new System.Windows.Forms.Label();
            this.gainedExpProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // saveGameBtn
            // 
            this.saveGameBtn.Location = new System.Drawing.Point(115, 428);
            this.saveGameBtn.Name = "saveGameBtn";
            this.saveGameBtn.Size = new System.Drawing.Size(115, 32);
            this.saveGameBtn.TabIndex = 0;
            this.saveGameBtn.Text = "경기 저장";
            this.saveGameBtn.UseVisualStyleBackColor = true;
            // 
            // confirmBtn
            // 
            this.confirmBtn.Location = new System.Drawing.Point(236, 428);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(115, 32);
            this.confirmBtn.TabIndex = 1;
            this.confirmBtn.Text = "확인";
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // rankingPanel
            // 
            this.rankingPanel.Location = new System.Drawing.Point(13, 13);
            this.rankingPanel.Name = "rankingPanel";
            this.rankingPanel.Size = new System.Drawing.Size(338, 308);
            this.rankingPanel.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 324);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "획득한 경험치: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 324);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "획득한 핑: ";
            // 
            // gainedExpLabel
            // 
            this.gainedExpLabel.AutoSize = true;
            this.gainedExpLabel.Location = new System.Drawing.Point(101, 324);
            this.gainedExpLabel.Name = "gainedExpLabel";
            this.gainedExpLabel.Size = new System.Drawing.Size(0, 12);
            this.gainedExpLabel.TabIndex = 5;
            // 
            // gainedMoneyLabel
            // 
            this.gainedMoneyLabel.AutoSize = true;
            this.gainedMoneyLabel.Location = new System.Drawing.Point(237, 324);
            this.gainedMoneyLabel.Name = "gainedMoneyLabel";
            this.gainedMoneyLabel.Size = new System.Drawing.Size(0, 12);
            this.gainedMoneyLabel.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 358);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "레벨";
            // 
            // levelLabel
            // 
            this.levelLabel.AutoSize = true;
            this.levelLabel.Location = new System.Drawing.Point(22, 383);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(0, 12);
            this.levelLabel.TabIndex = 8;
            // 
            // gainedExpProgressBar
            // 
            this.gainedExpProgressBar.Location = new System.Drawing.Point(71, 371);
            this.gainedExpProgressBar.Name = "gainedExpProgressBar";
            this.gainedExpProgressBar.Size = new System.Drawing.Size(280, 23);
            this.gainedExpProgressBar.TabIndex = 9;
            // 
            // GameResultDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 472);
            this.Controls.Add(this.gainedExpProgressBar);
            this.Controls.Add(this.levelLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gainedMoneyLabel);
            this.Controls.Add(this.gainedExpLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rankingPanel);
            this.Controls.Add(this.confirmBtn);
            this.Controls.Add(this.saveGameBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameResultDialog";
            this.Text = "게임 결과";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveGameBtn;
        private System.Windows.Forms.Button confirmBtn;
        private System.Windows.Forms.Panel rankingPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label gainedExpLabel;
        private System.Windows.Forms.Label gainedMoneyLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label levelLabel;
        private System.Windows.Forms.ProgressBar gainedExpProgressBar;
    }
}