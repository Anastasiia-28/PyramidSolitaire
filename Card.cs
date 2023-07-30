using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace pyramid
{
    public class Card
    {
        public CardSuit cardSuit;
        public CardValue cardValue;
        public bool cardVisual;
        public bool cardFrontClickable;
        public bool cardIsDelete;

        public Card()
        {
        }
        public Card(CardValue cardValue, CardSuit cardSuit, bool cardVisual, bool cardFrontClickable, bool cardIsDelete)
        {
            this.cardValue = cardValue;
            this.cardSuit = cardSuit;
            this.cardVisual = cardVisual;
            this.cardFrontClickable = cardFrontClickable;
            this.cardIsDelete = cardIsDelete;
        }

        public Card(CardValue cardValue, CardSuit cardSuit)
        {
            this.cardValue = cardValue;
            this.cardSuit = cardSuit;
 
        }
        public int GetValue(CardValue cardValue)
        {
            switch (cardValue)
            {
                case (CardValue.card_2):
                    return 2;
                case (CardValue.card_3):
                    return 3;
                case (CardValue.card_4):
                    return 4;
                case (CardValue.card_5):
                    return 5;
                case (CardValue.card_6):
                    return 6;
                case (CardValue.card_7):
                    return 7;
                case (CardValue.card_8):
                    return 8;
                case (CardValue.card_9):
                    return 9;
                case (CardValue.card_10):
                    return 10;
                case (CardValue.card_J):
                    return 11;
                case (CardValue.card_Q):
                    return 12;
                case (CardValue.card_K):
                    return 13;
                case (CardValue.card_A):
                    return 1;
                default: return -1;
            }
        }
    }
    public enum CardSuit
    {
        hearts,
        diamonds,
        clubs,
        spades
    }

    public enum CardValue
    {
        card_2,
        card_3,
        card_4,
        card_5,
        card_6,
        card_7,
        card_8,
        card_9,
        card_10,
        card_J,
        card_Q,
        card_K,
        card_A
    }
}