namespace EvilCorp
{
    partial class DashboardForm
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
            this.pnlHeader = new DoubleBufferedPanel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlStatusBar = new System.Windows.Forms.Panel();
            this.pnlLockIcon = new DoubleBufferedPanel();
            this.pnlUserDot = new DoubleBufferedPanel();
            this.lblHeaderUser = new System.Windows.Forms.Label();
            this.lblNavSection = new System.Windows.Forms.Label();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnSendMessages = new System.Windows.Forms.Button();
            this.btnCrypto = new System.Windows.Forms.Button();
            this.btnAttack = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnSteganography = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();

            // Content controls
            this.pnlScrollableContent = new System.Windows.Forms.Panel();
            this.pnlWelcomeCard = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblUserId = new System.Windows.Forms.Label();
            this.lblSession = new System.Windows.Forms.Label();
            this.lblLiveTime = new System.Windows.Forms.Label();
            this.pnlStatsRow = new System.Windows.Forms.Panel();
            this.pnlStatSecurity = new System.Windows.Forms.Panel();
            this.pnlStatMessages = new System.Windows.Forms.Panel();
            this.pnlStatCrypto = new System.Windows.Forms.Panel();
            this.pnlStatAttack = new System.Windows.Forms.Panel();
            this.pnlSecurityRow = new System.Windows.Forms.Panel();
            this.pnlThreatLevel = new System.Windows.Forms.Panel();
            this.pnlRecentActivity = new System.Windows.Forms.Panel();
            this.pnlSystemHealth = new System.Windows.Forms.Panel();
            this.tableLayoutPanelContent = new System.Windows.Forms.TableLayoutPanel();

            // Status bar
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblStatusClock = new System.Windows.Forms.Label();
            this.clockTimer = new System.Windows.Forms.Timer();
            this.pulseTimer = new System.Windows.Forms.Timer();

            this.SuspendLayout();

            // ════════════════════════════════════════════════════════════
            // FORM
            // ════════════════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1400, 900);
            this.MinimumSize = new System.Drawing.Size(1100, 750);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EvilCorp — Dashboard";

            // ════════════════════════════════════════════════════════════
            // TIMERS
            // ════════════════════════════════════════════════════════════
            this.clockTimer.Interval = 1000;
            this.clockTimer.Tick += new System.EventHandler(this.clockTimer_Tick);
            this.clockTimer.Start();

            this.pulseTimer.Interval = 80;
            this.pulseTimer.Tick += new System.EventHandler(this.pulseTimer_Tick);
            this.pulseTimer.Start();

            // ════════════════════════════════════════════════════════════
            // HEADER  — 110px, DockStyle.Top — DoubleBufferedPanel
            // ════════════════════════════════════════════════════════════
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 110;
            this.pnlHeader.Name = "pnlHeader";

            // Lock icon
            this.pnlLockIcon.Size = new System.Drawing.Size(70, 70);
            this.pnlLockIcon.Location = new System.Drawing.Point(18, 20);
            this.pnlLockIcon.Name = "pnlLockIcon";
            this.pnlLockIcon.BackColor = System.Drawing.Color.Transparent;


            this.pnlUserDot.Size = new System.Drawing.Size(13, 13);
            this.pnlUserDot.Location = new System.Drawing.Point(1310, 49);
            this.pnlUserDot.Anchor =
                System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.pnlUserDot.Name = "pnlUserDot";
            this.pnlUserDot.BackColor = System.Drawing.Color.Transparent;

            this.lblHeaderUser.Text = "";
            this.lblHeaderUser.AutoSize = true;
            this.lblHeaderUser.Location = new System.Drawing.Point(1328, 43);
            this.lblHeaderUser.Anchor =
                System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblHeaderUser.Name = "lblHeaderUser";

