namespace EvilCorp
{
    partial class ProfileForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();

            this.pnlView = new System.Windows.Forms.Panel();
            this.pnlViewCard = new System.Windows.Forms.Panel();
            this.lblUsernameCaption = new System.Windows.Forms.Label();
            this.lblUsernameValue = new System.Windows.Forms.Label();
            this.sep1 = new System.Windows.Forms.Label();
            this.lblUserIdCaption = new System.Windows.Forms.Label();
            this.lblUserIdValue = new System.Windows.Forms.Label();
            this.sep2 = new System.Windows.Forms.Label();
            this.lblPasswordCaption = new System.Windows.Forms.Label();
            this.lblPasswordValue = new System.Windows.Forms.Label();
            this.btnTogglePassword = new System.Windows.Forms.Button();
            this.btnEditToggle = new System.Windows.Forms.Button();

            this.pnlEdit = new System.Windows.Forms.Panel();
            this.pnlEditCard = new System.Windows.Forms.Panel();
            this.lblEditUsernameCaption = new System.Windows.Forms.Label();
            this.txtEditUsername = new System.Windows.Forms.TextBox();
            this.lblCurrentPwCaption = new System.Windows.Forms.Label();
            this.txtCurrentPassword = new System.Windows.Forms.TextBox();
            this.lblEditPasswordCaption = new System.Windows.Forms.Label();
            this.txtEditPassword = new System.Windows.Forms.TextBox();
            this.strengthBar = new System.Windows.Forms.ProgressBar();
            this.lblStrength = new System.Windows.Forms.Label();
            this.lblEditConfirmCaption = new System.Windows.Forms.Label();
            this.txtEditConfirm = new System.Windows.Forms.TextBox();
            this.lblEditFeedback = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancelEdit = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // ════════════════════════════════════════════════════════════
            // FORM  — 620 × 760, resizable
            // ════════════════════════════════════════════════════════════
            this.ClientSize = new System.Drawing.Size(620, 760);
            this.MinimumSize = new System.Drawing.Size(580, 680);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "ProfileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Profile";

            // ════════════════════════════════════════════════════════════
            // HEADER  — taller so subtitle is never clipped
            // ════════════════════════════════════════════════════════════
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 110;
            this.pnlHeader.Name = "pnlHeader";

            this.lblTitle.Text = "My Profile";
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(30, 18);
            this.lblTitle.Name = "lblTitle";

            this.lblSubtitle.Text = "View and manage your account details";
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Location = new System.Drawing.Point(31, 56);
            this.lblSubtitle.Name = "lblSubtitle";

