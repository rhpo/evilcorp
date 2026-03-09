namespace EvilCorp
{
    partial class CryptoTestForm
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
            this.lblAlgorithm = new System.Windows.Forms.Label();
            this.cmbAlgorithm = new System.Windows.Forms.ComboBox();
            this.lblKey = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.lblDirection = new System.Windows.Forms.Label();
            this.cmbDirection = new System.Windows.Forms.ComboBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnCrypto = new System.Windows.Forms.Button();
            this.lblMode = new System.Windows.Forms.Label();
            this.cmbMode = new System.Windows.Forms.ComboBox();
            this.lblInput = new System.Windows.Forms.Label();
            this.lblOutput = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlMiddle = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.pnlButtons = new System.Windows.Forms.Panel();

            this.pnlTop.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();

            // FORM
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 680);
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.BackColor = System.Drawing.Color.FromArgb(25, 35, 55);
            this.Name = "CryptoTestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Encrypt / Decrypt Tester";

            // TOP PANEL — fixed height, contains algorithm + key + direction side by side
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 90;
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(20, 30, 50);
            this.pnlTop.Padding = new System.Windows.Forms.Padding(20, 10, 20, 0);

            // Algorithm — fixed width, left
            this.lblAlgorithm.Text = "Algorithm";
            this.lblAlgorithm.AutoSize = true;
            this.lblAlgorithm.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAlgorithm.ForeColor = System.Drawing.Color.FromArgb(180, 200, 230);
            this.lblAlgorithm.Location = new System.Drawing.Point(20, 10);

            this.cmbAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlgorithm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbAlgorithm.BackColor = System.Drawing.Color.FromArgb(30, 40, 60);
            this.cmbAlgorithm.ForeColor = System.Drawing.Color.FromArgb(230, 240, 255);
            this.cmbAlgorithm.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbAlgorithm.Location = new System.Drawing.Point(20, 32);
            this.cmbAlgorithm.Size = new System.Drawing.Size(170, 26);
            this.cmbAlgorithm.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.cmbAlgorithm.SelectedIndexChanged += new System.EventHandler(this.cmbAlgorithm_SelectedIndexChanged);

            // Key — fixed width next to algorithm
            this.lblKey.Text = "Key";
            this.lblKey.AutoSize = true;
            this.lblKey.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKey.ForeColor = System.Drawing.Color.FromArgb(180, 200, 230);
            this.lblKey.Location = new System.Drawing.Point(206, 10);

            this.txtKey.BackColor = System.Drawing.Color.FromArgb(30, 40, 60);
            this.txtKey.ForeColor = System.Drawing.Color.FromArgb(230, 240, 255);
            this.txtKey.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtKey.Location = new System.Drawing.Point(206, 32);
            this.txtKey.Size = new System.Drawing.Size(200, 26);
            this.txtKey.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;

            // Direction — fixed width next to key, always visible space reserved
            this.lblDirection.Text = "Direction";
            this.lblDirection.AutoSize = true;
            this.lblDirection.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDirection.ForeColor = System.Drawing.Color.FromArgb(180, 200, 230);
            this.lblDirection.Location = new System.Drawing.Point(422, 10);
            this.lblDirection.Visible = false;

            this.cmbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDirection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDirection.BackColor = System.Drawing.Color.FromArgb(30, 40, 60);
            this.cmbDirection.ForeColor = System.Drawing.Color.FromArgb(230, 240, 255);
            this.cmbDirection.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbDirection.Location = new System.Drawing.Point(422, 32);
            this.cmbDirection.Size = new System.Drawing.Size(120, 26);
            this.cmbDirection.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.cmbDirection.Visible = false;

            this.pnlTop.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblAlgorithm, this.cmbAlgorithm,
                this.lblKey,       this.txtKey,
                this.lblDirection, this.cmbDirection });

            // MIDDLE PANEL — input text, fills available space
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddle.BackColor = System.Drawing.Color.FromArgb(25, 35, 55);
            this.pnlMiddle.Padding = new System.Windows.Forms.Padding(20, 8, 20, 8);

            this.lblInput.Text = "Input Text";
            this.lblInput.AutoSize = true;
            this.lblInput.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblInput.ForeColor = System.Drawing.Color.FromArgb(180, 200, 230);
            this.lblInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInput.Height = 22;

            this.txtInput.BackColor = System.Drawing.Color.FromArgb(30, 40, 60);
            this.txtInput.ForeColor = System.Drawing.Color.FromArgb(230, 240, 255);
            this.txtInput.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtInput.Multiline = true;
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // Add label first (Dock Top), then Fill takes rest
            this.pnlMiddle.Controls.Add(this.txtInput);
            this.pnlMiddle.Controls.Add(this.lblInput);

            // BUTTONS PANEL
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Height = 58;
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(20, 30, 50);
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(20, 10, 20, 0);

            this.lblMode.Text = "Mode";
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMode.ForeColor = System.Drawing.Color.FromArgb(180, 200, 230);
            this.lblMode.Location = new System.Drawing.Point(20, 10);

            this.cmbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMode.BackColor = System.Drawing.Color.FromArgb(30, 40, 60);
            this.cmbMode.ForeColor = System.Drawing.Color.FromArgb(230, 240, 255);
            this.cmbMode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbMode.Location = new System.Drawing.Point(20, 32);
            this.cmbMode.Size = new System.Drawing.Size(120, 26);

            this.btnCrypto.Text = "🔒🔓  ENCRYPT / DECRYPT";
            this.btnCrypto.BackColor = System.Drawing.Color.FromArgb(50, 100, 200);
            this.btnCrypto.ForeColor = System.Drawing.Color.White;
            this.btnCrypto.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCrypto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrypto.FlatAppearance.BorderSize = 0;
            this.btnCrypto.Size = new System.Drawing.Size(260, 36);
            this.btnCrypto.Location = new System.Drawing.Point(154, 10);
            this.btnCrypto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrypto.Click += new System.EventHandler(this.btnCrypto_Click);

            this.pnlButtons.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblMode, this.cmbMode, this.btnCrypto });

            // BOTTOM PANEL — output text, fixed height
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Height = 200;
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(25, 35, 55);
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(20, 8, 20, 16);

            this.lblOutput.Text = "Result";
            this.lblOutput.AutoSize = true;
            this.lblOutput.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblOutput.ForeColor = System.Drawing.Color.FromArgb(180, 200, 230);
            this.lblOutput.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblOutput.Height = 22;

            this.txtOutput.BackColor = System.Drawing.Color.FromArgb(14, 20, 38);
            this.txtOutput.ForeColor = System.Drawing.Color.FromArgb(100, 200, 150);
            this.txtOutput.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtOutput.Multiline = true;
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;

            this.pnlBottom.Controls.Add(this.txtOutput);
            this.pnlBottom.Controls.Add(this.lblOutput);

            // ASSEMBLE
            this.Controls.Add(this.pnlMiddle);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlMiddle.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblAlgorithm;
        private System.Windows.Forms.ComboBox cmbAlgorithm;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.ComboBox cmbDirection;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnCrypto;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.ComboBox cmbMode;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlMiddle;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlButtons;
    }
}
