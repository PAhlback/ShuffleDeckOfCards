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
            int j = 2;
            for (int i = 2; i <= 14; i++)
            {
                if (i > 10 && i <= 13) { j = 10; }
                else if (i == 14) { j = 11; }
                else { j = i; }
                name = Card.GetName(i);
                Card c = new Card("Hearts", j, name);
                Deck.Add(c);
            }
            for (int i = 2; i <= 14; i++)
            {
                if (i > 10 && i <= 13) { j = 10; }
                else if (i == 14) { j = 11; }
                else { j = i; }
                name = Card.GetName(i);
                Card c = new Card("Diamonds", j, name);
                Deck.Add(c);
            }
            for (int i = 2; i <= 14; i++)
            {
                if (i > 10 && i <= 13) { j = 10; }
                else if (i == 14) { j = 11; }
                else { j = i; }
                name = Card.GetName(i);
                Card c = new Card("Spades", j, name);
                Deck.Add(c);
            }
            for (int i = 2; i <= 14; i++)
            {
                if (i > 10 && i <= 13) { j = 10; }
                else if (i == 14) { j = 11; }
                else { j = i; }
                name = Card.GetName(i);
                Card c = new Card("Clubs", j, name);
                Deck.Add(c);
            }
        }

        public static void DrawCard(Stack<Card> cardStack, Player p)
        {
            if (cardStack.Peek().Name == "Ace") { p.AceDrawn = true; }
            p.Hand.Push(cardStack.Peek());
            p.Total += cardStack.Pop().Number;
            if(p.Total > 21 && p.AceDrawn)
            {
                p.Total = p.Total - 10;
                p.AceDrawn = false;
            }
        }
    }
}
