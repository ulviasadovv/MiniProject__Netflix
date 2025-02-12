namespace MiniProject__Netflix
{
    internal class User : BaseModel
    {
        public string Name { get; private set; }
        public string Password { get; private set; }
        public List<Movie> MoviesOwned { get; set; }


        public User(string name, string password) : base()
        {
            Name = name;
            Password = password;
        }

        enum UserStatus
        {
            Admin,
            User,
        }
    }
}
