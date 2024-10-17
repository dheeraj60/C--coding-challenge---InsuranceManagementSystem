namespace InsuranceManagementSystem.entity
{
    public class User
    {
        public int UserId { get; set; }
        public required string Username { get; set; } 
        public required string Password { get; set; }
        public required string Role { get; set; } 

        public User() { }

        public User(int userId, string username, string password, string role)
        {
            UserId = userId;
            Username = username;
            Password = password;
            Role = role;
        }

        public override string ToString()
        {
            return $"UserId: {UserId}, Username: {Username}, Role: {Role}";
        }
    }
}