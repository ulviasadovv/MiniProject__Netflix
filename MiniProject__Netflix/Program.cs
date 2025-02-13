namespace MiniProject__Netflix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dataContext = new DataContext();
            User user;

            do
            {
                Console.Write("Welcome to Netflix, please log in: ");
                string name = Console.ReadLine();

                if (name == "admin")
                {
                    Console.Write("Enter your name: ");
                    string adminName = Console.ReadLine();
                    Console.Write("Enter your password: ");
                    string adminPassword = Console.ReadLine();
                    user = dataContext.GetUser(adminName, adminPassword);
                    break;
                }
                Console.Write("Enter your password: ");
                string password = Console.ReadLine();
                user = dataContext.GetUser(name, password);

            } while (user.Name == "undefined");

            if (user.IsAdmin)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"Welcome to the admin page {user.Name}!");
                Console.WriteLine("Your options are:");
                Console.WriteLine("1. Add movie");
                Console.WriteLine("2. Remove movie");
                Console.WriteLine("3. Add genre");
                Console.WriteLine("4. Remove genre");
                Console.WriteLine("5. Most view");
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Welcome {user.Name}!");
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Watch movies");
                Console.WriteLine("2. Filter movies by genre");
                Console.WriteLine("3. Add to watchlist");
                Console.WriteLine("4. Search movie");
            }
        }
    }
}
