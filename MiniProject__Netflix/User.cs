namespace MiniProject__Netflix
{
    internal class User : BaseModel
    {
        private string _name;
        public User(string name, string password, bool isAdmin = false) : base()
        {
            Name = name;
            Password = password;
            IsAdmin = isAdmin;
        }

        public string Name 
        {
            get => char.ToUpper(_name[0]) + _name.Substring(1).ToLower();
            set => _name = value;
        }
        public string Password { get; private set; }
        public bool IsAdmin { get; private set; }
        public List<Movie> Watchlist { get; set; }
    }
}
