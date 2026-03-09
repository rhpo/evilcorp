namespace EvilCorp
{
    partial class ReportsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlTitleBar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOpenExternal = new System.Windows.Forms.Button();
            this.lblCurrentFile = new System.Windows.Forms.Label();
            this.pnlBrowserCard = new System.Windows.Forms.Panel();
            this.pdfBrowser = new System.Windows.Forms.WebBrowser();
            this.lblPlaceholder = new System.Windows.Forms.Label();

            this.pnlTitleBar.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.pnlBrowserCard.SuspendLayout();
            this.SuspendLayout();

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 780);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "ReportsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EvilCorp — Reports";

            this.pnlTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitleBar.Height = 90;
            this.pnlTitleBar.Name = "pnlTitleBar";
            this.pnlTitleBar.Padding = new System.Windows.Forms.Padding(24, 0, 24, 0);

            this.lblTitle.Text = "📊   Reports";
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(24, 18);
            this.lblTitle.Name = "lblTitle";

            this.lblSubtitle.Text = "View and manage your PDF reports";
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Location = new System.Drawing.Point(26, 58);
            this.lblSubtitle.Name = "lblSubtitle";

            this.pnlTitleBar.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle, this.lblSubtitle });

            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Height = 52;
            this.pnlToolbar.Name = "pnlToolbar";

            this.btnClose.Location = new System.Drawing.Point(20, 10);
            this.btnClose.Size = new System.Drawing.Size(110, 32);
            this.btnClose.Name = "btnClose";
            this.btnClose.TabIndex = 0;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.btnOpenExternal.Location = new System.Drawing.Point(140, 10);
            this.btnOpenExternal.Size = new System.Drawing.Size(140, 32);
            this.btnOpenExternal.Name = "btnOpenExternal";
            this.btnOpenExternal.TabIndex = 1;
            this.btnOpenExternal.Click += new System.EventHandler(this.btnOpenExternal_Click);

            this.lblCurrentFile.AutoSize = true;
            this.lblCurrentFile.Location = new System.Drawing.Point(295, 17);
            this.lblCurrentFile.Name = "lblCurrentFile";
            this.lblCurrentFile.Text = "";

            this.pnlToolbar.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.btnClose, this.btnOpenExternal, this.lblCurrentFile });

            this.pnlBrowserCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBrowserCard.Name = "pnlBrowserCard";
            this.pnlBrowserCard.Padding = new System.Windows.Forms.Padding(16);

            this.pdfBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfBrowser.Name = "pdfBrowser";
            this.pdfBrowser.ScrollBarsEnabled = true;
            this.pdfBrowser.Visible = false;

            this.lblPlaceholder.Text = "Loading report...";
            this.lblPlaceholder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPlaceholder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPlaceholder.Name = "lblPlaceholder";
            this.lblPlaceholder.Visible = true;

            this.pnlBrowserCard.Controls.Add(this.pdfBrowser);
            this.pnlBrowserCard.Controls.Add(this.lblPlaceholder);

            this.Controls.Add(this.pnlBrowserCard);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlTitleBar);

            this.pnlBrowserCard.ResumeLayout(false);
            this.pnlToolbar.ResumeLayout(false);
            this.pnlTitleBar.ResumeLayout(false);
            this.pnlTitleBar.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTitleBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOpenExternal;
        private System.Windows.Forms.Label lblCurrentFile;
        private System.Windows.Forms.Panel pnlBrowserCard;
        private System.Windows.Forms.WebBrowser pdfBrowser;
        private System.Windows.Forms.Label lblPlaceholder;
    }
}
