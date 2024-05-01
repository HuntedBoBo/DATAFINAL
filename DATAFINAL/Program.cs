using System; // Repeating games will crash the program, Has Warnings but it works as intended
using System.Collections.Generic;

// Define the Game class
class Game
{
    public required string Title { get; set; }
    public required string Genre { get; set; }
    public DateTime ReleaseDate { get; set; }
    public required string GamingSystem { get; set; }
}

// Define the CollectionOfGames class
class CollectionOfGames
{
    // Hash table to store games
    private readonly Dictionary<string, Game> gameHashTable;

    // Dictionary to store games by gaming system
    private readonly Dictionary<string, LinkedList<Game>> gamesBySystem;

    public CollectionOfGames()
    {
        gameHashTable = new Dictionary<string, Game>();
        gamesBySystem = new Dictionary<string, LinkedList<Game>>();
    }

    // Add a game to the collection
    public void AddGame(Game game)
    {
        gameHashTable.Add(game.Title, game);
        if (!gamesBySystem.ContainsKey(game.GamingSystem))
        {
            gamesBySystem[game.GamingSystem] = new LinkedList<Game>();
        }
        gamesBySystem[game.GamingSystem].AddLast(game);
        Console.WriteLine($"Game '{game.Title}' added successfully.");
    }

    // Remove a game from the collection
    public void RemoveGame(string title)
    {
        if (gameHashTable.ContainsKey(title))
        {
            Game gameToRemove = gameHashTable[title];
            gameHashTable.Remove(title);
            gamesBySystem[gameToRemove.GamingSystem].Remove(gameToRemove);
            Console.WriteLine($"Game '{title}' removed successfully.");
        }
        else
        {
            Console.WriteLine("Game not found.");
        }
    }

    // Retrieve all games for a specific gaming system
    public List<Game> GetGamesBySystem(string gamingSystem)
    {
        if (gamesBySystem.ContainsKey(gamingSystem))
        {
            return new List<Game>(gamesBySystem[gamingSystem]);
        }
        else
        {
            Console.WriteLine($"No games found for {gamingSystem}.");
            return new List<Game>();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        CollectionOfGames collection = new CollectionOfGames();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add Game");
            Console.WriteLine("2. Remove Game");
            Console.WriteLine("3. View Games by System");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddGame(collection);
                    break;

                case "2":
                    RemoveGame(collection);
                    break;

                case "3":
                    ViewGamesBySystem(collection);
                    break;

                case "4":
                    exit = true;
                    Console.WriteLine("Exiting program.");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void AddGame(CollectionOfGames collection)
    {
        Console.Write("Enter the title of the game: ");
        string title = Console.ReadLine();
        Console.Write("Enter the genre of the game: ");
        string genre = Console.ReadLine();
        Console.Write("Enter the release date of the game (YYYY-MM-DD): ");
        DateTime releaseDate = DateTime.Parse(Console.ReadLine());
        Console.Write("Enter the gaming system of the game: ");
        string gamingSystem = Console.ReadLine();

        collection.AddGame(new Game { Title = title, Genre = genre, ReleaseDate = releaseDate, GamingSystem = gamingSystem });
    }

    static void RemoveGame(CollectionOfGames collection)
    {
        Console.Write("Enter the title of the game to remove: ");
        string titleToRemove = Console.ReadLine();
        collection.RemoveGame(titleToRemove);
    }

    static void ViewGamesBySystem(CollectionOfGames collection)
    {
        Console.Write("Enter the gaming system to view games for: ");
        string systemToView = Console.ReadLine();
        List<Game> gamesForSystem = collection.GetGamesBySystem(systemToView);
        Console.WriteLine($"\nGames for {systemToView}:");
        foreach (var game in gamesForSystem)
        {
            Console.WriteLine($"Title: {game.Title}, Genre: {game.Genre}, Release Date: {game.ReleaseDate}");
        }
    }
}
