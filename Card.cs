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
            HighCards myEnum = (HighCards)number;
            return (number > 10) ? myEnum.ToString() : number.ToString();
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
