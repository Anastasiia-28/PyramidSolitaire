using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;


namespace pyramid
{
    public partial class MainWindow : Window
    {

        CardView cardView = new CardView();
        Card card = new Card();
        Croupier croupier = new Croupier();

        List<Image> pyramidCardImages;

        List<Card> pyramidCards = new List<Card>();
        List<Card> pyramidCards1 = new List<Card>();
        Stack<Card> spareCardsStack;
        Stack<Card> spareCardsStackMoved = new Stack<Card>();

        List<Card> spareCardsDeck;
        List<Card> spareCardsDeckMoved = new List<Card>();
        Card[][] pyramid;

        private const char PYRAMID_KEY = 'p';

        bool flag = false;
        int value1 = 0;
        int value2 = 0;
        Card card1;
        Card card2;

        string imageName;
        public MainWindow()
        {
            InitializeComponent();

            spareCardsDeck = croupier.GetSpareArray();
            
            spareCardsStack = new Stack<Card>(spareCardsDeck);
            pyramidCardImages = new List<Image> { p_0_0, p_1_0, p_1_1, p_2_0, p_2_1, p_2_2, p_3_0, p_3_1,
                                                 p_3_2, p_3_3, p_4_0, p_4_1, p_4_2, p_4_3, p_4_4, p_5_0, p_5_1, p_5_2,
                                                 p_5_3, p_5_4, p_5_5, p_6_0, p_6_1, p_6_2, p_6_3, p_6_4, p_6_5, p_6_6};

        }
        public void OnClosedDeckClick(object sender, RoutedEventArgs e) 
        {
            GetNull();
            openDeckArea.Opacity = 0;//?
            if (spareCardsStack.Count != 0)
            {
                Card v = spareCardsStack.Pop();
                spareCardsStackMoved.Push(v);
                s_deck1.Source = new BitmapImage(new Uri(GetLinkByCardData(v)));
                if (spareCardsStack.Count == 0)
                {
                    s_deck.Source = null;
                    spareCardsDeckMoved = spareCardsStackMoved.ToList();
                    GetRepeat();
                }
            }
        }
        private void GetRepeat()
        {
            Repeat.Opacity = 1;
            Repeat.IsEnabled = true;
        }
        public void RepeatClick(object sender, RoutedEventArgs e) 
        {
            GetNewDeck();
        }
        private void GetNewDeck()
        {
            Card card_ = new Card() ;
            if (spareCardsStackMoved.Count != 0)
            {
                spareCardsDeckMoved = spareCardsStackMoved.ToList();
                for (int i = 0; i < spareCardsDeckMoved.Count; i++)
                {
                    card_ = spareCardsStackMoved.Pop();
                    spareCardsStack.Push(card_);
                }

                GetClosedDeckImage();
                s_deck1.Source = null;
            }

            Repeat.Opacity = 0;
            Repeat.IsEnabled = false;
        }

        #region Visualize State
        private void GetClosedDeckImage()
        {
            openDeckArea.Opacity = 0.20;
            string link = "D:/projects/pyramid/images/card.png";
            if (spareCardsStack.Count != 0)
            {
                s_deck.Source = new BitmapImage(new Uri(link));
            }
            else
                s_deck.Source = null;
        }
        public List<Card> GetListCardsFromPyramid()
        {
            foreach (Card[] row in croupier.GetPyramidArray())
            {
                foreach (Card number in row)
                {
                    pyramidCards1.Add(number);
                }
                
            }
            pyramidCards = pyramidCards1;
            return pyramidCards1;
        }

        private void UpdateGameView()
        {
            GetClosedDeckImage();
            (List<string> linksForPyramid, List<string> linksForSpareDeck) = GetListsOfLinks(croupier);

            for (int i = 0; i < pyramidCardImages.Count; i++)
            {
                var v = new BitmapImage(new Uri(linksForPyramid[i]));
              
                pyramidCardImages[i].Source = v;
            }

        }
        public void SetCardsOnTable(object sender, RoutedEventArgs e)
        {
            croupier.InitCroupier();
            pyramid = croupier.GetPyramidArray();
            spareCardsDeck = croupier.GetSpareArray();
            spareCardsStack = new Stack<Card>(spareCardsDeck);
            GetListCardsFromPyramid();
            UpdateGameView(); 
            GetNewDeck();
            GetNull();
            openDeckArea.Opacity = 0.20;
            GetNewGame();
        }
        private void GetNewGame()
        {
            for (int i = 0; i < pyramidCardImages.Count; i++)
            {
                pyramidCardImages[i].Opacity = 1;
                pyramidCardImages[i].IsHitTestVisible = true;
            }
        }
        public (List<string>, List<string>) GetListsOfLinks(Croupier croupier)
        {
            List<string> linksOfCards = new List<string>();
            List<string> spareDeckLinks = new List<string>();

            int i = 0;
            foreach (Card[] line in pyramid)
            {
                foreach (Card card in line)
                {
                    linksOfCards.Add(GetLinkByCardData(card));

                    if (card.cardVisual == false)
                    {
                        pyramidCardImages[i].Opacity = 0;
                        pyramidCardImages[i].IsHitTestVisible = false;
                    }
                    i++;
                }
            }
            return (linksOfCards, spareDeckLinks);
        }

