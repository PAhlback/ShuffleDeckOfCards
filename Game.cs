﻿using System;
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

            Console.WriteLine("Pulling your first cards...");
            Thread.Sleep(500);
            int playerTotal = DeckOfCards.DrawCard(cardStack);
            playerTotal += DeckOfCards.DrawCard(cardStack);

            Console.WriteLine("Pulling computers first cards...");
            Thread.Sleep(500);
            int cpuTotal = DeckOfCards.DrawCard(cardStack);
            cpuTotal += DeckOfCards.DrawCard(cardStack);

            char choice = 'x';
            while (playerTotal <= 21)
            {
                Console.WriteLine();
                Console.WriteLine($"You have {playerTotal}");
                Console.WriteLine($"Computer has {cpuTotal}");
                Console.WriteLine("Hit again?");
                Console.Write("y/n: ");
                choice = char.Parse(Console.ReadLine().ToLower());
                Console.WriteLine();
                if (choice == 'y')
                {
                    Console.Write("You draw: ");
                    playerTotal += DeckOfCards.DrawCard(cardStack);
                    if (playerTotal > 21)
                    {
                        Console.WriteLine($"Dang, you LOST! ");
                        FinalScores(playerTotal, cpuTotal);
                        break;
                    }
                }
                if (playerTotal > cpuTotal)
                {
                    Thread.Sleep(500);
                    Console.Write("Computer draws card: ");
                    cpuTotal += DeckOfCards.DrawCard(cardStack);
                    Thread.Sleep(500);
                }
                if (cpuTotal > 21)
                {
                    Console.WriteLine("Computers total is over 21. You WIN by default!");
                    FinalScores(playerTotal, cpuTotal);
                    Thread.Sleep(500);
                    break;
                }
                if (choice == 'n' && cpuTotal < 22)
                {
                    if (playerTotal > cpuTotal && playerTotal <= 21)
                    {
                        Console.WriteLine("You WON!");
                        FinalScores(playerTotal, cpuTotal);
                        break;
                    }
                    else if (playerTotal < cpuTotal)
                    {
                        Console.WriteLine("You LOST. Better luck next time!");
                        FinalScores(playerTotal, cpuTotal);
                        break;
                    }
                    else if (playerTotal == cpuTotal)
                    {
                        Console.WriteLine("DRAW! Computer wins ;)");
                        FinalScores(playerTotal, cpuTotal);
                        break;
                    }
                }
                if (choice != 'y' && choice != 'n')
                {
                    Console.WriteLine("Only enter y or n");
                    Thread.Sleep(1200);
                    Console.Clear();
                }
            }
        }

        public static void FinalScores(int playerTotal, int cpuTotal)
        {
            Console.WriteLine($"You final score was: {playerTotal}.");
            Console.WriteLine($"Computers final score was: {cpuTotal}.");
        }
    }
}
