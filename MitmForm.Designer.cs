using System.Windows.Forms;

namespace EvilCorp
{
    partial class MitmForm
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
            this.splitMain = new System.Windows.Forms.SplitContainer();

            // Left side controls
            this.pnlListenerConfig = new System.Windows.Forms.Panel();
            this.lblListenerTitle = new System.Windows.Forms.Label();
            this.lblTargetPipe = new System.Windows.Forms.Label();
            this.cmbTargetUser = new System.Windows.Forms.ComboBox();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.pnlStatusBar = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblStatusDot = new System.Windows.Forms.Label();

            // Protection toggle
            this.pnlProtection = new System.Windows.Forms.Panel();
            this.lblProtectionTitle = new System.Windows.Forms.Label();
            this.lblProtectionDesc = new System.Windows.Forms.Label();
            this.btnToggleProtection = new System.Windows.Forms.Button();

            // Right side - intercepted messages log
            this.pnlLogHeader = new System.Windows.Forms.Panel();
            this.lblLogTitle = new System.Windows.Forms.Label();
            this.lblInterceptCount = new System.Windows.Forms.Label();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.rtbLog = new System.Windows.Forms.RichTextBox();

            this.SuspendLayout();

            // ── Form ──────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1600, 950);
            this.MinimumSize = new System.Drawing.Size(1200, 800);
            this.BackColor = System.Drawing.Color.FromArgb(9, 12, 22);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "MitmForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EvilCorp - MITM Interceptor";

            // ── Header ────────────────────────────────────────────────
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 96;
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(12, 16, 30);
            this.pnlHeader.Name = "pnlHeader";

            // ── Main split ────────────────────────────────────────────
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.SplitterDistance = 500;
            this.splitMain.SplitterWidth = 2;
            this.splitMain.BackColor = System.Drawing.Color.FromArgb(24, 36, 64);
            this.splitMain.Name = "splitMain";

            // ═══════════ LEFT PANEL ═══════════════════════════════════

            // ── Listener Config Card ──────────────────────────────────
            this.pnlListenerConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlListenerConfig.Height = 250;
            this.pnlListenerConfig.BackColor = System.Drawing.Color.FromArgb(14, 20, 38);
            this.pnlListenerConfig.Padding = new System.Windows.Forms.Padding(24);
            this.pnlListenerConfig.Margin = new System.Windows.Forms.Padding(12);
            this.pnlListenerConfig.Name = "pnlListenerConfig";

            this.lblListenerTitle.Text = "LISTENER CONFIGURATION";
            this.lblListenerTitle.AutoSize = true;
            this.lblListenerTitle.Location = new System.Drawing.Point(24, 18);
            this.lblListenerTitle.Name = "lblListenerTitle";

            this.lblTargetPipe.Text = "Target User Pipe";
            this.lblTargetPipe.AutoSize = true;
            this.lblTargetPipe.Location = new System.Drawing.Point(24, 60);
            this.lblTargetPipe.Name = "lblTargetPipe";

            this.cmbTargetUser.Location = new System.Drawing.Point(24, 86);
            this.cmbTargetUser.Size = new System.Drawing.Size(440, 32);
            this.cmbTargetUser.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.cmbTargetUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTargetUser.Name = "cmbTargetUser";