        public string GetLinkByCardData(Card card)
        {
            string linkPattern = "D:/projects/pyramid/images/{0}_of_{1}.png";
            return string.Format(linkPattern, cardView.GetValueName(card.cardValue), cardView.GetSuitName(card.cardSuit));
        }
        #endregion
        #region On Cards Click
        private void OnCardClick(object sender, MouseEventArgs e)
        {
            if (sender is Image convertedImage)
            {
                imageName = convertedImage.Name;

                string[] cardParams = imageName.Split('_');
                                                            
                char cardKey = Convert.ToChar(cardParams[0]);

                if (cardKey == PYRAMID_KEY)
                {
                    OnCardInPyramidClick(cardParams);
                }
            }
        }
        #endregion 
        private void GetNull() 
        {
            flag = false;
            value1 = 0;
            value2 = 0;
            card1 = new Card();
            card2 = new Card();
        }
        private void GetNewVisualForOpenDeck()
        {
            if (spareCardsStackMoved.Count == 0)
            {
                s_deck1.Source = null;
                return;
            }
            else
            {
                Card v = spareCardsStackMoved.Peek();
                s_deck1.Source = new BitmapImage(new Uri(GetLinkByCardData(v)));
            }           
        }

        public void OnOpenDeckClick(object sender, RoutedEventArgs e) 
        {
            card1 = spareCardsStackMoved.Peek();
            int valueOfCard = card.GetValue(card1.cardValue);

            if (value1 != 0)
            {
                value2 = valueOfCard;
                if (value1 + value2 == 13)
                {
                    DeleteCardFromPyramid(card2);
                    spareCardsStackMoved.Pop();
                    Trace.WriteLine($"{spareCardsStackMoved.Count} cards in Stack");
                    spareCardsDeckMoved = spareCardsStackMoved.ToList();
                    GetNull();
                    GetNewVisualForOpenDeck();
                    UpdateGameView();
                }
                else
                {
                    GetNull();
                    GetNewVisualForOpenDeck();
                    UpdateGameView();
                }
            }

            else if (value1 == 0)
            {
                value1 = valueOfCard;
                flag = true;
                if (value1 == 13)
                {
                    spareCardsStackMoved.Pop();
                    Trace.WriteLine($"{spareCardsStackMoved.Count} cards in Stack");
                    spareCardsDeckMoved = spareCardsStackMoved.ToList();
                    flag = false;
                    value1 = 0;
                    GetNewVisualForOpenDeck();
                }
            }


            if (value2 != 0)
            {
                if (value1 + value2 == 13)
                {
                    DeleteCardFromPyramid(card2);
                    spareCardsStackMoved.Pop();
                    Trace.WriteLine($"{spareCardsStackMoved.Count} cards in Stack");
                    spareCardsDeckMoved = spareCardsStackMoved.ToList();
                    GetNull();
                    GetNewVisualForOpenDeck();
                    UpdateGameView();
                }
                else
                {
                    GetNull();
                    GetNewVisualForOpenDeck();
                    UpdateGameView();
                }
            }
        }


        private void OnCardInPyramidClick(string[] cardParams)
        {

            int cardIndexI = Convert.ToInt32(cardParams[1]);
            int cardIndexJ = Convert.ToInt32(cardParams[2]);

            if (pyramid[cardIndexI][cardIndexJ].cardFrontClickable == true)
            {

                card2 = pyramid[cardIndexI][cardIndexJ];

                int valueOfCard = card.GetValue(card2.cardValue);
                Trace.WriteLine($"{card2.cardValue} {card2.cardSuit} card is CLICK");


                if (flag == true)
                {
                    value2 = valueOfCard;
                    if (value2 + value1 == 13)
                    {
                        DeleteCardFromPyramid(card2);
                        spareCardsStackMoved.Pop();
                        Trace.WriteLine($"{spareCardsStackMoved.Count} cards in Stack");

                        GetNewVisualForOpenDeck();
                        UpdateGameView();
                        GetNull();
                    }
                    else
                    {
                        GetNull();
                        UpdateGameView();
                    }
                }
                else
                {
                    if (value1 == 0)
                    {
                        value1 = valueOfCard;
                        card1 = pyramid[cardIndexI][cardIndexJ];
                        if (value1 == 13)
                        {
                            DeleteCardFromPyramid(card1);
                            UpdateGameView();
                            GetNull();
                        }
                    }
                    else if (value1 != 0)
                    {
                        value2 = valueOfCard;
                        
                        card2 = pyramid[cardIndexI][cardIndexJ];

                        if (card1 == card2)
                            GetNull();


                        if (value1 + value2 == 13)
                        {
                            DeleteCardFromPyramid(card2);
                            DeleteCardFromPyramid(card1);
                            UpdateGameView();
                            GetNull();
                        }
                        else
                        {
                            GetNull();
                            UpdateGameView();
                        }
                    }
                }
            }
        }
















































