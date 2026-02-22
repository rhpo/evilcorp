namespace EvilCorp
{
    partial class AttackForm
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
            this.lblAttackType = new System.Windows.Forms.Label();
            this.cmbAttackType = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // lblTarget
            //
            this.lblTarget.AutoSize = true;
            this.lblTarget.Location = new System.Drawing.Point(20, 20);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(74, 15);
            this.lblTarget.TabIndex = 0;
            this.lblTarget.Text = "Target User";
            //
            // cmbTargetUser
            //
            this.cmbTargetUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTargetUser.Location = new System.Drawing.Point(20, 45);
            this.cmbTargetUser.Name = "cmbTargetUser";
            this.cmbTargetUser.Size = new System.Drawing.Size(300, 23);
            this.cmbTargetUser.TabIndex = 1;
            //
            // lblAttackType
            //
            this.lblAttackType.AutoSize = true;
            this.lblAttackType.Location = new System.Drawing.Point(20, 85);
            this.lblAttackType.Name = "lblAttackType";
            this.lblAttackType.Size = new System.Drawing.Size(66, 15);
            this.lblAttackType.TabIndex = 2;
            this.lblAttackType.Text = "Attack Type";
            //
            // cmbAttackType
            //
            this.cmbAttackType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAttackType.Location = new System.Drawing.Point(20, 110);
            this.cmbAttackType.Name = "cmbAttackType";
            this.cmbAttackType.Size = new System.Drawing.Size(300, 23);
            this.cmbAttackType.TabIndex = 3;
            //
            // btnStart
            //
            this.btnStart.Location = new System.Drawing.Point(20, 150);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(300, 40);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            //
            // progress
            //
            this.progress.Location = new System.Drawing.Point(20, 205);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(300, 20);
            this.progress.TabIndex = 5;
            //
            // lblStatus
            //
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(20, 235);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 15);
            this.lblStatus.TabIndex = 6;
            //
            // AttackForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 280);
            this.Controls.Add(this.lblTarget);
            this.Controls.Add(this.cmbTargetUser);
            this.Controls.Add(this.lblAttackType);
            this.Controls.Add(this.cmbAttackType);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.lblStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AttackForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Attack Interface (Simulation)";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.ComboBox cmbTargetUser;
        private System.Windows.Forms.Label lblAttackType;
        private System.Windows.Forms.ComboBox cmbAttackType;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Label lblStatus;
    }
}
