using System;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace EvilCorp
{
    public partial class RegistrationForm : Form
    {
        public string? CreatedUsername { get; private set; }

        private static readonly Color Bg = Color.FromArgb(9, 12, 22);
        private static readonly Color CardBg = Color.FromArgb(15, 20, 38);
        private static readonly Color CardBorder = Color.FromArgb(35, 50, 85);
        private static readonly Color FieldBg = Color.FromArgb(22, 30, 54);
        private static readonly Color FieldFocus = Color.FromArgb(28, 40, 68);
        private static readonly Color AccentBlue = Color.FromArgb(55, 115, 220);
        private static readonly Color AccentCyan = Color.FromArgb(40, 190, 200);
        private static readonly Color AccentGreen = Color.FromArgb(35, 170, 95);
        private static readonly Color AccentOrange = Color.FromArgb(220, 145, 30);
        private static readonly Color AccentRed = Color.FromArgb(210, 60, 60);
        private static readonly Color TextPrimary = Color.FromArgb(220, 232, 255);
        private static readonly Color TextSecondary = Color.FromArgb(90, 115, 165);
        private static readonly Color TextMuted = Color.FromArgb(55, 72, 110);

        private const string UpperChars = "ABCDEFGHJKLMNPQRSTUVWXYZ";
        private const string LowerChars = "abcdefghjkmnpqrstuvwxyz";
        private const string DigitChars = "23456789";
        private const string SpecialChars = "!@#$%^&*-_=+?";

        private bool _passwordVisible = false;

        public RegistrationForm()
        {
            InitializeComponent();
            ApplyTheme();
            WireEvents();
            UpdateRequirements(string.Empty);
        }

        // ── Requirement checks ────────────────────────────────────────────
        private bool MeetsLength(string p) => p.Length >= 8;
        private bool MeetsUpper(string p) => p.Any(char.IsUpper);
        private bool MeetsDigit(string p) => p.Any(char.IsDigit);
        private bool MeetsSpecial(string p) => p.Any(c => SpecialChars.Contains(c));
        private int MetCount(string p) =>
            (MeetsLength(p) ? 1 : 0) + (MeetsUpper(p) ? 1 : 0) +
            (MeetsDigit(p) ? 1 : 0) + (MeetsSpecial(p) ? 1 : 0);

        private void UpdateStrengthUI(string pwd)
        {
            UpdateRequirements(pwd);
            if (pwd.Length == 0) { lblStrength.Text = ""; strengthBar.Value = 0; return; }

            int met = MetCount(pwd);
            strengthBar.Value = met * 25;

            switch (met)
            {
                case 1:
                    lblStrength.Text = "Weak"; lblStrength.ForeColor = AccentRed;
                    strengthBar.ForeColor = AccentRed; break;
                case 2:
                    lblStrength.Text = "Fair"; lblStrength.ForeColor = AccentOrange;
                    strengthBar.ForeColor = AccentOrange; break;
                case 3:
                    lblStrength.Text = "Almost"; lblStrength.ForeColor = AccentCyan;
                    strengthBar.ForeColor = AccentCyan; break;
                case 4:
                    lblStrength.Text = pwd.Length >= 12 ? "Excellent ✔" : "Strong ✔";
                    lblStrength.ForeColor = AccentGreen;
                    strengthBar.ForeColor = AccentGreen;
                    strengthBar.Value = 100; break;
                default:
                    lblStrength.Text = "Too short"; lblStrength.ForeColor = AccentRed;
                    strengthBar.ForeColor = AccentRed; break;
            }
        }

        private void UpdateRequirements(string pwd)
        {
            SetReq(lblReqLength, MeetsLength(pwd), "8+ characters");
            SetReq(lblReqUpper, MeetsUpper(pwd), "One uppercase letter");
            SetReq(lblReqDigit, MeetsDigit(pwd), "One number");
            SetReq(lblReqSpecial, MeetsSpecial(pwd), "One special character");
        }

        private void SetReq(Label lbl, bool met, string text)
        {
            lbl.Text = (met ? "✔  " : "✗  ") + text;
            lbl.ForeColor = met ? AccentGreen : AccentRed;
        }

        // ── Generator ─────────────────────────────────────────────────────
        private string GenerateStrongPassword()
        {
            var rng = RandomNumberGenerator.Create();
            var sb = new StringBuilder();
            sb.Append(Pick(rng, UpperChars));
            sb.Append(Pick(rng, LowerChars));
            sb.Append(Pick(rng, DigitChars));
            sb.Append(Pick(rng, SpecialChars));
            string all = UpperChars + LowerChars + DigitChars + SpecialChars;
            for (int i = 0; i < 10; i++) sb.Append(Pick(rng, all));
            char[] arr = sb.ToString().ToCharArray();
            for (int i = arr.Length - 1; i > 0; i--)
            { int j = RandInt(rng, i + 1); (arr[i], arr[j]) = (arr[j], arr[i]); }
            return new string(arr);
        }
        private static char Pick(RandomNumberGenerator r, string s) => s[RandInt(r, s.Length)];
        private static int RandInt(RandomNumberGenerator r, int max)
        { byte[] b = new byte[4]; r.GetBytes(b); return (int)(BitConverter.ToUInt32(b, 0) % (uint)max); }

        // ── Handlers ──────────────────────────────────────────────────────
        private void btnRegister_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            string u = txtUsername.Text.Trim(), p = txtPassword.Text, c = txtConfirm.Text;
            if (string.IsNullOrWhiteSpace(u)) { ShowError("Username is required."); return; }
            if (u.Length < 3) { ShowError("Username must be at least 3 characters."); return; }
            if (!MeetsLength(p)) { ShowError("Password must be at least 8 characters."); return; }
            if (!MeetsUpper(p)) { ShowError("Password needs at least one uppercase letter."); return; }
            if (!MeetsDigit(p)) { ShowError("Password needs at least one number."); return; }
            if (!MeetsSpecial(p)) { ShowError("Password needs at least one special character."); return; }
            if (p != c) { ShowError("Passwords do not match."); return; }
            if (!DatabaseManager.CreateUser(u, p, out string err)) { ShowError(err); return; }
            CreatedUsername = u;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string gen = GenerateStrongPassword();
            txtPassword.Text = txtConfirm.Text = gen;
            _passwordVisible = true;
            txtPassword.PasswordChar = txtConfirm.PasswordChar = '\0';
            btnTogglePassword.Text = "🙈";
            btnTogglePassword.ForeColor = AccentCyan;
            UpdateStrengthUI(gen);
        }

        private void btnTogglePassword_Click(object sender, EventArgs e)
        {
            _passwordVisible = !_passwordVisible;
            txtPassword.PasswordChar = txtConfirm.PasswordChar = _passwordVisible ? '\0' : '●';
            btnTogglePassword.Text = _passwordVisible ? "🙈" : "👁";
            btnTogglePassword.ForeColor = _passwordVisible ? AccentCyan : TextSecondary;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e) => UpdateStrengthUI(txtPassword.Text);
        private void ShowError(string m) { lblError.ForeColor = AccentRed; lblError.Text = "⚠  " + m; }

        private void WireEvents()
        {
            foreach (var tb in new[] { txtUsername, txtPassword, txtConfirm })
            {
                tb.Enter += (s, _) => ((TextBox)s!).BackColor = FieldFocus;
                tb.Leave += (s, _) => ((TextBox)s!).BackColor = FieldBg;
            }
            txtUsername.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; txtPassword.Focus(); } };
            txtPassword.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; txtConfirm.Focus(); } };
            txtConfirm.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; btnRegister_Click(s!, e); } };
        }

        // ── Theme ─────────────────────────────────────────────────────────
        private void ApplyTheme()
        {
            this.BackColor = Bg;
            pnlOuter.BackColor = Bg;
            pnlCard.BackColor = CardBg;
            pnlCard.Paint += (s, e) =>
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
            };

            lblTitle.ForeColor = TextPrimary;
            lblTitle.Font = new Font("Segoe UI", 22f, FontStyle.Bold);
            lblSubtitle.ForeColor = TextSecondary;
            lblSubtitle.Font = new Font("Segoe UI", 11f);

            foreach (var l in new[] { lblUsernameCaption, lblPasswordCaption, lblConfirmCaption })
            { l.ForeColor = TextSecondary; l.Font = new Font("Segoe UI", 9f, FontStyle.Bold); }

            foreach (var tb in new[] { txtUsername, txtPassword, txtConfirm })
            { tb.BackColor = FieldBg; tb.ForeColor = TextPrimary; tb.Font = new Font("Segoe UI", 12.5f); tb.BorderStyle = BorderStyle.FixedSingle; }

            btnTogglePassword.BackColor = FieldBg;
            btnTogglePassword.ForeColor = TextSecondary;
            btnTogglePassword.FlatStyle = FlatStyle.Flat;
            btnTogglePassword.FlatAppearance.BorderSize = 0;
            btnTogglePassword.Font = new Font("Segoe UI", 13f);
            btnTogglePassword.Cursor = Cursors.Hand;

            btnGenerate.BackColor = Color.FromArgb(16, 50, 80);
            btnGenerate.ForeColor = AccentCyan;
            btnGenerate.FlatStyle = FlatStyle.Flat;
            btnGenerate.FlatAppearance.BorderColor = Color.FromArgb(30, 95, 135);
            btnGenerate.FlatAppearance.BorderSize = 1;
            btnGenerate.FlatAppearance.MouseOverBackColor = Color.FromArgb(22, 62, 98);
            btnGenerate.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            btnGenerate.Cursor = Cursors.Hand;

            strengthBar.BackColor = Color.FromArgb(18, 26, 48);
            lblStrength.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);

            foreach (var l in new[] { lblReqLength, lblReqUpper, lblReqDigit, lblReqSpecial })
                l.Font = new Font("Segoe UI", 9.5f);
            lblReqNote.ForeColor = TextMuted;
            lblReqNote.Font = new Font("Segoe UI", 8.5f, FontStyle.Italic);

            btnRegister.BackColor = AccentBlue;
            btnRegister.ForeColor = Color.Transparent; 
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnRegister.Cursor = Cursors.Hand;
            btnRegister.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using var grad = new LinearGradientBrush(
                    new Point(0, 0), new Point(btnRegister.Width, 0),
                    Color.FromArgb(48, 105, 215), Color.FromArgb(78, 148, 245));
                g.FillRectangle(grad, 0, 0, btnRegister.Width, btnRegister.Height);
                using var font = new Font("Segoe UI", 13f, FontStyle.Bold);
                using var brush = new SolidBrush(Color.White);
                var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                g.DrawString(btnRegister.Text, font, brush,
                    new RectangleF(0, 0, btnRegister.Width, btnRegister.Height), sf);
            };

            lblError.Font = new Font("Segoe UI", 10f);
        }
    }
}