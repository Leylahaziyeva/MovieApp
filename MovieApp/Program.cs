namespace MovieApp;
internal class Program
{
    static void Main(string[] args)
    {
        MovieSystem movieSystem = new MovieSystem(); 

        Console.Write("Enter your name: ");
        string name = Console.ReadLine();
        Console.Write("Enter user type (Admin/User): ");
        UserType type;

        while (!Enum.TryParse(Console.ReadLine(), true, out type))
        {
            Console.WriteLine("Invalid user type. Please enter either 'Admin' or 'User'.");
            Console.Write("Enter user type (Admin/User): ");
        }

        User user = new User(name, type);
        ApplyStyle(user.Type);

        while (true)
        {
            Console.WriteLine(" \nCommands:");
            if (user.Type == UserType.Admin)
            {
                Console.WriteLine("1. Add movie");
                Console.WriteLine("2. Remove movie");
                Console.WriteLine("3. Add genre");
                Console.WriteLine("4. Remove genre");
                Console.WriteLine("5. Most viewed");
                Console.WriteLine("6. Print all movies");
            }
            else
            {
                Console.WriteLine("1. Watch movie");
                Console.WriteLine("2. Filter movie by genre");
                Console.WriteLine("3. Add to watchlist");
                Console.WriteLine("4. Search movie");
            }
            Console.WriteLine(" Logout");
            Console.WriteLine(" Exit");

            Console.Write("Enter command: ");
            string command = Console.ReadLine().ToLower();

            if (command == "exit")
                break;
            if (command == "logout")
            {
                Console.Clear();
                return;
            }

            if (user.Type == UserType.Admin)
            {
                AdminCommands(command, movieSystem);
            }
            else
            {
                UserCommands(command, user, movieSystem); 
            }
        }
    }
    static void ApplyStyle(UserType type)
    {
        if (type == UserType.Admin)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
        }
        else
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
        }
        Console.Clear();
    }

    static void AdminCommands(string command, MovieSystem movieSystem)
    {
        if (command == "add movie")
        {
            Console.Write("Enter movie title: ");
            string title = Console.ReadLine();
            Console.Write("Enter movie genre: ");
            string genre = Console.ReadLine();
            movieSystem.AddMovie(title, genre); 
        }
        else if (command == "remove movie")
        {
            Console.Write("Enter movie title to remove: ");
            string title = Console.ReadLine();
            movieSystem.RemoveMovie(title); 
        }
        else if (command == "add genre")
        {
            Console.Write("Enter genre name: ");
            string name = Console.ReadLine();
            movieSystem.AddGenre(name);
        }
        else if (command == "remove genre")
        {
            Console.Write("Enter genre name to remove: ");
            string name = Console.ReadLine();
            movieSystem.RemoveGenre(name);
        }
        else if (command == "most viewed")
        {
            movieSystem.MostViewed();
        }
        else if (command == "print all movies") 
        {
            movieSystem.PrintMovies();
        }
    }

    static void UserCommands(string command, User user, MovieSystem movieSystem)
    {
        if (command == "watch movie")
        {
            Console.Write("Enter movie title: ");
            string title = Console.ReadLine();
            movieSystem.WatchMovie(title); 
        }
        else if (command == "filter movie by genre")
        {
            Console.Write("Enter genre: ");
            string genre = Console.ReadLine();
            movieSystem.FilterByGenre(genre); 
        }
        else if (command == "add to watchlist")
        {
            Console.Write("Enter movie title: ");
            string title = Console.ReadLine();
            user.AddToWatchlist(title);
        }
        else if (command == "search movie")
        {
            Console.Write("Enter movie title: ");
            string title = Console.ReadLine();
            movieSystem.SearchMovie(title); 
        }
    }
}