using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace EvilCorp
{
    public partial class ProfileForm : Form
    {
        private User _user;
        private bool _editMode = false;
        private bool _passwordVisible = false;
        private string _currentPasswordPlain = string.Empty;

        private static readonly Color BgDark = Color.FromArgb(13, 18, 32);
        private static readonly Color BgCard = Color.FromArgb(20, 28, 48);
        private static readonly Color BgField = Color.FromArgb(28, 38, 60);
        private static readonly Color AccentBlue = Color.FromArgb(55, 115, 220);
        private static readonly Color AccentGreen = Color.FromArgb(35, 170, 95);
        private static readonly Color AccentRed = Color.FromArgb(210, 60, 60);
        private static readonly Color AccentOrange = Color.FromArgb(220, 140, 30);
        private static readonly Color TextPrimary = Color.FromArgb(225, 235, 255);
        private static readonly Color TextSecondary = Color.FromArgb(110, 135, 180);
        private static readonly Color SeparatorColor = Color.FromArgb(38, 52, 80);

        public ProfileForm(User user)
        {
            InitializeComponent();
            _user = user;
            ApplyTheme();
            LoadProfile();
        }

        // ── Load / Refresh ──────────────────────────────────────────────────

        private void LoadProfile()
        {
            lblUsernameValue.Text = _user.Username;
            lblUserIdValue.Text = $"#{_user.Id:D4}";

            try { _currentPasswordPlain = DatabaseManager.GetPasswordFromDb(_user.Id); }
            catch { _currentPasswordPlain = string.Empty; }

            _passwordVisible = false;
            UpdatePasswordDisplay();
            SetEditMode(false);
        }

        private void UpdatePasswordDisplay()
        {
            if (_passwordVisible && !string.IsNullOrEmpty(_currentPasswordPlain))
            {
                lblPasswordValue.Text = _currentPasswordPlain;
                btnTogglePassword.Text = "🙈  Hide";
            }
            else
            {
                lblPasswordValue.Text = string.IsNullOrEmpty(_currentPasswordPlain)
                    ? "(unavailable)" : new string('•', Math.Min(_currentPasswordPlain.Length, 14));
                btnTogglePassword.Text = "👁  Show";
            }
        }

        // ── Edit Mode ───────────────────────────────────────────────────────

        private void SetEditMode(bool editing)
        {
            _editMode = editing;
            pnlView.Visible = !editing;
            pnlEdit.Visible = editing;

            if (editing)
            {
                txtEditUsername.Text = _user.Username;
                txtCurrentPassword.Text = string.Empty;
                txtEditPassword.Text = string.Empty;
                txtEditConfirm.Text = string.Empty;
                lblEditFeedback.Text = string.Empty;
                UpdateStrengthBar(string.Empty);
                txtEditUsername.Focus();
            }

            btnEditToggle.Text = editing ? "✕  Cancel" : "✏  Edit Profile";
            btnEditToggle.BackColor = editing ? Color.FromArgb(65, 30, 30) : AccentBlue;
        }

        // ── Handlers ────────────────────────────────────────────────────────

        private void btnEditToggle_Click(object sender, EventArgs e) => SetEditMode(!_editMode);
        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void btnTogglePassword_Click(object sender, EventArgs e)
        {
            _passwordVisible = !_passwordVisible;
            UpdatePasswordDisplay();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lblEditFeedback.Text = string.Empty;

            string newUsername = txtEditUsername.Text.Trim();
            string currentPw = txtCurrentPassword.Text;
            string newPw = txtEditPassword.Text;
            string confirmPw = txtEditConfirm.Text;

            // Validate username
            if (string.IsNullOrWhiteSpace(newUsername))
            { ShowFeedback("Username cannot be empty.", false); return; }
            if (newUsername.Length < 3)
            { ShowFeedback("Username must be at least 3 characters.", false); return; }
            if (newUsername.Length > 32)
            { ShowFeedback("Username cannot exceed 32 characters.", false); return; }

            // Validate new password if provided
            bool changingPassword = !string.IsNullOrEmpty(newPw);
            if (changingPassword)
            {
                if (newPw.Length < 6)
                { ShowFeedback("New password must be at least 6 characters.", false); return; }
                if (newPw != confirmPw)
                { ShowFeedback("Passwords do not match.", false); return; }
            }

            // Require current password to authorise any change
            if (string.IsNullOrEmpty(currentPw))
            { ShowFeedback("Enter your current password to save changes.", false); return; }

            if (DatabaseManager.AuthenticateUser(_user.Username, currentPw) == null)
            { ShowFeedback("Current password is incorrect.", false); txtCurrentPassword.Focus(); return; }

            // Commit
            bool ok = DatabaseManager.UpdateUser(
                _user.Id, newUsername,
                changingPassword ? newPw : null,
                out string dbError);

            if (!ok) { ShowFeedback(dbError, false); return; }

            // Refresh local state
            var updated = DatabaseManager.GetAllUsers().FirstOrDefault(u => u.Id == _user.Id);
            if (updated != null) _user = updated;
            if (changingPassword) _currentPasswordPlain = newPw;

            LoadProfile();
            ShowFeedback("✔  Profile updated successfully!", true);
        }

        private void txtEditPassword_TextChanged(object sender, EventArgs e)
            => UpdateStrengthBar(txtEditPassword.Text);

        // ── Password strength ────────────────────────────────────────────────

        private void UpdateStrengthBar(string pwd)
        {
            int score = 0;
            if (pwd.Length >= 6) score++;
            if (pwd.Length >= 10) score++;
            if (pwd.Any(char.IsUpper)) score++;
            if (pwd.Any(char.IsDigit)) score++;
            if (pwd.Any(c => !char.IsLetterOrDigit(c))) score++;

            if (pwd.Length == 0)
            {
                lblStrength.Text = "";
                strengthBar.Value = 0;
                return;
            }

            switch (score)
            {
                case 0:
                case 1:
                    lblStrength.Text = "Weak";
                    lblStrength.ForeColor = AccentRed;
                    strengthBar.Value = 20;
                    strengthBar.ForeColor = AccentRed;
                    break;
                case 2:
                case 3:
                    lblStrength.Text = "Fair";
                    lblStrength.ForeColor = AccentOrange;
                    strengthBar.Value = 60;
                    strengthBar.ForeColor = AccentOrange;
                    break;
                default:
                    lblStrength.Text = "Strong";
                    lblStrength.ForeColor = AccentGreen;
                    strengthBar.Value = 100;
                    strengthBar.ForeColor = AccentGreen;
                    break;
            }
        }

        // ── Helpers ──────────────────────────────────────────────────────────

        private void ShowFeedback(string msg, bool success)
        {
            lblEditFeedback.ForeColor = success ? AccentGreen : AccentRed;
            lblEditFeedback.Text = msg;
        }

        // ── Theme ─────────────────────────────────────────────────────────────

        private void ApplyTheme()
        {
            this.BackColor = BgDark;
            pnlHeader.BackColor = BgCard;
            pnlViewCard.BackColor = BgCard;
            pnlEditCard.BackColor = BgCard;

            lblTitle.ForeColor = TextPrimary;
            lblTitle.Font = new Font("Segoe UI", 16f, FontStyle.Bold);
            lblSubtitle.ForeColor = TextSecondary;
            lblSubtitle.Font = new Font("Segoe UI", 9.5f);

            // View captions
            foreach (var l in new[] { lblUsernameCaption, lblUserIdCaption, lblPasswordCaption })
            {
                l.ForeColor = TextSecondary;
                l.Font = new Font("Segoe UI", 8.5f, FontStyle.Regular);
            }
            // View values
            foreach (var l in new[] { lblUsernameValue, lblUserIdValue, lblPasswordValue })
            {
                l.ForeColor = TextPrimary;
                l.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
            }

            StyleButton(btnTogglePassword, Color.FromArgb(32, 44, 68), TextSecondary, 9f);
            StyleButton(btnEditToggle, AccentBlue, Color.White, 10.5f);
            StyleButton(btnClose, Color.FromArgb(32, 44, 68), TextSecondary, 10f);
            StyleButton(btnSave, AccentGreen, Color.White, 10.5f);
            StyleButton(btnCancelEdit, Color.FromArgb(65, 30, 30), Color.FromArgb(255, 140, 140), 9.5f);

            // Edit labels
            foreach (var l in new[] { lblEditUsernameCaption, lblCurrentPwCaption,
                                       lblEditPasswordCaption, lblEditConfirmCaption })
            {
                l.ForeColor = TextSecondary;
                l.Font = new Font("Segoe UI", 8.5f);
            }

            // Edit textboxes
            foreach (var tb in new[] { txtEditUsername, txtCurrentPassword, txtEditPassword, txtEditConfirm })
            {
                tb.BackColor = BgField;
                tb.ForeColor = TextPrimary;
                tb.Font = new Font("Segoe UI", 11f);
                tb.BorderStyle = BorderStyle.FixedSingle;
            }

            lblStrength.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblEditFeedback.Font = new Font("Segoe UI", 9.5f);
            strengthBar.BackColor = BgField;
        }

        private static void StyleButton(Button btn, Color back, Color fore, float fontSize = 9.5f)
        {
            btn.BackColor = back;
            btn.ForeColor = fore;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = ControlPaint.Light(back, 0.15f);
            btn.Font = new Font("Segoe UI", fontSize, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
        }
    }
}