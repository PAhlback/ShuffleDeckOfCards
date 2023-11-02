using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuffleDeckOfCards
{
    internal class Game
    {
        public static void PlayGame(Stack<Card> cardStack)
        {
            bool winCheck = false;

            Player player = new Player();
            Player cpu = new Player();
            Console.WriteLine("Welcome to 21!");
            Console.WriteLine("Your goal is to get 21. Good Luck!");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.WriteLine();

            Console.WriteLine("Pulling your first cards...");
            Thread.Sleep(500);
            DeckOfCards.DrawCard(cardStack, player);
            DeckOfCards.DrawCard(cardStack, player);

            Console.WriteLine("Pulling computers first cards...");
            Thread.Sleep(500);
            DeckOfCards.DrawCard(cardStack, cpu);
            DeckOfCards.DrawCard(cardStack, cpu);

            char choice = 'x';
            while (!winCheck)
            {
                Console.WriteLine();
                Console.WriteLine($"You have {player.Total}");
                Console.WriteLine($"Computer has {cpu.Total}");
                Console.WriteLine("Hit or stand?");
                Console.Write("h/s: ");
                choice = char.Parse(Console.ReadLine().ToLower());
                Console.WriteLine();
                if (choice == 'h')
                {
                    Console.Write("You draw: ");
                    DeckOfCards.DrawCard(cardStack, player);
                    if (player.Total > 21)
                    {
                        Console.WriteLine($"Dang, you LOST! ");
                        winCheck = true;
                        PrintFinalScores(player.Total, cpu.Total);
                    }
                }
                if (player.Total > cpu.Total)
                {
                    Thread.Sleep(500);
                    Console.Write("Computer draws card: ");
                    DeckOfCards.DrawCard(cardStack, cpu);
                    Thread.Sleep(500);
                }
                if (cpu.Total > 21)
                {
                    Console.WriteLine("Computers total is over 21. You WIN by default!");
                    winCheck = true;
                    PrintFinalScores(player.Total, cpu.Total);
                    Thread.Sleep(500);
                }
                if (choice == 's' && cpu.Total < 22)
                {
                    if (player.Total == cpu.Total)
                    {
                        Console.WriteLine();
                        Console.WriteLine("DRAW! Computer wins ;)");
                        winCheck = true;
                        PrintFinalScores(player.Total, cpu.Total);
                    }
                    else
                    {
                        while (cpu.Total < player.Total && cpu.Total < 22)
                        {
                            Console.Write("Computer draws card: ");
                            DeckOfCards.DrawCard(cardStack, cpu);
                            if (player.Total > cpu.Total && player.Total <= 21)
                            {
                                Console.WriteLine("You WON!");
                                winCheck = true;
                                PrintFinalScores(player.Total, cpu.Total);
                            }
                            else if (player.Total < cpu.Total)
                            {
                                Console.WriteLine("You LOST. Better luck next time!");
                                winCheck = true;
                                PrintFinalScores(player.Total, cpu.Total);
                            }
                        }
                    }
                }
                if (choice != 'h' && choice != 's')
                {
                    Console.WriteLine("Only enter h or s");
                    Thread.Sleep(1200);
                    Console.Clear();
                }
            }
        }

        public static void PrintFinalScores(int playerTotal, int cpuTotal)
        {
            Console.WriteLine($"You final score was: {playerTotal}.");
            Console.WriteLine($"Computers final score was: {cpuTotal}.");
        }
    }
}
