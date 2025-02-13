namespace MiniProject__Netflix
{
    internal class PrintHelpers
    {
        #region PrintMethods
        public static void PrintMovies(DataContext dataContext)
        {
            dataContext.Movies.ForEach(movie =>
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
            });
        }
        public static void PrintGenres(DataContext dataContext)
        {
            dataContext.Genres.ForEach(genre =>
            {
                Console.WriteLine();
                Console.WriteLine(new string('=', 30));
                Console.WriteLine($"ID: {genre.Id}");
                Console.WriteLine(new string('-', 30));
                Console.WriteLine($"Name: {genre.Name}");
                Console.WriteLine(new string('=', 30));
                Console.WriteLine();
            });
        }
        #endregion
    }
}
