namespace MovieApp;
public enum UserType { Admin, User }
public class User
{
    public string Name { get; set; }
    public UserType Type { get; set; }

    private string[] Watchlist = new string[100];
    private int WatchlistCount = 0;

    public User(string name, UserType type)
    {
        Name = name;
        Type = type;
    }
    public void AddToWatchlist(string movie)
    {
        for (int i = 0; i < WatchlistCount; i++)
        {
            if (Watchlist[i] == movie)
            {
                Console.WriteLine($"{movie} is already in your watchlist.");
                return;
            }
        }

        if (WatchlistCount < Watchlist.Length)
        {
            Watchlist[WatchlistCount++] = movie;
            Console.WriteLine($"{movie} added to watchlist.");
        }
        else
        {
            Console.WriteLine("Watchlist is full.");
        }
    }

}