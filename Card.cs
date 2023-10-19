using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuffleDeckOfCards
{
    internal class Card
    {
        public string Color { get; set; } = string.Empty;
        public int Number { get; set; }

        public Card(string color, int number) 
        {
            Color = color;
            Number = number;
        }
    }
}
