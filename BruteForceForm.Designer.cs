namespace EvilCorp
{
    partial class BruteForceForm
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
            this.pnlCard = new System.Windows.Forms.Panel();
            this.pnlDefenseBar = new System.Windows.Forms.Panel();
            this.tbl = new System.Windows.Forms.TableLayoutPanel();
            this.lblTargetLbl = new System.Windows.Forms.Label();
            this.cmbTargetUser = new System.Windows.Forms.ComboBox();
            this.lblCharsetLbl = new System.Windows.Forms.Label();
            this.txtCharset = new System.Windows.Forms.TextBox();
            this.lblMinLbl = new System.Windows.Forms.Label();
            this.lblMaxLbl = new System.Windows.Forms.Label();
            this.pnlLengthRow = new System.Windows.Forms.Panel();
            this.numMinLength = new System.Windows.Forms.NumericUpDown();
            this.numMaxLength = new System.Windows.Forms.NumericUpDown();
            this.pnlButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnDefense = new System.Windows.Forms.Button();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.numMinLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxLength)).BeginInit();
            this.SuspendLayout();

            // ── Form ─────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(1100, 900);
            this.MinimumSize = new System.Drawing.Size(900, 740);
            this.BackColor = System.Drawing.Color.FromArgb(7, 10, 20);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "BruteForceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EvilCorp — Brute Force Attack";

            // ── Header: 130px — title@24, subtitle@80, no overlap ─────
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 130;
            this.pnlHeader.Name = "pnlHeader";

            // ── Defense bar ───────────────────────────────────────────
            this.pnlDefenseBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDefenseBar.Height = 64;
            this.pnlDefenseBar.Name = "pnlDefenseBar";

            // ── Card ──────────────────────────────────────────────────
            this.pnlCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCard.Name = "pnlCard";

            // ── Table ─────────────────────────────────────────────────
            this.tbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl.Padding = new System.Windows.Forms.Padding(64, 50, 64, 40);
            this.tbl.ColumnCount = 2;
            this.tbl.Name = "tbl";
            this.tbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));

            this.tbl.RowCount = 14;
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));  // 0 target lbl
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));  // 1 target combo
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));  // 2 spacer
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));  // 3 charset lbl
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));  // 4 charset input
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));  // 5 spacer
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));  // 6 min/max lbl
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));  // 7 min/max inputs
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));  // 8 spacer
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66F));  // 9 start+stop btns
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));  // 10 spacer
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66F));  // 11 defense btn
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));  // 12 spacer
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));  // 13 progress+status

            // Row 0
            this.lblTargetLbl.Name = "lblTargetLbl";
            this.lblTargetLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl.Controls.Add(this.lblTargetLbl, 0, 0);
            this.tbl.SetColumnSpan(this.lblTargetLbl, 2);

            // Row 1
            this.cmbTargetUser.Name = "cmbTargetUser";
            this.cmbTargetUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbTargetUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbl.Controls.Add(this.cmbTargetUser, 0, 1);
            this.tbl.SetColumnSpan(this.cmbTargetUser, 2);

            // Row 3
            this.lblCharsetLbl.Name = "lblCharsetLbl";
            this.lblCharsetLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl.Controls.Add(this.lblCharsetLbl, 0, 3);
            this.tbl.SetColumnSpan(this.lblCharsetLbl, 2);

            // Row 4
            this.txtCharset.Name = "txtCharset";
            this.txtCharset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCharset.Text = "abcdefghijklmnopqrstuvwxyz0123456789";
            this.tbl.Controls.Add(this.txtCharset, 0, 4);
            this.tbl.SetColumnSpan(this.txtCharset, 2);

            // Row 6
            this.lblMinLbl.Name = "lblMinLbl";
            this.lblMinLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl.Controls.Add(this.lblMinLbl, 0, 6);

            this.lblMaxLbl.Name = "lblMaxLbl";
            this.lblMaxLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl.Controls.Add(this.lblMaxLbl, 1, 6);

            // Row 7
            this.numMinLength.Name = "numMinLength";
            this.numMinLength.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numMinLength.Minimum = 1;
            this.numMinLength.Maximum = 20;
            this.numMinLength.Value = 1;
            this.tbl.Controls.Add(this.numMinLength, 0, 7);

            this.numMaxLength.Name = "numMaxLength";
            this.numMaxLength.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numMaxLength.Minimum = 1;
            this.numMaxLength.Maximum = 20;
            this.numMaxLength.Value = 4;
            this.tbl.Controls.Add(this.numMaxLength, 1, 7);

            // Row 9 — launch + abort
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtons.ColumnCount = 2;
            this.pnlButtons.RowCount = 1;
            this.pnlButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.pnlButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.pnlButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(0);
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(0);
            this.pnlButtons.BackColor = System.Drawing.Color.Transparent;

            this.btnStart.Name = "btnStart";
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStart.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            this.pnlButtons.Controls.Add(this.btnStart, 0, 0);

            this.btnStop.Name = "btnStop";
            this.btnStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStop.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            this.pnlButtons.Controls.Add(this.btnStop, 1, 0);

            this.tbl.Controls.Add(this.pnlButtons, 0, 9);
            this.tbl.SetColumnSpan(this.pnlButtons, 2);

            // Row 11 — defense
            this.btnDefense.Name = "btnDefense";
            this.btnDefense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDefense.Click += new System.EventHandler(this.btnDefense_Click);
            this.tbl.Controls.Add(this.btnDefense, 0, 11);
            this.tbl.SetColumnSpan(this.btnDefense, 2);

            // Row 13 — progress + status
            var pnlBottom = new System.Windows.Forms.TableLayoutPanel
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                Margin = new System.Windows.Forms.Padding(0),
                Padding = new System.Windows.Forms.Padding(0),
                BackColor = System.Drawing.Color.Transparent
            };
            pnlBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            pnlBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            pnlBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            this.progress.Name = "progress";
            this.progress.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlBottom.Controls.Add(this.progress, 0, 0);

            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.AutoSize = false;
            this.lblStatus.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            pnlBottom.Controls.Add(this.lblStatus, 0, 1);

            this.tbl.Controls.Add(pnlBottom, 0, 13);
            this.tbl.SetColumnSpan(pnlBottom, 2);

            this.pnlCard.Controls.Add(this.tbl);
            this.Controls.Add(this.pnlCard);
            this.Controls.Add(this.pnlDefenseBar);
            this.Controls.Add(this.pnlHeader);

            ((System.ComponentModel.ISupportInitialize)(this.numMinLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxLength)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Panel pnlDefenseBar;
        private System.Windows.Forms.TableLayoutPanel tbl;
        private System.Windows.Forms.Label lblTargetLbl;
        private System.Windows.Forms.ComboBox cmbTargetUser;
        private System.Windows.Forms.Label lblCharsetLbl;
        private System.Windows.Forms.TextBox txtCharset;
        private System.Windows.Forms.Label lblMinLbl;
        private System.Windows.Forms.Label lblMaxLbl;
        private System.Windows.Forms.Panel pnlLengthRow;
        private System.Windows.Forms.NumericUpDown numMinLength;
        private System.Windows.Forms.NumericUpDown numMaxLength;
        private System.Windows.Forms.TableLayoutPanel pnlButtons;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnDefense;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Label lblStatus;
    }
}