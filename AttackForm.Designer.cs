namespace EvilCorp
{
    partial class AttackForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlCards = new System.Windows.Forms.Panel();
            this.pnlBrute = new System.Windows.Forms.Panel();
            this.pnlDict = new System.Windows.Forms.Panel();
            this.pnlMitm = new System.Windows.Forms.Panel();

            this.SuspendLayout();

            // ── Form ────────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.MinimumSize = new System.Drawing.Size(960, 580);
            this.BackColor = System.Drawing.Color.FromArgb(9, 12, 22);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "AttackForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EvilCorp — Attack Terminal";

            // ── Header — fully custom painted, no labels ─────────────────
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 96;
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(12, 16, 30);
            this.pnlHeader.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                int w = pnlHeader.Width, h = pnlHeader.Height;

                // Background gradient
                using var grad = new System.Drawing.Drawing2D.LinearGradientBrush(
                    new System.Drawing.Point(0, 0), new System.Drawing.Point(500, 0),
                    System.Drawing.Color.FromArgb(30, 55, 115, 220),
                    System.Drawing.Color.FromArgb(0, 55, 115, 220));
                g.FillRectangle(grad, 0, 0, 500, h);

                // Top cyan accent line
                using var cyanP = new System.Drawing.Pen(System.Drawing.Color.FromArgb(80, 40, 190, 200), 2);
                g.DrawLine(cyanP, 0, 0, 520, 0);

                // Bottom border
                using var borderP = new System.Drawing.Pen(System.Drawing.Color.FromArgb(24, 36, 64), 1);
                g.DrawLine(borderP, 0, h - 1, w, h - 1);

                // Title text only — no emoji prefix
                using var titleF = new System.Drawing.Font("Segoe UI", 20f, System.Drawing.FontStyle.Bold);
                g.DrawString("Attack Terminal", titleF,
                    new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(218, 230, 255)),
                    new System.Drawing.PointF(28, 14));

                // Subtitle
                using var subF = new System.Drawing.Font("Segoe UI", 10f);
                g.DrawString("Select an attack vector to launch", subF,
                    new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(84, 108, 158)),
                    new System.Drawing.PointF(28, 58));
            };

            // ── Cards panel ─────────────────────────────────────────────
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCards.BackColor = System.Drawing.Color.Transparent;
            this.pnlCards.Name = "pnlCards";

            this.pnlBrute.Name = "pnlBrute";
            this.pnlDict.Name = "pnlDict";
            this.pnlMitm.Name = "pnlMitm";

            this.pnlCards.Controls.Add(this.pnlBrute);
            this.pnlCards.Controls.Add(this.pnlDict);
            this.pnlCards.Controls.Add(this.pnlMitm);

            this.pnlCards.Resize += (s, e) => LayoutCards();
            this.Load += (s, e) => LayoutCards();

            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.pnlHeader);

            this.ResumeLayout(false);
        }

        private void LayoutCards()
        {
            int pad = 48;
            int gap = 24;
            int avail = pnlCards.ClientSize.Width - pad * 2;
            int cw = (avail - gap * 2) / 3;
            int top = 36;
            int ch = pnlCards.ClientSize.Height - top - 40;
            ch = System.Math.Max(ch, 260);

            pnlBrute.SetBounds(pad, top, cw, ch);
            pnlDict.SetBounds(pad + cw + gap, top, cw, ch);
            pnlMitm.SetBounds(pad + (cw + gap) * 2, top, cw, ch);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlCards;
        private System.Windows.Forms.Panel pnlBrute;
        private System.Windows.Forms.Panel pnlDict;
        private System.Windows.Forms.Panel pnlMitm;
    }
}