namespace MovieApp;
public class Movie
{
    public string Title { get; private set; }
    public string Genre { get; private set; }
    public int NumberOfViews { get; set; } = 0;

    public Movie(string title, string genre, int numberOfViews = 0)
    {
        Title = title;
        Genre = genre;
        NumberOfViews = numberOfViews;
    }

    public void Watch()
    {
        NumberOfViews++;
        Console.WriteLine($"You watched {Title}. Total views: {NumberOfViews}");
    }
}
