using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    public class DeckOfCards
    { 
        public Card[] deck; // array of Card objects
        public const int NUMBER_OF_CARDS = 52; 
        public Random randomNbr; // random number generator
        public int currentCard; // index of next Card to be dealt

        //build the deck
        public DeckOfCards()
        {
            string[] ranks = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
            string[] suits = { "Clubs", "Diamonds", "Hearts", "Spades" };
            deck = new Card[NUMBER_OF_CARDS]; // create array of Card objects
            currentCard = 0; // set currentCard so first Card dealt is deck[ 0 ]
            randomNbr = new Random(); 

            // populate deck with Card objects
            for (int count = 0; count < deck.Length; count++)
                deck[count] =
                new Card(ranks[count % 13], suits[count / 13],
                count % 13, count / 13);
        } 
        
            
            public void ShuffleTheDeck()
            {
                currentCard = 0; 

                // for each Card, pick another random Card and swap them
                for (int first = 0; first < deck.Length; first++)
                {
                    // select a random number between 0 and 51
                    int second = randomNbr.Next(NUMBER_OF_CARDS);
                    // swap current Card with randomly selected Card
                    Card temp = deck[first];
                    deck[first] = deck[second];
                    deck[second] = temp;
                } 
            }

            
            public Card Deal1Card()
            {
                if (currentCard < deck.Length)
                    return deck[currentCard++]; 
                else
                    return null;
            }
        }
    }
