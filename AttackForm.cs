using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace EvilCorp
{
    public partial class AttackForm : Form
    {
        // ── Palette ───────────────────────────────────────────────────
        private static readonly Color Bg = Color.FromArgb(9, 12, 22);
        private static readonly Color CardBg = Color.FromArgb(14, 20, 38);
        private static readonly Color CardBorder = Color.FromArgb(28, 42, 74);
        private static readonly Color CardHover = Color.FromArgb(20, 30, 54);
        private static readonly Color AccentBlue = Color.FromArgb(55, 115, 220);
        private static readonly Color AccentGreen = Color.FromArgb(35, 170, 95);
        private static readonly Color AccentOrange = Color.FromArgb(220, 145, 30);
        private static readonly Color TextPrimary = Color.FromArgb(218, 230, 255);
        private static readonly Color TextSecondary = Color.FromArgb(84, 108, 158);
        private static readonly Color HeaderBorder = Color.FromArgb(24, 36, 64);

        private record AttackCard(Panel Panel, string Icon, string Title, string Sub, string Tag, Color Accent);
        private AttackCard[] _cards = null!;

        public AttackForm()
        {
            InitializeComponent();
            SetupCards();
            this.Paint += PaintBackground;
        }

        private void SetupCards()
        {
            _cards = new[]
            {
                new AttackCard(pnlBrute, "⚡", "Brute Force",        "Exhaustive key search\nover charset space",   "FORCE",     AccentBlue),
                new AttackCard(pnlDict,  "📖", "Dictionary",          "Word-list based\npassword cracking",          "CRACK",     AccentGreen),
                new AttackCard(pnlMitm,  "🕸", "Man in the Middle",   "Intercept & manipulate\nnetwork traffic",     "INTERCEPT", AccentOrange),
            };

            foreach (var card in _cards)
            {
                var c = card;
                c.Panel.BackColor = CardBg;
                c.Panel.Cursor = Cursors.Hand;
                c.Panel.MouseEnter += (s, e) => { c.Panel.BackColor = CardHover; c.Panel.Invalidate(); };
                c.Panel.MouseLeave += (s, e) => { c.Panel.BackColor = CardBg; c.Panel.Invalidate(); };
                c.Panel.Paint += (s, e) => PaintAttackCard(e.Graphics, c, c.Panel.Width, c.Panel.Height);
                c.Panel.Click += CardClicked;
            }
        }

        private void CardClicked(object? sender, EventArgs e)
        {
            var panel = (Panel)sender!;
            if (panel == pnlBrute) { using var f = new BruteForceForm(); f.ShowDialog(); }
            else if (panel == pnlDict) { using var f = new DictionaryAttackForm(); f.ShowDialog(); }
            else if (panel == pnlMitm)
            {
                var f = new MitmForm();
                f.Show();
            }
        }

        private void PaintBackground(object? s, PaintEventArgs e)
        {
            var g = e.Graphics;
            int w = this.ClientSize.Width, h = this.ClientSize.Height;
            using var dot = new SolidBrush(Color.FromArgb(7, AccentBlue));
            for (int x = 24; x < w; x += 36)
                for (int y = 24; y < h; y += 36)
                    g.FillEllipse(dot, x, y, 2, 2);
            using var glow = new SolidBrush(Color.FromArgb(8, AccentBlue));
            g.FillEllipse(glow, w - 300, h - 300, 500, 500);
        }

        private void PaintAttackCard(Graphics g, AttackCard card, int w, int h)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            // Border
            using var bp = new Pen(CardBorder, 1);
            g.DrawRectangle(bp, 0, 0, w - 1, h - 1);

            // Left accent stripe
            using var stripe = new LinearGradientBrush(new Point(0, 0), new Point(0, h),
                card.Accent, Color.FromArgb(30, card.Accent));
            g.FillRectangle(stripe, 0, 0, 4, h);

            // Corner glow
            using var gl = new SolidBrush(Color.FromArgb(10, card.Accent));
            g.FillEllipse(gl, w - 130, h - 130, 220, 220);

            // Top-right tag badge
            using var tagF = new Font("Segoe UI", 7.5f, FontStyle.Bold);
            var tagSz = g.MeasureString(card.Tag, tagF);
            var tagR = new RectangleF(w - tagSz.Width - 20, 14, tagSz.Width + 14, tagSz.Height + 6);
            using var tagBg = new SolidBrush(Color.FromArgb(28, card.Accent));
            FillRoundedRect(g, tagBg, tagR, 4);
            using var tagBorder = new Pen(Color.FromArgb(55, card.Accent), 1);
            g.DrawRectangle(tagBorder, tagR.X, tagR.Y, tagR.Width - 1, tagR.Height - 1);
            g.DrawString(card.Tag, tagF, new SolidBrush(card.Accent), tagR.X + 7, tagR.Y + 3);

            // Icon
            using var iconF = new Font("Segoe UI Emoji", 32f);
            g.DrawString(card.Icon, iconF, new SolidBrush(card.Accent), new PointF(16, 16));

            // Title
            using var titleF = new Font("Segoe UI", 14f, FontStyle.Bold);
            g.DrawString(card.Title, titleF, new SolidBrush(TextPrimary), new PointF(16, h - 88));

            // Divider
            using var div = new Pen(Color.FromArgb(22, card.Accent), 1);
            g.DrawLine(div, 16, h - 68, w - 16, h - 68);

            // Sub description
            using var subF = new Font("Segoe UI", 9f);
            g.DrawString(card.Sub, subF, new SolidBrush(TextSecondary),
                new RectangleF(16, h - 62, w - 32, 46));

            // Arrow hint bottom-right
            using var arrowF = new Font("Segoe UI", 13f);
            g.DrawString("→", arrowF, new SolidBrush(Color.FromArgb(70, card.Accent)),
                new PointF(w - 32, h - 28));
        }

        private static void FillRoundedRect(Graphics g, Brush b, RectangleF r, float radius)
        {
            float d = radius * 2;
            using var path = new GraphicsPath();
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            g.FillPath(b, path);
        }
    }
}
