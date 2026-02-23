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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnBruteForce = new System.Windows.Forms.Button();
            this.btnDictionary = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Inter", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(161, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Attack Terminal";
            //
            // btnBruteForce
            //
            this.btnBruteForce.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.btnBruteForce.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBruteForce.FlatAppearance.BorderSize = 0;
            this.btnBruteForce.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBruteForce.Font = new System.Drawing.Font("Inter", 10F, System.Drawing.FontStyle.Bold);
            this.btnBruteForce.ForeColor = System.Drawing.Color.White;
            this.btnBruteForce.Location = new System.Drawing.Point(20, 80);
            this.btnBruteForce.Name = "btnBruteForce";
            this.btnBruteForce.Size = new System.Drawing.Size(320, 50);
            this.btnBruteForce.TabIndex = 1;
            this.btnBruteForce.Text = "BRUTE FORCE ATTACK";
            this.btnBruteForce.UseVisualStyleBackColor = false;
            this.btnBruteForce.Click += new System.EventHandler(this.btnBruteForce_Click);
            //
            // btnDictionary
            //
            this.btnDictionary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(150)))), ((int)(((byte)(90)))));
            this.btnDictionary.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDictionary.FlatAppearance.BorderSize = 0;
            this.btnDictionary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDictionary.Font = new System.Drawing.Font("Inter", 10F, System.Drawing.FontStyle.Bold);
            this.btnDictionary.ForeColor = System.Drawing.Color.White;
            this.btnDictionary.Location = new System.Drawing.Point(20, 140);
            this.btnDictionary.Name = "btnDictionary";
            this.btnDictionary.Size = new System.Drawing.Size(320, 50);
            this.btnDictionary.TabIndex = 2;
            this.btnDictionary.Text = "DICTIONARY ATTACK";
            this.btnDictionary.UseVisualStyleBackColor = false;
            this.btnDictionary.Click += new System.EventHandler(this.btnDictionary_Click);
            //
            // lblDescription
            //
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Inter", 9F);
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.lblDescription.Location = new System.Drawing.Point(20, 50);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(217, 15);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Select an attack method to proceed.";
            //
            // AttackForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(35)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(360, 220);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnDictionary);
            this.Controls.Add(this.btnBruteForce);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AttackForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Attack Control Center";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnBruteForce;
        private System.Windows.Forms.Button btnDictionary;
        private System.Windows.Forms.Label lblDescription;
    }
}