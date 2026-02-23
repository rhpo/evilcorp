namespace EvilCorp
{
    partial class BruteForceForm
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
            this.lblCharset = new System.Windows.Forms.Label();
            this.txtCharset = new System.Windows.Forms.TextBox();
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
            // lblCharset
            //
            this.lblCharset.AutoSize = true;
            this.lblCharset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.lblCharset.Location = new System.Drawing.Point(20, 80);
            this.lblCharset.Name = "lblCharset";
            this.lblCharset.Size = new System.Drawing.Size(47, 15);
            this.lblCharset.TabIndex = 2;
            this.lblCharset.Text = "Charset";
            //
            // txtCharset
            //
            this.txtCharset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.txtCharset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCharset.ForeColor = System.Drawing.Color.White;
            this.txtCharset.Location = new System.Drawing.Point(20, 100);
            this.txtCharset.Name = "txtCharset";
            this.txtCharset.Size = new System.Drawing.Size(300, 23);
            this.txtCharset.TabIndex = 3;
            this.txtCharset.Text = "abcdefghijklmnopqrstuvwxyz0123456789";
            //
            // lblMinLength
            //
            this.lblMinLength.AutoSize = true;
            this.lblMinLength.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.lblMinLength.Location = new System.Drawing.Point(20, 140);
            this.lblMinLength.Name = "lblMinLength";
            this.lblMinLength.Size = new System.Drawing.Size(69, 15);
            this.lblMinLength.TabIndex = 4;
            this.lblMinLength.Text = "Min Length";
            //
            // numMinLength
            //
            this.numMinLength.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.numMinLength.ForeColor = System.Drawing.Color.White;
            this.numMinLength.Location = new System.Drawing.Point(20, 160);
            this.numMinLength.Name = "numMinLength";
            this.numMinLength.Size = new System.Drawing.Size(140, 23);
            this.numMinLength.TabIndex = 5;
            this.numMinLength.Value = new decimal(new int[] { 1, 0, 0, 0 });
            //
            // lblMaxLength
            //
            this.lblMaxLength.AutoSize = true;
            this.lblMaxLength.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.lblMaxLength.Location = new System.Drawing.Point(180, 140);
            this.lblMaxLength.Name = "lblMaxLength";
            this.lblMaxLength.Size = new System.Drawing.Size(71, 15);
            this.lblMaxLength.TabIndex = 6;
            this.lblMaxLength.Text = "Max Length";
            //
            // numMaxLength
            //
            this.numMaxLength.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.numMaxLength.ForeColor = System.Drawing.Color.White;
            this.numMaxLength.Location = new System.Drawing.Point(180, 160);
            this.numMaxLength.Name = "numMaxLength";
            this.numMaxLength.Size = new System.Drawing.Size(140, 23);
            this.numMaxLength.TabIndex = 7;
            this.numMaxLength.Value = new decimal(new int[] { 4, 0, 0, 0 });
            //
            // btnStart
            //
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Inter", 10F, System.Drawing.FontStyle.Bold);
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(20, 210);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(300, 40);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "START BRUTE FORCE";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            //
            // progress
            //
            this.progress.Location = new System.Drawing.Point(20, 260);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(300, 20);
            this.progress.TabIndex = 9;
            //
            // lblStatus
            //
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.lblStatus.Location = new System.Drawing.Point(20, 290);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(39, 15);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Ready";
            //
            // BruteForceForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(35)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(340, 330);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.numMaxLength);
            this.Controls.Add(this.lblMaxLength);
            this.Controls.Add(this.numMinLength);
            this.Controls.Add(this.lblMinLength);
            this.Controls.Add(this.txtCharset);
            this.Controls.Add(this.lblCharset);
            this.Controls.Add(this.cmbTargetUser);
            this.Controls.Add(this.lblTarget);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "BruteForceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Brute Force Attack";
            ((System.ComponentModel.ISupportInitialize)(this.numMinLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxLength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.ComboBox cmbTargetUser;
        private System.Windows.Forms.Label lblCharset;
        private System.Windows.Forms.TextBox txtCharset;
        private System.Windows.Forms.Label lblMinLength;
        private System.Windows.Forms.NumericUpDown numMinLength;
        private System.Windows.Forms.Label lblMaxLength;
        private System.Windows.Forms.NumericUpDown numMaxLength;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Label lblStatus;
    }
}
