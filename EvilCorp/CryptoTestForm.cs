namespace EvilCorp
{
    public partial class CryptoTestForm : Form
    {
        private User _currentUser;

        public CryptoTestForm(User user)
        {
            InitializeComponent();
            _currentUser = user;

            cmbAlgorithm.Items.AddRange(new object[] { "Caesar", "Affine", "Hill" });
            cmbAlgorithm.SelectedIndex = 0;

            cmbDirection.Items.AddRange(new object[] { "Right", "Left" });
            cmbDirection.SelectedIndex = 0;

            UpdateKeyPlaceholder();
        }

        private void cmbAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateKeyPlaceholder();
        }

        private void UpdateKeyPlaceholder()
        {
            var algorithm = cmbAlgorithm.SelectedItem?.ToString() ?? "Caesar";
            switch (algorithm)
            {
                case "Caesar":
                    lblKey.Text = "Key (integer)";
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

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string algorithm = cmbAlgorithm.SelectedItem?.ToString() ?? "Caesar";
            string key = txtKey.Text;
            string input = txtInput.Text ?? string.Empty;

            if (!ValidateKey(algorithm, key))
            {
                MessageBox.Show("Invalid key for selected algorithm.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string encrypted = EncryptMessage(input, algorithm, key);
            txtOutput.Text = encrypted;
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string algorithm = cmbAlgorithm.SelectedItem?.ToString() ?? "Caesar";
            string key = txtKey.Text;
            string input = txtInput.Text ?? string.Empty;

            if (!ValidateKey(algorithm, key))
            {
                MessageBox.Show("Invalid key for selected algorithm.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string decrypted = DecryptMessage(input, algorithm, key);
            txtOutput.Text = decrypted;
        }

        private bool ValidateKey(string algorithm, string key)
        {
            switch (algorithm)
            {
                case "Caesar":
                    if (!int.TryParse(key, out int caesarKey))
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
    }
}
