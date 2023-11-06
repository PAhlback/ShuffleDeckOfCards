using ShuffleDeckOfCards.Data;
using ShuffleDeckOfCards.Models;
using System.Security.Cryptography.X509Certificates;

namespace ShuffleDeckOfCards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Select User profile or create a new one
            using (UserContext context = new UserContext())
            {
                User user = UserMenu(context);

                StartMenu(user);
                
                // Everything is contained in this while loop, since this makes it easy to check if the player wants to play
                // again, or quit. Also generates a new deck of cards for each game.
                while (true)
                {
                    //Creates a list of cards within the DeckOfCards class called cardDeck
                    DeckOfCards cardDeck = new DeckOfCards();

                    ////----------------------------
                    //// Code for testing
                    //foreach (Card card in cardDeck.Deck)
                    //{
                    //    Console.WriteLine($"{card.Name} {card.Color} {card.Number}");
                    //}
                    //Console.ReadLine();
                    ////----------------------------

                    // Shuffles the deck of cards
                    Shuffle.ShuffleMethod(cardDeck.Deck);

                    // Moves the shuffled cards from the DeckOfCards list to a Stack.
                    Stack<Card> cardStack = new Stack<Card>();
                    for (int i = 0; i < cardDeck.Deck.Count(); i++)
                    {
                        cardStack.Push(cardDeck.Deck[i]);
                    }

                    // Runs the game itself
                    Game.PlayGame(cardStack, user);
                    context.SaveChanges();

                    // Checks if the player wants to play again.

                    Console.WriteLine();

                    user = EndMenu(user, context);

                    Console.WriteLine("Loading, please wait...");
                    Thread.Sleep(1000);
                    Console.Clear();

                }
            }

            static User UserMenu(UserContext context)
            {
                Console.Clear();
                Console.WriteLine("Welcome to 21!");
                Console.WriteLine("Please select profile");
                List<User> users = context.Users.ToList();
                for(int i = 1; i <= users.Count; i++)
                {
                    Console.WriteLine($"{i}. {users[i-1].Name}");
                }
                Console.WriteLine("c to create new user");
                string input = Console.ReadLine().ToLower();

                if(input == "c")
                {
                    Console.Write("Enter name: ");
                    string name = Console.ReadLine();
                    User user = new User()
                    {
                        Name = name
                    };
                    context.Users.Add(user);
                    context.SaveChanges();
                    return user;
                }

                int menuChoice = Convert.ToInt32(input) - 1;
                Console.Clear();
                return users[menuChoice];
            }

            static void StartMenu(User user)
            {
                while (true)
                {
                    Console.WriteLine($"Hello, {user.Name}!");
                    Console.WriteLine("1. Play the game");
                    Console.WriteLine("2. Check stats");
                    Console.WriteLine("3. Quit");
                    int input = int.Parse(Console.ReadLine());
                    if (input == 1)
                    {
                        Console.Clear();
                        return;
                    }
                    else if (input == 2) user.PrintStats();
                    else if (input == 3)
                    {
                        Console.WriteLine("Good bye!");
                        Thread.Sleep(500);
                        Environment.Exit(0);
                    }
                }
            }

            static User EndMenu(User user, UserContext context)
            {
                while(true)
                {
                    Console.WriteLine("What do you want to do?");
                    Console.WriteLine("1. Play again");
                    Console.WriteLine("2. Check player stats");
                    Console.WriteLine("3. Switch profile");
                    Console.WriteLine("4. Quit");
                    int check = int.Parse(Console.ReadLine());
                    while (true)
                    {
                        if (check == 1)
                        {
                            return user;
                        }
                        else if (check == 2) 
                        {
                            user.PrintStats();
                            break;                           
                        }
                        else if (check == 3)
                        {
                            user = UserMenu(context);
                            return user;
                        }
                        else if (check == 4)
                        {
                            Console.WriteLine("Thanks for playing!");
                            Thread.Sleep(1000);
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("Only enter 1, 2, 3 or 4");
                            Console.WriteLine("Please wait...");
                            Thread.Sleep(500);
                        }
                    }
                }
            }
        }
    } 
}
