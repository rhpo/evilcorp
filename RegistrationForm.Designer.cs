namespace EvilCorp
{
    partial class RegistrationForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblUsernameCaption = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPasswordCaption = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnTogglePassword = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.strengthBar = new System.Windows.Forms.ProgressBar();
            this.lblStrength = new System.Windows.Forms.Label();
            this.lblReqLength = new System.Windows.Forms.Label();
            this.lblReqUpper = new System.Windows.Forms.Label();
            this.lblReqDigit = new System.Windows.Forms.Label();
            this.lblReqSpecial = new System.Windows.Forms.Label();
            this.lblReqNote = new System.Windows.Forms.Label();
            this.lblConfirmCaption = new System.Windows.Forms.Label();
            this.txtConfirm = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // ── FORM  1000 × 1080  (matches LoginForm exactly) ────────────
            this.ClientSize = new System.Drawing.Size(1000, 1080);
            this.MinimumSize = new System.Drawing.Size(880, 940);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "RegistrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Account";

            // ── OUTER ─────────────────────────────────────────────────────
            this.pnlOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOuter.Name = "pnlOuter";
            this.pnlOuter.Resize += (s, e) => CentreCard();

            // ── CARD  660 × 940  (matches LoginForm card) ─────────────────
            this.pnlCard.Size = new System.Drawing.Size(660, 940);
            this.pnlCard.Name = "pnlCard";

            int px = 64;    // left/right padding
            int pw = 532;   // usable width = 660 - 64*2

            // ── Title — 80px tall, font set to 22pt in ApplyTheme ─────────
            this.lblTitle.Text = "Create Account";
            this.lblTitle.AutoSize = false;
            this.lblTitle.Size = new System.Drawing.Size(pw, 80);
            this.lblTitle.Location = new System.Drawing.Point(px, 48);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Name = "lblTitle";

            // ── Subtitle — sits below title, never overlaps ───────────────
            this.lblSubtitle.Text = "All fields required. Password must be strong.";
            this.lblSubtitle.AutoSize = false;
            this.lblSubtitle.Size = new System.Drawing.Size(pw, 30);
            this.lblSubtitle.Location = new System.Drawing.Point(px, 136);   // 48+80+8
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSubtitle.Name = "lblSubtitle";

            // ── USERNAME  y = 136+30+24 = 190 ────────────────────────────
            this.lblUsernameCaption.Text = "USERNAME";
            this.lblUsernameCaption.AutoSize = true;
            this.lblUsernameCaption.Location = new System.Drawing.Point(px, 190);
            this.lblUsernameCaption.Name = "lblUsernameCaption";

            this.txtUsername.Location = new System.Drawing.Point(px, 216);
            this.txtUsername.Size = new System.Drawing.Size(pw, 44);
            this.txtUsername.MaxLength = 32;
            this.txtUsername.TabIndex = 1;
            this.txtUsername.Name = "txtUsername";

            // ── PASSWORD  y = 216+44+26 = 286 ────────────────────────────
            this.lblPasswordCaption.Text = "PASSWORD";
            this.lblPasswordCaption.AutoSize = true;
            this.lblPasswordCaption.Location = new System.Drawing.Point(px, 282);
            this.lblPasswordCaption.Name = "lblPasswordCaption";

            // password | toggle | generate
            this.txtPassword.Location = new System.Drawing.Point(px, 308);
            this.txtPassword.Size = new System.Drawing.Size(368, 44);
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.TabIndex = 2;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);

            this.btnTogglePassword.Text = "👁";
            this.btnTogglePassword.Location = new System.Drawing.Point(px + 372, 308);
            this.btnTogglePassword.Size = new System.Drawing.Size(52, 44);
            this.btnTogglePassword.TabStop = false;
            this.btnTogglePassword.Name = "btnTogglePassword";
            this.btnTogglePassword.Click += new System.EventHandler(this.btnTogglePassword_Click);

            this.btnGenerate.Text = "⚡ Generate";
            this.btnGenerate.Location = new System.Drawing.Point(px + 430, 308);
            this.btnGenerate.Size = new System.Drawing.Size(pw - 430, 44);
            this.btnGenerate.TabStop = false;
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);

            // ── STRENGTH BAR  y = 308+44+12 = 364 ────────────────────────
            this.strengthBar.Location = new System.Drawing.Point(px, 364);
            this.strengthBar.Size = new System.Drawing.Size(380, 9);
            this.strengthBar.Minimum = 0;
            this.strengthBar.Maximum = 100;
            this.strengthBar.Value = 0;
            this.strengthBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.strengthBar.Name = "strengthBar";

            this.lblStrength.Text = "";
            this.lblStrength.AutoSize = true;
            this.lblStrength.Location = new System.Drawing.Point(px + 392, 355);
            this.lblStrength.Name = "lblStrength";

            // ── REQUIREMENTS  y = 364+9+12 = 385 ─────────────────────────
            this.lblReqLength.Text = "✗  8+ characters";
            this.lblReqLength.AutoSize = true;
            this.lblReqLength.Location = new System.Drawing.Point(px, 386);
            this.lblReqLength.Name = "lblReqLength";

            this.lblReqUpper.Text = "✗  One uppercase letter";
            this.lblReqUpper.AutoSize = true;
            this.lblReqUpper.Location = new System.Drawing.Point(px, 412);
            this.lblReqUpper.Name = "lblReqUpper";

            this.lblReqDigit.Text = "✗  One number";
            this.lblReqDigit.AutoSize = true;
            this.lblReqDigit.Location = new System.Drawing.Point(px + 268, 386);
            this.lblReqDigit.Name = "lblReqDigit";

            this.lblReqSpecial.Text = "✗  One special character";
            this.lblReqSpecial.AutoSize = true;
            this.lblReqSpecial.Location = new System.Drawing.Point(px + 268, 412);
            this.lblReqSpecial.Name = "lblReqSpecial";

            this.lblReqNote.Text = "Special chars: ! @ # $ % ^ & * - _ = + ?";
            this.lblReqNote.AutoSize = true;
            this.lblReqNote.Location = new System.Drawing.Point(px, 440);
            this.lblReqNote.Name = "lblReqNote";

            // ── CONFIRM PASSWORD  y = 440+22+26 = 488 ────────────────────
            this.lblConfirmCaption.Text = "CONFIRM PASSWORD";
            this.lblConfirmCaption.AutoSize = true;
            this.lblConfirmCaption.Location = new System.Drawing.Point(px, 476);
            this.lblConfirmCaption.Name = "lblConfirmCaption";

            this.txtConfirm.Location = new System.Drawing.Point(px, 502);
            this.txtConfirm.Size = new System.Drawing.Size(pw, 44);
            this.txtConfirm.PasswordChar = '●';
            this.txtConfirm.TabIndex = 5;
            this.txtConfirm.Name = "txtConfirm";

            // ── ERROR LABEL  y = 502+44+14 = 560 ─────────────────────────
            this.lblError.Text = "";
            this.lblError.AutoSize = false;
            this.lblError.Size = new System.Drawing.Size(pw, 26);
            this.lblError.Location = new System.Drawing.Point(px, 560);
            this.lblError.Name = "lblError";

            // ── REGISTER BUTTON  y = 560+26+10 = 596 ─────────────────────
            this.btnRegister.Text = "Create Account  →";
            this.btnRegister.Location = new System.Drawing.Point(px, 596);
            this.btnRegister.Size = new System.Drawing.Size(pw, 68);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            // ── Assemble ──────────────────────────────────────────────────
            this.pnlCard.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle, this.lblSubtitle,
                this.lblUsernameCaption, this.txtUsername,
                this.lblPasswordCaption, this.txtPassword,
                this.btnTogglePassword, this.btnGenerate,
                this.strengthBar, this.lblStrength,
                this.lblReqLength, this.lblReqUpper,
                this.lblReqDigit, this.lblReqSpecial, this.lblReqNote,
                this.lblConfirmCaption, this.txtConfirm,
                this.lblError, this.btnRegister });

            this.pnlOuter.Controls.Add(this.pnlCard);
            this.Controls.Add(this.pnlOuter);
            this.Load += (s, e) => CentreCard();
            this.ResumeLayout(false);
        }

        private void CentreCard()
        {
            pnlCard.Location = new System.Drawing.Point(
                (pnlOuter.ClientSize.Width - pnlCard.Width) / 2,
                Math.Max(30, (pnlOuter.ClientSize.Height - pnlCard.Height) / 2));
        }
        #endregion

        private System.Windows.Forms.Panel pnlOuter;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblUsernameCaption;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPasswordCaption;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnTogglePassword;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.ProgressBar strengthBar;
        private System.Windows.Forms.Label lblStrength;
        private System.Windows.Forms.Label lblReqLength;
        private System.Windows.Forms.Label lblReqUpper;
        private System.Windows.Forms.Label lblReqDigit;
        private System.Windows.Forms.Label lblReqSpecial;
        private System.Windows.Forms.Label lblReqNote;
        private System.Windows.Forms.Label lblConfirmCaption;
        private System.Windows.Forms.TextBox txtConfirm;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnRegister;
    }
}