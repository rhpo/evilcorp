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

            cmbMode.Items.AddRange(new object[] { "Encrypt", "Decrypt" });
            cmbMode.SelectedIndex = 0;

            UpdateKeyPlaceholder();
        }

        private void cmbAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateKeyPlaceholder();
        }

        private void UpdateKeyPlaceholder()
        {
            string algorithm = cmbAlgorithm.SelectedItem?.ToString() ?? "Caesar";
            switch (algorithm)
            {
                case "Caesar":
                    lblKey.Text = "Key (integer, 1–26)";
                    txtKey.Text = "3";
                    lblDirection.Visible = true;
                    cmbDirection.Visible = true;
                    break;
                case "Affine":
                    lblKey.Text = "Key (a,b)  —  valid a: 1,3,5,7,9,11,15,17,19,21,23,25";
                    txtKey.Text = "5,8";
                    lblDirection.Visible = false;
                    cmbDirection.Visible = false;
                    break;
                case "Hill":
                    lblKey.Text = "Key (a,b,c,d)  —  2×2 matrix, det must be coprime with 26";
                    txtKey.Text = "3,3,2,5";
                    lblDirection.Visible = false;
                    cmbDirection.Visible = false;
                    break;
            }
        }

        private void btnCrypto_Click(object sender, EventArgs e)
        {
            string algorithm = cmbAlgorithm.SelectedItem?.ToString() ?? "Caesar";
            string mode = cmbMode.SelectedItem?.ToString() ?? "Encrypt";
            string key = txtKey.Text.Trim();
            string input = txtInput.Text ?? string.Empty;

            // Validate key
            string? keyError = ValidateKey(algorithm, key);
            if (keyError != null) { ShowError(keyError, "Invalid Key"); return; }

            // Validate input
            string? inputError = ValidateInput(algorithm, input);
            if (inputError != null) { ShowError(inputError, "Invalid Input"); return; }

            string result;
            if (mode == "Encrypt")
            {
                result = EncryptMessage(input, algorithm, key);
            }
            else
            {
                // For decryption Hill input must also be letters only (already handled by ValidateInput)
                result = DecryptMessage(input, algorithm, key);
            }

            if (result != null) txtOutput.Text = result;
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
                return "Input text cannot be empty.";

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
                ShowError(ex.Message, "Encryption Error");
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
            catch (Exception ex)
            {
                ShowError(ex.Message, "Decryption Error");
                return string.Empty;
            }
        }

        private void ShowError(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
