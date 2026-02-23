namespace EvilCorp
{
    public partial class ProfileForm : Form
    {
        private User _user;

        public ProfileForm(User user)
        {
            InitializeComponent();
            _user = user;

            txtUsername.Text = _user.Username;
            txtUserId.Text = _user.Id.ToString();

            // Show a masked version of stored password hash for security education
            using (var connection = new System.Data.SQLite.SQLiteConnection("Data Source=evilcorp.db;Version=3;"))
            {
                connection.Open();
                string query = "SELECT PasswordHash FROM Users WHERE Id = @id";
                using (var cmd = new System.Data.SQLite.SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", _user.Id);
                    var val = cmd.ExecuteScalar();
                    if (val != null)
                    {
                        var hash = val.ToString() ?? string.Empty;
                        if (hash.Length > 8)
                            txtPasswordHash.Text = hash.Substring(0, 4) + new string('*', Math.Min(8, hash.Length - 4));
                        else
                            txtPasswordHash.Text = new string('*', hash.Length);
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
