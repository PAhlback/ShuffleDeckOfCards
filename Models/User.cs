using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuffleDeckOfCards.Models
{
    internal class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Draws { get; set; }

        public void PrintStats()
        {
            Console.Clear();
            Console.WriteLine($"{Name}");
            Console.WriteLine($"Total games played: {Wins + Losses + Draws}");
            Console.WriteLine($"Wins: {Wins}");
            Console.WriteLine($"Losses: {Losses}");
            Console.WriteLine($"Draws: {Draws}");
            Console.WriteLine("Press enter to go back to menu");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
