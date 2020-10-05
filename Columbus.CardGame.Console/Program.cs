using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Columbus.CardGame.Logic;
using cons = System.Console;

namespace Columbus.CardGame.Console
{
    //This console application is used verify the application functionality 
    //Further implementation is done in ASP.NET MVC web application

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CardDeck deck = new CardDeck();

                //Create a new deck
                deck = deck.CreateDeck(deck);
                cons.WriteLine(" New deck");
                DisplayDesk(deck);

                //Shuffle the deck
                deck = deck.ShuffleDeck(deck);
                cons.WriteLine(" Shuffled deck");
                DisplayDesk(deck);

                //Sot the deck
                deck = deck.SortDeck(deck);
                cons.WriteLine(" Sorted deck ");
                DisplayDesk(deck);

                //pull a card
                Card card = deck.PullACardFromDeck(deck);
                cons.WriteLine($" Card pulled - Value: {card.CardValue }  Shade: { card.CardShade} ");
                cons.ReadLine();

                cons.WriteLine(" Updated deck");
                DisplayDesk(deck);
                cons.ReadLine();
            }
            catch(Exception ex)
            {
                cons.WriteLine($"Error: {ex.Message.ToString()}");
            }

        }

        //Displya the cards from a deck
        static void DisplayDesk(CardDeck deck)
        {
            cons.WriteLine("****** Deck start *******");
            var cards = deck.Cards;
            for(int cardNo=0; cardNo < deck.Cards.Count; cardNo++)
            {
                try
                {
                    cons.Write($"Card value:  {cards[cardNo].CardValue.ToString()}");
                    cons.Write($" Card shade: {cards[cardNo].CardShade.ToString()}");
                    cons.WriteLine();
                }
                catch (Exception ex)
                {
                    cons.WriteLine($"Error: {ex.Message.ToString()}");
                }
            }
            cons.WriteLine("***** Deck end *****");
            cons.ReadLine();
          
        }
    }
}
