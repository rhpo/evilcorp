using System.Windows.Forms;
using System.Drawing;
using System;

namespace EvilCorp
{
    public partial class SteganographySelectionForm : Form
    {
        private Button btnImageStegano;
        private Button btnTextStegano;
        private Label lblTitle;

        private static readonly Color BgColor = Color.FromArgb(15, 23, 42);
        private static readonly Color AccentBlue = Color.FromArgb(45, 126, 247);

        public SteganographySelectionForm()
        {
            InitializeComponent();
            this.BackColor = BgColor;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "EvilHide Selection";
            this.Size = new Size(650, 500); // Larger window

            lblTitle = new Label
            {
                Text = "Choisissez votre méthode EvilHide",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 20f, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 120 // Spacious header
            };

            btnImageStegano = new Button
            {
                Text = "🖼  Image dans Image",
                Size = new Size(500, 80),
                Location = new Point(75, 120),
                FlatStyle = FlatStyle.Flat,
                BackColor = AccentBlue,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 14f, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnImageStegano.FlatAppearance.BorderSize = 0;
            btnImageStegano.Click += (s, e) =>
            {
                this.Hide();
                using var f = new SteganographyForm();
                f.ShowDialog(this);
                this.Close();
            };

            btnTextStegano = new Button
            {
                Text = "📝  Texte dans Image",
                Size = new Size(500, 80),
                Location = new Point(75, 220), // Significant gap
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(45, 55, 72),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 14f, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnTextStegano.FlatAppearance.BorderSize = 0;
            btnTextStegano.Click += (s, e) =>
            {
                this.Hide();
                using var f = new TextSteganographyForm();
                f.ShowDialog(this);
                this.Close();
            };

            var btnReport = new Button
            {
                Text = "📘  Consulter le rapport d'algorithme",
                Size = new Size(500, 50),
                Location = new Point(75, 330),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = Color.FromArgb(100, 163, 230),
                Font = new Font("Segoe UI", 11f, FontStyle.Underline),
                Cursor = Cursors.Hand
            };
            btnReport.FlatAppearance.BorderSize = 0;
            btnReport.Click += (s, e) =>
            {
                try
                {
                    System.Diagnostics.Process.Start("notepad.exe", "steganography_report.md");
                }
                catch { }
            };

            this.Controls.Add(btnImageStegano);
            this.Controls.Add(btnTextStegano);
            this.Controls.Add(btnReport);
            this.Controls.Add(lblTitle);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Name = "SteganographySelectionForm";
            this.ResumeLayout(false);
        }
    }
}