            this.pnlHeader.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.pnlLockIcon,
                this.pnlUserDot,  this.lblHeaderUser });

            // ════════════════════════════════════════════════════════════
            // STATUS BAR — 34px, DockStyle.Bottom
            // ════════════════════════════════════════════════════════════
            this.pnlStatusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStatusBar.Height = 34;
            this.pnlStatusBar.Name = "pnlStatusBar";

            this.lblStatus.Text = "";
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(20, 9);
            this.lblStatus.Name = "lblStatus";

            this.lblStatusClock.Text = "";
            this.lblStatusClock.AutoSize = true;
            this.lblStatusClock.Location = new System.Drawing.Point(340, 9);
            this.lblStatusClock.Name = "lblStatusClock";

            this.pnlStatusBar.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblStatus, this.lblStatusClock });

            // ════════════════════════════════════════════════════════════
            // BODY
            // ════════════════════════════════════════════════════════════
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Name = "pnlBody";

            // ════════════════════════════════════════════════════════════
            // SIDEBAR — DockStyle.Left, 340px
            // ════════════════════════════════════════════════════════════
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Width = 340;
            this.pnlSidebar.Name = "pnlSidebar";

            this.lblNavSection.Text = "NAVIGATION";
            this.lblNavSection.AutoSize = true;
            this.lblNavSection.Location = new System.Drawing.Point(22, 28);
            this.lblNavSection.Name = "lblNavSection";

            int ny = 62; int nw = 304; int nh = 58; int ngap = 8;

            this.btnProfile.Text = "Profile";
            this.btnProfile.Location = new System.Drawing.Point(18, ny);
            this.btnProfile.Size = new System.Drawing.Size(nw, nh);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);

            this.btnSendMessages.Text = "Messages";
            this.btnSendMessages.Location = new System.Drawing.Point(18, ny + (nh + ngap));
            this.btnSendMessages.Size = new System.Drawing.Size(nw, nh);
            this.btnSendMessages.Name = "btnSendMessages";
            this.btnSendMessages.Click += new System.EventHandler(this.btnSendMessages_Click);

            this.btnCrypto.Text = "Encrypt / Decrypt";
            this.btnCrypto.Location = new System.Drawing.Point(18, ny + (nh + ngap) * 2);
            this.btnCrypto.Size = new System.Drawing.Size(nw, nh);
            this.btnCrypto.Name = "btnCrypto";
            this.btnCrypto.Click += new System.EventHandler(this.btnCrypto_Click);

            this.btnAttack.Text = "Attack";
            this.btnAttack.Location = new System.Drawing.Point(18, ny + (nh + ngap) * 3);
            this.btnAttack.Size = new System.Drawing.Size(nw, nh);
            this.btnAttack.Name = "btnAttack";
            this.btnAttack.Click += new System.EventHandler(this.btnAttack_Click);

            this.btnReports.Text = "Reports";
            this.btnReports.Location = new System.Drawing.Point(18, ny + (nh + ngap) * 4);
            this.btnReports.Size = new System.Drawing.Size(nw, nh);
            this.btnReports.Name = "btnReports";
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);

            this.btnSteganography.Text = "Steganography";
            this.btnSteganography.Location = new System.Drawing.Point(18, ny + (nh + ngap) * 5);
            this.btnSteganography.Size = new System.Drawing.Size(nw, nh);
            this.btnSteganography.Name = "btnSteganography";
            this.btnSteganography.Click += new System.EventHandler(this.btnSteganography_Click);

            this.btnLogout.Text = "⏻   Sign Out";
            this.btnLogout.Size = new System.Drawing.Size(nw, nh);
            this.btnLogout.Anchor =
                System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.btnLogout.Location = new System.Drawing.Point(18, 760);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            this.pnlSidebar.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblNavSection,
                this.btnProfile, this.btnSendMessages, this.btnCrypto,
                this.btnAttack,  this.btnReports,      this.btnSteganography,
                this.btnLogout });

            // ════════════════════════════════════════════════════════════
            // CONTENT
            // ════════════════════════════════════════════════════════════
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(0);

            this.pnlScrollableContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScrollableContent.AutoScroll = true;
            this.pnlScrollableContent.Padding = new System.Windows.Forms.Padding(28, 24, 28, 24);
            this.pnlScrollableContent.Name = "pnlScrollableContent";

            // Welcome card
            this.pnlWelcomeCard.Location = new System.Drawing.Point(28, 24);
            this.pnlWelcomeCard.Height = 160;
            this.pnlWelcomeCard.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;
            this.pnlWelcomeCard.Name = "pnlWelcomeCard";

            this.lblWelcome.Text = "Welcome back";
            this.lblWelcome.AutoSize = false;
            this.lblWelcome.Size = new System.Drawing.Size(700, 56);
            this.lblWelcome.Location = new System.Drawing.Point(28, 20);
            this.lblWelcome.Name = "lblWelcome";

            this.lblUserId.Text = "";
            this.lblUserId.AutoSize = true;
            this.lblUserId.Location = new System.Drawing.Point(30, 86);
            this.lblUserId.Name = "lblUserId";

            this.lblSession.Text = "";
            this.lblSession.AutoSize = true;
            this.lblSession.Location = new System.Drawing.Point(30, 114);
            this.lblSession.Name = "lblSession";

            this.lblLiveTime.Text = "";
            this.lblLiveTime.AutoSize = true;
            this.lblLiveTime.Location = new System.Drawing.Point(820, 22);
            this.lblLiveTime.Anchor =
                System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblLiveTime.Name = "lblLiveTime";

            this.pnlWelcomeCard.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblWelcome, this.lblUserId, this.lblSession, this.lblLiveTime });

            // Stats row
            this.pnlStatsRow.Location = new System.Drawing.Point(28, 200);
            this.pnlStatsRow.Height = 210;
            this.pnlStatsRow.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;
            this.pnlStatsRow.Name = "pnlStatsRow";

            this.pnlStatSecurity.Name = "pnlStatSecurity";
            this.pnlStatMessages.Name = "pnlStatMessages";
            this.pnlStatCrypto.Name = "pnlStatCrypto";
            this.pnlStatAttack.Name = "pnlStatAttack";

            this.pnlStatsRow.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.pnlStatSecurity, this.pnlStatMessages,
                this.pnlStatCrypto,   this.pnlStatAttack });

            // Table layout (embedded forms)
            this.tableLayoutPanelContent.Location = new System.Drawing.Point(28, 396);
            this.tableLayoutPanelContent.Height = 300;
            this.tableLayoutPanelContent.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;
            this.tableLayoutPanelContent.ColumnCount = 1;
            this.tableLayoutPanelContent.RowCount = 1;
            this.tableLayoutPanelContent.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelContent.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelContent.Name = "tableLayoutPanelContent";

            this.pnlScrollableContent.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.pnlWelcomeCard,
                this.pnlStatsRow,
                // pnlThreatMeter, pnlMiniLock, pnlActivityLog added dynamically in ApplyTheme
                this.tableLayoutPanelContent });

            this.pnlContent.Controls.Add(this.pnlScrollableContent);

            // Assemble body
            this.pnlBody.Controls.Add(this.pnlContent);
            this.pnlBody.Controls.Add(this.pnlSidebar);

            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlStatusBar);
            this.Controls.Add(this.pnlHeader);

            this.ResumeLayout(false);
        }
        #endregion

        private DoubleBufferedPanel pnlHeader;
        private DoubleBufferedPanel pnlLockIcon;
        private DoubleBufferedPanel pnlUserDot;
        private System.Windows.Forms.Label lblHeaderUser;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Label lblNavSection;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnSendMessages;
        private System.Windows.Forms.Button btnCrypto;
        private System.Windows.Forms.Button btnAttack;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnSteganography;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlScrollableContent;
        private System.Windows.Forms.Panel pnlWelcomeCard;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Label lblSession;
        private System.Windows.Forms.Label lblLiveTime;
        private System.Windows.Forms.Panel pnlStatsRow;
        private System.Windows.Forms.Panel pnlStatSecurity;
        private System.Windows.Forms.Panel pnlStatMessages;
        private System.Windows.Forms.Panel pnlStatCrypto;
        private System.Windows.Forms.Panel pnlStatAttack;
        private System.Windows.Forms.Panel pnlSecurityRow;
        private System.Windows.Forms.Panel pnlThreatLevel;
        private System.Windows.Forms.Panel pnlRecentActivity;
        private System.Windows.Forms.Panel pnlSystemHealth;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelContent;
        private System.Windows.Forms.Panel pnlStatusBar;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblStatusClock;
        private System.Windows.Forms.Timer clockTimer;
        private System.Windows.Forms.Timer pulseTimer;
    }

    public class DoubleBufferedPanel : System.Windows.Forms.Panel
    {
        public DoubleBufferedPanel()
        {
            this.DoubleBuffered = true;
            this.SetStyle(
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }
    }
}
