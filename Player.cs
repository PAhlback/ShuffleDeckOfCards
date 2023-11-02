using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuffleDeckOfCards
{
    internal class Player
    {
        public bool AceDrawn { get; set; } = false;
        public List<Card> Hand = new List<Card>();
        public int Total {  get; set; }
    }
}
