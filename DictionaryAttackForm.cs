using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvilCorp
{
    public partial class DictionaryAttackForm : Form
    {
        private List<User> _users = new();

        public DictionaryAttackForm()
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

            string dictionaryText = txtDictionary.Text;
            int minLen = (int)numMinLength.Value;
            int maxLen = (int)numMaxLength.Value;

            if (string.IsNullOrWhiteSpace(dictionaryText))
            {
                MessageBox.Show("Dictionary cannot be empty.");
                return;
            }

            btnStart.Enabled = false;
            progress.Value = 0;
            lblStatus.Text = "Running dictionary attack...";

            await RunDictionaryAttack(targetPassword, dictionaryText, minLen, maxLen);

            btnStart.Enabled = true;
        }

        private async Task RunDictionaryAttack(string targetPassword, string dictionaryText, int minLength, int maxLength)
        {
            string[] allWords = dictionaryText.Split(new[] { Environment.NewLine, "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);

            // Filter words by length
            List<string> filteredDictionary = new List<string>();
            foreach (var word in allWords)
            {
                string cleanWord = word.Trim();
                if (cleanWord.Length >= minLength && cleanWord.Length <= maxLength)
                {
                    filteredDictionary.Add(cleanWord);
                }
            }

            if (filteredDictionary.Count == 0)
            {
                MessageBox.Show("No words in the dictionary match the length criteria.");
                lblStatus.Text = "No valid words found.";
                return;
            }

            int attempts = 0;
            Stopwatch sw = Stopwatch.StartNew();

            foreach (var word in filteredDictionary)
            {
                attempts++;

                progress.Value = attempts * 100 / filteredDictionary.Count;

                lblStatus.Text = $"Testing: {word}...";


                if (word.Equals(targetPassword, StringComparison.Ordinal))
                {
                    sw.Stop();
                    lblStatus.Text = "Success!";
                    progress.Value = 100;
                    MessageBox.Show(
                        $"Password found: {word}\nAttempts: {attempts}\nTime: {sw.Elapsed.TotalNanoseconds} nanoseconds\n{sw.ElapsedMilliseconds} en ms",
                        "Dictionary Success");
                    return;
                }
            }

            sw.Stop();
            lblStatus.Text = "Failed.";
            MessageBox.Show(
                $"Password not found.\nAttempts: {attempts}\nTime: {sw.Elapsed.TotalNanoseconds} nanoseconds\n{sw.ElapsedMilliseconds} en ms",
                "Dictionary Failed");
        }

        private void DictionaryAttackForm_Load(object sender, EventArgs e)
        {


        }

        public static string GenerateDictionary(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            int length = input.Length;
            char[] charset = input.ToCharArray();

            var result = new System.Text.StringBuilder();

            void Generate(string current)
            {
                if (current.Length == length)
                {
                    result.AppendLine(current);
                    return;
                }

                foreach (char c in charset)
                {
                    Generate(current + c);
                }
            }

            Generate("");
            return result.ToString();
        }

        private void cmbTargetUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTargetUser.SelectedItem is not User selectedUser)
            {
                MessageBox.Show("Select a target user.");
                return;
            }

            string targetPassword = DatabaseManager.GetPasswordFromDb(selectedUser.Id);

            txtDictionary.Text = GenerateDictionary(targetPassword);
        }
    }
}
