namespace EvilCorp
{
    public partial class EditProfileForm : Form
    {
        private User _user;

        public EditProfileForm(User user)
        {
            InitializeComponent();
            _user = user;
            txtUsername.Text = _user.Username;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            var newUsername = txtUsername.Text.Trim();
            var newPassword = txtNewPassword.Text;
            var confirm = txtConfirm.Text;
            var current = txtCurrentPassword.Text;

            if (string.IsNullOrEmpty(newUsername))
            {
                lblError.Text = "Username cannot be empty.";
                return;
            }

            if (!string.IsNullOrEmpty(newPassword) && newPassword != confirm)
            {
                lblError.Text = "Passwords do not match.";
                return;
            }

            if (string.IsNullOrEmpty(current))
            {
                lblError.Text = "Enter current password to confirm changes.";
                return;
            }

            // Verify current password
            var auth = DatabaseManager.AuthenticateUser(_user.Username, current);
            if (auth == null)
            {
                lblError.Text = "Current password is incorrect.";
                return;
            }

            // Confirm changes with user
            var confirmBox = MessageBox.Show("Apply profile changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmBox != DialogResult.Yes)
                return;

            bool ok = DatabaseManager.UpdateUser(_user.Id, newUsername, string.IsNullOrEmpty(newPassword) ? null : newPassword, out string error);
            // No-op placeholder to ensure file saved after earlier changes
            if (!ok)
            {
                lblError.Text = error;
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
