using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvilCorp
{
    public partial class AttackForm : Form
    {
        private List<User> _users = new();

        public AttackForm()
        {
            InitializeComponent();

            _users = DatabaseManager.GetAllUsers();

            cmbTargetUser.DisplayMember = "Username";
            cmbTargetUser.ValueMember = "Id";
            cmbTargetUser.DataSource = _users;

            cmbAttackType.Items.AddRange(new object[]
            {
                "Brute Force",
                "Dictionary"
            });

            cmbAttackType.SelectedIndex = 0;
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (cmbTargetUser.SelectedItem is not User selectedUser)
            {
                MessageBox.Show("Select a target user.");
                return;
            }

            string targetPassword = GetPasswordFromDb(selectedUser.Id);

            if (string.IsNullOrEmpty(targetPassword))
            {
                MessageBox.Show("No password found for this user.");
                return;
            }

            progress.Value = 0;

            if (cmbAttackType.SelectedItem?.ToString() == "Dictionary")
                await RunDictionaryAttack(targetPassword);
            else
                await RunBruteForce(targetPassword);
        }

        private string GetPasswordFromDb(int userId)
        {
            using (var connection = new System.Data.SQLite.SQLiteConnection("Data Source=evilcorp.db;Version=3;"))
            {
                connection.Open();
                string query = "SELECT PasswordHash FROM Users WHERE Id = @id";

                using (var cmd = new System.Data.SQLite.SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", userId);
                    var result = cmd.ExecuteScalar();
                    return result?.ToString() ?? string.Empty;
                }
            }
        }

        // =========================
        // DICTIONARY ATTACK 
        // =========================
        private async Task RunDictionaryAttack(string targetPassword)
        {
            lblStatus.Text = "Running dictionary attack...";

            string[] dictionary =
            {
                "234",
                "54321",
                "password",
                "admin",
                "azerty",
                "test",
                "hello"
            };

            int attempts = 0;
            Stopwatch sw = Stopwatch.StartNew();

            foreach (var word in dictionary)
            {

                attempts++;

                progress.Value = attempts * 100 / dictionary.Length;
                await Task.Delay(50);


                if (word.Equals(targetPassword, StringComparison.Ordinal))
                {
                    sw.Stop();

                    MessageBox.Show(
                        $"Password found: {word}\nAttempts: {attempts}\nTime: {sw.ElapsedMilliseconds} ms",
                        "Dictionary Success");

                    lblStatus.Text = "Dictionary attack success.";
                    return;
                }
            }

            sw.Stop();
            MessageBox.Show(
                $"Password not found.\nAttempts: {attempts}\nTime: {sw.ElapsedMilliseconds} ms",
                "Dictionary Failed");

            lblStatus.Text = "Dictionary attack failed.";
        }

        // =========================
        // BRUTE FORCE
        // =========================
        private async Task RunBruteForce(string targetPassword)
        {
            lblStatus.Text = "Running brute force...";

            string charset = "1234";
            int maxLength = 3;

            int attempts = 0;
            Stopwatch sw = Stopwatch.StartNew();

            foreach (var candidate in GenerateCombinations(charset, maxLength))
            {
                attempts++;
                MessageBox.Show($"{candidate}-{targetPassword}");
                if (candidate.Equals(targetPassword, StringComparison.Ordinal))
                {
                    sw.Stop();

                    MessageBox.Show(
                        $"Password found: {candidate}\nAttempts: {attempts}\nTime: {sw.ElapsedMilliseconds} ms",
                        "Brute Force Success");

                    lblStatus.Text = "Brute force success.";
                    return;
                }

                if (attempts % 10 == 0)
                {
                    progress.Value = Math.Min(100, attempts / 2);
                    await Task.Delay(1);
                }
            }

            sw.Stop();
            MessageBox.Show(
                $"Password not found.\nAttempts: {attempts}\nTime: {sw.ElapsedMilliseconds} ms",
                "Brute Force Failed");

            lblStatus.Text = "Brute force failed.";
        }

        // =========================
        // COMBINATION GENERATOR
        // =========================
        private static IEnumerable<string> GenerateCombinations(string charset, int maxLength)
        {
            for (int length = 1; length <= maxLength; length++)
            {
                foreach (var result in Generate(charset, "", length))
                    yield return result;
            }
        }

        private static IEnumerable<string> Generate(string charset, string prefix, int remaining)
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