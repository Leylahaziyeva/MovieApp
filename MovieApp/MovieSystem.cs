namespace MovieApp;
public class MovieSystem
{
    private Movie[] movies = new Movie[100]; 
    private Genre[] genres = new Genre[50];
    private int movieCount = 0;
    private int genreCount = 0;

    public void AddMovie(string title, string genre)
    {
        movies[movieCount++] = new Movie(title, genre);
        Console.WriteLine("Movie added successfully.");
    }

    public void RemoveMovie(string title)
    {
        for (int i = 0; i < movieCount; i++)
        {
            if (movies[i] != null && movies[i].Title == title)
            {
                movies[i] = movies[--movieCount];
                movies[movieCount] = null;
                Console.WriteLine("Movie removed successfully.");
                return;
            }
        }
        Console.WriteLine("Movie not found.");
    }

    public void AddGenre(string name)
    {
        if (name == null || name.Trim() == "")
        {
            Console.WriteLine("Invalid genre name.");
            return;
        }

        for (int i = 0; i < genreCount; i++)
        {
            if (genres[i] != null && genres[i].Name.ToLower() == name.ToLower())
            {
                Console.WriteLine("Genre already exists.");
                return;
            }
        }

        genres[genreCount++] = new Genre(name);
        Console.WriteLine("Genre added successfully.");
    }

    public void RemoveGenre(string name)
    {
        for (int i = 0; i < genreCount; i++)
        {
            if (genres[i] != null && genres[i].Name.ToLower() == name.ToLower())
            {
                genres[i] = genres[--genreCount]; 
                genres[genreCount] = null;
                Console.WriteLine("Genre removed successfully.");
                return;
            }
        }
        Console.WriteLine("Genre not found.");
    }

    public void MostViewed()
    {
        if (movieCount == 0)
        {
            Console.WriteLine("No movies available.");
            return;
        }

        Movie mostViewed = movies[0];
        for (int i = 1; i < movieCount; i++)
        {
            if (movies[i] != null && movies[i].NumberOfViews > mostViewed.NumberOfViews)
            {
                mostViewed = movies[i];
            }
        }
        Console.WriteLine("Most viewed movie: " + mostViewed.Title + " with " + mostViewed.NumberOfViews + " views.");
    }

    public void WatchMovie(string title)
    {
        for (int i = 0; i < movieCount; i++)
        {
            if (movies[i] != null && movies[i].Title == title)
            {
                movies[i].NumberOfViews++;
                Console.WriteLine($"You are watching {title}.");
                return;
            }
        }
        Console.WriteLine("Movie not found.");
    }

    public void FilterByGenre(string genre)
    {
        Console.WriteLine("Movies in genre " + genre + ":");
        for (int i = 0; i < movieCount; i++)
        {
            if (movies[i] != null && movies[i].Genre.ToLower() == genre.ToLower())
            {
                Console.WriteLine(movies[i].Title);
            }
        }
    }

    public void SearchMovie(string title)
    {
        bool found = false;
        for (int i = 0; i < movieCount; i++)
        {
            if (movies[i] != null && movies[i].Title.ToLower().Contains(title.ToLower()))
            {
                Console.WriteLine("Found: " + movies[i].Title);
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("Movie not found.");
        }
    }

}