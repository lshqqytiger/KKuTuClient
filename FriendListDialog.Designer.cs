
namespace BFKKuTuClient
{
    partial class FriendListDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FriendListDialog));
            this.friendAddBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // friendAddBtn
            // 
            this.friendAddBtn.Location = new System.Drawing.Point(213, 360);
            this.friendAddBtn.Name = "friendAddBtn";
            this.friendAddBtn.Size = new System.Drawing.Size(115, 32);
            this.friendAddBtn.TabIndex = 3;
            this.friendAddBtn.Text = "친구 추가";
            this.friendAddBtn.UseVisualStyleBackColor = true;
            // 
            // FriendListDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 404);
            this.Controls.Add(this.friendAddBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FriendListDialog";
            this.Text = "친구 목록";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button friendAddBtn;
    }
}