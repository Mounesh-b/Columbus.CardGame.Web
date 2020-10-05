using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Columbus.CardGame.Logic
{
    //Not used, can be used firther extension of the Game
    interface ICardDeck
    {
        CardDeck CreateDeck();

        CardDeck ShuffleDeck();

        CardDeck SortDeck();
    }
}
