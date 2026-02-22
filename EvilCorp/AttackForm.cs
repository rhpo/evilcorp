namespace EvilCorp
{
    public partial class AttackForm : Form
    {
        private User _currentUser;

        public AttackForm(User user)
        {
            InitializeComponent();
            _currentUser = user;

            LoadTargets();
            cmbAttackType.Items.AddRange(new object[] { "Brute Force", "Dictionary", "Man-in-the-Middle" });
            cmbAttackType.SelectedIndex = 0;
        }

        private void LoadTargets()
        {
            var users = DatabaseManager.GetAllUsers().Where(u => u.Id != _currentUser.Id).ToList();
            foreach (var u in users)
            {
                cmbTargetUser.Items.Add(new UserItem { User = u });
            }
            if (cmbTargetUser.Items.Count > 0)
                cmbTargetUser.SelectedIndex = 0;
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (cmbTargetUser.SelectedItem == null)
                return;

            string attackType = cmbAttackType.SelectedItem?.ToString() ?? "Brute Force";
            var target = ((UserItem)cmbTargetUser.SelectedItem).User;

            if (attackType != "Brute Force")
            {
                MessageBox.Show("Only a safe simulation is provided for non-destructive testing. Real attack implementations are disabled.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Simulated brute-force: do NOT attempt to retrieve real passwords. This is an ethics-safe simulation only.
            progress.Value = 0;
            lblStatus.Text = "Simulating brute-force...";

            for (int i = 0; i <= 100; i += 5)
            {
                progress.Value = i;
                await Task.Delay(80);
            }

            lblStatus.Text = "Simulation complete. Real attack disabled for safety.";
            MessageBox.Show("Brute-force simulation finished. This build does not perform real attacks or reveal credentials.", "Simulation Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private class UserItem
        {
            public User User { get; set; } = null!;
            public override string ToString() => User.Username;
        }
    }
}
