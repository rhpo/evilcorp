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
            lblTarget = new Label();
            cmbTargetUser = new ComboBox();
            lblDictionary = new Label();
            txtDictionary = new TextBox();
            lblMinLength = new Label();
            numMinLength = new NumericUpDown();
            lblMaxLength = new Label();
            numMaxLength = new NumericUpDown();
            btnStart = new Button();
            progress = new ProgressBar();
            lblStatus = new Label();
            ((System.ComponentModel.ISupportInitialize)numMinLength).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMaxLength).BeginInit();
            SuspendLayout();
            // 
            // lblTarget
            // 
            lblTarget.AutoSize = true;
            lblTarget.ForeColor = Color.FromArgb(180, 200, 230);
            lblTarget.Location = new Point(23, 27);
            lblTarget.Name = "lblTarget";
            lblTarget.Size = new Size(83, 20);
            lblTarget.TabIndex = 0;
            lblTarget.Text = "Target User";
            // 
            // cmbTargetUser
            // 
            cmbTargetUser.BackColor = Color.FromArgb(30, 40, 60);
            cmbTargetUser.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTargetUser.FlatStyle = FlatStyle.Flat;
            cmbTargetUser.ForeColor = Color.White;
            cmbTargetUser.Location = new Point(23, 53);
            cmbTargetUser.Margin = new Padding(3, 4, 3, 4);
            cmbTargetUser.Name = "cmbTargetUser";
            cmbTargetUser.Size = new Size(342, 28);
            cmbTargetUser.TabIndex = 1;
            cmbTargetUser.SelectedIndexChanged += cmbTargetUser_SelectedIndexChanged;
            // 
            // lblDictionary
            // 
            lblDictionary.AutoSize = true;
            lblDictionary.ForeColor = Color.FromArgb(180, 200, 230);
            lblDictionary.Location = new Point(23, 107);
            lblDictionary.Name = "lblDictionary";
            lblDictionary.Size = new Size(170, 20);
            lblDictionary.TabIndex = 2;
            lblDictionary.Text = "Dictionary (one per line)";
            // 
            // txtDictionary
            // 
            txtDictionary.BackColor = Color.FromArgb(30, 40, 60);
            txtDictionary.BorderStyle = BorderStyle.FixedSingle;
            txtDictionary.ForeColor = Color.White;
            txtDictionary.Location = new Point(23, 133);
            txtDictionary.Margin = new Padding(3, 4, 3, 4);
            txtDictionary.Multiline = true;
            txtDictionary.Name = "txtDictionary";
            txtDictionary.ScrollBars = ScrollBars.Vertical;
            txtDictionary.Size = new Size(343, 199);
            txtDictionary.TabIndex = 3;
            // 
            // lblMinLength
            // 
            lblMinLength.AutoSize = true;
            lblMinLength.ForeColor = Color.FromArgb(180, 200, 230);
            lblMinLength.Location = new Point(23, 353);
            lblMinLength.Name = "lblMinLength";
            lblMinLength.Size = new Size(83, 20);
            lblMinLength.TabIndex = 4;
            lblMinLength.Text = "Min Length";
            // 
            // numMinLength
            // 
            numMinLength.BackColor = Color.FromArgb(30, 40, 60);
            numMinLength.ForeColor = Color.White;
            numMinLength.Location = new Point(23, 380);
            numMinLength.Margin = new Padding(3, 4, 3, 4);
            numMinLength.Name = "numMinLength";
            numMinLength.Size = new Size(160, 27);
            numMinLength.TabIndex = 5;
            numMinLength.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblMaxLength
            // 
            lblMaxLength.AutoSize = true;
            lblMaxLength.ForeColor = Color.FromArgb(180, 200, 230);
            lblMaxLength.Location = new Point(206, 353);
            lblMaxLength.Name = "lblMaxLength";
            lblMaxLength.Size = new Size(86, 20);
            lblMaxLength.TabIndex = 6;
            lblMaxLength.Text = "Max Length";
            // 
            // numMaxLength
            // 
            numMaxLength.BackColor = Color.FromArgb(30, 40, 60);
            numMaxLength.ForeColor = Color.White;
            numMaxLength.Location = new Point(206, 380);
            numMaxLength.Margin = new Padding(3, 4, 3, 4);
            numMaxLength.Name = "numMaxLength";
            numMaxLength.Size = new Size(160, 27);
            numMaxLength.TabIndex = 7;
            numMaxLength.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.FromArgb(40, 150, 90);
            btnStart.FlatAppearance.BorderSize = 0;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("Inter", 10F, FontStyle.Bold);
            btnStart.ForeColor = Color.White;
            btnStart.Location = new Point(23, 440);
            btnStart.Margin = new Padding(3, 4, 3, 4);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(343, 53);
            btnStart.TabIndex = 8;
            btnStart.Text = "START DICTIONARY ATTACK";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // progress
            // 
            progress.Location = new Point(23, 513);
            progress.Margin = new Padding(3, 4, 3, 4);
            progress.Name = "progress";
            progress.Size = new Size(343, 27);
            progress.TabIndex = 9;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.ForeColor = Color.FromArgb(180, 200, 230);
            lblStatus.Location = new Point(23, 553);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(50, 20);
            lblStatus.TabIndex = 10;
            lblStatus.Text = "Ready";
            // 
            // DictionaryAttackForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 35, 55);
            ClientSize = new Size(389, 600);
            Controls.Add(lblStatus);
            Controls.Add(progress);
            Controls.Add(btnStart);
            Controls.Add(numMaxLength);
            Controls.Add(lblMaxLength);
            Controls.Add(numMinLength);
            Controls.Add(lblMinLength);
            Controls.Add(txtDictionary);
            Controls.Add(lblDictionary);
            Controls.Add(cmbTargetUser);
            Controls.Add(lblTarget);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "DictionaryAttackForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Dictionary Attack";
            Load += DictionaryAttackForm_Load;
            ((System.ComponentModel.ISupportInitialize)numMinLength).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMaxLength).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
