using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pyramid
{
    public class Croupier
    {
        Deck deck = new Deck();
        List<Card> cardsDeck = new List<Card>();

        public List<Card> pyramidCards = new List<Card>();
        public List<Card> spareCards = new List<Card>();

        public void InitCroupier()//TODO: Rename                   
        {
            (List<Card> pyramidCardsList, List<Card> spareCardsList) = GetPyramidAndSpareDeck();
          
            this.pyramidCards = pyramidCardsList;
            this.spareCards = spareCardsList;
        }
        public List<Card> SuffleDeck(List<Card> deckOfCards)      
        {
            Random random = new Random();

            for (int i = deckOfCards.Count - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                var temp = deckOfCards[j];
                deckOfCards[j] = deckOfCards[i];
                deckOfCards[i] = temp;
            }
            return deckOfCards;
        }
        
        public List<Card> GetShuffledDeck()                   
        {
            cardsDeck = deck.GetFullDeck();
            SuffleDeck(cardsDeck);
            return cardsDeck;
        }

        public (List<Card>, List<Card>) GetPyramidAndSpareDeck()   
        {
            Card[] cardsForPyramid = new Card[28];
            Card[] spare = new Card[24];
            List<Card> shuffledDeck = GetShuffledDeck();

            shuffledDeck.CopyTo(0, cardsForPyramid, 0, 28);
            shuffledDeck.CopyTo(28, spare, 0, 24);

            return (cardsForPyramid.ToList(), spare.ToList());
        }

        public Card[][] GetPyramidArray()                          
        {
            Card[][] pyramid =
                {
            new Card[1],
            new Card[2],
            new Card[3],
            new Card[4],
            new Card[5],
            new Card[6],
            new Card[7]
            };

            int counter = 0;

            for (int i = 0; i < pyramid.Length; i++)
            {
                for (int j = 0; j < pyramid[i].Length; j++)
                {
                    pyramid[i][j] = pyramidCards[counter];
                    pyramid[i][j].cardVisual = true;
                    
                    counter++;
                    if (i == 6)
                    {
                        pyramid[i][j].cardFrontClickable = true;
                    }
                    else
                        pyramid[i][j].cardFrontClickable = false;
                }

            }
            return pyramid;
        }

        public List<Card> GetSpareArray()                          
        {
            return spareCards;
        }
    }
}
