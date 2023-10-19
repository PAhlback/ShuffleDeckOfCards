﻿namespace ShuffleDeckOfCards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Card> deck = new List<Card>();
            for (int i = 2; i <= 10; i++)
            {
                Card c = new Card("Hearts", i);
                deck.Add(c);
            }
            for (int i = 2; i <= 10; i++)
            {
                Card c = new Card("Diamonds", i);
                deck.Add(c);
            }
            for (int i = 2; i <= 10; i++)
            {
                Card c = new Card("Spades", i);
                deck.Add(c);
            }
            for (int i = 2; i <= 10; i++)
            {
                Card c = new Card("Clubs", i);
                deck.Add(c);
            }

            Shuffle.ShuffleMethod(deck);

            Stack<Card> cardStack = new Stack<Card>();
            for (int i = 0; i < deck.Count(); i++)
            {
                cardStack.Push(deck[i]);
            }

            //foreach (Card card in cardStack)
            //{
            //    Console.WriteLine($"{card.Color} {card.Number}");
            //}

            Console.WriteLine("Welcome to 21!");
            Console.WriteLine("Your goal is to get 21. Good Luck!");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.WriteLine();

            Console.WriteLine("Pulling first cards...");
            Thread.Sleep(500);
            Console.WriteLine($"{cardStack.Peek().Color} {cardStack.Peek().Number}");
            int y = cardStack.Pop().Number;
            Thread.Sleep(500);
            Console.WriteLine($"{cardStack.Peek().Color} {cardStack.Peek().Number}");
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
                    Console.WriteLine($"{cardStack.Peek().Color} {cardStack.Peek().Number}");
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
                if (y == 21)
                {
                    Console.WriteLine("You got 21! Congratulations!");
                }
            }
        } 
    }
}