            this.btnClose.Text = "✕";
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnClose.Location = new System.Drawing.Point(566, 34);
            this.btnClose.Name = "btnClose";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.pnlHeader.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle, this.lblSubtitle, this.btnClose });

            // ════════════════════════════════════════════════════════════
            // VIEW PANEL
            // ════════════════════════════════════════════════════════════
            this.pnlView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlView.Padding = new System.Windows.Forms.Padding(28, 24, 28, 24);
            this.pnlView.Name = "pnlView";

            this.pnlViewCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlViewCard.Height = 440;
            this.pnlViewCard.Padding = new System.Windows.Forms.Padding(32, 28, 32, 28);
            this.pnlViewCard.Name = "pnlViewCard";

            int cx = 32;
            int cw = 500; // separator width

            // USERNAME
            this.lblUsernameCaption.Text = "USERNAME";
            this.lblUsernameCaption.AutoSize = true;
            this.lblUsernameCaption.Location = new System.Drawing.Point(cx, 30);
            this.lblUsernameCaption.Name = "lblUsernameCaption";

            this.lblUsernameValue.Text = "";
            this.lblUsernameValue.AutoSize = true;
            this.lblUsernameValue.Location = new System.Drawing.Point(cx, 58);
            this.lblUsernameValue.Name = "lblUsernameValue";

            this.sep1.Location = new System.Drawing.Point(cx, 100);
            this.sep1.Size = new System.Drawing.Size(cw, 1);
            this.sep1.BackColor = System.Drawing.Color.FromArgb(38, 52, 80);
            this.sep1.Name = "sep1";

            // USER ID
            this.lblUserIdCaption.Text = "USER ID";
            this.lblUserIdCaption.AutoSize = true;
            this.lblUserIdCaption.Location = new System.Drawing.Point(cx, 116);
            this.lblUserIdCaption.Name = "lblUserIdCaption";

            this.lblUserIdValue.Text = "";
            this.lblUserIdValue.AutoSize = true;
            this.lblUserIdValue.Location = new System.Drawing.Point(cx, 144);
            this.lblUserIdValue.Name = "lblUserIdValue";

            this.sep2.Location = new System.Drawing.Point(cx, 186);
            this.sep2.Size = new System.Drawing.Size(cw, 1);
            this.sep2.BackColor = System.Drawing.Color.FromArgb(38, 52, 80);
            this.sep2.Name = "sep2";

            // PASSWORD
            this.lblPasswordCaption.Text = "PASSWORD";
            this.lblPasswordCaption.AutoSize = true;
            this.lblPasswordCaption.Location = new System.Drawing.Point(cx, 202);
            this.lblPasswordCaption.Name = "lblPasswordCaption";

            this.lblPasswordValue.Text = "••••••••";
            this.lblPasswordValue.AutoSize = true;
            this.lblPasswordValue.Location = new System.Drawing.Point(cx, 230);
            this.lblPasswordValue.Name = "lblPasswordValue";

            this.btnTogglePassword.Text = "👁  Show";
            this.btnTogglePassword.Size = new System.Drawing.Size(130, 36);
            this.btnTogglePassword.Location = new System.Drawing.Point(400, 222);
            this.btnTogglePassword.Name = "btnTogglePassword";
            this.btnTogglePassword.Click += new System.EventHandler(this.btnTogglePassword_Click);

            // Edit button
            this.btnEditToggle.Text = "✏  Edit Profile";
            this.btnEditToggle.Size = new System.Drawing.Size(cw, 58);
            this.btnEditToggle.Location = new System.Drawing.Point(cx, 340);
            this.btnEditToggle.Name = "btnEditToggle";
            this.btnEditToggle.Click += new System.EventHandler(this.btnEditToggle_Click);

            this.pnlViewCard.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblUsernameCaption, this.lblUsernameValue, this.sep1,
                this.lblUserIdCaption,   this.lblUserIdValue,   this.sep2,
                this.lblPasswordCaption, this.lblPasswordValue,
                this.btnTogglePassword,  this.btnEditToggle });

            this.pnlView.Controls.Add(this.pnlViewCard);

            // ════════════════════════════════════════════════════════════
            // EDIT PANEL
            // ════════════════════════════════════════════════════════════
            this.pnlEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEdit.Padding = new System.Windows.Forms.Padding(28, 24, 28, 24);
            this.pnlEdit.Name = "pnlEdit";
            this.pnlEdit.Visible = false;

            this.pnlEditCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEditCard.Height = 600;
            this.pnlEditCard.Padding = new System.Windows.Forms.Padding(32, 28, 32, 28);
            this.pnlEditCard.Name = "pnlEditCard";

            int ex = 32; int ew = 500;

            this.lblEditUsernameCaption.Text = "NEW USERNAME";
            this.lblEditUsernameCaption.AutoSize = true;
            this.lblEditUsernameCaption.Location = new System.Drawing.Point(ex, 28);
            this.lblEditUsernameCaption.Name = "lblEditUsernameCaption";

            this.txtEditUsername.Location = new System.Drawing.Point(ex, 52);
            this.txtEditUsername.Size = new System.Drawing.Size(ew, 32);
            this.txtEditUsername.MaxLength = 32;
            this.txtEditUsername.TabIndex = 1;
            this.txtEditUsername.Name = "txtEditUsername";

            this.lblCurrentPwCaption.Text = "CURRENT PASSWORD  (required to confirm changes)";
            this.lblCurrentPwCaption.AutoSize = true;
            this.lblCurrentPwCaption.Location = new System.Drawing.Point(ex, 104);
            this.lblCurrentPwCaption.Name = "lblCurrentPwCaption";

            this.txtCurrentPassword.Location = new System.Drawing.Point(ex, 128);
            this.txtCurrentPassword.Size = new System.Drawing.Size(ew, 32);
            this.txtCurrentPassword.PasswordChar = '●';
            this.txtCurrentPassword.TabIndex = 2;
            this.txtCurrentPassword.Name = "txtCurrentPassword";

            this.lblEditPasswordCaption.Text = "NEW PASSWORD  (leave blank to keep current)";
            this.lblEditPasswordCaption.AutoSize = true;
            this.lblEditPasswordCaption.Location = new System.Drawing.Point(ex, 180);
            this.lblEditPasswordCaption.Name = "lblEditPasswordCaption";

            this.txtEditPassword.Location = new System.Drawing.Point(ex, 204);
            this.txtEditPassword.Size = new System.Drawing.Size(ew, 32);
            this.txtEditPassword.PasswordChar = '●';
            this.txtEditPassword.TabIndex = 3;
            this.txtEditPassword.Name = "txtEditPassword";
            this.txtEditPassword.TextChanged += new System.EventHandler(this.txtEditPassword_TextChanged);

            this.strengthBar.Location = new System.Drawing.Point(ex, 246);
            this.strengthBar.Size = new System.Drawing.Size(380, 8);
            this.strengthBar.Minimum = 0;
            this.strengthBar.Maximum = 100;
            this.strengthBar.Value = 0;
            this.strengthBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.strengthBar.Name = "strengthBar";

            this.lblStrength.Text = "";
            this.lblStrength.AutoSize = true;
            this.lblStrength.Location = new System.Drawing.Point(440, 238);
            this.lblStrength.Name = "lblStrength";

            this.lblEditConfirmCaption.Text = "CONFIRM NEW PASSWORD";
            this.lblEditConfirmCaption.AutoSize = true;
            this.lblEditConfirmCaption.Location = new System.Drawing.Point(ex, 268);
            this.lblEditConfirmCaption.Name = "lblEditConfirmCaption";

            this.txtEditConfirm.Location = new System.Drawing.Point(ex, 292);
            this.txtEditConfirm.Size = new System.Drawing.Size(ew, 32);
            this.txtEditConfirm.PasswordChar = '●';
            this.txtEditConfirm.TabIndex = 4;
            this.txtEditConfirm.Name = "txtEditConfirm";

            this.lblEditFeedback.Text = "";
            this.lblEditFeedback.AutoSize = true;
            this.lblEditFeedback.Location = new System.Drawing.Point(ex, 342);
            this.lblEditFeedback.Name = "lblEditFeedback";

            this.btnSave.Text = "💾  Save Changes";
            this.btnSave.Size = new System.Drawing.Size(ew, 58);
            this.btnSave.Location = new System.Drawing.Point(ex, 372);
            this.btnSave.TabIndex = 5;
            this.btnSave.Name = "btnSave";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancelEdit.Text = "✕  Cancel";
            this.btnCancelEdit.Size = new System.Drawing.Size(ew, 44);
            this.btnCancelEdit.Location = new System.Drawing.Point(ex, 446);
            this.btnCancelEdit.TabIndex = 6;
            this.btnCancelEdit.Name = "btnCancelEdit";
            this.btnCancelEdit.Click += new System.EventHandler(this.btnEditToggle_Click);

            this.pnlEditCard.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblEditUsernameCaption, this.txtEditUsername,
                this.lblCurrentPwCaption,    this.txtCurrentPassword,
                this.lblEditPasswordCaption, this.txtEditPassword,
                this.strengthBar,            this.lblStrength,
                this.lblEditConfirmCaption,  this.txtEditConfirm,
                this.lblEditFeedback,
                this.btnSave, this.btnCancelEdit });

            this.pnlEdit.Controls.Add(this.pnlEditCard);

            // Wire up — order matters: Fill panels go before Top panels
            this.Controls.Add(this.pnlView);
            this.Controls.Add(this.pnlEdit);
            this.Controls.Add(this.pnlHeader);

            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlView;
        private System.Windows.Forms.Panel pnlViewCard;
        private System.Windows.Forms.Label lblUsernameCaption;
        private System.Windows.Forms.Label lblUsernameValue;
        private System.Windows.Forms.Label sep1;
        private System.Windows.Forms.Label lblUserIdCaption;
        private System.Windows.Forms.Label lblUserIdValue;
        private System.Windows.Forms.Label sep2;
        private System.Windows.Forms.Label lblPasswordCaption;
        private System.Windows.Forms.Label lblPasswordValue;
        private System.Windows.Forms.Button btnTogglePassword;
        private System.Windows.Forms.Button btnEditToggle;
        private System.Windows.Forms.Panel pnlEdit;
        private System.Windows.Forms.Panel pnlEditCard;
        private System.Windows.Forms.Label lblEditUsernameCaption;
        private System.Windows.Forms.TextBox txtEditUsername;
        private System.Windows.Forms.Label lblCurrentPwCaption;
        private System.Windows.Forms.TextBox txtCurrentPassword;
        private System.Windows.Forms.Label lblEditPasswordCaption;
        private System.Windows.Forms.TextBox txtEditPassword;
        private System.Windows.Forms.ProgressBar strengthBar;
        private System.Windows.Forms.Label lblStrength;
        private System.Windows.Forms.Label lblEditConfirmCaption;
        private System.Windows.Forms.TextBox txtEditConfirm;
        private System.Windows.Forms.Label lblEditFeedback;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancelEdit;
    }
}