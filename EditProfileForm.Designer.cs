namespace EvilCorp
{
    partial class EditProfileForm
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.txtConfirm = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            //
            // panelMain
            //
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(35)))), ((int)(((byte)(55)))));
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.AutoScroll = true;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(520, 420);
            this.panelMain.TabIndex = 0;
            //
            // lblUsername
            //
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Inter", 10F);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.lblUsername.Location = new System.Drawing.Point(20, 20);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(73, 17);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username";
            //
            // txtUsername
            //
            this.txtUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Font = new System.Drawing.Font("Inter", 11F);
            this.txtUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.txtUsername.Location = new System.Drawing.Point(20, 75);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(380, 25);
            this.txtUsername.TabIndex = 2;
            //
            // lblCurrentPassword
            //
            this.lblCurrentPassword = new System.Windows.Forms.Label();
            this.lblCurrentPassword.AutoSize = true;
            this.lblCurrentPassword.Font = new System.Drawing.Font("Inter", 10F);
            this.lblCurrentPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.lblCurrentPassword.Location = new System.Drawing.Point(20, 110);
            this.lblCurrentPassword.Name = "lblCurrentPassword";
            this.lblCurrentPassword.Size = new System.Drawing.Size(120, 17);
            this.lblCurrentPassword.TabIndex = 3;
            this.lblCurrentPassword.Text = "Current password";

            // txtCurrentPassword
            //
            this.txtCurrentPassword = new System.Windows.Forms.TextBox();
            this.txtCurrentPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.txtCurrentPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCurrentPassword.Font = new System.Drawing.Font("Inter", 11F);
            this.txtCurrentPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.txtCurrentPassword.Location = new System.Drawing.Point(20, 135);
            this.txtCurrentPassword.Name = "txtCurrentPassword";
            this.txtCurrentPassword.PasswordChar = '●';
            this.txtCurrentPassword.Size = new System.Drawing.Size(380, 25);
            this.txtCurrentPassword.TabIndex = 4;

            // lblNewPassword
            //
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Font = new System.Drawing.Font("Inter", 10F);
            this.lblNewPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.lblNewPassword.Location = new System.Drawing.Point(20, 170);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(98, 17);
            this.lblNewPassword.TabIndex = 5;
            this.lblNewPassword.Text = "New password";
            //
            // txtNewPassword
            //
            this.txtNewPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.txtNewPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewPassword.Font = new System.Drawing.Font("Inter", 11F);
            this.txtNewPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.txtNewPassword.Location = new System.Drawing.Point(20, 195);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '●';
            this.txtNewPassword.Size = new System.Drawing.Size(380, 25);
            this.txtNewPassword.TabIndex = 4;
            //
            // lblConfirm
            //
            this.lblConfirm.AutoSize = true;
            this.lblConfirm.Font = new System.Drawing.Font("Inter", 10F);
            this.lblConfirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.lblConfirm.Location = new System.Drawing.Point(20, 230);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Size = new System.Drawing.Size(110, 17);
            this.lblConfirm.TabIndex = 6;
            this.lblConfirm.Text = "Confirm password";
            //
            // txtConfirm
            //
            this.txtConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.txtConfirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfirm.Font = new System.Drawing.Font("Inter", 11F);
            this.txtConfirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.txtConfirm.Location = new System.Drawing.Point(20, 255);
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.PasswordChar = '●';
            this.txtConfirm.Size = new System.Drawing.Size(380, 25);
            this.txtConfirm.TabIndex = 6;
            //
            // btnSave
            //
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(20, 295);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(180, 35);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // btnCancel
            //
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(220, 295);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(180, 35);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // lblError
            //
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Inter", 9F);
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblError.Location = new System.Drawing.Point(20, 340);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 15);
            this.lblError.TabIndex = 9;
            //
            // EditProfileForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 420);
            this.MinimumSize = new System.Drawing.Size(480, 360);
            this.Controls.Add(this.panelMain);
            this.panelMain.Controls.Add(this.lblUsername);
            this.panelMain.Controls.Add(this.txtUsername);
            this.panelMain.Controls.Add(this.lblCurrentPassword);
            this.panelMain.Controls.Add(this.txtCurrentPassword);
            this.panelMain.Controls.Add(this.lblNewPassword);
            this.panelMain.Controls.Add(this.txtNewPassword);
            this.panelMain.Controls.Add(this.lblConfirm);
            this.panelMain.Controls.Add(this.txtConfirm);
            this.panelMain.Controls.Add(this.btnSave);
            this.panelMain.Controls.Add(this.btnCancel);
            this.panelMain.Controls.Add(this.lblError);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "EditProfileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Profile";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblCurrentPassword;
        private System.Windows.Forms.TextBox txtCurrentPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.TextBox txtConfirm;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblError;
    }
}
