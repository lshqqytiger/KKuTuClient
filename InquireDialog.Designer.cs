
namespace BFKKuTuClient
{
    partial class InquireDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InquireDialog));
            this.inquireBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // inquireBtn
            // 
            this.inquireBtn.Location = new System.Drawing.Point(354, 364);
            this.inquireBtn.Name = "inquireBtn";
            this.inquireBtn.Size = new System.Drawing.Size(115, 32);
            this.inquireBtn.TabIndex = 2;
            this.inquireBtn.Text = "문의 등록";
            this.inquireBtn.UseVisualStyleBackColor = true;
            // 
            // InquireDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 408);
            this.Controls.Add(this.inquireBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InquireDialog";
            this.Text = "문의";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button inquireBtn;
    }
}