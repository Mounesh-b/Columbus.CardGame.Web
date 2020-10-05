using Columbus.CardGame.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Columbus.CardGame.Web.Models
{
    //Model to store the required objects for the game
    public class GameModel
    {
        //Number of decks used for the game
        public int NoOfDecks { get; set; }

        //Deck contains cards & loaded initially
        public CardDeck OriginalDeck { get; set; }

        //Deck to store Player1 cards
        public CardDeck Player1Deck { get; set; }

        //Deck to store Player2 cards
        public CardDeck Player2Deck { get; set; }

        public GameModel()
        {
            HttpContext context = HttpContext.Current;
            

            if (context.Session["OriginalDeck"] == null)
            {
                
                OriginalDeck = new CardDeck();
                Player1Deck = new CardDeck();
                Player2Deck = new CardDeck();
                if (context.Session["NoOfDecks"] != null)
                {
                    NoOfDecks = Convert.ToInt32(context.Session["NoOfDecks"]);
                    
                }
                else
                {
                    NoOfDecks = 1;
                    context.Session["NoOfDecks"] = 1;
                }

                OriginalDeck = OriginalDeck.CreateDeck(OriginalDeck, NoOfDecks);
                OriginalDeck = OriginalDeck.ShuffleDeck(OriginalDeck);

            }
            else
            {
                
                OriginalDeck = (CardDeck)(context.Session["OriginalDeck"]);
                 
                if((CardDeck)context.Session["Player1Deck"] != null)
                {
                    Player1Deck = (CardDeck)(context.Session["Player1Deck"]);
                }
                else
                {
                    Player1Deck = new CardDeck();
                    context.Session["Player1Deck"] = Player1Deck;

                }

                if ((CardDeck)context.Session["Player2Deck"] != null)
                {
                    Player2Deck = (CardDeck)(context.Session["Player2Deck"]);                    
                }
                else
                {
                    Player2Deck = new CardDeck();
                    context.Session["Player2Deck"] = Player2Deck;
                }

                if (context.Session["NoOfDecks"] != null)
                {
                    NoOfDecks = Convert.ToInt32(context.Session["NoOfDecks"]);

                }
                else
                {
                    NoOfDecks = 1;
                    context.Session["NoOfDecks"] = 1;
                }
            }
            

        }

       
    }
}