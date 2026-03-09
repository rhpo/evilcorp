using System;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;

namespace EvilCorp
{
    public static class DatabaseManager
    {
        private static readonly string ConnectionString = "Data Source=evilcorp.db;Version=3;";

        public static void InitializeDatabase()
        {
            if (!File.Exists("evilcorp.db"))
                SQLiteConnection.CreateFile("evilcorp.db");

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                // Safe column migration — won't crash if column already exists
                try
                {
                    using (var cmd = new SQLiteCommand("ALTER TABLE Users ADD COLUMN PasswordEncrypted TEXT", connection))
                        cmd.ExecuteNonQuery();
                }
                catch { }

                string createUsersTable = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT UNIQUE NOT NULL,
                        PasswordHash TEXT NOT NULL,
                        PasswordEncrypted TEXT
                    )";

                string createMessagesTable = @"
                    CREATE TABLE IF NOT EXISTS Messages (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        SenderId INTEGER NOT NULL,
                        ReceiverId INTEGER NOT NULL,
                        Content TEXT NOT NULL,
                        Algorithm TEXT NOT NULL,
                        Key TEXT NOT NULL,
                        Timestamp DATETIME DEFAULT CURRENT_TIMESTAMP,
                        FOREIGN KEY (SenderId) REFERENCES Users(Id),
                        FOREIGN KEY (ReceiverId) REFERENCES Users(Id)
                    )";

                using (var cmd = new SQLiteCommand(createUsersTable, connection))
                    cmd.ExecuteNonQuery();

                using (var cmd = new SQLiteCommand(createMessagesTable, connection))
                    cmd.ExecuteNonQuery();

