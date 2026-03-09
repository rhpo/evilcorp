using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvilCorp
{
    public partial class DictionaryAttackForm : Form
    {
        private List<User> _users = new();
        private CancellationTokenSource _cts;

        private bool _defenseActive = false;
        private int _maxFailedAttempts = 3;
        private int _failedAttemptCount = 0;
        private bool _accountLocked = false;

        private static readonly Color Bg = Color.FromArgb(7, 10, 20);
        private static readonly Color CardBg = Color.FromArgb(12, 17, 34);
        private static readonly Color CardBorder = Color.FromArgb(32, 48, 85);
        private static readonly Color AccentGreen = Color.FromArgb(35, 200, 100);
        private static readonly Color AccentRed = Color.FromArgb(220, 55, 55);
        private static readonly Color AccentOrange = Color.FromArgb(230, 150, 30);
        private static readonly Color AccentYellow = Color.FromArgb(240, 210, 40);
        private static readonly Color AccentCyan = Color.FromArgb(40, 200, 220);
        private static readonly Color TextPrimary = Color.FromArgb(220, 232, 255);
        private static readonly Color TextSecondary = Color.FromArgb(80, 105, 160);

        public DictionaryAttackForm()
        {
            InitializeComponent();
            ApplyTheme();
            LoadUsers();
        }

        private void ApplyTheme()
        {
            this.BackColor = Bg;

            pnlHeader.BackColor = Color.FromArgb(9, 12, 25);
            pnlHeader.Paint += PaintHeader;

            pnlCard.BackColor = CardBg;
            pnlCard.Paint += PaintCard;

            StyleSectionLabel(lblTargetLbl, "01  |  TARGET USER");
            StyleSectionLabel(lblDictionaryLbl, "02  |  DICTIONARY  (one word per line)");
            StyleSectionLabel(lblMinLbl, "03  |  MIN LENGTH");
            StyleSectionLabel(lblMaxLbl, "      |  MAX LENGTH");

            StyleCombo(cmbTargetUser);
            StyleTextArea(txtDictionary);
            StyleNumeric(numMinLength);
            StyleNumeric(numMaxLength);

            StyleStartButton(btnStart);
            StyleStopButton(btnStop);
            StyleDefenseButton(btnDefense);

            pnlDefenseBar.BackColor = Color.FromArgb(8, 12, 24);
            pnlDefenseBar.Paint += PaintDefenseBar;

            progress.Style = ProgressBarStyle.Continuous;
            progress.BackColor = Color.FromArgb(10, 14, 28);
            progress.ForeColor = AccentGreen;

            lblStatus.Font = new Font("Consolas", 9.5f);
            lblStatus.ForeColor = TextSecondary;
            lblStatus.Text = "[ IDLE ]  Ready to launch attack";
        }

        private void PaintHeader(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            int w = pnlHeader.Width, h = pnlHeader.Height;

            using var bgGrad = new LinearGradientBrush(
                new Point(0, 0), new Point(w * 2 / 3, 0),
                Color.FromArgb(55, AccentGreen), Color.FromArgb(0, AccentGreen));
            g.FillRectangle(bgGrad, 0, 0, w, h);

            g.DrawLine(new Pen(Color.FromArgb(160, AccentGreen), 2), 0, 0, w * 2 / 3, 0);
            g.DrawLine(new Pen(Color.FromArgb(28, 45, 80), 1), 0, h - 1, w, h - 1);

            using var titleFont = new Font("Segoe UI", 24f, FontStyle.Bold);
            g.DrawString("Dictionary Attack", titleFont,
                new SolidBrush(TextPrimary), new PointF(28, 24));

            using var subFont = new Font("Segoe UI", 10f);
            g.DrawString("Word-list based password cracking  |  EvilCorp Security Suite", subFont,
                new SolidBrush(TextSecondary), new PointF(30, 80));

            using var dotBrush = new SolidBrush(Color.FromArgb(55, AccentCyan));
            for (int i = 0; i < 7; i++)
                g.FillEllipse(dotBrush, w - 120 + i * 15, 20, 8, 8);
        }

        private void PaintCard(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int w = pnlCard.Width, h = pnlCard.Height;

            using var bar = new LinearGradientBrush(
                new Point(0, 0), new Point(0, h),
                AccentGreen, Color.FromArgb(5, AccentGreen));
            g.FillRectangle(bar, 0, 0, 4, h);

            g.DrawRectangle(new Pen(CardBorder, 1), 0, 0, w - 1, h - 1);
            g.FillEllipse(new SolidBrush(Color.FromArgb(7, AccentGreen)), w - 320, h - 320, 460, 460);

            using var cornerPen = new Pen(Color.FromArgb(35, AccentGreen), 1);
            g.DrawLine(cornerPen, w - 65, 2, w - 2, 2);
            g.DrawLine(cornerPen, w - 2, 2, w - 2, 65);
        }

        private void PaintDefenseBar(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            int w = pnlDefenseBar.Width, h = pnlDefenseBar.Height;

            g.FillRectangle(new SolidBrush(Color.FromArgb(8, 12, 24)), 0, 0, w, h);
            g.DrawLine(new Pen(Color.FromArgb(25, 40, 72), 1), 0, 0, w, 0);

            if (!_defenseActive)
            {
                using var offFont = new Font("Segoe UI", 9.5f);
                g.DrawString("  DEFENSE OFFLINE  —  Enable lockout protection via 'Activate Defense'",
                    offFont, new SolidBrush(TextSecondary), new PointF(14, h / 2f - 10));
                return;
            }

            Color barColor = _accountLocked ? AccentRed
                           : _failedAttemptCount > 0 ? AccentYellow
                           : AccentGreen;

            using var font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            string txt = _accountLocked
                ? $"  ACCOUNT LOCKED  |  {_failedAttemptCount} / {_maxFailedAttempts} wrong guesses"
                : $"  DEFENSE ACTIVE  |  Wrong guesses: {_failedAttemptCount} / {_maxFailedAttempts}";
            g.DrawString(txt, font, new SolidBrush(barColor), new PointF(14, 8));

            int pipW = 20, pipH = 11, pipGap = 5, startX = 14, pipY = 34;
            for (int i = 0; i < _maxFailedAttempts && i < 30; i++)
            {
                Color fill = i < _failedAttemptCount
                    ? Color.FromArgb(200, 50, 50) : Color.FromArgb(18, 32, 60);
                g.FillRectangle(new SolidBrush(fill), startX + i * (pipW + pipGap), pipY, pipW, pipH);
                g.DrawRectangle(new Pen(Color.FromArgb(45, 72, 120), 1),
                    startX + i * (pipW + pipGap), pipY, pipW, pipH);
            }
        }

        private static void StyleSectionLabel(Label lbl, string text)
        {
            lbl.Text = text;
            lbl.Font = new Font("Consolas", 8.5f, FontStyle.Bold);
            lbl.ForeColor = Color.FromArgb(55, 95, 158);
            lbl.AutoSize = false;
        }

        private static void StyleCombo(ComboBox cmb)
        {
            cmb.BackColor = Color.FromArgb(8, 13, 26);
            cmb.ForeColor = Color.FromArgb(185, 212, 255);
            cmb.FlatStyle = FlatStyle.Flat;
            cmb.Font = new Font("Segoe UI", 10.5f);
            cmb.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private static void StyleTextArea(TextBox tb)
        {
            tb.BackColor = Color.FromArgb(8, 13, 26);
            tb.ForeColor = Color.FromArgb(70, 205, 255);
            tb.BorderStyle = BorderStyle.FixedSingle;
            tb.Font = new Font("Consolas", 9.5f);
            tb.ScrollBars = ScrollBars.Vertical;
        }

        private static void StyleNumeric(NumericUpDown num)
        {
            num.BackColor = Color.FromArgb(8, 13, 26);
            num.ForeColor = Color.FromArgb(185, 212, 255);
            num.Font = new Font("Consolas", 12f, FontStyle.Bold);
        }

        private static void StyleStartButton(Button btn)
        {
            btn.Text = "⚡  START DICTIONARY ATTACK";
            btn.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            btn.ForeColor = Color.FromArgb(180, 255, 210);
            btn.BackColor = Color.FromArgb(8, 36, 18);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = Color.FromArgb(35, 170, 95);
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(12, 52, 26);
            btn.Cursor = Cursors.Hand;
        }

        private static void StyleStopButton(Button btn)
        {
            btn.Text = "⛔  ABORT";
            btn.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            btn.ForeColor = Color.FromArgb(255, 165, 165);
            btn.BackColor = Color.FromArgb(42, 10, 10);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = Color.FromArgb(200, 48, 48);
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 15, 15);
            btn.Cursor = Cursors.Hand;
            btn.Enabled = false;
        }

        private static void StyleDefenseButton(Button btn)
        {
            btn.Text = "[ DEFENSE OFF ]  ACTIVATE DEFENSE";
            btn.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            btn.ForeColor = Color.FromArgb(155, 255, 185);
            btn.BackColor = Color.FromArgb(8, 36, 18);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = Color.FromArgb(35, 170, 95);
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(12, 52, 26);
            btn.Cursor = Cursors.Hand;
        }

        private void LoadUsers()
        {
            try
            {
                _users = DatabaseManager.GetAllUsers();
                cmbTargetUser.DisplayMember = "Username";
                cmbTargetUser.ValueMember = "Id";
                cmbTargetUser.DataSource = _users;
            }
            catch (Exception ex) { MessageBox.Show("Error loading users: " + ex.Message); }
        }

        private void btnDefense_Click(object sender, EventArgs e)
        {
            using var dlg = new DefenseConfigDialog(_defenseActive, _maxFailedAttempts);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                _defenseActive = dlg.DefenseEnabled;
                _maxFailedAttempts = dlg.MaxFailedAttempts;
                _failedAttemptCount = 0;
                _accountLocked = false;
                btnStart.Enabled = true;

                btnDefense.Text = _defenseActive
                    ? "[ DEFENSE ON ]  CONFIGURE DEFENSE"
                    : "[ DEFENSE OFF ]  ACTIVATE DEFENSE";
                btnDefense.BackColor = _defenseActive
                    ? Color.FromArgb(10, 52, 24) : Color.FromArgb(8, 36, 18);
                btnDefense.FlatAppearance.BorderColor = _defenseActive
                    ? Color.FromArgb(35, 200, 100) : Color.FromArgb(35, 170, 95);

                pnlDefenseBar.Invalidate();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
            btnStop.Enabled = false;
            lblStatus.Text = "[ ABORTED ]  Attack cancelled by user";
            lblStatus.ForeColor = AccentRed;
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (_accountLocked)
            {
                MessageBox.Show(
                    $"Account is LOCKED.\n\nDefense blocked {_failedAttemptCount} wrong guesses (limit: {_maxFailedAttempts}).",
                    "Account Locked", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (cmbTargetUser.SelectedItem is not User selectedUser) { MessageBox.Show("Select a target user."); return; }
            string targetPassword = DatabaseManager.GetPasswordFromDb(selectedUser.Id);
            if (string.IsNullOrEmpty(targetPassword)) { MessageBox.Show("No password found for this user."); return; }

            string dictionaryText = txtDictionary.Text;
            int minLen = (int)numMinLength.Value;
            int maxLen = (int)numMaxLength.Value;
            if (string.IsNullOrWhiteSpace(dictionaryText)) { MessageBox.Show("Dictionary cannot be empty."); return; }

            _cts = new CancellationTokenSource();
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            progress.Value = 0;
            lblStatus.Text = "[ RUNNING ]  Dictionary attack in progress...";
            lblStatus.ForeColor = AccentOrange;

            await RunDictionaryAttack(targetPassword, dictionaryText, minLen, maxLen, _cts.Token);

            if (!_accountLocked) { btnStart.Enabled = true; btnStop.Enabled = false; }
        }

        private async Task RunDictionaryAttack(string targetPassword, string dictionaryText,
            int minLength, int maxLength, CancellationToken token)
        {
            string[] allWords = dictionaryText.Split(
                new[] { Environment.NewLine, "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);

            var filtered = new List<string>();
            foreach (var w in allWords)
            {
                string clean = w.Trim();
                if (clean.Length >= minLength && clean.Length <= maxLength)
                    filtered.Add(clean);
            }

            if (filtered.Count == 0)
            {
                MessageBox.Show("No words match the length criteria.");
                lblStatus.Text = "[ IDLE ]  No valid words found.";
                return;
            }

            int attempts = 0;
            var sw = Stopwatch.StartNew();

            foreach (var word in filtered)
            {
                if (token.IsCancellationRequested) { sw.Stop(); return; }
                if (_defenseActive && _accountLocked) { sw.Stop(); _cts?.Cancel(); ShowLockoutMessage(); return; }

                attempts++;
                progress.Value = attempts * 100 / filtered.Count;

                if (word.Equals(targetPassword, StringComparison.Ordinal))
                {
                    sw.Stop();
                    progress.Value = 100; btnStop.Enabled = false;
                    lblStatus.Text = "[ SUCCESS ]  Password cracked!";
                    lblStatus.ForeColor = AccentGreen;
                    MessageBox.Show($"Password found:  {word}\n\nAttempts : {attempts:N0}\nTime : {sw.Elapsed.TotalMilliseconds:N2} ms",
                        "Dictionary Attack - Cracked!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (_defenseActive)
                {
                    _failedAttemptCount++;
                    pnlDefenseBar.Invalidate();
                    if (_failedAttemptCount >= _maxFailedAttempts)
                    {
                        sw.Stop();
                        _accountLocked = true; _cts?.Cancel();
                        btnStop.Enabled = false; btnStart.Enabled = false;
                        pnlDefenseBar.Invalidate();
                        lblStatus.Text = "[ LOCKED ]  Account locked by defense system!";
                        lblStatus.ForeColor = AccentRed;
                        ShowLockoutMessage(); return;
                    }
                }

                lblStatus.Text = $"[ RUNNING ]  Testing: {word}   ({attempts:N0} / {filtered.Count})";
                if (attempts % 50 == 0)
                    await Task.Delay(1, token).ContinueWith(_ => { });
            }

            sw.Stop();
            lblStatus.Text = "[ FAILED ]  Password not found in dictionary.";
            lblStatus.ForeColor = AccentRed; btnStop.Enabled = false;
            MessageBox.Show($"Password not found.\n\nAttempts : {attempts:N0}\nTime : {sw.Elapsed.TotalMilliseconds:N2} ms",
                "Dictionary Attack - Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ShowLockoutMessage() =>
            MessageBox.Show(
                $"ACCOUNT LOCKED\n\nDefense blocked the attack after {_failedAttemptCount} wrong guess(es).\nLimit: {_maxFailedAttempts}",
                "Defense Active - Account Locked", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        private void DictionaryAttackForm_Load(object sender, EventArgs e) { }

        public static string GenerateDictionary(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            int length = input.Length;
            char[] charset = input.ToCharArray();
            var result = new System.Text.StringBuilder();
            void Generate(string current)
            {
                if (current.Length == length) { result.AppendLine(current); return; }
                foreach (char c in charset) Generate(current + c);
            }
            Generate("");
            return result.ToString();
        }

        private void cmbTargetUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTargetUser.SelectedItem is not User selectedUser) return;
            string targetPassword = DatabaseManager.GetPasswordFromDb(selectedUser.Id);
            txtDictionary.Text = GenerateDictionary(targetPassword);
        }
    }
}