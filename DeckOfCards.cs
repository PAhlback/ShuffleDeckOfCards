using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShuffleDeckOfCards
{
    internal class DeckOfCards
    {
        public List<Card> Deck = new List<Card>();
        public DeckOfCards() 
        {
            string name = string.Empty;
            for (int i = 2; i <= 14; i++)
            {
                name = Card.GetName(i);
                Card c = new Card("Hearts", i, name);
                Deck.Add(c);
            }
            for (int i = 2; i <= 14; i++)
            {
                name = Card.GetName(i);
                Card c = new Card("Diamonds", i, name);
                Deck.Add(c);
            }
            for (int i = 2; i <= 14; i++)
            {
                name = Card.GetName(i);
                Card c = new Card("Spades", i, name);
                Deck.Add(c);
            }
            for (int i = 2; i <= 14; i++)
            {
                name = Card.GetName(i);
                Card c = new Card("Clubs", i, name);
                Deck.Add(c);
            }
        }
    }
}
