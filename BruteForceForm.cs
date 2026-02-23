using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvilCorp
{
    public partial class BruteForceForm : Form
    {
        private List<User> _users = new();

        public BruteForceForm()
        {
            InitializeComponent();
            LoadUsers();
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
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message);
            }
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (cmbTargetUser.SelectedItem is not User selectedUser)
            {
                MessageBox.Show("Select a target user.");
                return;
            }

            string targetPassword = DatabaseManager.GetPasswordFromDb(selectedUser.Id);

            if (string.IsNullOrEmpty(targetPassword))
            {
                MessageBox.Show("No password found for this user.");
                return;
            }

            string charset = txtCharset.Text;
            int minLen = (int)numMinLength.Value;
            int maxLen = (int)numMaxLength.Value;

            if (string.IsNullOrEmpty(charset))
            {
                MessageBox.Show("Charset cannot be empty.");
                return;
            }

            if (minLen > maxLen)
            {
                MessageBox.Show("Min length cannot be greater than max length.");
                return;
            }

            btnStart.Enabled = false;
            progress.Value = 0;
            lblStatus.Text = "Running brute force...";

            await RunBruteForce(targetPassword, charset, minLen, maxLen);

            btnStart.Enabled = true;
        }

        private async Task RunBruteForce(string targetPassword, string charset, int minLength, int maxLength)
        {
            int attempts = 0;
            Stopwatch sw = Stopwatch.StartNew();

            foreach (var candidate in GenerateCombinations(charset, minLength, maxLength))
            {
                attempts++;

                // MessageBox.Show("Testing: " + candidate + "\n" + "Actual Password: " + targetPassword);

                if (candidate.Equals(targetPassword, StringComparison.Ordinal))
                {
                    sw.Stop();
                    lblStatus.Text = "Success!";
                    progress.Value = 100;

                    MessageBox.Show(
                        $"Password found: {candidate}\nAttempts: {attempts}\nTime: {sw.ElapsedMilliseconds} ms",
                        "Brute Force Success");
                    return;
                }

                if (attempts % 100 == 0)
                {
                    lblStatus.Text = $"Testing: {candidate}...";
                    // Just a dummy progress update
                    progress.Value = (attempts / 100) % 101;
                    await Task.Delay(1);
                }
            }

            sw.Stop();
            lblStatus.Text = "Failed.";
            MessageBox.Show(
                $"Password not found.\nAttempts: {attempts}\nTime: {sw.ElapsedMilliseconds} ms",
                "Brute Force Failed");
        }

        private IEnumerable<string> GenerateCombinations(string charset, int minLength, int maxLength)
        {
            for (int length = minLength; length <= maxLength; length++)
            {
                foreach (var result in Generate(charset, "", length))
                    yield return result;
            }
        }

        private IEnumerable<string> Generate(string charset, string prefix, int remaining)
        {
            if (remaining == 0)
            {
                yield return prefix;
                yield break;
            }

            foreach (char c in charset)
            {
                foreach (var result in Generate(charset, prefix + c, remaining - 1))
                    yield return result;
            }
        }
    }
}
