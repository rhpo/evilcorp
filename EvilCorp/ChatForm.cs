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
                {
                    cmbReceiver.Items.Add(new UserItem { User = user });
                }
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
            if (InvokeRequired)
            {
                Invoke(new Action<string>(OnMessageReceived), message);
                return;
            }

            try
            {
                var messageData = JsonSerializer.Deserialize<MessageData>(message);
                if (messageData != null)
                {
                    string decryptedContent = DecryptMessage(messageData.Content, messageData.Algorithm, messageData.Key);
                    string senderName = GetUserNameById(messageData.SenderId);

                    DatabaseManager.SaveMessage(messageData.SenderId, _currentUser.Id, messageData.Content, messageData.Algorithm, messageData.Key);

                    AppendMessage($"[{DateTime.Now:HH:mm:ss}] {senderName} → You\n");
                    AppendMessage($"  Encrypted: {messageData.Content}\n", System.Drawing.Color.FromArgb(150, 170, 200));
                    AppendMessage($"  Key: {messageData.Key} | Algorithm: {messageData.Algorithm}\n", System.Drawing.Color.FromArgb(120, 140, 180));
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
            string key = txtKey.Text;

            if (!ValidateKey(algorithm, key))
            {
                MessageBox.Show("Invalid key for selected algorithm.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string encryptedContent = EncryptMessage(txtMessage.Text, algorithm, key);
            var receiver = ((UserItem)cmbReceiver.SelectedItem).User;

            DatabaseManager.SaveMessage(_currentUser.Id, receiver.Id, encryptedContent, algorithm, key);

            var messageData = new MessageData
            {
                SenderId = _currentUser.Id,
                ReceiverId = receiver.Id,
                Content = encryptedContent,
                Algorithm = algorithm,
                Key = key
            };

            string json = JsonSerializer.Serialize(messageData);
            CommunicationChannel.SendMessage($"EvilCorp_{receiver.Id}", json);

            AppendMessage($"[{DateTime.Now:HH:mm:ss}] You → {receiver.Username}\n");
            AppendMessage($"  Original: {txtMessage.Text}\n", System.Drawing.Color.FromArgb(200, 220, 255));
            AppendMessage($"  Encrypted: {encryptedContent}\n", System.Drawing.Color.FromArgb(150, 170, 200));
            AppendMessage($"  Key: {key} | Algorithm: {algorithm}\n\n", System.Drawing.Color.FromArgb(120, 140, 180));

            txtMessage.Clear();
        }

        private bool ValidateKey(string algorithm, string key)
        {
            switch (algorithm)
            {
                case "Caesar":
                    if (!int.TryParse(key, out int caesarKey) || caesarKey <= 0)
                        return false;
                    return true;
                case "Affine":
                    var parts = key.Split(',');
                    return parts.Length == 2 && int.TryParse(parts[0], out _) && int.TryParse(parts[1], out _);
                case "Hill":
                    var matrixParts = key.Split(',');
                    return matrixParts.Length == 4 && matrixParts.All(p => int.TryParse(p, out _));
                default:
                    return false;
            }
        }

        private string EncryptMessage(string message, string algorithm, string key)
        {
            try
            {
                switch (algorithm)
                {
                    case "Caesar":
                        int caesarKey = int.Parse(key);
                        string direction = cmbDirection.SelectedItem?.ToString() ?? "Right";
                        if (direction == "Left")
                            caesarKey = -caesarKey;
                        return CryptoHelper.CaesarEncrypt(message, caesarKey);
                    case "Affine":
                        var affineParts = key.Split(',');
                        int a = int.Parse(affineParts[0]);
                        int b = int.Parse(affineParts[1]);
                        return CryptoHelper.AffineEncrypt(message, a, b);
                    case "Hill":
                        var hillParts = key.Split(',');
                        int[,] matrix = new int[2, 2];
                        matrix[0, 0] = int.Parse(hillParts[0]);
                        matrix[0, 1] = int.Parse(hillParts[1]);
                        matrix[1, 0] = int.Parse(hillParts[2]);
                        matrix[1, 1] = int.Parse(hillParts[3]);
                        return CryptoHelper.HillEncrypt(message, matrix);
                    default:
                        return message;
                }
            }
            catch
            {
                return message;
            }
        }

        private string DecryptMessage(string message, string algorithm, string key)
        {
            try
            {
                switch (algorithm)
                {
                    case "Caesar":
                        int caesarKey = int.Parse(key);
                        return CryptoHelper.CaesarDecrypt(message, caesarKey);
                    case "Affine":
                        var affineParts = key.Split(',');
                        int a = int.Parse(affineParts[0]);
                        int b = int.Parse(affineParts[1]);
                        return CryptoHelper.AffineDecrypt(message, a, b);
                    case "Hill":
                        var hillParts = key.Split(',');
                        int[,] matrix = new int[2, 2];
                        matrix[0, 0] = int.Parse(hillParts[0]);
                        matrix[0, 1] = int.Parse(hillParts[1]);
                        matrix[1, 0] = int.Parse(hillParts[2]);
                        matrix[1, 1] = int.Parse(hillParts[3]);
                        return CryptoHelper.HillDecrypt(message, matrix);
                    default:
                        return message;
                }
            }
            catch
            {
                return message;
            }
        }

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
                    lblKey.Text = "Key (positive integer)";
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
                    lblKey.Text = "Key (matrix 2x2: a,b,c,d)";
                    txtKey.Text = "3,3,2,5";
                    lblDirection.Visible = false;
                    cmbDirection.Visible = false;
                    break;
            }
        }

        private void btnSend_MouseEnter(object sender, EventArgs e)
        {
            btnSend.BackColor = System.Drawing.Color.FromArgb(60, 120, 220);
        }

        private void btnSend_MouseLeave(object sender, EventArgs e)
        {
            btnSend.BackColor = System.Drawing.Color.FromArgb(50, 100, 200);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChatForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CommunicationChannel.Stop();
        }

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
