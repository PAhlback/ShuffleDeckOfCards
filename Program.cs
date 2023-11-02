namespace ShuffleDeckOfCards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Everything is contained in this while loop, since this makes it easy to check if the player wants to play
            // again, or quit. Also generates a new deck of cards for each game.
            while (true)
            {
                //Creates a list of cards within the DeckOfCards class called cardDeck
                DeckOfCards cardDeck = new DeckOfCards();

                ////----------------------------
                //// Code for testing
                //foreach(Card card in cardDeck.Deck)
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
                Game.PlayGame(cardStack);

                // Checks if the player wants to play again.
                Console.WriteLine();
                Console.WriteLine("Want to play again? (y/n)");
                string yesNo = Console.ReadLine().ToLower();
                if(yesNo == "y")
                {
                    Console.WriteLine("Loading, please wait...");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
                else if (yesNo == "n")
                {
                    Console.WriteLine("Thanks for playing!");
                    Thread.Sleep(1000);
                    break;
                }
            }
            Environment.Exit(0);
        }
    } 
}
