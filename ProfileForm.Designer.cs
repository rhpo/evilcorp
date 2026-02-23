namespace EvilCorp
{
    partial class ProfileForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblUserId = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.lblPasswordHash = new System.Windows.Forms.Label();
            this.txtPasswordHash = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblHeader
            //
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Inter", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lblHeader.Location = new System.Drawing.Point(20, 20);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(98, 26);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Profile";
            //
            // lblUsername
            //
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Inter", 10F);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.lblUsername.Location = new System.Drawing.Point(20, 70);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(73, 17);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username";
            //
            // txtUsername
            //
            this.txtUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.txtUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Location = new System.Drawing.Point(20, 95);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(360, 23);
            this.txtUsername.TabIndex = 2;
            //
            // lblUserId
            //
            this.lblUserId.AutoSize = true;
            this.lblUserId.Font = new System.Drawing.Font("Inter", 10F);
            this.lblUserId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.lblUserId.Location = new System.Drawing.Point(20, 130);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(18, 17);
            this.lblUserId.TabIndex = 3;
            this.lblUserId.Text = "Id";
            //
            // txtUserId
            //
            this.txtUserId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.txtUserId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.txtUserId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserId.Location = new System.Drawing.Point(20, 155);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.ReadOnly = true;
            this.txtUserId.Size = new System.Drawing.Size(360, 23);
            this.txtUserId.TabIndex = 4;
            //
            // lblPasswordHash
            //
            this.lblPasswordHash.AutoSize = true;
            this.lblPasswordHash.Font = new System.Drawing.Font("Inter", 10F);
            this.lblPasswordHash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.lblPasswordHash.Location = new System.Drawing.Point(20, 190);
            this.lblPasswordHash.Name = "lblPasswordHash";
            this.lblPasswordHash.Size = new System.Drawing.Size(98, 17);
            this.lblPasswordHash.TabIndex = 5;
            this.lblPasswordHash.Text = "Password Hash";
            //
            // txtPasswordHash
            //
            this.txtPasswordHash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.txtPasswordHash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.txtPasswordHash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPasswordHash.Location = new System.Drawing.Point(20, 215);
            this.txtPasswordHash.Name = "txtPasswordHash";
            this.txtPasswordHash.ReadOnly = true;
            this.txtPasswordHash.Size = new System.Drawing.Size(360, 23);
            this.txtPasswordHash.TabIndex = 6;
            //
            // btnClose
            //
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(20, 255);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(360, 35);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // ProfileForm
            //
            this.ClientSize = new System.Drawing.Size(400, 310);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(35)))), ((int)(((byte)(55)))));
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUserId);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.lblPasswordHash);
            this.Controls.Add(this.txtPasswordHash);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ProfileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Profile";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Label lblPasswordHash;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.TextBox txtPasswordHash;
        private System.Windows.Forms.Button btnClose;
    }
}
