using System.Data.SQLite;
using System.Security.Cryptography;
using System.Text;

namespace EvilCorp
{
    public static class DatabaseManager
    {
        private static readonly string ConnectionString = "Data Source=evilcorp.db;Version=3;";

        public static void InitializeDatabase()
        {
            if (!File.Exists("evilcorp.db"))
            {
                SQLiteConnection.CreateFile("evilcorp.db");
            }

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                string createUsersTable = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT UNIQUE NOT NULL,
                        PasswordHash TEXT NOT NULL
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

                using (var command = new SQLiteCommand(createUsersTable, connection))
                {
                    command.ExecuteNonQuery();
                }

                using (var command = new SQLiteCommand(createMessagesTable, connection))
                {
                    command.ExecuteNonQuery();
                }

                SeedUsers(connection);
            }
        }

        private static void SeedUsers(SQLiteConnection connection)
        {
            var users = new[]
            {
                new { Username = "mehdi", Password = "234" },
                new { Username = "anis", Password = "54321" },
                new { Username = "ramy", Password = "#esst#" }
            };

            foreach (var user in users)
            {
                string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @username";
                using (var checkCmd = new SQLiteCommand(checkQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@username", user.Username);
                    long count = (long)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        string hashedPassword = CryptoHelper.CaesarHash(user.Password, 13);
                        string insertQuery = "INSERT INTO Users (Username, PasswordHash) VALUES (@username, @password)";
                        using (var insertCmd = new SQLiteCommand(insertQuery, connection))
                        {
                            insertCmd.Parameters.AddWithValue("@username", user.Username);
                            insertCmd.Parameters.AddWithValue("@password", hashedPassword);
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public static User? AuthenticateUser(string username, string password)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string hashedPassword = CryptoHelper.CaesarHash(password, 13);

                string query = "SELECT Id, Username FROM Users WHERE Username = @username AND PasswordHash = @password";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", hashedPassword);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                Id = reader.GetInt32(0),
                                Username = reader.GetString(1)
                            };
                        }
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
                string query = "SELECT Id, Username FROM Users";
                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new User
                            {
                                Id = reader.GetInt32(0),
                                Username = reader.GetString(1)
                            });
                        }
                    }
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
    }
}
