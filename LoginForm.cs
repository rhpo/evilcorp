using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace EvilCorp
{
    public partial class LoginForm : Form
    {
        public User? AuthenticatedUser { get; private set; }

        private static readonly Color Bg = Color.FromArgb(9, 12, 22);
        private static readonly Color CardBg = Color.FromArgb(15, 20, 38);
        private static readonly Color CardBorder = Color.FromArgb(35, 50, 85);
        private static readonly Color FieldBg = Color.FromArgb(22, 30, 54);
        private static readonly Color FieldFocus = Color.FromArgb(28, 40, 68);
        private static readonly Color AccentBlue = Color.FromArgb(55, 115, 220);
        private static readonly Color AccentCyan = Color.FromArgb(40, 190, 200);
        private static readonly Color AccentGreen = Color.FromArgb(35, 170, 95);
        private static readonly Color AccentRed = Color.FromArgb(210, 60, 60);
        private static readonly Color TextPrimary = Color.FromArgb(220, 232, 255);
        private static readonly Color TextSecondary = Color.FromArgb(90, 115, 165);
        private static readonly Color TextMuted = Color.FromArgb(55, 72, 110);

        private bool _passwordVisible = false;

        public LoginForm()
        {
            InitializeComponent();
            ApplyTheme();
            WireEvents();
        }

        // ── Handlers ──────────────────────────────────────────────────────

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ClearMessage();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ShowMessage("Please enter both username and password.", false);
                return;
            }

            btnLogin.Enabled = false;
            btnLogin.Text = "Authenticating…";
            Application.DoEvents();

            User? user = DatabaseManager.AuthenticateUser(username, password);

            if (user != null)
            {
                AuthenticatedUser = user;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                ShowMessage("Invalid username or password.", false);
                txtPassword.Clear();
                txtPassword.Focus();
                btnLogin.Enabled = true;
                btnLogin.Text = "Sign In";
                btnLogin.Invalidate();
            }
        }

        private void btnTogglePassword_Click(object sender, EventArgs e)
        {
            _passwordVisible = !_passwordVisible;
            txtPassword.PasswordChar = _passwordVisible ? '\0' : '●';
            btnTogglePassword.Text = _passwordVisible ? "🙈" : "👁";
            btnTogglePassword.ForeColor = _passwordVisible ? AccentCyan : TextSecondary;
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            using (var reg = new RegistrationForm())
            {
                if (reg.ShowDialog() == DialogResult.OK)
                {
                    txtUsername.Text = reg.CreatedUsername ?? string.Empty;
                    ShowMessage("Account created — you can sign in now.", true);
                }
            }
        }

        private void ShowMessage(string msg, bool success)
        {
            lblMessage.ForeColor = success ? AccentGreen : AccentRed;
            lblMessage.Text = (success ? "✔  " : "⚠  ") + msg;
        }

        private void ClearMessage() => lblMessage.Text = string.Empty;

        private void WireEvents()
        {
            txtUsername.Enter += (s, _) => txtUsername.BackColor = FieldFocus;
            txtUsername.Leave += (s, _) => txtUsername.BackColor = FieldBg;
            txtPassword.Enter += (s, _) => txtPassword.BackColor = FieldFocus;
            txtPassword.Leave += (s, _) => txtPassword.BackColor = FieldBg;
            txtUsername.KeyDown += (s, e) =>
            { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; txtPassword.Focus(); } };
            txtPassword.KeyDown += (s, e) =>
            { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; btnLogin_Click(s!, e); } };
        }

        // ── Theme ─────────────────────────────────────────────────────────

        private void ApplyTheme()
        {
            this.BackColor = Bg;
            pnlOuter.BackColor = Bg;
            pnlCard.BackColor = CardBg;
            pnlCard.Paint += PaintCard;

            pnlLockIcon.BackColor = Color.Transparent;
            pnlLockIcon.Paint += PaintLockIcon;
            lblAppName.ForeColor = TextPrimary;
            lblAppName.Font = new Font("Segoe UI", 22f, FontStyle.Bold);

            lblTagline.ForeColor = TextSecondary;
            lblTagline.Font = new Font("Segoe UI", 11f);

            lblDividerLine.BackColor = CardBorder;

            foreach (var l in new[] { lblUsernameCaption, lblPasswordCaption })
            {
                l.ForeColor = TextSecondary;
                l.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            }

            foreach (var tb in new[] { txtUsername, txtPassword })
            {
                tb.BackColor = FieldBg;
                tb.ForeColor = TextPrimary;
                tb.Font = new Font("Segoe UI", 12.5f);
                tb.BorderStyle = BorderStyle.FixedSingle;
            }

            btnTogglePassword.BackColor = FieldBg;
            btnTogglePassword.ForeColor = TextSecondary;
            btnTogglePassword.FlatStyle = FlatStyle.Flat;
            btnTogglePassword.FlatAppearance.BorderSize = 0;
            btnTogglePassword.Font = new Font("Segoe UI", 13f);
            btnTogglePassword.Cursor = Cursors.Hand;

            lblMessage.Font = new Font("Segoe UI", 10f);
            lblMessage.ForeColor = AccentRed;

            btnLogin.ForeColor = Color.Transparent;
            btnLogin.BackColor = AccentBlue;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.Paint += PaintLoginButton;

            lblOrDivider.ForeColor = TextMuted;
            lblOrDivider.Font = new Font("Segoe UI", 9.5f);

            btnCreateAccount.BackColor = Color.FromArgb(18, 26, 50);
            btnCreateAccount.ForeColor = AccentCyan;
            btnCreateAccount.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            btnCreateAccount.FlatStyle = FlatStyle.Flat;
            btnCreateAccount.FlatAppearance.BorderColor = Color.FromArgb(35, 80, 130);
            btnCreateAccount.FlatAppearance.BorderSize = 1;
            btnCreateAccount.FlatAppearance.MouseOverBackColor = Color.FromArgb(22, 34, 62);
            btnCreateAccount.Cursor = Cursors.Hand;

            lblFooter.ForeColor = TextMuted;
            lblFooter.Font = new Font("Segoe UI", 8.5f);
        }

        // ── Custom painting ───────────────────────────────────────────────

        private void PaintCard(object? sender, System.Windows.Forms.PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using var accent = new LinearGradientBrush(
                new Point(0, 0), new Point(pnlCard.Width, 0),
                Color.FromArgb(0, AccentBlue), AccentBlue);
            accent.SetBlendTriangularShape(0.5f);
            g.FillRectangle(accent, 0, 0, pnlCard.Width, 3);

            using var pen = new Pen(CardBorder, 1);
            g.DrawRectangle(pen, 0, 0, pnlCard.Width - 1, pnlCard.Height - 1);
        }

        private void PaintLockIcon(object? sender, System.Windows.Forms.PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int cx = pnlLockIcon.Width / 2;
            int cy = pnlLockIcon.Height / 2;

            // Outer glow
            using var glow1 = new SolidBrush(Color.FromArgb(18, 55, 115, 220));
            g.FillEllipse(glow1, cx - 58, cy - 58, 116, 116);
            using var glow2 = new SolidBrush(Color.FromArgb(30, 55, 115, 220));
            g.FillEllipse(glow2, cx - 44, cy - 44, 88, 88);

            // Inner circle
            using var inner = new SolidBrush(Color.FromArgb(26, 36, 66));
            g.FillEllipse(inner, cx - 32, cy - 32, 64, 64);
            using var ring = new Pen(Color.FromArgb(58, 118, 228), 2f);
            g.DrawEllipse(ring, cx - 32, cy - 32, 64, 64);

            // Shackle
            using var shackle = new Pen(Color.FromArgb(78, 148, 242), 4f);
            shackle.StartCap = LineCap.Round;
            shackle.EndCap = LineCap.Round;
            g.DrawArc(shackle, cx - 12, cy - 24, 24, 22, 180, 180);

            // Body
            var body = new RectangleF(cx - 15, cy - 5, 30, 24);
            using var bodyBrush = new SolidBrush(Color.FromArgb(62, 128, 238));
            FillRoundedRect(g, bodyBrush, body, 5);

            // Keyhole
            using var hole = new SolidBrush(Color.FromArgb(18, 25, 50));
            g.FillEllipse(hole, cx - 5, cy + 1, 10, 10);
            g.FillRectangle(hole, cx - 3, cy + 9, 6, 7);
        }

        private void PaintLoginButton(object? sender, System.Windows.Forms.PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Color c1 = btnLogin.Enabled ? Color.FromArgb(48, 105, 215) : Color.FromArgb(40, 55, 90);
            Color c2 = btnLogin.Enabled ? Color.FromArgb(78, 148, 245) : Color.FromArgb(50, 65, 100);

            using var grad = new LinearGradientBrush(
                new Point(0, 0), new Point(btnLogin.Width, 0), c1, c2);
            g.FillRectangle(grad, 0, 0, btnLogin.Width, btnLogin.Height);

            using var font = new Font("Segoe UI", 13f, FontStyle.Bold);
            using var brush = new SolidBrush(Color.White);
            var sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            g.DrawString(btnLogin.Text, font, brush,
                new RectangleF(0, 0, btnLogin.Width, btnLogin.Height), sf);
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