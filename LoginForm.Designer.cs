namespace EvilCorp
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.pnlOuter = new System.Windows.Forms.Panel();
            this.pnlCard = new System.Windows.Forms.Panel();
            this.pnlLockIcon = new System.Windows.Forms.Panel();
            this.lblAppName = new System.Windows.Forms.Label();
            this.lblTagline = new System.Windows.Forms.Label();
            this.lblDividerLine = new System.Windows.Forms.Label();
            this.lblUsernameCaption = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPasswordCaption = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnTogglePassword = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblOrDivider = new System.Windows.Forms.Label();
            this.btnCreateAccount = new System.Windows.Forms.Button();
            this.lblFooter = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // ── FORM  1000 × 1080 ─────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(1000, 1080);
            this.MinimumSize = new System.Drawing.Size(880, 940);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EvilCorp — Secure Authentication";

            // ── OUTER ─────────────────────────────────────────────────────
            this.pnlOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOuter.Name = "pnlOuter";
            this.pnlOuter.Resize += (s, e) => CentreCard();

            // ── CARD  660 × 940 ───────────────────────────────────────────
            this.pnlCard.Size = new System.Drawing.Size(660, 940);
            this.pnlCard.Name = "pnlCard";

            int px = 64;    // left/right padding inside card
            int pw = 532;   // usable width = 660 - 64*2

            // Lock icon 140 × 140
            this.pnlLockIcon.Size = new System.Drawing.Size(140, 140);
            this.pnlLockIcon.Location = new System.Drawing.Point((660 - 140) / 2, 52);
            this.pnlLockIcon.Name = "pnlLockIcon";

            // App name — font is 22pt in code (~36px tall).
            // Label is 80px tall so there is ALWAYS room, no clipping possible.
            this.lblAppName.Text = "EvilCorp Auth+";
            this.lblAppName.AutoSize = false;
            this.lblAppName.Size = new System.Drawing.Size(pw, 80);
            this.lblAppName.Location = new System.Drawing.Point(px, 208);
            this.lblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAppName.Name = "lblAppName";

            // Tagline  y = 208+80+8 = 296
            this.lblTagline.Text = "Secure access to your account";
            this.lblTagline.AutoSize = false;
            this.lblTagline.Size = new System.Drawing.Size(pw, 32);
            this.lblTagline.Location = new System.Drawing.Point(px, 296);
            this.lblTagline.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTagline.Name = "lblTagline";

            // Divider  y = 296+32+18 = 346
            this.lblDividerLine.Size = new System.Drawing.Size(pw, 1);
            this.lblDividerLine.Location = new System.Drawing.Point(px, 346);
            this.lblDividerLine.Name = "lblDividerLine";

            // USERNAME  y = 368
            this.lblUsernameCaption.Text = "USERNAME";
            this.lblUsernameCaption.AutoSize = true;
            this.lblUsernameCaption.Location = new System.Drawing.Point(px, 368);
            this.lblUsernameCaption.Name = "lblUsernameCaption";

            this.txtUsername.Location = new System.Drawing.Point(px, 396);
            this.txtUsername.Size = new System.Drawing.Size(pw, 44);
            this.txtUsername.MaxLength = 32;
            this.txtUsername.TabIndex = 1;
            this.txtUsername.Name = "txtUsername";

            // PASSWORD  y = 460
            this.lblPasswordCaption.Text = "PASSWORD";
            this.lblPasswordCaption.AutoSize = true;
            this.lblPasswordCaption.Location = new System.Drawing.Point(px, 460);
            this.lblPasswordCaption.Name = "lblPasswordCaption";

            this.txtPassword.Location = new System.Drawing.Point(px, 488);
            this.txtPassword.Size = new System.Drawing.Size(472, 44);
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.TabIndex = 2;
            this.txtPassword.Name = "txtPassword";

            this.btnTogglePassword.Text = "👁";
            this.btnTogglePassword.Location = new System.Drawing.Point(px + 476, 488);
            this.btnTogglePassword.Size = new System.Drawing.Size(56, 44);
            this.btnTogglePassword.TabStop = false;
            this.btnTogglePassword.Name = "btnTogglePassword";
            this.btnTogglePassword.Click += new System.EventHandler(this.btnTogglePassword_Click);

            // Message  y = 548
            this.lblMessage.Text = "";
            this.lblMessage.AutoSize = false;
            this.lblMessage.Size = new System.Drawing.Size(pw, 26);
            this.lblMessage.Location = new System.Drawing.Point(px, 548);
            this.lblMessage.Name = "lblMessage";

            // Sign In  y = 582
            this.btnLogin.Text = "Sign In";
            this.btnLogin.Size = new System.Drawing.Size(pw, 68);
            this.btnLogin.Location = new System.Drawing.Point(px, 582);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // OR  y = 666
            this.lblOrDivider.Text = "──────────────────  or  ──────────────────";
            this.lblOrDivider.AutoSize = false;
            this.lblOrDivider.Size = new System.Drawing.Size(pw, 28);
            this.lblOrDivider.Location = new System.Drawing.Point(px, 666);
            this.lblOrDivider.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblOrDivider.Name = "lblOrDivider";

            // Create Account  y = 704
            this.btnCreateAccount.Text = "Create an Account";
            this.btnCreateAccount.Size = new System.Drawing.Size(pw, 60);
            this.btnCreateAccount.Location = new System.Drawing.Point(px, 704);
            this.btnCreateAccount.TabIndex = 4;
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.Click += new System.EventHandler(this.btnCreateAccount_Click);

            // Footer  y = 864
            this.lblFooter.Text = "EvilCorp © 2026 — All rights reserved";
            this.lblFooter.AutoSize = false;
            this.lblFooter.Size = new System.Drawing.Size(pw, 22);
            this.lblFooter.Location = new System.Drawing.Point(px, 864);
            this.lblFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFooter.Name = "lblFooter";

            this.pnlCard.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.pnlLockIcon,
                this.lblAppName, this.lblTagline, this.lblDividerLine,
                this.lblUsernameCaption, this.txtUsername,
                this.lblPasswordCaption, this.txtPassword, this.btnTogglePassword,
                this.lblMessage, this.btnLogin,
                this.lblOrDivider, this.btnCreateAccount,
                this.lblFooter });

            this.pnlOuter.Controls.Add(this.pnlCard);
            this.Controls.Add(this.pnlOuter);
            this.Load += (s, e) => CentreCard();
            this.ResumeLayout(false);
        }

        private void CentreCard()
        {
            pnlCard.Location = new System.Drawing.Point(
                (pnlOuter.ClientSize.Width - pnlCard.Width) / 2,
                (pnlOuter.ClientSize.Height - pnlCard.Height) / 2);
        }
        #endregion

        private System.Windows.Forms.Panel pnlOuter;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Panel pnlLockIcon;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label lblTagline;
        private System.Windows.Forms.Label lblDividerLine;
        private System.Windows.Forms.Label lblUsernameCaption;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPasswordCaption;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnTogglePassword;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblOrDivider;
        private System.Windows.Forms.Button btnCreateAccount;
        private System.Windows.Forms.Label lblFooter;
    }
}