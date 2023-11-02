using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ShuffleDeckOfCards
{
    internal class Player
    {
        public bool AceDrawn { get; set; } = false;
        public Stack<Card> Hand = new Stack<Card>();
        public int Total {  get; set; }
        public Card CpuSecondCard { get; set; }

        public void PrintLastCard()
        {
            Console.WriteLine($"{Hand.Peek().Name} of {Hand.Peek().Color}");
            Thread.Sleep(750);
        }
    }
}
