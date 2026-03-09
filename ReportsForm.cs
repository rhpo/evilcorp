using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace EvilCorp
{
    public partial class ReportsForm : Form
    {
        // -- Palette  -----------------------------------------------
        private static readonly Color Bg = Color.FromArgb(9, 12, 22);
        private static readonly Color HeaderBg = Color.FromArgb(12, 16, 30);
        private static readonly Color HeaderBorder = Color.FromArgb(24, 36, 64);
        private static readonly Color CardBg = Color.FromArgb(14, 20, 38);
        private static readonly Color CardBorder = Color.FromArgb(28, 42, 74);
        private static readonly Color AccentBlue = Color.FromArgb(55, 115, 220);
        private static readonly Color AccentCyan = Color.FromArgb(40, 190, 200);
        private static readonly Color AccentGreen = Color.FromArgb(35, 190, 85);
        private static readonly Color TextPrimary = Color.FromArgb(218, 230, 255);
        private static readonly Color TextSecondary = Color.FromArgb(84, 108, 158);

        private string? _pdfPath;

        public ReportsForm()
        {
            InitializeComponent();
            ApplyTheme();
            TryLoadDefaultPdf();
        }

        // -- Find and open the PDF with the system default viewer
        private void TryLoadDefaultPdf()
        {
            string pdfPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "security-report-en.pdf");
            if (!File.Exists(pdfPath))
            {
                // Fallback: check project root (in case running from IDE)
                string altPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "security-report-en.pdf");
                if (File.Exists(altPath))
                    pdfPath = Path.GetFullPath(altPath);
            }

            if (File.Exists(pdfPath))
            {
                _pdfPath = pdfPath;
                lblCurrentFile.Text = Path.GetFileName(pdfPath);
                lblCurrentFile.Visible = true;

                // Open immediately in default PDF viewer
                OpenPdfExternal(pdfPath);

                lblPlaceholder.Text = "Report opened in your default PDF viewer.\n\n"
                    + Path.GetFileName(pdfPath) + "\n"
                    + $"Size: {new FileInfo(pdfPath).Length / 1024} KB\n\n"
                    + "Click \"Open Report\" to open it again.";
                lblPlaceholder.Visible = true;
                pdfBrowser.Visible = false;

                // Show the open button
                btnOpenExternal.Visible = true;
            }
            else
            {
                lblPlaceholder.Text = "Report not found.\nMake sure \"security-report-en.pdf\" is in the application folder.";
                lblPlaceholder.Visible = true;
                pdfBrowser.Visible = false;
                btnOpenExternal.Visible = false;
            }
        }

        private void OpenPdfExternal(string path)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = path,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open PDF: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOpenExternal_Click(object? sender, EventArgs e)
        {
            if (_pdfPath != null && File.Exists(_pdfPath))
                OpenPdfExternal(_pdfPath);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ApplyTheme()
        {
            this.BackColor = Bg;

            // Title bar strip
            pnlTitleBar.BackColor = HeaderBg;
            pnlTitleBar.Paint += (s, e) =>
            {
                var g = e.Graphics;
                int w = pnlTitleBar.Width, h = pnlTitleBar.Height;
                using var grad = new LinearGradientBrush(new Point(0, 0), new Point(w / 2, 0),
                    AccentCyan, Color.FromArgb(0, AccentCyan));
                g.FillRectangle(grad, 0, 0, w / 2, 2);
                using var bp = new Pen(HeaderBorder, 1);
                g.DrawLine(bp, 0, h - 1, w, h - 1);
            };

            lblTitle.Font = new Font("Segoe UI", 16f, FontStyle.Bold);
            lblTitle.ForeColor = TextPrimary;

            lblSubtitle.Font = new Font("Segoe UI", 9.5f);
            lblSubtitle.ForeColor = TextSecondary;

            lblCurrentFile.Font = new Font("Segoe UI", 9.5f, FontStyle.Italic);
            lblCurrentFile.ForeColor = AccentBlue;
            lblCurrentFile.Visible = false;

            // Browser container card
            pnlBrowserCard.BackColor = CardBg;
            pnlBrowserCard.Paint += (s, e) =>
            {
                using var p = new Pen(CardBorder, 1);
                e.Graphics.DrawRectangle(p, 0, 0, pnlBrowserCard.Width - 1, pnlBrowserCard.Height - 1);
                using var stripe = new LinearGradientBrush(new Point(0, 0), new Point(0, pnlBrowserCard.Height),
                    AccentBlue, Color.FromArgb(0, AccentBlue));
                e.Graphics.FillRectangle(stripe, 0, 0, 3, pnlBrowserCard.Height);
            };

            // Toolbar strip
            pnlToolbar.BackColor = Color.FromArgb(11, 15, 28);
            pnlToolbar.Paint += (s, e) =>
            {
                using var bp = new Pen(HeaderBorder, 1);
                e.Graphics.DrawLine(bp, 0, pnlToolbar.Height - 1, pnlToolbar.Width, pnlToolbar.Height - 1);
            };

            StyleButton(btnClose, Color.FromArgb(160, 48, 48), "Close");
            StyleButton(btnOpenExternal, AccentGreen, "Open Report");
            btnOpenExternal.Visible = false;

            lblPlaceholder.Font = new Font("Segoe UI", 11f);
            lblPlaceholder.ForeColor = TextSecondary;

            pdfBrowser.Visible = false;
        }

        private void StyleButton(Button btn, Color accent, string text)
        {
            btn.Text = text;
            btn.BackColor = Color.FromArgb(20, accent.R, accent.G, accent.B);
            btn.ForeColor = accent;
            btn.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = Color.FromArgb(60, accent.R, accent.G, accent.B);
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, accent.R, accent.G, accent.B);
            btn.Cursor = Cursors.Hand;
            btn.TextAlign = ContentAlignment.MiddleCenter;
        }
    }
}
