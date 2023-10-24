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
            Console.WriteLine("Welcome to 21!");
            Console.WriteLine("Your goal is to get 21. Good Luck!");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.WriteLine();

            Console.WriteLine("Pulling first cards...");
            Thread.Sleep(500);
            Console.WriteLine($"{cardStack.Peek().Name} of {cardStack.Peek().Color}");
            int y = cardStack.Pop().Number;
            Thread.Sleep(500);
            Console.WriteLine($"{cardStack.Peek().Name} of {cardStack.Peek().Color}");
            y += cardStack.Pop().Number;
            char choice = 'x';
            Thread.Sleep(500);

            while (y <= 21)
            {
                Console.WriteLine($"You have {y}. Hit again?");
                Console.WriteLine("y/n: ");
                choice = char.Parse(Console.ReadLine());
                if (choice == 'y')
                {
                    Console.WriteLine($"{cardStack.Peek().Name} of {cardStack.Peek().Color}");
                    y += cardStack.Pop().Number;
                    if (y > 21)
                    {
                        Console.WriteLine($"Dang, you lost! You got {y}.");
                        break;
                    }
                }
                else if (choice == 'n')
                {
                    if (y > 18)
                    {
                        Console.WriteLine($"You got {y}. Close!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Could have gone better, right?");
                        break;
                    }
                }
                else if (choice != 'y' || choice != 'n')
                {
                    Console.WriteLine("Only enter y or n");
                    Thread.Sleep(1200);
                    Console.Clear();
                }
                if (y == 21)
                {
                    Console.WriteLine("You got 21! Congratulations!");
                }
            }
        }
    }
}
