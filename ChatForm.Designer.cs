namespace EvilCorp
{
    partial class ChatForm
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
            //
            // panelTop
            //
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
            this.panelTop.Controls.Add(this.lblLoggedInUser);
            this.panelTop.Controls.Add(this.lblUserLabel);
            this.panelTop.Controls.Add(this.btnLogout);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(900, 60);
            this.panelTop.TabIndex = 0;
            //
            // lblLoggedInUser
            //
            this.lblLoggedInUser.AutoSize = true;
            this.lblLoggedInUser.Font = new System.Drawing.Font("Inter", 14F, System.Drawing.FontStyle.Bold);
            this.lblLoggedInUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.lblLoggedInUser.Location = new System.Drawing.Point(150, 18);
            this.lblLoggedInUser.Name = "lblLoggedInUser";
            this.lblLoggedInUser.Size = new System.Drawing.Size(58, 23);
            this.lblLoggedInUser.TabIndex = 2;
            this.lblLoggedInUser.Text = "User";
            //
            // lblUserLabel
            //
            this.lblUserLabel.AutoSize = true;
            this.lblUserLabel.Font = new System.Drawing.Font("Inter", 12F);
            this.lblUserLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.lblUserLabel.Location = new System.Drawing.Point(20, 20);
            this.lblUserLabel.Name = "lblUserLabel";
            this.lblUserLabel.Size = new System.Drawing.Size(113, 19);
            this.lblUserLabel.TabIndex = 1;
            this.lblUserLabel.Text = "Logged in as:";
            //
            // btnLogout
            //
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Inter", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(780, 15);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 30);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            //
            // panelEncryption
            //
            this.panelEncryption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this.panelEncryption.Controls.Add(this.lblAlgorithm);
            this.panelEncryption.Controls.Add(this.cmbAlgorithm);
            this.panelEncryption.Controls.Add(this.lblKey);
            this.panelEncryption.Controls.Add(this.txtKey);
            this.panelEncryption.Controls.Add(this.lblDirection);
            this.panelEncryption.Controls.Add(this.cmbDirection);
            this.panelEncryption.Controls.Add(this.lblReceiver);
            this.panelEncryption.Controls.Add(this.cmbReceiver);
            this.panelEncryption.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEncryption.Location = new System.Drawing.Point(0, 60);
            this.panelEncryption.Name = "panelEncryption";
            this.panelEncryption.Size = new System.Drawing.Size(900, 100);
            this.panelEncryption.TabIndex = 1;
            //
            // lblAlgorithm
            //
            this.lblAlgorithm.AutoSize = true;
            this.lblAlgorithm.Font = new System.Drawing.Font("Inter", 10F);
            this.lblAlgorithm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.lblAlgorithm.Location = new System.Drawing.Point(20, 20);
            this.lblAlgorithm.Name = "lblAlgorithm";
            this.lblAlgorithm.Size = new System.Drawing.Size(148, 17);
            this.lblAlgorithm.TabIndex = 0;
            this.lblAlgorithm.Text = "Encryption Algorithm";
            //
            // cmbAlgorithm
            //
            this.cmbAlgorithm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.cmbAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlgorithm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbAlgorithm.Font = new System.Drawing.Font("Inter", 10F);
            this.cmbAlgorithm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.cmbAlgorithm.FormattingEnabled = true;
            this.cmbAlgorithm.Location = new System.Drawing.Point(20, 45);
            this.cmbAlgorithm.Name = "cmbAlgorithm";
            this.cmbAlgorithm.Size = new System.Drawing.Size(200, 25);
            this.cmbAlgorithm.TabIndex = 1;
            this.cmbAlgorithm.SelectedIndexChanged += new System.EventHandler(this.cmbAlgorithm_SelectedIndexChanged);
            //
            // lblKey
            //
            this.lblKey.AutoSize = true;
            this.lblKey.Font = new System.Drawing.Font("Inter", 10F);
            this.lblKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.lblKey.Location = new System.Drawing.Point(240, 20);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(31, 17);
            this.lblKey.TabIndex = 2;
            this.lblKey.Text = "Key";
            //
            // txtKey
            //
            this.txtKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.txtKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKey.Font = new System.Drawing.Font("Inter", 10F);
            this.txtKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.txtKey.Location = new System.Drawing.Point(240, 45);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(150, 24);
            this.txtKey.TabIndex = 3;
            //
            // lblDirection
            //
            this.lblDirection.AutoSize = true;
            this.lblDirection.Font = new System.Drawing.Font("Inter", 10F);
            this.lblDirection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.lblDirection.Location = new System.Drawing.Point(410, 20);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Size = new System.Drawing.Size(68, 17);
            this.lblDirection.TabIndex = 6;
            this.lblDirection.Text = "Direction";
            this.lblDirection.Visible = false;
            //
            // cmbDirection
            //
            this.cmbDirection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.cmbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDirection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDirection.Font = new System.Drawing.Font("Inter", 10F);
            this.cmbDirection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.cmbDirection.FormattingEnabled = true;
            this.cmbDirection.Location = new System.Drawing.Point(410, 45);
            this.cmbDirection.Name = "cmbDirection";
            this.cmbDirection.Size = new System.Drawing.Size(100, 25);
            this.cmbDirection.TabIndex = 7;
            this.cmbDirection.Visible = false;
            //
            // lblReceiver
            //
            this.lblReceiver.AutoSize = true;
            this.lblReceiver.Font = new System.Drawing.Font("Inter", 10F);
            this.lblReceiver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.lblReceiver.Location = new System.Drawing.Point(530, 20);
            this.lblReceiver.Name = "lblReceiver";
            this.lblReceiver.Size = new System.Drawing.Size(63, 17);
            this.lblReceiver.TabIndex = 4;
            this.lblReceiver.Text = "Send To";
            //
            // cmbReceiver
            //
            this.cmbReceiver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.cmbReceiver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReceiver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbReceiver.Font = new System.Drawing.Font("Inter", 10F);
            this.cmbReceiver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.cmbReceiver.FormattingEnabled = true;
            this.cmbReceiver.Location = new System.Drawing.Point(530, 45);
            this.cmbReceiver.Name = "cmbReceiver";
            this.cmbReceiver.Size = new System.Drawing.Size(200, 25);
            this.cmbReceiver.TabIndex = 5;
            //
            // panelChat
            //
            this.panelChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(35)))), ((int)(((byte)(55)))));
            this.panelChat.Controls.Add(this.rtbChat);
            this.panelChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChat.Location = new System.Drawing.Point(0, 160);
            this.panelChat.Name = "panelChat";
            this.panelChat.Padding = new System.Windows.Forms.Padding(10);
            this.panelChat.Size = new System.Drawing.Size(900, 390);
            this.panelChat.TabIndex = 2;
            //
            // rtbChat
            //
            this.rtbChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.rtbChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbChat.Font = new System.Drawing.Font("Inter", 10F);
            this.rtbChat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.rtbChat.Location = new System.Drawing.Point(10, 10);
            this.rtbChat.Name = "rtbChat";
            this.rtbChat.ReadOnly = true;
            this.rtbChat.Size = new System.Drawing.Size(880, 370);
            this.rtbChat.TabIndex = 0;
            this.rtbChat.Text = "";
            //
            // panelInput
            //
            this.panelInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this.panelInput.Controls.Add(this.txtMessage);
            this.panelInput.Controls.Add(this.btnSend);
            this.panelInput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelInput.Location = new System.Drawing.Point(0, 550);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(900, 70);
            this.panelInput.TabIndex = 3;
            //
            // txtMessage
            //
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessage.Font = new System.Drawing.Font("Inter", 11F);
            this.txtMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.txtMessage.Location = new System.Drawing.Point(20, 20);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(740, 25);
            this.txtMessage.TabIndex = 0;
            //
            // btnSend
            //
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Inter", 11F, System.Drawing.FontStyle.Bold);
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Location = new System.Drawing.Point(780, 15);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(100, 35);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            this.btnSend.MouseEnter += new System.EventHandler(this.btnSend_MouseEnter);
            this.btnSend.MouseLeave += new System.EventHandler(this.btnSend_MouseLeave);
            //
            // ChatForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 620);
            this.Controls.Add(this.panelChat);
            this.Controls.Add(this.panelInput);
            this.Controls.Add(this.panelEncryption);
            this.Controls.Add(this.panelTop);
            this.Name = "ChatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EvilCorp - Secure Chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatForm_FormClosing);
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
