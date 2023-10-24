using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShuffleDeckOfCards
{
    internal class Card
    {
        public string Color { get; set; } = string.Empty;
        public int Number { get; set; }
        public string Name { get; set; }

        public Card(string color, int number, string name) 
        {
            Color = color;
            Number = number;
            Name = name;
        }

        public static string GetName(int number)
        {
            string name = string.Empty;
            if (number > 10)
            {
                HighCards myEnum = (HighCards)number;
                name = myEnum.ToString();
            }
            else
            {
                name = number.ToString();
            }
            return name;
        }
        enum HighCards
        {
            Jack = 11,
            Queen,
            King,
            Ace
        }
    }
}
