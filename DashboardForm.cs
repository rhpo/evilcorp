using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace EvilCorp
{
    public partial class DashboardForm : Form
    {
        private User _currentUser;
        private Button? _activeNavBtn = null;
        private bool _pulseOn = true;
        private int _activityPulse = 0;

        // ── Palette ────────────────────────────────────────────────────────
        private static readonly Color Bg = Color.FromArgb(9, 12, 22);
        private static readonly Color SidebarBg = Color.FromArgb(12, 16, 30);
        private static readonly Color SidebarBorder = Color.FromArgb(24, 36, 64);
        private static readonly Color HeaderBg = Color.FromArgb(12, 16, 30);
        private static readonly Color HeaderBorder = Color.FromArgb(24, 36, 64);
        private static readonly Color ContentBg = Color.FromArgb(10, 13, 24);
        private static readonly Color CardBg = Color.FromArgb(14, 20, 38);
        private static readonly Color CardBgHover = Color.FromArgb(18, 26, 48);
        private static readonly Color CardBorder = Color.FromArgb(28, 42, 74);
        private static readonly Color NavIdle = Color.FromArgb(12, 16, 30);
        private static readonly Color NavHover = Color.FromArgb(19, 28, 52);
        private static readonly Color NavActive = Color.FromArgb(23, 36, 66);
        private static readonly Color NavActiveLine = Color.FromArgb(55, 115, 220);
        private static readonly Color AccentBlue = Color.FromArgb(55, 115, 220);
        private static readonly Color AccentCyan = Color.FromArgb(40, 190, 200);
        private static readonly Color AccentGreen = Color.FromArgb(35, 170, 95);
        private static readonly Color AccentOrange = Color.FromArgb(220, 145, 30);
        private static readonly Color AccentRed = Color.FromArgb(210, 55, 55);
        private static readonly Color TextPrimary = Color.FromArgb(218, 230, 255);
        private static readonly Color TextSecondary = Color.FromArgb(84, 108, 158);
        private static readonly Color TextMuted = Color.FromArgb(42, 58, 96);

        private record StatCard(Panel Panel, string Icon, string Title, string Status, Color Accent);
        private StatCard[] _statCards = null!;

        // ── Animation state ────────────────────────────────────────────────
        private int _animTick = 0;
        private float _headerGlowPhase = 0f;
        private bool _lockOpen = false;
        private float _lockOpenAngle = 0f;          // shackle opens slowly on welcome card

        private readonly Random _rng = new Random();
        private readonly (float X, float Y, float Speed, float Size)[] _particles;

        // ── Key cursor ─────────────────────────────────────────────────────
        private Cursor _keyCursor = null!;



        public DashboardForm(User user)
        {
            InitializeComponent();
            _currentUser = user;

            _statCards = new[]
            {
                new StatCard(pnlStatSecurity, "🔒", "Security",    "Active",  AccentGreen),
                new StatCard(pnlStatMessages, "💬", "Messages",    "Online",  AccentCyan),
                new StatCard(pnlStatCrypto,   "🔐", "Encryption",  "Enabled", AccentBlue),
                new StatCard(pnlStatAttack,   "⚔",  "Attack Mode", "Ready",   AccentOrange),
            };

            _particles = new (float, float, float, float)[22];
            for (int i = 0; i < _particles.Length; i++)
                _particles[i] = (_rng.Next(100, 1400), _rng.Next(0, 80),
                                 0.3f + (float)_rng.NextDouble() * 0.9f,
                                 1.2f + (float)_rng.NextDouble() * 2.8f);

            BuildKeyCursor();
            ApplyTheme();
            PopulateWelcomeCard();
            SetActiveButton(btnSendMessages);

            pnlScrollableContent.Resize += (s, e) => DoResponsiveLayout();
            this.Load += (s, e) => { DoResponsiveLayout(); UpdateLiveTime(); };

            // Apply key cursor everywhere
            ApplyKeyCursorToAll(this);
        }

        private void BuildKeyCursor()
        {
            // Draw a key into a 32×32 bitmap then create a cursor
            var bmp = new Bitmap(32, 32, PixelFormat.Format32bppArgb);
            using var g = Graphics.FromImage(bmp);
            g.Clear(Color.Transparent);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Key head (ring)
            using var ringPen = new Pen(Color.FromArgb(255, 55, 115, 220), 2.5f);
            using var ringFill = new SolidBrush(Color.FromArgb(180, 14, 20, 38));
            g.FillEllipse(ringFill, 1, 1, 15, 15);
            g.DrawEllipse(ringPen, 1, 1, 15, 15);

            // Inner hole
            using var holeBrush = new SolidBrush(Color.FromArgb(200, 9, 12, 22));
            g.FillEllipse(holeBrush, 5, 5, 7, 7);

            // Key shaft
            using var shaftPen = new Pen(Color.FromArgb(255, 55, 115, 220), 2.5f);
            g.DrawLine(shaftPen, 14, 9, 30, 9);

            // Key teeth
            g.DrawLine(shaftPen, 24, 9, 24, 14);
            g.DrawLine(shaftPen, 27, 9, 27, 13);
            g.DrawLine(shaftPen, 30, 9, 30, 12);

            // Glow highlight
            using var glowBrush = new SolidBrush(Color.FromArgb(80, 40, 190, 200));
            g.FillEllipse(glowBrush, 3, 3, 7, 7);

            _keyCursor = CreateCursorFromBitmap(bmp, new Point(2, 9));
        }

        private static Cursor CreateCursorFromBitmap(Bitmap bmp, Point hotspot)
        {
            // Use Win32 ICONINFO to bake a cursor from our bitmap
            try
            {
                var hIcon = bmp.GetHicon();
                ICONINFO info = new ICONINFO();
                GetIconInfo(hIcon, out info);
                info.xHotspot = hotspot.X;
                info.yHotspot = hotspot.Y;
                info.fIcon = false;
                var hCursor = CreateIconIndirect(ref info);
                DestroyIcon(hIcon);
                return new Cursor(hCursor);
            }
            catch
            {
                return Cursors.Cross;
            }
        }

        [DllImport("user32.dll")] static extern bool GetIconInfo(IntPtr hIcon, out ICONINFO pIconInfo);
        [DllImport("user32.dll")] static extern IntPtr CreateIconIndirect(ref ICONINFO icon);
        [DllImport("user32.dll")] static extern bool DestroyIcon(IntPtr handle);

        [StructLayout(LayoutKind.Sequential)]
        struct ICONINFO
        {
            public bool fIcon;
            public int xHotspot;
            public int yHotspot;
            public IntPtr hbmMask;
            public IntPtr hbmColor;
        }

        private void ApplyKeyCursorToAll(Control ctrl)
        {
            ctrl.Cursor = _keyCursor;
            foreach (Control child in ctrl.Controls)
                ApplyKeyCursorToAll(child);
        }

        private void DoResponsiveLayout()
        {
            int pad = 28;
            int avail = pnlScrollableContent.ClientSize.Width - pad * 2;
            if (avail < 100) return;

            pnlWelcomeCard.Width = avail;
            pnlWelcomeCard.Left = pad;
            pnlWelcomeCard.Top = 24;

            pnlStatsRow.Width = avail;
            pnlStatsRow.Left = pad;
            pnlStatsRow.Top = pnlWelcomeCard.Bottom + 18;

            int count = _statCards.Length;
            int gap = 16;
            int cw = (avail - gap * (count - 1)) / count;
            int ch = pnlStatsRow.Height - 4;
            for (int i = 0; i < count; i++)
            {
                var p = _statCards[i].Panel;
                p.Size = new Size(cw, ch);
                p.Location = new Point(i * (cw + gap), 0);
                p.Invalidate();
            }

            tableLayoutPanelContent.Width = avail;
            tableLayoutPanelContent.Left = pad;
            tableLayoutPanelContent.Top = pnlStatsRow.Bottom + 18;

            lblLiveTime.Left = pnlWelcomeCard.Width - lblLiveTime.Width - 30;

            pnlScrollableContent.AutoScrollMinSize =
                new Size(0, tableLayoutPanelContent.Bottom + 24);
        }

        private void clockTimer_Tick(object? sender, EventArgs e) => UpdateLiveTime();

        private void pulseTimer_Tick(object? sender, EventArgs e)
        {
            _animTick++;
            _headerGlowPhase = (_headerGlowPhase + 0.012f) % (float)(Math.PI * 2);

            // Slowly open lock shackle when cursor hovers welcome card
            if (_lockOpen && _lockOpenAngle < 90f) _lockOpenAngle = Math.Min(90f, _lockOpenAngle + 2.5f);
            if (!_lockOpen && _lockOpenAngle > 0f) _lockOpenAngle = Math.Max(0f, _lockOpenAngle - 2.5f);

            // Move particles
            for (int i = 0; i < _particles.Length; i++)
            {
                var (px, py, spd, sz) = _particles[i];
                px += spd;
                if (px > pnlHeader.Width + 10) px = -10;
                _particles[i] = (px, py, spd, sz);
            }

            pnlHeader.Invalidate();
            pnlLockIcon.Invalidate();

            if (_animTick % 25 == 0)
            {
                _pulseOn = !_pulseOn;
                _activityPulse = (_activityPulse + 1) % 3;
                pnlUserDot.Invalidate();
                lblStatus.ForeColor = _pulseOn
                    ? AccentGreen
                    : Color.FromArgb(60, AccentGreen.R, AccentGreen.G, AccentGreen.B);
            }
        }

        private void UpdateLiveTime()
        {
            var now = DateTime.Now;
            lblLiveTime.Text = now.ToString("HH:mm:ss");
            lblStatusClock.Text = $"·  {now:ddd dd MMM yyyy  HH:mm:ss}";
            if (pnlWelcomeCard.Width > 100)
                lblLiveTime.Left = pnlWelcomeCard.Width - lblLiveTime.Width - 30;
        }

        private void PopulateWelcomeCard()
        {
            lblWelcome.Text = $"Welcome back, {_currentUser.Username}";
            lblUserId.Text = $"User ID  ·  #{_currentUser.Id:D4}";
            lblSession.Text = $"Session started  ·  {DateTime.Now:HH:mm  dd MMM yyyy}";
        }

        private void SetActiveButton(Button btn)
        {
            if (_activeNavBtn != null)
            {
                _activeNavBtn.BackColor = NavIdle;
                _activeNavBtn.ForeColor = TextSecondary;
                _activeNavBtn.Invalidate();
            }
            _activeNavBtn = btn;
            btn.BackColor = NavActive;
            btn.ForeColor = TextPrimary;
            btn.Invalidate();
        }

        private void btnProfile_Click(object s, EventArgs e)
        { SetActiveButton(btnProfile); using var f = new ProfileForm(_currentUser); f.ShowDialog(); }

        private void btnSendMessages_Click(object s, EventArgs e)
        { SetActiveButton(btnSendMessages); using var f = new ChatForm(_currentUser); f.ShowDialog(); }

        private void btnCrypto_Click(object s, EventArgs e)
        { SetActiveButton(btnCrypto); using var f = new CryptoTestForm(_currentUser); f.ShowDialog(); }

        private void btnAttack_Click(object s, EventArgs e)
        { SetActiveButton(btnAttack); using var f = new AttackForm(); f.ShowDialog(); }

        private void btnReports_Click(object s, EventArgs e)
        { SetActiveButton(btnReports); using var f = new ReportsForm(); f.ShowDialog(this); }

        private void btnSteganography_Click(object s, EventArgs e)
        { SetActiveButton(btnSteganography); using var f = new SteganographySelectionForm(); f.ShowDialog(this); }

        private void btnLogout_Click(object s, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?", "Confirm Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void LoadFormInContent(Form form)
        {
            try
            {
                tableLayoutPanelContent.Controls.Clear();
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                var host = new Panel { Dock = DockStyle.Fill };
                host.Controls.Add(form);
                tableLayoutPanelContent.Controls.Add(host, 0, 0);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyTheme()
        {
            this.BackColor = Bg;

            pnlHeader.BackColor = HeaderBg;
            pnlHeader.Paint += PaintHeader;
            pnlLockIcon.BackColor = Color.Transparent;
            pnlLockIcon.Paint += PaintLockIcon;

            lblHeaderUser.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            lblHeaderUser.ForeColor = TextPrimary;
            lblHeaderUser.Text = _currentUser.Username;
            pnlUserDot.BackColor = Color.Transparent;
            pnlUserDot.Paint += PaintUserDot;

            pnlSidebar.BackColor = SidebarBg;
            pnlSidebar.Paint += PaintSidebar;
            lblNavSection.Font = new Font("Segoe UI", 8.5f, FontStyle.Bold);
            lblNavSection.ForeColor = TextMuted;

            string[] icons = { "👤", "💬", "🔐", "⚔", "📊", "🖼" };
            string[] texts = { "Profile", "Messages", "Encrypt / Decrypt", "Attack", "Reports", "EvilHide" };
            var navBtns = new[] { btnProfile, btnSendMessages, btnCrypto, btnAttack, btnReports, btnSteganography };
            for (int i = 0; i < navBtns.Length; i++) StyleNavButton(navBtns[i], icons[i], texts[i]);

            btnLogout.BackColor = Color.FromArgb(26, 10, 10);
            btnLogout.ForeColor = Color.FromArgb(195, 58, 58);
            btnLogout.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 14, 14);
            btnLogout.Cursor = _keyCursor;
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.Padding = new Padding(20, 0, 0, 0);
            btnLogout.Paint += (s, e) =>
            {
                using var b = new SolidBrush(Color.FromArgb(160, 48, 48));
                e.Graphics.FillRectangle(b, 0, 10, 4, btnLogout.Height - 20);
            };

            pnlContent.BackColor = ContentBg;
            pnlScrollableContent.BackColor = ContentBg;

            // Welcome card
            pnlWelcomeCard.BackColor = CardBg;
            pnlWelcomeCard.Paint += PaintWelcomeCard;
            pnlWelcomeCard.MouseEnter += (s, e) => { _lockOpen = true; };
            pnlWelcomeCard.MouseLeave += (s, e) => { _lockOpen = false; };
            lblWelcome.Font = new Font("Segoe UI", 22f, FontStyle.Bold);
            lblWelcome.ForeColor = TextPrimary;
            lblUserId.Font = new Font("Segoe UI", 11f);
            lblUserId.ForeColor = TextSecondary;
            lblSession.Font = new Font("Segoe UI", 11f);
            lblSession.ForeColor = TextSecondary;
            lblLiveTime.Font = new Font("Segoe UI", 26f, FontStyle.Bold);
            lblLiveTime.ForeColor = Color.FromArgb(38, 82, 168);

            pnlStatsRow.BackColor = ContentBg;
            foreach (var sc in _statCards) WireStatCard(sc);

            tableLayoutPanelContent.BackColor = ContentBg;

            pnlStatusBar.BackColor = HeaderBg;
            pnlStatusBar.Paint += (s, e) =>
            {
                using var p = new Pen(HeaderBorder, 1);
                e.Graphics.DrawLine(p, 0, 0, pnlStatusBar.Width, 0);
            };
            lblStatus.Font = new Font("Segoe UI", 9.5f);
            lblStatus.ForeColor = AccentGreen;
            lblStatus.Text = "●  Connected  ·  EvilCorp Server";
            lblStatusClock.Font = new Font("Segoe UI", 9.5f);
            lblStatusClock.ForeColor = TextSecondary;
        }

        private void StyleNavButton(Button btn, string icon, string label)
        {
            btn.BackColor = NavIdle;
            btn.ForeColor = TextSecondary;
            btn.Font = new Font("Segoe UI", 11f);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = NavHover;
            btn.Cursor = _keyCursor;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(18, 0, 0, 0);
            btn.Text = $"{icon}   {label}";

            btn.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                if (btn == _activeNavBtn)
                {
                    using var grad = new LinearGradientBrush(
                        new Point(0, 0), new Point(0, btn.Height),
                        NavActiveLine, Color.FromArgb(70, NavActiveLine));
                    g.FillRectangle(grad, 0, 8, 4, btn.Height - 16);

                    using var arrowBrush = new SolidBrush(Color.FromArgb(55, NavActiveLine));
                    g.FillPolygon(arrowBrush, new PointF[] {
                        new(btn.Width - 16, btn.Height / 2f - 6),
                        new(btn.Width -  8, btn.Height / 2f),
                        new(btn.Width - 16, btn.Height / 2f + 6),
                    });
                }
            };
        }

        private void WireStatCard(StatCard sc)
        {
            sc.Panel.BackColor = CardBg;
            sc.Panel.Cursor = _keyCursor;
            sc.Panel.MouseEnter += (s, e) => { sc.Panel.BackColor = CardBgHover; sc.Panel.Invalidate(); };
            sc.Panel.MouseLeave += (s, e) => { sc.Panel.BackColor = CardBg; sc.Panel.Invalidate(); };
            sc.Panel.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                int w = sc.Panel.Width, h = sc.Panel.Height;

                using var bpn = new Pen(CardBorder, 1);
                g.DrawRectangle(bpn, 0, 0, w - 1, h - 1);

                using var ab = new LinearGradientBrush(
                    new Point(0, 0), new Point(w, 0),
                    sc.Accent, Color.FromArgb(50, sc.Accent));
                g.FillRectangle(ab, 0, 0, w, 4);

                using var gbr = new SolidBrush(Color.FromArgb(14, sc.Accent.R, sc.Accent.G, sc.Accent.B));
                g.FillEllipse(gbr, w - 110, h - 110, 180, 180);

                using var iF = new Font("Segoe UI Emoji", 34f);
                g.DrawString(sc.Icon, iF, new SolidBrush(sc.Accent), new PointF(18, 18));

                using var tF = new Font("Segoe UI", 13f, FontStyle.Bold);
                g.DrawString(sc.Title, tF, new SolidBrush(TextPrimary), new PointF(18, h - 90));

                using var sF = new Font("Segoe UI", 10f, FontStyle.Bold);
                var ss = g.MeasureString(sc.Status, sF);
                var pr = new RectangleF(16, h - 42, ss.Width + 18, ss.Height + 8);
                using var pb2 = new SolidBrush(Color.FromArgb(40, sc.Accent.R, sc.Accent.G, sc.Accent.B));
                FillRoundedRect(g, pb2, pr, 7);
                using var ppb = new Pen(Color.FromArgb(80, sc.Accent.R, sc.Accent.G, sc.Accent.B), 1);
                g.DrawRectangle(ppb, pr.X, pr.Y, pr.Width - 1, pr.Height - 1);
                g.DrawString(sc.Status, sF, new SolidBrush(sc.Accent), new PointF(pr.X + 9, pr.Y + 4));
            };
        }

        private void PaintHeader(object? s, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int w = pnlHeader.Width, h = pnlHeader.Height;

            using var bgGrad = new LinearGradientBrush(new Point(0, 0), new Point(Math.Max(w, 1), 0),
                Color.FromArgb(22, AccentBlue), Color.FromArgb(0, AccentBlue));
            g.FillRectangle(bgGrad, 0, 0, w, h);

            foreach (var (px, py, spd, sz) in _particles)
            {
                if (px < 320) continue;
                int alpha = (int)(18 + 20 * (spd / 1.0f));
                using var pb = new SolidBrush(Color.FromArgb(Math.Min(alpha, 45), AccentCyan));
                g.FillEllipse(pb, px - sz / 2, py - sz / 2, sz, sz);
            }

            float pulse = (float)(0.5 + 0.5 * Math.Sin(_headerGlowPhase));
            int lineAlpha = (int)(40 + 35 * pulse);
            using var topLine = new LinearGradientBrush(new Point(0, 0), new Point(w * 2 / 3, 0),
                Color.FromArgb(lineAlpha, AccentCyan), Color.FromArgb(0, AccentCyan));
            g.FillRectangle(topLine, 0, 0, w * 2 / 3, 2);

            // EvilCorp title glow text
            using var glowFont = new Font("Segoe UI", 24f, FontStyle.Bold);
            using var glowBrush = new SolidBrush(Color.FromArgb((int)(18 + 18 * pulse), AccentBlue));
            for (int ox = -2; ox <= 2; ox++)
                for (int oy = -2; oy <= 2; oy++)
                    g.DrawString("EvilCorp", glowFont, glowBrush, new PointF(100 + ox, 18 + oy));

            using var pn = new Pen(HeaderBorder, 1);
            g.DrawLine(pn, 0, h - 1, w, h - 1);
        }

        private void PaintSidebar(object? s, PaintEventArgs e)
        {
            var g = e.Graphics;
            using var pn = new Pen(SidebarBorder, 1);
            g.DrawLine(pn, pnlSidebar.Width - 1, 0, pnlSidebar.Width - 1, pnlSidebar.Height);
            using var grad = new LinearGradientBrush(
                new Point(0, pnlSidebar.Height - 180), new Point(0, pnlSidebar.Height),
                Color.FromArgb(0, SidebarBg), Color.FromArgb(80, 5, 6, 14));
            g.FillRectangle(grad, 0, pnlSidebar.Height - 180, pnlSidebar.Width, 180);
        }

        private void PaintWelcomeCard(object? s, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int w = pnlWelcomeCard.Width, h = pnlWelcomeCard.Height;

            using var bpn = new Pen(CardBorder, 1);
            g.DrawRectangle(bpn, 0, 0, w - 1, h - 1);

            using var stripe = new LinearGradientBrush(new Point(0, 0), new Point(0, h),
                AccentBlue, Color.FromArgb(0, AccentBlue));
            g.FillRectangle(stripe, 0, 0, 5, h);

            using var dot = new SolidBrush(Color.FromArgb(8, AccentBlue));
            for (int x = 40; x < w; x += 34)
                for (int y = 14; y < h; y += 34)
                    g.FillEllipse(dot, x, y, 2, 2);

            using var glow = new SolidBrush(Color.FromArgb(7, AccentBlue));
            g.FillEllipse(glow, w - 240, -80, 340, 340);

            // Mini lock badge top-right of welcome card (shows lock open state)
            DrawWelcardLockBadge(g, w - 70, 20, 40);
        }

        private void DrawWelcardLockBadge(Graphics g, int bx, int by, int size)
        {
            float breath = (float)(0.5 + 0.5 * Math.Sin(_headerGlowPhase));
            int cx = bx + size / 2, cy = by + size / 2;

            using var outerGlow = new SolidBrush(Color.FromArgb((int)(10 + 15 * breath), AccentBlue));
            g.FillEllipse(outerGlow, bx - 4, by - 4, size + 8, size + 8);

            using var ring = new Pen(Color.FromArgb((int)(60 + 80 * breath), AccentCyan), 1.5f);
            g.DrawEllipse(ring, bx + 1, by + 1, size - 2, size - 2);

            // Shackle
            using var shackle = new Pen(Color.FromArgb((int)(160 + 95 * breath), 130, 175, 255), 2.5f)
            { StartCap = LineCap.Round, EndCap = LineCap.Round };
            float open = _lockOpenAngle;
            g.DrawArc(shackle, cx - 8, cy - 14, 16, 12, 180 + open, 180 - open);

            // Body
            using var bodyFill = new SolidBrush(Color.FromArgb(80, AccentBlue));
            FillRoundedRect(g, bodyFill, new RectangleF(cx - 9, cy - 2, 18, 14), 3);
            using var bodyBorder = new Pen(Color.FromArgb((int)(100 + 80 * breath), AccentCyan), 1f);
            DrawRoundedRect(g, bodyBorder, new RectangleF(cx - 9, cy - 2, 18, 14), 3);

            // Keyhole
            using var hole = new SolidBrush(Color.FromArgb(10, 14, 32));
            g.FillEllipse(hole, cx - 3, cy + 1, 6, 5);
            g.FillRectangle(hole, cx - 2, cy + 5, 4, 4);
        }

        private void PaintUserDot(object? s, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int w = pnlUserDot.Width, h = pnlUserDot.Height;
            using var glow = new SolidBrush(Color.FromArgb(_pulseOn ? 38 : 10, AccentGreen));
            g.FillEllipse(glow, -3, -3, w + 6, h + 6);
            using var dot = new SolidBrush(_pulseOn ? AccentGreen : Color.FromArgb(150, AccentGreen));
            g.FillEllipse(dot, 0, 0, w - 1, h - 1);
        }

        private void PaintLockIcon(object? s, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int w = pnlLockIcon.Width, h = pnlLockIcon.Height;
            int cx = w / 2, cy = h / 2;

            float breath = (float)(0.5 + 0.5 * Math.Sin(_headerGlowPhase));

            using var halo = new SolidBrush(Color.FromArgb((int)(18 + 28 * breath), AccentBlue));
            g.FillEllipse(halo, 2, 2, w - 4, h - 4);

            using var midFill = new SolidBrush(Color.FromArgb((int)(22 + 38 * breath), AccentCyan));
            g.FillEllipse(midFill, 8, 8, w - 16, h - 16);

            using var ringPen = new Pen(Color.FromArgb((int)(90 + 165 * breath), AccentCyan), 2f);
            g.DrawEllipse(ringPen, 9, 9, w - 18, h - 18);

            using var shackle = new Pen(Color.FromArgb((int)(180 + 75 * breath), 130, 175, 255), 3.5f)
            { StartCap = LineCap.Round, EndCap = LineCap.Round };
            g.DrawArc(shackle, cx - 11, cy - 17, 22, 20, 180, 180);

            using var bodyBg = new SolidBrush(Color.FromArgb(24, 36, 68));
            FillRoundedRect(g, bodyBg, new RectangleF(cx - 14, cy - 1, 28, 22), 5);
            using var bodyFill = new SolidBrush(Color.FromArgb(90, 150, 255));
            FillRoundedRect(g, bodyFill, new RectangleF(cx - 14, cy - 1, 28, 22), 5);

            using var hole = new SolidBrush(Color.FromArgb(10, 16, 40));
            g.FillEllipse(hole, cx - 4, cy + 3, 8, 7);
            g.FillRectangle(hole, cx - 3, cy + 8, 6, 6);
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

        private static void DrawRoundedRect(Graphics g, Pen p, RectangleF r, float radius)
        {
            float d = radius * 2;
            using var path = new GraphicsPath();
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            g.DrawPath(p, path);
        }
    }
}
