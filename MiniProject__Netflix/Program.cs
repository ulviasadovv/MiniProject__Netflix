namespace MiniProject__Netflix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dataContext = new DataContext();
            User user;

            bool exit = false;
            do
            {
                do
                {
                    Console.WriteLine();
                    Console.Write("Welcome to Netflix, please log in: ");
                    string name = Console.ReadLine();

                    if (name.Trim() == "")
                    {
                        Console.WriteLine("Exiting...");
                        return;
                    }

                    if (name == "admin")
                    {
                        Console.Write("Enter your name: ");
                        string adminName = Console.ReadLine();
                        adminName = char.ToUpper(adminName[0]) + adminName.Substring(1).ToLower();
                        Console.Write("Enter your password: ");
                        string adminPassword = Console.ReadLine();
                        user = dataContext.GetUser(adminName, adminPassword);
                        break;
                    }
                    name = char.ToUpper(name[0]) + name.Substring(1).ToLower();
                    Console.Write("Enter your password: ");
                    string password = Console.ReadLine();
                    user = dataContext.GetUser(name, password);

                } while (user.Name == "Undefined");

                bool logout = false;
                if (user.IsAdmin)
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"Welcome to the admin page {user.Name}!");
                    do
                    {
                        Console.WriteLine("Your options are:");
                        Console.WriteLine("1. Add movie");
                        Console.WriteLine("2. Remove movie");
                        Console.WriteLine("3. Add genre");
                        Console.WriteLine("4. Remove genre");
                        Console.WriteLine("5. Most view");
                        Console.WriteLine("6. Log out");
                        Console.WriteLine("7. Exit");

                        string option = Console.ReadLine();

                        switch (option)
                        {
                            case "1":
                                var movie = new Movie();

                                Console.Write("Enter movie name: ");
                                movie.Name = Console.ReadLine();

                                Console.Write("Enter movie genre: ");
                                var genre = new Genre(Console.ReadLine());
                                movie.Genre = genre;

                                Console.Write("Enter movie release year: ");
                                movie.ReleaseYear = int.Parse(Console.ReadLine());

                                Console.Write("Enter movie duration: ");
                                movie.Duration = int.Parse(Console.ReadLine());
                                dataContext.AddMovie(movie);
                                break;
                            case "2":
                                Console.Write("Enter movie name: ");
                                string movieName = Console.ReadLine();
                                dataContext.RemoveMovieByName(movieName);
                                break;
                            case "3":
                                Console.Write("Enter genre name: ");
                                var newGenre = new Genre(Console.ReadLine());
                                dataContext.AddGenre(newGenre);
                                break;
                            case "4":
                                Console.Write("Enter genre name: ");
                                string genreToBeDeleted = Console.ReadLine();
                                dataContext.RemoveGenreByName(genreToBeDeleted);
                                break;
                            case "5":
                                dataContext.GetMostViewedMovie();
                                break;
                            case "6":
                                Console.WriteLine("Logging out...");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.White;
                                logout = true;
                                break;
                            case "7":
                                Console.WriteLine("Exiting...");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.White;
                                logout = true;
                                exit = true;
                                break;
                            default:
                                Console.WriteLine("Invalid option!");
                                break;
                        }
                    } while (!logout);
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    Console.WriteLine($"Welcome {user.Name}!");
                    do
                    {
                        Console.WriteLine("Choose an option:");
                        Console.WriteLine("1. Watch movies");
                        Console.WriteLine("2. Filter movies by genre");
                        Console.WriteLine("3. Add to watchlist");
                        Console.WriteLine("4. Search movie");
                        Console.WriteLine("5. Log out");
                        Console.WriteLine("6. Exit");

                        string option = Console.ReadLine();

                        switch (option)
                        {
                            case "1":
                                Console.WriteLine();
                                Console.WriteLine("Movies:");
                                foreach (var movie in dataContext.Movies)
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
                                    Console.WriteLine(new string('=', 30));
                                    Console.WriteLine();
                                }
                                Console.Write("Enter movie name: ");
                                string movieToWatch = Console.ReadLine();
                                Movie watchingMovie = dataContext.GetMovieByName(movieToWatch);
                                if (watchingMovie.Name != "undefined")
                                {
                                    watchingMovie.NumberOfView++;
                                    Console.WriteLine($"Watching the movie {watchingMovie.Name}");
                                }
                                else Console.WriteLine("There is no moive by that name!");

                                break;
                            case "2":
                                var genre = new Genre();
                                do
                                {
                                    Console.Write("Enter genre name: ");
                                    genre = dataContext.GetGenre(Console.ReadLine());

                                    if (genre.Name == "undefined")
                                    {
                                        Console.WriteLine("Genre not found!");
                                    }
                                } while (genre.Name == "undefined");
                                var movies = dataContext.GetMoviesByGenre(genre);
                                foreach (var movie in movies)
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
                                    Console.WriteLine(new string('=', 30));
                                    Console.WriteLine();
                                }
                                break;
                            case "3":
                                Console.Write("Enter movie ID: ");
                                int movieId = int.Parse(Console.ReadLine());
                                break;
                            case "4":
                                Console.Write("Enter movie name: ");
                                string movieName = Console.ReadLine();
                                var searchedMovie = dataContext.GetMovieByName(movieName);
                                if (searchedMovie.Name == "undefined")
                                {
                                    Console.WriteLine("Movie not found!");
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine(new string('=', 30));
                                    Console.WriteLine($"ID: {searchedMovie.Id}");
                                    Console.WriteLine(new string('-', 30));
                                    Console.WriteLine($"Name: {searchedMovie.Name}");
                                    Console.WriteLine(new string('-', 30));
                                    Console.WriteLine($"Genre: {searchedMovie.Genre.Name}");
                                    Console.WriteLine(new string('-', 30));
                                    Console.WriteLine($"Duration: {searchedMovie.Duration} min");
                                    Console.WriteLine(new string('-', 30));
                                    Console.WriteLine($"Release Year: {searchedMovie.ReleaseYear}");
                                    Console.WriteLine(new string('=', 30));
                                    Console.WriteLine();
                                }
                                break;
                            case "5":
                                logout = true;
                                Console.WriteLine("Logging out...");
                                break;
                            case "6":
                                logout = true;
                                exit = true;
                                Console.WriteLine("Exiting...");
                                break;
                            default:
                                Console.WriteLine("Invalid option!");
                                break;
                        }
                    } while (!logout);
                }
            } while (!exit);
        }
    }
}
