using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    public class Card
    {
        public string rank { get; set; }
        public string suit { get; set; } 
        public int rankIndex { get; set; }
        public int suitIndex { get; set; }


        // set the card's rank and suit
        public Card(string cardRank, string cardSuit, int rIndex, int sIndex)
        {
            rank = cardRank; 
            suit = cardSuit; 
            rankIndex = rIndex;
            suitIndex = sIndex;
        } 


        public string Rank { get
            {
             return rank;
            }
        } 

        public string Suit { get
            {
                return suit;
            }
        } 


        // Read-Only rankValue property
        public int rankValue
        {
            get
            {
                if (rankIndex >= 10)
                    return 10;
                else
                    return rankIndex + 1;
            }
        } 


        // return String representation of Card
        public override String ToString()
        {
            return Rank + " of " + Suit;
        } 
    }
}