            this.btnStartStop.Location = new System.Drawing.Point(24, 136);
            this.btnStartStop.Size = new System.Drawing.Size(440, 48);
            this.btnStartStop.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Text = "START INTERCEPTING";
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);

            // Status bar inside listener config
            this.pnlStatusBar.Location = new System.Drawing.Point(24, 200);
            this.pnlStatusBar.Size = new System.Drawing.Size(440, 32);
            this.pnlStatusBar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.pnlStatusBar.BackColor = System.Drawing.Color.FromArgb(10, 14, 26);
            this.pnlStatusBar.Name = "pnlStatusBar";

            this.lblStatusDot.Text = "\u25CF";
            this.lblStatusDot.AutoSize = true;
            this.lblStatusDot.Location = new System.Drawing.Point(10, 6);
            this.lblStatusDot.Name = "lblStatusDot";

            this.lblStatus.Text = "IDLE";
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(28, 7);
            this.lblStatus.Name = "lblStatus";

            this.pnlStatusBar.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblStatusDot, this.lblStatus });

            this.pnlListenerConfig.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblListenerTitle, this.lblTargetPipe, this.cmbTargetUser,
                this.btnStartStop, this.pnlStatusBar });

            // ── Protection Card ───────────────────────────────────────
            this.pnlProtection.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProtection.Height = 210;
            this.pnlProtection.BackColor = System.Drawing.Color.FromArgb(14, 20, 38);
            this.pnlProtection.Padding = new System.Windows.Forms.Padding(24);
            this.pnlProtection.Name = "pnlProtection";

            this.lblProtectionTitle.Text = "MESSAGE PROTECTION";
            this.lblProtectionTitle.AutoSize = true;
            this.lblProtectionTitle.Location = new System.Drawing.Point(24, 18);
            this.lblProtectionTitle.Name = "lblProtectionTitle";

            this.lblProtectionDesc.Text = "When enabled, messages are sent using the bundler.\nAlgorithm and key are hidden in the payload.\nWhen disabled, messages are sent in clear text.";
            this.lblProtectionDesc.AutoSize = true;
            this.lblProtectionDesc.Location = new System.Drawing.Point(24, 56);
            this.lblProtectionDesc.MaximumSize = new System.Drawing.Size(440, 0);
            this.lblProtectionDesc.Name = "lblProtectionDesc";

            this.btnToggleProtection.Location = new System.Drawing.Point(24, 140);
            this.btnToggleProtection.Size = new System.Drawing.Size(440, 48);
            this.btnToggleProtection.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.btnToggleProtection.Name = "btnToggleProtection";
            this.btnToggleProtection.Text = "PROTECTION: ON";
            this.btnToggleProtection.Click += new System.EventHandler(this.btnToggleProtection_Click);

            this.pnlProtection.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblProtectionTitle, this.lblProtectionDesc, this.btnToggleProtection });

            // Assemble left panel
            this.splitMain.Panel1.BackColor = System.Drawing.Color.FromArgb(9, 12, 22);
            this.splitMain.Panel1.Padding = new System.Windows.Forms.Padding(12);
            this.splitMain.Panel1.Controls.Add(this.pnlProtection);  // added first = below
            this.splitMain.Panel1.Controls.Add(this.pnlListenerConfig); // added second = above (Dock.Top stacking)

            // ═══════════ RIGHT PANEL ══════════════════════════════════

            this.pnlLogHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogHeader.Height = 50;
            this.pnlLogHeader.BackColor = System.Drawing.Color.FromArgb(12, 16, 30);
            this.pnlLogHeader.Name = "pnlLogHeader";

            this.lblLogTitle.Text = "INTERCEPTED MESSAGES";
            this.lblLogTitle.AutoSize = true;
            this.lblLogTitle.Location = new System.Drawing.Point(16, 14);
            this.lblLogTitle.Name = "lblLogTitle";

            this.lblInterceptCount.Text = "0 packets";
            this.lblInterceptCount.AutoSize = true;
            this.lblInterceptCount.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblInterceptCount.Name = "lblInterceptCount";

            this.btnClearLog.Text = "CLEAR";
            this.btnClearLog.Size = new System.Drawing.Size(80, 26);
            this.btnClearLog.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);

            this.pnlLogHeader.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblLogTitle, this.lblInterceptCount, this.btnClearLog });

            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.BackColor = System.Drawing.Color.FromArgb(9, 12, 22);
            this.rtbLog.ForeColor = System.Drawing.Color.FromArgb(180, 200, 230);
            this.rtbLog.Font = new System.Drawing.Font("Consolas", 9.5f);
            this.rtbLog.ReadOnly = true;
            this.rtbLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;

            this.splitMain.Panel2.BackColor = System.Drawing.Color.FromArgb(9, 12, 22);
            this.splitMain.Panel2.Controls.Add(this.pnlLogHeader);
            this.splitMain.Panel2.Controls.Add(this.rtbLog);

            // ── Assemble form ─────────────────────────────────────────
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.pnlHeader);

            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.SplitContainer splitMain;

        private System.Windows.Forms.Panel pnlListenerConfig;
        private System.Windows.Forms.Label lblListenerTitle;
        private System.Windows.Forms.Label lblTargetPipe;
        private System.Windows.Forms.ComboBox cmbTargetUser;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Panel pnlStatusBar;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblStatusDot;

        private System.Windows.Forms.Panel pnlProtection;
        private System.Windows.Forms.Label lblProtectionTitle;
        private System.Windows.Forms.Label lblProtectionDesc;
        private System.Windows.Forms.Button btnToggleProtection;

        private System.Windows.Forms.Panel pnlLogHeader;
        private System.Windows.Forms.Label lblLogTitle;
        private System.Windows.Forms.Label lblInterceptCount;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.RichTextBox rtbLog;
    }
}
