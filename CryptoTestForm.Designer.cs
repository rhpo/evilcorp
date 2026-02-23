namespace EvilCorp
{
    partial class CryptoTestForm
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
            this.lblAlgorithm = new System.Windows.Forms.Label();
            this.cmbAlgorithm = new System.Windows.Forms.ComboBox();
            this.lblKey = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.lblDirection = new System.Windows.Forms.Label();
            this.cmbDirection = new System.Windows.Forms.ComboBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.lblInput = new System.Windows.Forms.Label();
            this.lblOutput = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // lblAlgorithm
            //
            this.lblAlgorithm.AutoSize = true;
            this.lblAlgorithm.Font = new System.Drawing.Font("Inter", 10F);
            this.lblAlgorithm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.lblAlgorithm.Location = new System.Drawing.Point(20, 20);
            this.lblAlgorithm.Name = "lblAlgorithm";
            this.lblAlgorithm.Size = new System.Drawing.Size(86, 17);
            this.lblAlgorithm.TabIndex = 0;
            this.lblAlgorithm.Text = "Algorithm";
            //
            // cmbAlgorithm
            //
            this.cmbAlgorithm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.cmbAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlgorithm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbAlgorithm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
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
            this.txtKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.txtKey.Location = new System.Drawing.Point(240, 45);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(180, 23);
            this.txtKey.TabIndex = 3;
            //
            // lblDirection
            //
            this.lblDirection.AutoSize = true;
            this.lblDirection.Font = new System.Drawing.Font("Inter", 10F);
            this.lblDirection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.lblDirection.Location = new System.Drawing.Point(440, 20);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Size = new System.Drawing.Size(68, 17);
            this.lblDirection.TabIndex = 4;
            this.lblDirection.Text = "Direction";
            this.lblDirection.Visible = false;
            //
            // cmbDirection
            //
            this.cmbDirection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.cmbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDirection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDirection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.cmbDirection.Location = new System.Drawing.Point(440, 45);
            this.cmbDirection.Name = "cmbDirection";
            this.cmbDirection.Size = new System.Drawing.Size(100, 25);
            this.cmbDirection.TabIndex = 5;
            this.cmbDirection.Visible = false;
            //
            // lblInput
            //
            this.lblInput.AutoSize = true;
            this.lblInput.Font = new System.Drawing.Font("Inter", 10F);
            this.lblInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.lblInput.Location = new System.Drawing.Point(20, 85);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(33, 17);
            this.lblInput.TabIndex = 6;
            this.lblInput.Text = "Text";
            //
            // txtInput
            //
            this.txtInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.txtInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.txtInput.Location = new System.Drawing.Point(20, 110);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(520, 120);
            this.txtInput.TabIndex = 7;
            //
            // btnEncrypt
            //
            this.btnEncrypt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.btnEncrypt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEncrypt.FlatAppearance.BorderSize = 0;
            this.btnEncrypt.ForeColor = System.Drawing.Color.White;
            this.btnEncrypt.Location = new System.Drawing.Point(20, 245);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(120, 35);
            this.btnEncrypt.TabIndex = 8;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = false;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            //
            // btnDecrypt
            //
            this.btnDecrypt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            this.btnDecrypt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecrypt.FlatAppearance.BorderSize = 0;
            this.btnDecrypt.ForeColor = System.Drawing.Color.White;
            this.btnDecrypt.Location = new System.Drawing.Point(150, 245);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(120, 35);
            this.btnDecrypt.TabIndex = 9;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = false;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            //
            // lblOutput
            //
            this.lblOutput.AutoSize = true;
            this.lblOutput.Font = new System.Drawing.Font("Inter", 10F);
            this.lblOutput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.lblOutput.Location = new System.Drawing.Point(20, 295);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(45, 17);
            this.lblOutput.TabIndex = 10;
            this.lblOutput.Text = "Result";
            //
            // txtOutput
            //
            this.txtOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.txtOutput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.txtOutput.Location = new System.Drawing.Point(20, 320);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(520, 120);
            this.txtOutput.TabIndex = 11;
            //
            // CryptoTestForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 460);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(35)))), ((int)(((byte)(55)))));
            this.Controls.Add(this.lblAlgorithm);
            this.Controls.Add(this.cmbAlgorithm);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.lblDirection);
            this.Controls.Add(this.cmbDirection);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.txtOutput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CryptoTestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Encrypt / Decrypt Tester";
            this.ResumeLayout(false);
            this.PerformLayout();
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
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.Label lblOutput;
    }
}
