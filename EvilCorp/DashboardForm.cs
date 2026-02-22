namespace EvilCorp
{
    public partial class DashboardForm : Form
    {
        private User _currentUser;

        public DashboardForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
            lblWelcome.Text = $"Welcome, {_currentUser.Username}";
        }

        private void btnSendMessages_Click(object sender, EventArgs e)
        {
            using (var chat = new ChatForm(_currentUser))
            {
                chat.ShowDialog();
            }
        }

        private void btnAttack_Click(object sender, EventArgs e)
        {
            using (var attack = new AttackForm(_currentUser))
            {
                attack.ShowDialog();
            }
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"User: {_currentUser.Username}\nId: {_currentUser.Id}", "Profile");
        }

        private void btnCrypto_Click(object sender, EventArgs e)
        {
            using (var crypto = new CryptoTestForm(_currentUser))
            {
                crypto.ShowDialog();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
