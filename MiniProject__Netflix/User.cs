namespace MiniProject__Netflix
{
    internal class User : BaseModel
    {
        public User(string name, string password, bool isAdmin = false) : base()
        {
            Name = name;
            Password = password;
            IsAdmin = isAdmin;
        }

        public string Name { get; private set; }
        public string Password { get; private set; }
        public bool IsAdmin { get; private set; }
        public List<Movie> Watchlist { get; set; }
    }
}
