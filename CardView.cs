using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace pyramid
{
    public class CardView
    {
        public string GetValueName(CardValue cardValue)
        {
            switch (cardValue)
            {
                case CardValue.card_2:
                    return "2";
                case CardValue.card_3:
                    return "3";
                case CardValue.card_4:
                    return "4";
                case CardValue.card_5:
                    return "5";
                case CardValue.card_6:
                    return "6";
                case CardValue.card_7:
                    return "7";
                case CardValue.card_8:
                    return "8";
                case CardValue.card_9:
                    return "9";
                case CardValue.card_10:
                    return "10";
                case CardValue.card_J:
                    return "jack";
                case CardValue.card_Q:
                    return "queen";
                case CardValue.card_K:
                    return "king";
                case CardValue.card_A:
                    return "ace";
                default: return string.Empty;
            }
        }
        public string GetSuitName(CardSuit cardSuit)
        {
            switch (cardSuit)
            {
                case CardSuit.hearts:
                    return "hearts";
                case CardSuit.clubs:
                    return "clubs";
                case CardSuit.spades:
                    return "spades";
                case CardSuit.diamonds:
                    return "diamonds";
                default: return string.Empty;
            }
        }
    }
}
