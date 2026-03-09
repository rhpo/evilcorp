using System.Text.Json;

namespace EvilCorp
{
    public partial class ChatForm : Form
    {
        private User _currentUser;
        private string _pipeName;

        public ChatForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
            _pipeName = $"EvilCorp_{_currentUser.Id}";

            InitializeForm();
            LoadUsers();
            LoadMessages();
            StartCommunicationChannel();
        }

        private void InitializeForm()
        {
            lblLoggedInUser.Text = _currentUser.Username;

            cmbAlgorithm.Items.AddRange(new object[] { "Caesar", "Affine", "Hill" });
            cmbAlgorithm.SelectedIndex = 0;

            cmbDirection.Items.AddRange(new object[] { "Right", "Left" });
            cmbDirection.SelectedIndex = 0;
        }

        private void LoadUsers()
        {
            var users = DatabaseManager.GetAllUsers();
            foreach (var user in users)
            {
                if (user.Id != _currentUser.Id)
                    cmbReceiver.Items.Add(new UserItem { User = user });
            }
            if (cmbReceiver.Items.Count > 0)
                cmbReceiver.SelectedIndex = 0;
        }

        private void LoadMessages()
        {
            var messages = DatabaseManager.GetMessagesForUser(_currentUser.Id);
            rtbChat.Clear();

            foreach (var message in messages.OrderBy(m => m.Timestamp))
            {
                string decryptedContent = DecryptMessage(message.Content, message.Algorithm, message.Key);
                string direction = message.SenderId == _currentUser.Id ? "You" : message.SenderName;
                string receiverName = message.ReceiverId == _currentUser.Id ? "You" : GetUserNameById(message.ReceiverId);

                AppendMessage($"[{message.Timestamp:HH:mm:ss}] {direction} → {receiverName}\n");
                AppendMessage($"  Encrypted: {message.Content}\n", System.Drawing.Color.FromArgb(150, 170, 200));
                AppendMessage($"  Key: {message.Key} | Algorithm: {message.Algorithm}\n", System.Drawing.Color.FromArgb(120, 140, 180));
                AppendMessage($"  Decrypted: {decryptedContent}\n\n", System.Drawing.Color.FromArgb(100, 200, 150));
            }
        }

        private string GetUserNameById(int userId)
        {
            var users = DatabaseManager.GetAllUsers();
            return users.FirstOrDefault(u => u.Id == userId)?.Username ?? "Unknown";
        }

        private void StartCommunicationChannel()
        {
            CommunicationChannel.MessageReceived += OnMessageReceived;
            CommunicationChannel.StartServer(_pipeName);
        }

