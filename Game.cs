using ShuffleDeckOfCards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ShuffleDeckOfCards
{
    internal class Game
    {
        public static void PlayGame(Stack<Card> cardStack, User user)
        {
            bool winCheck = false;

            Player player = new Player();
            Player cpu = new Player();
            Console.WriteLine($"Welcome to 21, {user.Name}!");
            Console.WriteLine("Your goal is to get 21. Good Luck!");
            Console.WriteLine("Press enter to continue");
            Console.ReadKey();
            Console.WriteLine();

            Console.WriteLine("Pulling your first cards...");
            Thread.Sleep(500);
            DeckOfCards.DrawCard(cardStack, player);
            player.PrintLastCard();
            DeckOfCards.DrawCard(cardStack, player);
            player.PrintLastCard();

            Console.WriteLine("Pulling computers first cards...");
            Thread.Sleep(500);
            DeckOfCards.DrawCard(cardStack, cpu);
            cpu.PrintLastCard();
            int cpuFirstNumber = cpu.Total;
            DeckOfCards.DrawCard(cardStack, cpu);
            cpu.CpuSecondCard = cpu.Hand.Peek();
            Console.WriteLine("Computers second card is hidden");

            char choice = 'x';
            while (!winCheck)
            {
                Console.WriteLine();
                Console.WriteLine($"You have {player.Total}");
                Console.WriteLine($"Computer has {cpuFirstNumber} + hidden hole card");
                Console.WriteLine("Hit or stand?");
                Console.Write("h/s: ");
                choice = char.Parse(Console.ReadLine().ToLower());
                Console.WriteLine();
                if (choice == 'h')
                {
                    Console.Write("You draw ");
                    DeckOfCards.DrawCard(cardStack, player);
                    player.PrintLastCard();
                    if (player.Total > 21)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Dang, you LOST!");
                        user.Losses++;
                        winCheck = true;
                        PrintFinalScores(player.Total, cpu.Total);
                    }
                }
                else if(choice == 's')
                {
                    Console.WriteLine("Computers turn!");
                    winCheck = CpusTurn(cpu, player, cardStack, user);
                    Thread.Sleep(800);
                }

                if (choice != 'h' && choice != 's')
                {
                    Console.WriteLine("Only enter h or s");
                    Thread.Sleep(1200);
                    Console.Clear();
                }
            }

            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }

        public static bool CpusTurn(Player cpu, Player player, Stack<Card> cardStack, User user)
        {
            Console.WriteLine($"Computers hole card is {cpu.CpuSecondCard.Name} of {cpu.CpuSecondCard.Color}");

            while (true)
            {
                Console.WriteLine($"Computer has {cpu.Total}");
                Console.WriteLine();
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                Thread.Sleep(500);
                if (cpu.Total > player.Total && cpu.Total < 22)
                {
                    Console.WriteLine("You LOST. Better luck next time!");
                    PrintFinalScores(player.Total, cpu.Total);
                    user.Losses++;
                    return true;
                }
                else if (cpu.Total == player.Total)
                {
                    Console.WriteLine("DRAW! Computer wins ;)");
                    PrintFinalScores(player.Total, cpu.Total);
                    user.Draws++;
                    return true;
                }
                else if (cpu.Total > 21)
                {
                    Console.WriteLine("You win! Computer went bust.");
                    PrintFinalScores(player.Total, cpu.Total);
                    user.Wins++;
                    return true;
                }
                else if (cpu.Total < player.Total)
                {
                    Console.Write("Computer draws ");
                    DeckOfCards.DrawCard(cardStack, cpu);
                    cpu.PrintLastCard();
                }
            }
        }

        public static void PrintFinalScores(int playerTotal, int cpuTotal)
        {
            Console.WriteLine($"Your final score was: {playerTotal}.");
            Console.WriteLine($"Computers final score was: {cpuTotal}.");
        }
    }
}
