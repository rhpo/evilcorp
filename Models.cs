namespace EvilCorp
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
    }

    public class Message
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Content { get; set; } = string.Empty;
        public string Algorithm { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public string SenderName { get; set; } = string.Empty;
    }

    public enum EncryptionAlgorithm
    {
        Caesar,
        Affine,
        Hill
    }
}
