namespace MiniProject__Netflix
{
    internal class DataContext
    {
        public DataContext()
        {
            Genres =
            [
                new Genre("Action"),
                new Genre("Comedy"),
                new Genre("Horror"),
                new Genre("Romance"),
            ];

            Users = 
            [
                new User("Jane", "3366", true),
                new User("John", "1234"),
                new User("Alice", "4585"),
                new User("Bob", "7894"),
                new User("Charlie", "4567"),
            ];

            Movies =
            [
                new Movie("The Shawshank Redemption", Genres[0], 1994, 142),
                new Movie("The Godfather", Genres[0], 1972, 175),
                new Movie("The Dark Knight", Genres[0], 2008, 152),
                new Movie("Pulp Fiction", Genres[1], 1994, 154),
                new Movie("Forrest Gump", Genres[1], 1994, 142),
                new Movie("The Matrix", Genres[0], 1999, 136),
                new Movie("The Silence of the Lambs", Genres[2], 1991, 118),
                new Movie("The Shining", Genres[2], 1980, 146),
                new Movie("The Conjuring", Genres[2], 2013, 112),
                new Movie("The Notebook", Genres[3], 2004, 123),
            ];
        }

        public List<User> Users { get; set; }
        public List<Movie> Movies { get; set; }
        public List<Genre> Genres { get; set; }

        #region Add Methods
        public void AddUser(User user)
        {
            Users.Add(user);
        }
        public void AddMovie(Movie movie)
        {
            Movies.Add(movie);
        }
        public void AddGenre(Genre genre)
        {
            Genres.Add(genre);
        }
        public void AddToWatchList(int userId, int movieId)
        {
            foreach (var user in Users)
            {
                if (user.Id == userId)
                {
                    user.Watchlist.Add(GetMovieById(movieId));
                    Console.WriteLine("Movie added to watchlist!");
                    return;
                }
            }

            Console.WriteLine("User not found!");
        }
        #endregion

        #region Get Methods
        // Get User
        public User GetUser(string name, string password)
        {
            foreach (var user in Users)
            {
                if (user.Name == name && user.Password == password)
                {
                    return user;
                }
            };
            return new User("undefined", "undefined");
        }
        public User GetUserById(int Id)
        {
            foreach (var user in Users)
            {
                if (user.Id == Id)
                {
                    return user;
                }
            };
            return new User("undefined", "undefined");
        }
        public List<User> GetUsers()
        {
            return Users;
        }
        // Get Movie
        public Movie GetMovie(string name)
        {
            foreach (var movie in Movies)
            {
                if (movie.Name == name)
                {
                    return movie;
                }
            };
            return new Movie();
        }
        public Movie GetMovieById(int Id)
        {
            foreach (var movie in Movies)
            {
                if (movie.Id == Id)
                {
                    return movie;
                }
            };
            return new Movie();
        }
        public Movie GetMovieByName(string name)
        {
            foreach (var movie in Movies)
            {
                if (movie.Name == name)
                {
                    return movie;
                }
            };
            return new Movie("undefined", new Genre("undefined"), 0, 0);
        }
        public List<Movie> GetMoviesByGenre(Genre genre)
        {
            List<Movie> SortedMovies = new List<Movie> { };

            foreach (var movie in Movies)
            {
                if (movie.Genre == genre)
                {
                    SortedMovies.Add(movie);
                }
            };
            return SortedMovies;
        }
        public void GetMostViewedMovie()
        {
            int max = 0;
            foreach (var movie in Movies) {
                if (movie.NumberOfView > max)
                {
                    max = movie.NumberOfView;
                }
            }

            foreach (var movie in Movies)
            {
                if (movie.NumberOfView == max)
                {
                    Console.WriteLine();
                    Console.WriteLine(new string('=', 30));
                    Console.WriteLine($"ID: {movie.Id}");
                    Console.WriteLine(new string('-', 30));
                    Console.WriteLine($"Name: {movie.Name}");
                    Console.WriteLine(new string('-', 30));
                    Console.WriteLine($"Genre: {movie.Genre.Name}");
                    Console.WriteLine(new string('-', 30));
                    Console.WriteLine($"Duration: {movie.Duration} min");
                    Console.WriteLine(new string('-', 30));
                    Console.WriteLine($"Release Year: {movie.ReleaseYear}");
                    Console.WriteLine(new string('-', 30));
                    Console.WriteLine($"Number of View: {movie.NumberOfView}");
                    Console.WriteLine(new string('=', 30));
                    Console.WriteLine();
                }
            }
        }
        // Get Genre
        public Genre GetGenre(string name)
        {
            foreach (var genre in Genres)
            {
                if (genre.Name == name)
                {
                    return genre;
                }
            };
            return new Genre("undefined");
        }
        #endregion

        #region Remove Methods
        // Remove User
        public void RemoveUser(User user)
        {
            Users.Remove(user);
        }
        public void RemoveUserByName(string name)
        {
            foreach (var user in Users)
            {
                if (user.Name == name)
                {
                    Users.Remove(user);
                    return;
                }
            };
        }
        public void RemoveUserById(int Id)
        {
            foreach (var user in Users)
            {
                if (user.Id == Id)
                {
                    Users.Remove(user);
                    return;
                }
            };
        }
        // Remove Genre
        public void RemoveGenre(Genre genre)
        {
            Genres.Remove(genre);
        }
        public void RemoveGenreByName(string name)
        {
            foreach (var genre in Genres)
            {
                if (genre.Name == name)
                {
                    Genres.Remove(genre);
                    return;
                }
            };
        }
        public void RemoveGenreById(int Id)
        {
            foreach (var genre in Genres)
            {
                if (genre.Id == Id)
                {
                    Genres.Remove(genre);
                    return;
                }
            };
        }
        // Remove Movie
        public void RemoveMovie(Movie movie)
        {
            Movies.Remove(movie);
        }
        public void RemoveMovieByName(string name)
        {
            foreach (var movie in Movies)
            {
                if (movie.Name == name)
                {
                    Movies.Remove(movie);
                    return;
                }
            };
        }
        public void RemoveMovieById(int Id)
        {
            foreach (var movie in Movies)
            {
                if (movie.Id == Id)
                {
                    Movies.Remove(movie);
                    return;
                }
            };
        }
        #endregion
    }
}
