using Microsoft.VisualBasic;

namespace MiniProject__Netflix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dataContext = new DataContext();
            dataContext.Start();

            dataContext.Genres.ForEach(genre => Console.WriteLine(genre.Id));
        }
    }
}