        private void GiveAccess(Card card_)
        {
            //Card localCard = new Card();
            //for(int i = 0; i < pyramid.Length; i++)
            //{
            //    for (int j = 0; j <= i; j++)
            //    {
            //        if (card_.cardValue == pyramid[i][j].cardValue && card_.cardSuit == pyramid[i][j].cardSuit)
            //            pyramid[i][j] =;
            //    }
            //}            //for (int i = 0; i < pyramid.Length; i++)
            //{
            for (int i = 0; i < pyramid.Length; i++)
            {
                for (int j = 0; j <= /*pyramid[*/i/*].Length*/; j++)
                {
                    if (card_.cardValue == pyramid[i][j].cardValue && card_.cardSuit == pyramid[i][j].cardSuit)
                    {
                        if (i == 0 && j == 0)
                        {
                            //вызвать окно "Вы победили! и кнопку ок или начать заново"
                            break;
                        }
                        if (j == i)
                        {
                            if (pyramid[i][j - 1].cardIsDelete == true)
                            {
                                pyramid[i - 1][j - 1].cardFrontClickable = true;
                                Trace.WriteLine("if (j == i)");
                                Trace.WriteLine($"{pyramid[i - 1][j - 1].cardValue} {pyramid[i - 1][j - 1].cardSuit}  card is Open");

                            }
                        }
                        else if (j == 0)
                        {
                            if (pyramid[i][j + 1].cardIsDelete == true)
                            {
                                pyramid[i - 1][j].cardFrontClickable = true;

                                Trace.WriteLine("if (j == 0)");
                                Trace.WriteLine($"{pyramid[i - 1][j].cardValue} {pyramid[i - 1][j].cardSuit}  card is Open");

                            }
                        }
                        else
                        {
                            if (pyramid[i][j + 1].cardIsDelete == true && pyramid[i][j].cardIsDelete == true)
                            {
                                pyramid[i - 1][j].cardFrontClickable = true;
                                //pyramid[i - 1][j - 1].cardFrontClickable = true;
                                //pyramid[i - 1][j + 1].cardFrontClickable = true;

                                Trace.WriteLine("1.else (pyramid[i][j+1].cardIsDelete == true)");
                                Trace.WriteLine($"{pyramid[i - 1][j].cardValue} {pyramid[i - 1][j].cardSuit} card is Open");
                                //Trace.WriteLine($"{pyramid[i - 1][j + 1].cardValue} {pyramid[i - 1][j + 1].cardSuit} card is Open");
                                //Trace.WriteLine($"{pyramid[i - 1][j - 1].cardValue} {pyramid[i - 1][j - 1].cardSuit} card is Open");

                            }
                            if (pyramid[i][j - 1].cardIsDelete == true && pyramid[i][j].cardIsDelete == true)
                            {
                                pyramid[i - 1][j - 1].cardFrontClickable = true;

                                Trace.WriteLine("2.else (pyramid[i][j - 1].cardIsDelete == true)");
                                Trace.WriteLine($"{pyramid[i - 1][j - 1].cardValue} {pyramid[i - 1][j - 1].cardSuit} card is Open");

                            }
                        }


                    }
                    //Trace.WriteLine($"j = {j}");
                }
                //Trace.WriteLine($"i = {i}");
            }
        }
            
        
    

        private void DeleteCardFromPyramid(Card card_)
        {
            foreach (Card[] row in pyramid)
            {
                foreach (Card card in row)
                {
                    if (card == card_)
                    {
                        card.cardVisual = false;
                        card.cardIsDelete = true;
                        card.cardFrontClickable = false;
                        Trace.WriteLine($"{card.cardValue} is Delete");
                        GiveAccess(card);
                    }
                        
                }
            }
        }






































        private void RulesClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Texts.rules);

        }
    }
}


















