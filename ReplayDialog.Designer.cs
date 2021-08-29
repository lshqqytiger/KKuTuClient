
namespace BFKKuTuClient
{
    partial class ReplayDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReplayDialog));
            this.playBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // playBtn
            // 
            this.playBtn.Location = new System.Drawing.Point(207, 333);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(115, 32);
            this.playBtn.TabIndex = 4;
            this.playBtn.Text = "재생";
            this.playBtn.UseVisualStyleBackColor = true;
            // 
            // ReplayDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 377);
            this.Controls.Add(this.playBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReplayDialog";
            this.Text = "리플레이";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button playBtn;
    }
}