namespace MiniProject__Netflix
{
    internal class DataContext
    {
        public List<User> Users { get; set; }
        public List<Movie> Movies { get; set; }
        public List<Genre> Genres { get; set; }

        public DataContext()
        {
            Users = new List<User>();
            Movies = new List<Movie>();
            Genres = new List<Genre>();
        }

        enum GenreType
        {
            Action,
            Comedy,
            Drama,
            Horror,
        }

        public void Start()
        {
            Genres.Add(new Genre("Action"));
            Genres.Add(new Genre("Comedy"));
            Genres.Add(new Genre("Horror"));
            Genres.Add(new Genre("Romance"));
            Movies.Add(new Movie("The Shawshank Redemption", Genres[0], 1994, 142));
            Movies.Add(new Movie("The Godfather", Genres[0], 1972, 175));
            Movies.Add(new Movie("The Dark Knight", Genres[0], 2008, 152));
            Movies.Add(new Movie("Pulp Fiction", Genres[1], 1994, 154));
            Movies.Add(new Movie("Forrest Gump", Genres[1], 1994, 142));
            Movies.Add(new Movie("The Matrix", Genres[0], 1999, 136));
            Movies.Add(new Movie("The Silence of the Lambs", Genres[2], 1991, 118));
            Movies.Add(new Movie("The Shining", Genres[2], 1980, 146));
            Movies.Add(new Movie("The Conjuring", Genres[2], 2013, 112));
            Movies.Add(new Movie("The Notebook", Genres[3], 2004, 123));
            Users.Add(new User("admin", "admin"));
            Users.Add(new User("user", "user"));
        }
    }
}
