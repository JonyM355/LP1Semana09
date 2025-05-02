using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayerManager4
{
    public class Program
    {
        private List<Player> playerList;

        private static void Main()
        {
            // Create a new instance of the player listing program
            Program prog = new Program();
            // Start the program instance
            prog.Start();
        }

        private Program()
        {
            // Initialize the player list with two players using collection
            // initialization syntax
            playerList = new List<Player>() {
                new Player("Best player ever", 100),
                new Player("An even better player", 500)
            };
        }

        private void Start()
        {
            // We keep the user's option here
            string option;

            // Main program loop
            do
            {
                // Show menu and get user option
                ShowMenu();
                option = Console.ReadLine();

                // Determine the option specified by the user and act on it
                switch (option)
                {
                    case "1":
                        InsertPlayer();
                        break;
                    case "2":
                        ListPlayers(playerList.OrderBy(p => p));
                        break;
                    case "3":
                        ListPlayers(playerList.OrderBy(p => p,
                        new CompareByName(true)));
                        break;
                    case "4":
                        ListPlayers(playerList.OrderBy(p => p,
                        new CompareByName(false)));
                        break;
                    case "5":
                        Console.WriteLine("Bye!");
                        break;
                    default:
                        Console.Error.WriteLine("\n>>> Unknown option! <<<\n");
                        break;
                }

                // Wait for user to press a key...
                Console.Write("\nPress any key to continue...");
                Console.ReadKey(true);
                Console.WriteLine("\n");

                // Loop keeps going until players choses to quit (option 4)
            } while (option != "4");
        }

        /// <summary>
        /// Shows the main menu.
        /// </summary>
        private void ShowMenu()
        {
            Console.WriteLine("Choose one of this options:");

            Console.WriteLine("1. Insert Player\n"
                            + "2. List of players\n"
                            + "3. List of higher score\n"
                            + "4. Exit");
        }

        /// <summary>
        /// Inserts a new player in the player list.
        /// </summary>
        private void InsertPlayer()
        {
            Console.WriteLine("Insert the new player name:\n");
            string name = Console.ReadLine();

            Console.WriteLine($"Insert the score for {name}:\n");
            int score = int.Parse(Console.ReadLine());

            Player n_player = new Player(name, score);

            playerList.Add(n_player);

            Console.WriteLine("Creation completed");
        }

        /// <summary>
        /// Show all players in a list of players. This method can be static
        /// because it doesn't depend on anything associated with an instance
        /// of the program. Namely, the list of players is given as a parameter
        /// to this method.
        /// </summary>
        /// <param name="playersToList">
        /// An enumerable object of players to show.
        /// </param>
        private static void ListPlayers(IEnumerable<Player> playersToList)
        {
            Console.WriteLine("Player List:\n");

            foreach(Player player in playersToList.OrderBy(p => p))
            {
                Console.WriteLine($"{player.Name} - {player.Score}");
            }
        }

        /// <summary>
        /// Show all players with a score higher than a user-specified value.
        /// </summary>
        private void ListPlayersWithScoreGreaterThan()
        {
            Console.WriteLine("Enter a score");
            int minScore = int.Parse(Console.ReadLine());

            IEnumerable<Player> highPlayers;
            highPlayers = GetPlayersWithScoreGreaterThan(minScore);

            ListPlayers(highPlayers);
        }

        /// <summary>
        /// Get players with a score higher than a given value.
        /// </summary>
        /// <param name="minScore">Minimum score players should have.</param>
        /// <returns>
        /// An enumerable of players with a score higher than the given value.
        /// </returns>
        private IEnumerable<Player> GetPlayersWithScoreGreaterThan(int minScore)
        {
            List<Player> filteredPlayers = new List<Player>();

            foreach (Player player in playerList)
            {
                if (player.Score > minScore)
                {
                    filteredPlayers.Add(player);
                }
            }

            return filteredPlayers;
        }
    }
}