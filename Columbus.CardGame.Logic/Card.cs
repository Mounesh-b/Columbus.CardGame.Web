using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Columbus.CardGame.Logic
{
    //Class to store a card information
    public class Card
    {
        //Prameterless constructor
        public Card()            
        {

        }

        //Prameterless constructor
        public Card(int cardNo, int cardShade)
        {

            CardValue = cardNo;
            CardShade = cardShade;
        }

        public int CardValue { get; set; }

        public int CardShade { get; set; }

    }
}
