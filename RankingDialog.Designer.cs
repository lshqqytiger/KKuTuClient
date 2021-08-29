
namespace BFKKuTuClient
{
    partial class RankingDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RankingDialog));
            this.nextBtn = new System.Windows.Forms.Button();
            this.myRankBtn = new System.Windows.Forms.Button();
            this.prevBtn = new System.Windows.Forms.Button();
            this.criteriaComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // nextBtn
            // 
            this.nextBtn.Location = new System.Drawing.Point(272, 423);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(115, 32);
            this.nextBtn.TabIndex = 2;
            this.nextBtn.Text = "다음";
            this.nextBtn.UseVisualStyleBackColor = true;
            // 
            // myRankBtn
            // 
            this.myRankBtn.Location = new System.Drawing.Point(151, 423);
            this.myRankBtn.Name = "myRankBtn";
            this.myRankBtn.Size = new System.Drawing.Size(115, 32);
            this.myRankBtn.TabIndex = 3;
            this.myRankBtn.Text = "내 순위";
            this.myRankBtn.UseVisualStyleBackColor = true;
            // 
            // prevBtn
            // 
            this.prevBtn.Location = new System.Drawing.Point(30, 423);
            this.prevBtn.Name = "prevBtn";
            this.prevBtn.Size = new System.Drawing.Size(115, 32);
            this.prevBtn.TabIndex = 4;
            this.prevBtn.Text = "이전";
            this.prevBtn.UseVisualStyleBackColor = true;
            // 
            // criteriaComboBox
            // 
            this.criteriaComboBox.FormattingEnabled = true;
            this.criteriaComboBox.Items.AddRange(new object[] {
            "경험치",
            "랭크 포인트"});
            this.criteriaComboBox.Location = new System.Drawing.Point(13, 13);
            this.criteriaComboBox.Name = "criteriaComboBox";
            this.criteriaComboBox.Size = new System.Drawing.Size(374, 20);
            this.criteriaComboBox.TabIndex = 5;
            // 
            // RankingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 467);
            this.Controls.Add(this.criteriaComboBox);
            this.Controls.Add(this.prevBtn);
            this.Controls.Add(this.myRankBtn);
            this.Controls.Add(this.nextBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RankingDialog";
            this.Text = "랭킹";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.Button myRankBtn;
        private System.Windows.Forms.Button prevBtn;
        private System.Windows.Forms.ComboBox criteriaComboBox;
    }
}