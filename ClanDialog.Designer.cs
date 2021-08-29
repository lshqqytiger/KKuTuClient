
namespace BFKKuTuClient
{
    partial class ClanDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClanDialog));
            this.makeClanBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // makeClanBtn
            // 
            this.makeClanBtn.Location = new System.Drawing.Point(365, 319);
            this.makeClanBtn.Name = "makeClanBtn";
            this.makeClanBtn.Size = new System.Drawing.Size(115, 32);
            this.makeClanBtn.TabIndex = 2;
            this.makeClanBtn.Text = "클랜 개설";
            this.makeClanBtn.UseVisualStyleBackColor = true;
            // 
            // ClanDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 363);
            this.Controls.Add(this.makeClanBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClanDialog";
            this.Text = "클랜";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button makeClanBtn;
    }
}