                SeedUsers(connection);
                MigratePasswordsToClearText(connection);
                // NOTE: We no longer auto-fill NULL PasswordEncrypted from hardcoded values.
                // If a user's PasswordEncrypted is NULL it means we don't know their current
                // plain password — it will be filled when they next save from Edit Profile.
            }
        }

        public static bool CreateUser(string username, string password, out string error)
        {
            error = string.Empty;
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                error = "Username and password are required.";
                return false;
            }

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                using (var cmd = new SQLiteCommand(
                    "SELECT COUNT(*) FROM Users WHERE Username = @username", connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    if ((long)cmd.ExecuteScalar() > 0)
                    {
                        error = "Username already exists.";
                        return false;
                    }
                }

                using (var cmd = new SQLiteCommand(
                    "INSERT INTO Users (Username, PasswordHash, PasswordEncrypted) VALUES (@username, @hash, @enc)",
                    connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@hash", ComputeSha256(password));
                    cmd.Parameters.AddWithValue("@enc", ProtectPassword(password));
                    cmd.ExecuteNonQuery();
                }
            }

            return true;
        }

        public static bool UpdateUser(int id, string newUsername, string? newPassword, out string error)
        {
            error = string.Empty;
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                using (var cmd = new SQLiteCommand(
                    "SELECT COUNT(*) FROM Users WHERE Username = @username AND Id != @id", connection))
                {
                    cmd.Parameters.AddWithValue("@username", newUsername);
                    cmd.Parameters.AddWithValue("@id", id);
                    if ((long)cmd.ExecuteScalar() > 0)
                    {
                        error = "Another user with that username already exists.";
                        return false;
                    }
                }

                if (!string.IsNullOrEmpty(newPassword))
                {
                    using (var cmd = new SQLiteCommand(
                        "UPDATE Users SET Username = @username, PasswordHash = @hash, PasswordEncrypted = @enc WHERE Id = @id",
                        connection))
                    {
                        cmd.Parameters.AddWithValue("@username", newUsername);
                        cmd.Parameters.AddWithValue("@hash", ComputeSha256(newPassword));
                        cmd.Parameters.AddWithValue("@enc", ProtectPassword(newPassword));
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    using (var cmd = new SQLiteCommand(
                        "UPDATE Users SET Username = @username WHERE Id = @id", connection))
                    {
                        cmd.Parameters.AddWithValue("@username", newUsername);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            return true;
        }

        private static void MigratePasswordsToClearText(SQLiteConnection connection)
        {
            string checkQuery = "SELECT PasswordHash FROM Users WHERE Username = 'mehdi'";
            using (var cmd = new SQLiteCommand(checkQuery, connection))
            {
                var result = cmd.ExecuteScalar()?.ToString();
                if (result != "nop") return;

                var updates = new List<(int Id, string ClearPassword)>();
                using (var readerCmd = new SQLiteCommand("SELECT Id, PasswordHash FROM Users", connection))
                using (var reader = readerCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int rowId = reader.GetInt32(0);
                        string decrypted = CryptoHelper.CaesarHash(reader.GetString(1), -13);
                        updates.Add((rowId, decrypted));
                    }
                }

                foreach (var (rowId, plain) in updates)
                {
                    using (var updateCmd = new SQLiteCommand(
                        "UPDATE Users SET PasswordHash = @pass, PasswordEncrypted = @enc WHERE Id = @id",
                        connection))
                    {
                        updateCmd.Parameters.AddWithValue("@pass", plain);
                        updateCmd.Parameters.AddWithValue("@enc", ProtectPassword(plain));
                        updateCmd.Parameters.AddWithValue("@id", rowId);
                        updateCmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private static void SeedUsers(SQLiteConnection connection)
        {
            var users = new[]
            {
                new { Username = "mehdi", Password = "234"    },
                new { Username = "anis",  Password = "54321"  },
                new { Username = "ramy",  Password = "#esst#" }
            };

            foreach (var user in users)
            {
                using (var checkCmd = new SQLiteCommand(
                    "SELECT COUNT(*) FROM Users WHERE Username = @username", connection))
                {
                    checkCmd.Parameters.AddWithValue("@username", user.Username);
                    if ((long)checkCmd.ExecuteScalar() > 0) continue;
                }

                using (var insertCmd = new SQLiteCommand(
                    "INSERT INTO Users (Username, PasswordHash, PasswordEncrypted) VALUES (@username, @hash, @enc)",
                    connection))
                {
                    insertCmd.Parameters.AddWithValue("@username", user.Username);
                    insertCmd.Parameters.AddWithValue("@hash", ComputeSha256(user.Password));
                    insertCmd.Parameters.AddWithValue("@enc", ProtectPassword(user.Password));
                    insertCmd.ExecuteNonQuery();
                }
            }
        }

        public static string GetPasswordFromDb(int userId)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (var cmd = new SQLiteCommand(
                    "SELECT PasswordEncrypted FROM Users WHERE Id = @id", connection))
                {
                    cmd.Parameters.AddWithValue("@id", userId);
                    var result = cmd.ExecuteScalar();
                    return DecryptPasswordFromDb(result?.ToString() ?? string.Empty);
                }
            }
        }

        public static string DecryptPasswordFromDb(string protectedPassword)
        {
            if (string.IsNullOrEmpty(protectedPassword)) return string.Empty;
            try { return UnprotectPassword(protectedPassword); }
            catch { return string.Empty; }
        }

        private static string ProtectPassword(string plain)
        {
            if (string.IsNullOrEmpty(plain)) return string.Empty;
            var bytes = Encoding.UTF8.GetBytes(plain);
            var protectedBytes = ProtectedData.Protect(bytes, null, DataProtectionScope.CurrentUser);
            return Convert.ToBase64String(protectedBytes);
        }

        private static string UnprotectPassword(string protectedB64)
        {
            var bytes = Convert.FromBase64String(protectedB64);
            var plain = ProtectedData.Unprotect(bytes, null, DataProtectionScope.CurrentUser);
            return Encoding.UTF8.GetString(plain);
        }

        public static User? AuthenticateUser(string username, string password)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT Id, Username FROM Users WHERE Username = @username AND PasswordHash = @password";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", ComputeSha256(password));
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                            return new User { Id = reader.GetInt32(0), Username = reader.GetString(1) };
                    }
                }
            }
            return null;
        }

        public static List<User> GetAllUsers()
        {
            var users = new List<User>();
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand("SELECT Id, Username FROM Users", connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        users.Add(new User { Id = reader.GetInt32(0), Username = reader.GetString(1) });
                }
            }
            return users;
        }

        public static void SaveMessage(int senderId, int receiverId, string content, string algorithm, string key)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string query = @"INSERT INTO Messages (SenderId, ReceiverId, Content, Algorithm, Key)
                               VALUES (@senderId, @receiverId, @content, @algorithm, @key)";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@senderId", senderId);
                    command.Parameters.AddWithValue("@receiverId", receiverId);
                    command.Parameters.AddWithValue("@content", content);
                    command.Parameters.AddWithValue("@algorithm", algorithm);
                    command.Parameters.AddWithValue("@key", key);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static List<Message> GetMessagesForUser(int userId)
        {
            var messages = new List<Message>();
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string query = @"SELECT m.Id, m.SenderId, m.ReceiverId, m.Content, m.Algorithm, m.Key, m.Timestamp,
                                       u.Username as SenderName
                                FROM Messages m
                                JOIN Users u ON m.SenderId = u.Id
                                WHERE m.ReceiverId = @userId OR m.SenderId = @userId
                                ORDER BY m.Timestamp DESC";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            messages.Add(new Message
                            {
                                Id = reader.GetInt32(0),
                                SenderId = reader.GetInt32(1),
                                ReceiverId = reader.GetInt32(2),
                                Content = reader.GetString(3),
                                Algorithm = reader.GetString(4),
                                Key = reader.GetString(5),
                                Timestamp = reader.GetDateTime(6),
                                SenderName = reader.GetString(7)
                            });
                        }
                    }
                }
            }
            return messages;
        }

        private static string ComputeSha256(string input)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToHexString(bytes).ToLower();
        }
    }
}