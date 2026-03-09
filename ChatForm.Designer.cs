namespace EvilCorp
{
    partial class ChatForm
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblLoggedInUser = new System.Windows.Forms.Label();
            this.lblUserLabel = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panelEncryption = new System.Windows.Forms.Panel();
            this.lblAlgorithm = new System.Windows.Forms.Label();
            this.cmbAlgorithm = new System.Windows.Forms.ComboBox();
            this.lblKey = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.lblDirection = new System.Windows.Forms.Label();
            this.cmbDirection = new System.Windows.Forms.ComboBox();
            this.lblReceiver = new System.Windows.Forms.Label();
            this.cmbReceiver = new System.Windows.Forms.ComboBox();
            this.panelChat = new System.Windows.Forms.Panel();
            this.rtbChat = new System.Windows.Forms.RichTextBox();
            this.panelInput = new System.Windows.Forms.Panel();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();

            this.panelTop.SuspendLayout();
            this.panelEncryption.SuspendLayout();
            this.panelChat.SuspendLayout();
            this.panelInput.SuspendLayout();
            this.SuspendLayout();

            // FORM
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 780);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.BackColor = System.Drawing.Color.FromArgb(25, 35, 55);
            this.Name = "ChatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EvilCorp — Secure Chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatForm_FormClosing);

            // TOP PANEL
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 64;
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(12, 16, 30);
            this.panelTop.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);

            this.lblUserLabel.Text = "Logged in as:";
            this.lblUserLabel.AutoSize = true;
            this.lblUserLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblUserLabel.ForeColor = System.Drawing.Color.FromArgb(180, 200, 230);
            this.lblUserLabel.Location = new System.Drawing.Point(20, 22);

            this.lblLoggedInUser.Text = "User";
            this.lblLoggedInUser.AutoSize = true;
            this.lblLoggedInUser.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblLoggedInUser.ForeColor = System.Drawing.Color.FromArgb(100, 160, 255);
            this.lblLoggedInUser.Location = new System.Drawing.Point(160, 20);

            this.btnLogout.Text = "Logout";
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(180, 45, 45);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.Size = new System.Drawing.Size(110, 34);
            this.btnLogout.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnLogout.Location = new System.Drawing.Point(970, 15);
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            this.panelTop.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblUserLabel, this.lblLoggedInUser, this.btnLogout });

            // ENCRYPTION PANEL
            this.panelEncryption.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEncryption.Height = 110;
            this.panelEncryption.BackColor = System.Drawing.Color.FromArgb(16, 24, 42);
            this.panelEncryption.Padding = new System.Windows.Forms.Padding(20, 10, 20, 0);

            this.lblAlgorithm.Text = "Algorithm";
            this.lblAlgorithm.AutoSize = true;
            this.lblAlgorithm.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblAlgorithm.ForeColor = System.Drawing.Color.FromArgb(150, 175, 215);
            this.lblAlgorithm.Location = new System.Drawing.Point(20, 12);

            this.cmbAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlgorithm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbAlgorithm.BackColor = System.Drawing.Color.FromArgb(28, 38, 58);
            this.cmbAlgorithm.ForeColor = System.Drawing.Color.FromArgb(230, 240, 255);
            this.cmbAlgorithm.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbAlgorithm.Location = new System.Drawing.Point(20, 36);
            this.cmbAlgorithm.Size = new System.Drawing.Size(180, 30);
            this.cmbAlgorithm.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.cmbAlgorithm.SelectedIndexChanged += new System.EventHandler(this.cmbAlgorithm_SelectedIndexChanged);

            this.lblKey.Text = "Key";
            this.lblKey.AutoSize = true;
            this.lblKey.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblKey.ForeColor = System.Drawing.Color.FromArgb(150, 175, 215);
            this.lblKey.Location = new System.Drawing.Point(215, 12);

            this.txtKey.BackColor = System.Drawing.Color.FromArgb(28, 38, 58);
            this.txtKey.ForeColor = System.Drawing.Color.FromArgb(230, 240, 255);
            this.txtKey.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtKey.Location = new System.Drawing.Point(215, 36);
            this.txtKey.Size = new System.Drawing.Size(200, 30);
            this.txtKey.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;

            this.lblDirection.Text = "Direction";
            this.lblDirection.AutoSize = true;
            this.lblDirection.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDirection.ForeColor = System.Drawing.Color.FromArgb(150, 175, 215);
            this.lblDirection.Location = new System.Drawing.Point(430, 12);
            this.lblDirection.Visible = false;

            this.cmbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDirection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDirection.BackColor = System.Drawing.Color.FromArgb(28, 38, 58);
            this.cmbDirection.ForeColor = System.Drawing.Color.FromArgb(230, 240, 255);
            this.cmbDirection.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbDirection.Location = new System.Drawing.Point(430, 36);
            this.cmbDirection.Size = new System.Drawing.Size(120, 30);
            this.cmbDirection.Visible = false;

            this.lblReceiver.Text = "Send To";
            this.lblReceiver.AutoSize = true;
            this.lblReceiver.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblReceiver.ForeColor = System.Drawing.Color.FromArgb(100, 200, 150);
            this.lblReceiver.Location = new System.Drawing.Point(570, 12);
            this.lblReceiver.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;

            this.cmbReceiver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReceiver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbReceiver.BackColor = System.Drawing.Color.FromArgb(28, 38, 58);
            this.cmbReceiver.ForeColor = System.Drawing.Color.FromArgb(230, 240, 255);
            this.cmbReceiver.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbReceiver.Location = new System.Drawing.Point(570, 36);
            this.cmbReceiver.Size = new System.Drawing.Size(220, 30);
            this.cmbReceiver.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;

            this.panelEncryption.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblAlgorithm, this.cmbAlgorithm,
                this.lblKey,       this.txtKey,
                this.lblDirection, this.cmbDirection,
                this.lblReceiver,  this.cmbReceiver });

            // INPUT PANEL — Dock Fill for textbox, Dock Right for button
            this.panelInput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelInput.Height = 60;
            this.panelInput.BackColor = System.Drawing.Color.FromArgb(16, 24, 42);
            this.panelInput.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);

            // Button docked RIGHT first so Fill respects it
            this.btnSend.Text = "Send";
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(50, 100, 200);
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.Width = 110;
            this.btnSend.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            this.btnSend.MouseEnter += new System.EventHandler(this.btnSend_MouseEnter);
            this.btnSend.MouseLeave += new System.EventHandler(this.btnSend_MouseLeave);

            this.txtMessage.BackColor = System.Drawing.Color.FromArgb(28, 38, 58);
            this.txtMessage.ForeColor = System.Drawing.Color.FromArgb(230, 240, 255);
            this.txtMessage.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill;

            // Add button BEFORE textbox so Dock.Right is claimed first
            this.panelInput.Controls.Add(this.txtMessage);
            this.panelInput.Controls.Add(this.btnSend);

            // CHAT PANEL
            this.panelChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChat.BackColor = System.Drawing.Color.FromArgb(22, 30, 50);
            this.panelChat.Padding = new System.Windows.Forms.Padding(12);

            this.rtbChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbChat.BackColor = System.Drawing.Color.FromArgb(14, 20, 38);
            this.rtbChat.ForeColor = System.Drawing.Color.FromArgb(230, 240, 255);
            this.rtbChat.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.rtbChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbChat.ReadOnly = true;
            this.rtbChat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;

            this.panelChat.Controls.Add(this.rtbChat);

            // ASSEMBLE — order matters for Dock stacking
            this.Controls.Add(this.panelChat);
            this.Controls.Add(this.panelInput);
            this.Controls.Add(this.panelEncryption);
            this.Controls.Add(this.panelTop);

            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelEncryption.ResumeLayout(false);
            this.panelEncryption.PerformLayout();
            this.panelChat.ResumeLayout(false);
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblLoggedInUser;
        private System.Windows.Forms.Label lblUserLabel;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelEncryption;
        private System.Windows.Forms.Label lblAlgorithm;
        private System.Windows.Forms.ComboBox cmbAlgorithm;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.ComboBox cmbDirection;
        private System.Windows.Forms.Label lblReceiver;
        private System.Windows.Forms.ComboBox cmbReceiver;
        private System.Windows.Forms.Panel panelChat;
        private System.Windows.Forms.RichTextBox rtbChat;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
    }
}
