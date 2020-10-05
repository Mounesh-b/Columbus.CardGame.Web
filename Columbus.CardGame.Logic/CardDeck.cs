using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Columbus.CardGame.Logic
{
    //Class for Card deck information
    public class CardDeck 
    {
        //stores the the cards
        public List<Card> Cards = new List<Card>();

        //Used for the player to store the recent card added
        public Card LatestCard = new Card();

        //Prameterless constructor
        public CardDeck()
        {
            //var deck = CreateDeck();
            //Cards = deck.Cards;
        }

        //Constructor with parameters
        public CardDeck(List<Card> cardList)
        {
            Cards = cardList;

        }

        //Create the new deck order by Value & Shades 
        public CardDeck CreateDeck(CardDeck deck)
        {
            //deck.Cards.Clear();
            //Create the new deck order by Value & Shades 
            for (int value = 1; value <= 13; value++)
            {
                for (int shade = 1; shade <= 4; shade++)
                {
                    this.Cards.Add(new Card(value, shade));
                }
            }

            return this;
        }

        //Create the new deck order by Value & Shades 
        //This takes number of decks parameter to create a deck combined by multiple decks 
        public CardDeck CreateDeck(CardDeck deck, int numberOfDecks)
        {
            //Clear the deck
            this.Cards.Clear();
            //deck.Cards.Clear();

            //Create the new deck order by Value & Shades 
            for (int noOfDeck = 0; noOfDeck < numberOfDecks; noOfDeck++)
            {
                for (int value = 1; value <= 13; value++)
                {
                    for (int shade = 1; shade <= 4; shade++)
                    {
                        this.Cards.Add(new Card(value, shade));
                    }
                }
            }

            return this;
        }

        //Shuffle the Deck
        public CardDeck ShuffleDeck(CardDeck deck)
        {

            CardDeck newDeck = new CardDeck();
            int noOfCards = deck.Cards.Count;
            for (int cardNo = 0; cardNo < noOfCards; cardNo++)
            {
                try
                {
                    Random random = new Random();
                    int randomIndex = random.Next(0, deck.Cards.Count);

                    newDeck.Cards.Add(deck.Cards[randomIndex]);
                    deck.Cards.RemoveAt(randomIndex);
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }


            return newDeck;
        }

        //Sort the Deck by Shades & Value 
        public CardDeck SortDeck(CardDeck deck)
        {
            //Order by Shades & then by Value
            deck.Cards = deck.Cards.OrderBy(s => s.CardShade).ThenBy(v => v.CardValue).ToList();

            return deck;
        }

        //Pull a card from deck, last card will be pulled from the deck (shuffled)
        public Card PullACardFromDeck(CardDeck deck)
        {
            int lastCard = deck.Cards.Count - 1;

            Card card = deck.Cards[lastCard];
            deck.Cards.RemoveAt(lastCard);

            return card;
        }
    }
}

