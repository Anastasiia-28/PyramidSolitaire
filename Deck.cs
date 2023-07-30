using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace pyramid
{
    public class Deck
    {
        public List<Card> GetFullDeck()
        {
            return new List<Card>()
            {
                new Card(CardValue.card_2, CardSuit.hearts),
                new Card(CardValue.card_3, CardSuit.hearts),
                new Card(CardValue.card_4, CardSuit.hearts),
                new Card(CardValue.card_5, CardSuit.hearts),
                new Card(CardValue.card_6, CardSuit.hearts),
                new Card(CardValue.card_7, CardSuit.hearts),
                new Card(CardValue.card_8, CardSuit.hearts),
                new Card(CardValue.card_9, CardSuit.hearts),
                new Card(CardValue.card_10,CardSuit.hearts),
                new Card(CardValue.card_J, CardSuit.hearts),
                new Card(CardValue.card_Q, CardSuit.hearts),
                new Card(CardValue.card_K, CardSuit.hearts),
                new Card(CardValue.card_A, CardSuit.hearts),
                new Card(CardValue.card_2, CardSuit.clubs),
                new Card(CardValue.card_3, CardSuit.clubs),
                new Card(CardValue.card_4, CardSuit.clubs),
                new Card(CardValue.card_5, CardSuit.clubs),
                new Card(CardValue.card_6, CardSuit.clubs),
                new Card(CardValue.card_7, CardSuit.clubs),
                new Card(CardValue.card_8, CardSuit.clubs),
                new Card(CardValue.card_9, CardSuit.clubs),
                new Card(CardValue.card_10,CardSuit.clubs),
                new Card(CardValue.card_J, CardSuit.clubs),
                new Card(CardValue.card_Q, CardSuit.clubs),
                new Card(CardValue.card_K, CardSuit.clubs),
                new Card(CardValue.card_A, CardSuit.clubs),
                new Card(CardValue.card_2, CardSuit.spades),
                new Card(CardValue.card_3, CardSuit.spades),
                new Card(CardValue.card_4, CardSuit.spades),
                new Card(CardValue.card_5, CardSuit.spades),
                new Card(CardValue.card_6, CardSuit.spades),
                new Card(CardValue.card_7, CardSuit.spades),
                new Card(CardValue.card_8, CardSuit.spades),
                new Card(CardValue.card_9, CardSuit.spades),
                new Card(CardValue.card_10,CardSuit.spades),
                new Card(CardValue.card_J, CardSuit.spades),
                new Card(CardValue.card_Q, CardSuit.spades),
                new Card(CardValue.card_K, CardSuit.spades),
                new Card(CardValue.card_A, CardSuit.spades),
                new Card(CardValue.card_2, CardSuit.diamonds),
                new Card(CardValue.card_3, CardSuit.diamonds),
                new Card(CardValue.card_4, CardSuit.diamonds),
                new Card(CardValue.card_5, CardSuit.diamonds),
                new Card(CardValue.card_6, CardSuit.diamonds),
                new Card(CardValue.card_7, CardSuit.diamonds),
                new Card(CardValue.card_8, CardSuit.diamonds),
                new Card(CardValue.card_9, CardSuit.diamonds),
                new Card(CardValue.card_10,CardSuit.diamonds),
                new Card(CardValue.card_J, CardSuit.diamonds),
                new Card(CardValue.card_Q, CardSuit.diamonds),
                new Card(CardValue.card_K, CardSuit.diamonds),
                new Card(CardValue.card_A, CardSuit.diamonds)
            };
        }
    }
}
