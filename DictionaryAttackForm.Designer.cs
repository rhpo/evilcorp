namespace EvilCorp
{
    partial class DictionaryAttackForm
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
            this.lblTarget = new System.Windows.Forms.Label();
            this.cmbTargetUser = new System.Windows.Forms.ComboBox();
            this.lblDictionary = new System.Windows.Forms.Label();
            this.txtDictionary = new System.Windows.Forms.TextBox();
            this.lblMinLength = new System.Windows.Forms.Label();
            this.numMinLength = new System.Windows.Forms.NumericUpDown();
            this.lblMaxLength = new System.Windows.Forms.Label();
            this.numMaxLength = new System.Windows.Forms.NumericUpDown();
            this.btnStart = new System.Windows.Forms.Button();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numMinLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxLength)).BeginInit();
            this.SuspendLayout();
            //
            // lblTarget
            //
            this.lblTarget.AutoSize = true;
            this.lblTarget.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.lblTarget.Location = new System.Drawing.Point(20, 20);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(65, 15);
            this.lblTarget.TabIndex = 0;
            this.lblTarget.Text = "Target User";
            //
            // cmbTargetUser
            //
            this.cmbTargetUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.cmbTargetUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTargetUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTargetUser.ForeColor = System.Drawing.Color.White;
            this.cmbTargetUser.Location = new System.Drawing.Point(20, 40);
            this.cmbTargetUser.Name = "cmbTargetUser";
            this.cmbTargetUser.Size = new System.Drawing.Size(300, 23);
            this.cmbTargetUser.TabIndex = 1;
            //
            // lblDictionary
            //
            this.lblDictionary.AutoSize = true;
            this.lblDictionary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.lblDictionary.Location = new System.Drawing.Point(20, 80);
            this.lblDictionary.Name = "lblDictionary";
            this.lblDictionary.Size = new System.Drawing.Size(125, 15);
            this.lblDictionary.TabIndex = 2;
            this.lblDictionary.Text = "Dictionary (one per line)";
            //
            // txtDictionary
            //
            this.txtDictionary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.txtDictionary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDictionary.ForeColor = System.Drawing.Color.White;
            this.txtDictionary.Location = new System.Drawing.Point(20, 100);
            this.txtDictionary.Multiline = true;
            this.txtDictionary.Name = "txtDictionary";
            this.txtDictionary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDictionary.Size = new System.Drawing.Size(300, 150);
            this.txtDictionary.TabIndex = 3;
            this.txtDictionary.Text = "password\r\nadmin\r\n123456\r\nqwerty\r\nhello\r\nwelcome";
            //
            // lblMinLength
            //
            this.lblMinLength.AutoSize = true;
            this.lblMinLength.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.lblMinLength.Location = new System.Drawing.Point(20, 265);
            this.lblMinLength.Name = "lblMinLength";
            this.lblMinLength.Size = new System.Drawing.Size(69, 15);
            this.lblMinLength.TabIndex = 4;
            this.lblMinLength.Text = "Min Length";
            //
            // numMinLength
            //
            this.numMinLength.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.numMinLength.ForeColor = System.Drawing.Color.White;
            this.numMinLength.Location = new System.Drawing.Point(20, 285);
            this.numMinLength.Name = "numMinLength";
            this.numMinLength.Size = new System.Drawing.Size(140, 23);
            this.numMinLength.TabIndex = 5;
            this.numMinLength.Value = new decimal(new int[] { 1, 0, 0, 0 });
            //
            // lblMaxLength
            //
            this.lblMaxLength.AutoSize = true;
            this.lblMaxLength.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.lblMaxLength.Location = new System.Drawing.Point(180, 265);
            this.lblMaxLength.Name = "lblMaxLength";
            this.lblMaxLength.Size = new System.Drawing.Size(71, 15);
            this.lblMaxLength.TabIndex = 6;
            this.lblMaxLength.Text = "Max Length";
            //
            // numMaxLength
            //
            this.numMaxLength.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.numMaxLength.ForeColor = System.Drawing.Color.White;
            this.numMaxLength.Location = new System.Drawing.Point(180, 285);
            this.numMaxLength.Name = "numMaxLength";
            this.numMaxLength.Size = new System.Drawing.Size(140, 23);
            this.numMaxLength.TabIndex = 7;
            this.numMaxLength.Value = new decimal(new int[] { 20, 0, 0, 0 });
            //
            // btnStart
            //
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(150)))), ((int)(((byte)(90)))));
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Inter", 10F, System.Drawing.FontStyle.Bold);
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(20, 330);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(300, 40);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "START DICTIONARY ATTACK";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            //
            // progress
            //
            this.progress.Location = new System.Drawing.Point(20, 385);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(300, 20);
            this.progress.TabIndex = 9;
            //
            // lblStatus
            //
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.lblStatus.Location = new System.Drawing.Point(20, 415);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(39, 15);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Ready";
            //
            // DictionaryAttackForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(35)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(340, 450);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.numMaxLength);
            this.Controls.Add(this.lblMaxLength);
            this.Controls.Add(this.numMinLength);
            this.Controls.Add(this.lblMinLength);
            this.Controls.Add(this.txtDictionary);
            this.Controls.Add(this.lblDictionary);
            this.Controls.Add(this.cmbTargetUser);
            this.Controls.Add(this.lblTarget);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "DictionaryAttackForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dictionary Attack";
            ((System.ComponentModel.ISupportInitialize)(this.numMinLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxLength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.ComboBox cmbTargetUser;
        private System.Windows.Forms.Label lblDictionary;
        private System.Windows.Forms.TextBox txtDictionary;
        private System.Windows.Forms.Label lblMinLength;
        private System.Windows.Forms.NumericUpDown numMinLength;
        private System.Windows.Forms.Label lblMaxLength;
        private System.Windows.Forms.NumericUpDown numMaxLength;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Label lblStatus;
    }
}
