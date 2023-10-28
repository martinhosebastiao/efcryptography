namespace EFCryptography
{
    public class User
    {
        protected User() { }

        public User(string email, string password)
        {
            Email = email;
            Password = password;
        }
        public byte UserId { get; private set; }
        public string Email { get; private set; } = default!;
        public string Password { get; private set; } = default!;

        public string GetName() => Email.Split("@").First();

    }
}

