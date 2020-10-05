using Columbus.CardGame.Logic;
using Columbus.CardGame.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Columbus.CardGame.Web.Controllers
{
    //This controller handles the Card Game 
    public class GameController : Controller
    {

        public bool isShuffle = false;
        public bool isRestart = false;

        [HttpGet]
        public ActionResult Index()
        {
            GameModel model = new GameModel();
            Session["OriginalDeck"] = model.OriginalDeck;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            GameModel model = new GameModel();
            try
            {
                if (form != null)
                {
                    int numberOfDecks = Convert.ToInt32(form["NoOfDecks"]);
                    Session["NoOfDecks"] = numberOfDecks;
                    model.NoOfDecks = numberOfDecks;
                }

                Session["OriginalDeck"] = model.OriginalDeck;
                Session["Player1Deck"] = model.Player1Deck;
                Session["Player2Deck"] = model.Player2Deck;

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return View(model);
        }

        //This methid is to Start the game 
        //Create a deck & shuffle, Update the sesssion object
        [HttpPost]
        public ActionResult StartGame(FormCollection form)
        {
            GameModel model = new GameModel();

            try
            {
                if (form != null)
                {
                    int numberOfDecks = Convert.ToInt32(form["NoOfDecks"]);
                    Session["NoOfDecks"] = numberOfDecks;
                    model.NoOfDecks = numberOfDecks;

                    if (numberOfDecks > 0)
                    {
                        model.OriginalDeck = model.OriginalDeck.CreateDeck(model.OriginalDeck, numberOfDecks);
                        model.OriginalDeck = model.OriginalDeck.ShuffleDeck(model.OriginalDeck);
                    }
                    else
                    {
                        numberOfDecks = 1;

                        model.OriginalDeck = model.OriginalDeck.CreateDeck(model.OriginalDeck, numberOfDecks);
                        model.OriginalDeck = model.OriginalDeck.ShuffleDeck(model.OriginalDeck);
                    }
                }

                Session["OriginalDeck"] = model.OriginalDeck;
                
                //Clear the player decks
                model.Player1Deck.Cards.Clear();
                model.Player1Deck.LatestCard.CardValue = 0;
                model.Player2Deck.Cards.Clear();
                model.Player2Deck.LatestCard.CardValue = 0;
                Session["Player1Deck"] = model.Player1Deck;
                Session["Player2Deck"] = model.Player2Deck;

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return View(model);
        }


        //This method handles the game if the action is to Shuffle the cards or Restart the Game
        [HttpGet]
        public ActionResult Game()
        {
            GameModel model = new GameModel();
            ViewBag.Message = "Game page.";
            try
            {
                if (Session["isShuffle"] != null)
                {
                    isShuffle = (bool)Session["isShuffle"];
                }
                if (Session["isRestart"] != null)
                {
                    isRestart = (bool)Session["isRestart"];
                }
                
                if (isShuffle || isRestart)
                {
                    //Dont process card
                    Session["OriginalDeck"] = model.OriginalDeck;
                    Session["Player1Deck"] = model.Player1Deck;
                    Session["Player2Deck"] = model.Player2Deck;

                    Session["isShuffle"] = false;
                    Session["isRestart"] = false;
                    isShuffle = false;
                    isRestart = false;
                }
                else
                {

                    Session["OriginalDeck"] = model.OriginalDeck;
                    Session["Player1Deck"] = model.Player1Deck;
                    Session["Player2Deck"] = model.Player2Deck;

                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

            return View(model);
        }

        //This method handles the game
        //If teh action is to pull the, it gets a card from deck and adds to the players deck
        [HttpPost]
        public ActionResult Game(GameModel model)
        {
            ViewBag.Message = "Game page.";

            if(Session["isShuffle"] != null)
            {
                isShuffle = (bool)Session["isShuffle"];
            }
            if (Session["isRestart"] != null)
            {
                isRestart = (bool)Session["isRestart"];
            }
            
            
            if (isShuffle || isRestart)
            {
                //Dont process card
                Session["isShuffle"] = false;
                Session["isRestart"] = false;
            }
            else
            {
                isShuffle = false;
                CardDeck cardDeck = model.OriginalDeck;
                try
                {
                    Session["OriginalDeck"] = model.OriginalDeck;
                    Session["OriginalDeck"] = model.OriginalDeck;
                    Session["Player1Deck"] = model.Player1Deck;
                    Session["Player2Deck"] = model.Player2Deck;
                    Card card = cardDeck.PullACardFromDeck(cardDeck);
                    AddCardToPlayer(model.Player1Deck, card);
                    Session["OriginalDeck"] = model.OriginalDeck;
                    Session["Player1Deck"] = model.Player1Deck;
                    Session["Player2Deck"] = model.Player2Deck;

                    Session["NoOfDecks"] = model.NoOfDecks;
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }

            return View(model);
        }


        //Restart the game
        [HttpPost]
        public ActionResult RestartGame(FormCollection form)
        {
            GameModel model = new GameModel();
            try
            {
                if (form != null)
                {
                    if (Session["NoOfDecks"] != null)
                    {
                        int numberOfDecks = Convert.ToInt32(Session["NoOfDecks"]);
                        Session["NoOfDecks"] = numberOfDecks;
                        model.NoOfDecks = numberOfDecks;

                        if (numberOfDecks > 1)
                        {
                            model.OriginalDeck = model.OriginalDeck.CreateDeck(model.OriginalDeck, numberOfDecks);
                            model.OriginalDeck = model.OriginalDeck.ShuffleDeck(model.OriginalDeck);

                            Session["OriginalDeck"] = model.OriginalDeck;
                        }
                        else
                        {
                            numberOfDecks = 1;
                            Session["NoOfDecks"] = numberOfDecks;
                            model.OriginalDeck = model.OriginalDeck.CreateDeck(model.OriginalDeck, numberOfDecks);
                            model.OriginalDeck = model.OriginalDeck.ShuffleDeck(model.OriginalDeck);
                            Session["OriginalDeck"] = model.OriginalDeck;
                        }
                    }
                    else
                    {
                        //
                    }
                }

                //Clear the player decks
                model.Player1Deck.Cards.Clear();
                model.Player1Deck.LatestCard.CardValue = 0;
                model.Player2Deck.Cards.Clear();
                model.Player2Deck.LatestCard.CardValue = 0;
                Session["Player1Deck"] = model.Player1Deck;
                Session["Player2Deck"] = model.Player2Deck;

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

            Session["isRestart"] = true;
            return RedirectToAction("Game");
        }

        //Restart the Game
        [HttpPost]
        public ActionResult ShuffleDeck(FormCollection form)
        {
            GameModel model = new GameModel();
            try
            {
                if (form != null)
                {
                    if (Session["OriginalDeck"] != null)
                    {
                        CardDeck deck = model.OriginalDeck;
                        model.OriginalDeck = (CardDeck)Session["OriginalDeck"];
                        model.OriginalDeck = model.OriginalDeck.ShuffleDeck(model.OriginalDeck);
                        Session["OriginalDeck"] = model.OriginalDeck;
                        Session["Player1Deck"] = model.Player1Deck;
                        Session["Player2Deck"] = model.Player2Deck;
                    }
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

            Session["isShuffle"] = true;
            return RedirectToAction("Game");
        }

        //This method adds the pulled card to the player's deck 
        //Set the latest added card and Sort the Player cards
        public CardDeck AddCardToPlayer(CardDeck cardDeck, Card card)
        {
            cardDeck.Cards.Add(card);
            cardDeck.LatestCard = card;
            cardDeck.SortDeck(cardDeck);
            return cardDeck;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}