        private void OnMessageReceived(string message)
        {
            if (InvokeRequired) { Invoke(new Action<string>(OnMessageReceived), message); return; }

            try
            {
                var messageData = JsonSerializer.Deserialize<MessageData>(message);
                if (messageData != null)
                {
                    var (actualContent, algorithm, key) = CryptoHelper.UnbundleMessage(messageData.Content);
                    string decryptedContent = DecryptMessage(actualContent, algorithm, key);
                    string senderName = GetUserNameById(messageData.SenderId);

                    DatabaseManager.SaveMessage(messageData.SenderId, _currentUser.Id, actualContent, algorithm, key);

                    AppendMessage($"[{DateTime.Now:HH:mm:ss}] {senderName} → You\n");
                    AppendMessage($"  Encrypted (Bundled): {messageData.Content}\n", System.Drawing.Color.FromArgb(150, 170, 200));
                    AppendMessage($"  Decrypted: {decryptedContent}\n\n", System.Drawing.Color.FromArgb(100, 200, 150));
                }
            }
            catch { }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMessage.Text) || cmbReceiver.SelectedItem == null)
                return;

            string algorithm = cmbAlgorithm.SelectedItem?.ToString() ?? "Caesar";
            string key = txtKey.Text.Trim();
            string message = txtMessage.Text;

            // ── Validate key ──────────────────────────────────────────────
            string? keyError = ValidateKey(algorithm, key);
            if (keyError != null)
            {
                MessageBox.Show(keyError, "Invalid Key", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ── Validate input ────────────────────────────────────────────
            string? inputError = ValidateInput(algorithm, message);
            if (inputError != null)
            {
                MessageBox.Show(inputError, "Invalid Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string encryptedContent = EncryptMessage(message, algorithm, key);
            if (string.IsNullOrEmpty(encryptedContent)) return;

            var receiver = ((UserItem)cmbReceiver.SelectedItem).User;
            DatabaseManager.SaveMessage(_currentUser.Id, receiver.Id, encryptedContent, algorithm, key);

            MessageData messageData;
            string displayLabel;

            if (MitmForm.ProtectionEnabled)
            {
                // Bundled: hide algorithm & key
                string bundledContent = CryptoHelper.BundleMessage(encryptedContent, algorithm, key);
                messageData = new MessageData
                {
                    SenderId = _currentUser.Id,
                    ReceiverId = receiver.Id,
                    Content = bundledContent,
                    Algorithm = "Hidden",
                    Key = "Hidden"
                };
                displayLabel = $"  Encrypted (Bundled): {bundledContent}\n";
            }
            else
            {
                // No protection: send clear with algorithm & key visible
                messageData = new MessageData
                {
                    SenderId = _currentUser.Id,
                    ReceiverId = receiver.Id,
                    Content = encryptedContent,
                    Algorithm = algorithm,
                    Key = key
                };
                displayLabel = $"  Encrypted (Clear): {encryptedContent}\n";
            }

            string json = JsonSerializer.Serialize(messageData);

            // Send via communication channel (Interceptor hook will handle it if active)
            CommunicationChannel.SendMessage($"EvilCorp_{receiver.Id}", json);

            AppendMessage($"[{DateTime.Now:HH:mm:ss}] You -> {receiver.Username}\n");
            AppendMessage($"  Original: {message}\n", System.Drawing.Color.FromArgb(200, 220, 255));
            AppendMessage(displayLabel, System.Drawing.Color.FromArgb(150, 170, 200));
            AppendMessage($"  Key: {key} | Algorithm: {algorithm}\n\n", System.Drawing.Color.FromArgb(120, 140, 180));

            txtMessage.Clear();
        }

        // ── Validation ────────────────────────────────────────────────────
        private string? ValidateKey(string algorithm, string key)
        {
            return algorithm switch
            {
                "Caesar" => CryptoHelper.ValidateCaesarKey(key),
                "Affine" => CryptoHelper.ValidateAffineKey(key),
                "Hill" => CryptoHelper.ValidateHillKey(key),
                _ => "Unknown algorithm."
            };
        }

        private string? ValidateInput(string algorithm, string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "Message cannot be empty.";

            return algorithm switch
            {
                "Caesar" => CryptoHelper.ValidateCaesarInput(input),
                "Affine" => CryptoHelper.ValidateAffineInput(input),
                "Hill" => CryptoHelper.ValidateHillInput(input),
                _ => null
            };
        }

        // ── Encrypt / Decrypt ─────────────────────────────────────────────
        private string EncryptMessage(string message, string algorithm, string key)
        {
            try
            {
                switch (algorithm)
                {
                    case "Caesar":
                        int caesarKey = int.Parse(key);
                        if ((cmbDirection.SelectedItem?.ToString() ?? "Right") == "Left")
                            caesarKey = -caesarKey;
                        return CryptoHelper.CaesarEncrypt(message, caesarKey);

                    case "Affine":
                        var ap = key.Split(',');
                        return CryptoHelper.AffineEncrypt(message, int.Parse(ap[0].Trim()), int.Parse(ap[1].Trim()));

                    case "Hill":
                        var hp = key.Split(',');
                        int[,] matrix = {
                            { int.Parse(hp[0].Trim()), int.Parse(hp[1].Trim()) },
                            { int.Parse(hp[2].Trim()), int.Parse(hp[3].Trim()) }
                        };
                        return CryptoHelper.HillEncrypt(message, matrix);

                    default: return message;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Encryption Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        private string DecryptMessage(string message, string algorithm, string key)
        {
            try
            {
                switch (algorithm)
                {
                    case "Caesar":
                        return CryptoHelper.CaesarDecrypt(message, int.Parse(key));

                    case "Affine":
                        var ap = key.Split(',');
                        return CryptoHelper.AffineDecrypt(message, int.Parse(ap[0].Trim()), int.Parse(ap[1].Trim()));

                    case "Hill":
                        var hp = key.Split(',');
                        int[,] matrix = {
                            { int.Parse(hp[0].Trim()), int.Parse(hp[1].Trim()) },
                            { int.Parse(hp[2].Trim()), int.Parse(hp[3].Trim()) }
                        };
                        return CryptoHelper.HillDecrypt(message, matrix);

                    default: return message;
                }
            }
            catch { return message; }
        }

        // ── UI helpers ────────────────────────────────────────────────────
        private void AppendMessage(string message, System.Drawing.Color? color = null)
        {
            int start = rtbChat.TextLength;
            rtbChat.AppendText(message);
            int end = rtbChat.TextLength;
            if (color.HasValue)
            {
                rtbChat.Select(start, end - start);
                rtbChat.SelectionColor = color.Value;
                rtbChat.Select(end, 0);
            }
            rtbChat.ScrollToCaret();
        }

        private void cmbAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string algorithm = cmbAlgorithm.SelectedItem?.ToString() ?? "";
            switch (algorithm)
            {
                case "Caesar":
                    lblKey.Text = "Key (integer, 1–26)";
                    txtKey.Text = "3";
                    lblDirection.Visible = true;
                    cmbDirection.Visible = true;
                    break;
                case "Affine":
                    lblKey.Text = "Key (a,b)";
                    txtKey.Text = "5,8";
                    lblDirection.Visible = false;
                    cmbDirection.Visible = false;
                    break;
                case "Hill":
                    lblKey.Text = "Key (a,b,c,d) — 2×2 matrix";
                    txtKey.Text = "3,3,2,5";
                    lblDirection.Visible = false;
                    cmbDirection.Visible = false;
                    break;
            }
        }

        private void btnSend_MouseEnter(object sender, EventArgs e)
            => btnSend.BackColor = System.Drawing.Color.FromArgb(60, 120, 220);

        private void btnSend_MouseLeave(object sender, EventArgs e)
            => btnSend.BackColor = System.Drawing.Color.FromArgb(50, 100, 200);

        private void btnLogout_Click(object sender, EventArgs e) => this.Close();

        private void ChatForm_FormClosing(object sender, FormClosingEventArgs e)
            => CommunicationChannel.Stop();

        // ── Inner types ───────────────────────────────────────────────────
        private class UserItem
        {
            public User User { get; set; } = null!;
            public override string ToString() => User.Username;
        }

        private class MessageData
        {
            public int SenderId { get; set; }
            public int ReceiverId { get; set; }
            public string Content { get; set; } = string.Empty;
            public string Algorithm { get; set; } = string.Empty;
            public string Key { get; set; } = string.Empty;
        }
    }
}
