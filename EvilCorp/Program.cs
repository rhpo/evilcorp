namespace EvilCorp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            DatabaseManager.InitializeDatabase();

            using (var loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK && loginForm.AuthenticatedUser != null)
                {
                    Application.Run(new ChatForm(loginForm.AuthenticatedUser));
                }
            }
        }
    }
}
