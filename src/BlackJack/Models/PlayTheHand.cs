using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BlackJack.Models
{
    public class PlayTheHand
    {
        List<Card>MyHand = new List<Card>();  //Create a list to hold the hand
        private int MinCardTotal;
        private int MaxCardTotal;
        public int CardTotal;
        public Card newCard { get; set; }
        public string question;
        public string gameStage { get; set; }  //possible values are 'player', 'dealer', and 'handOver'
        public bool letsPlayBlackJack;
        public bool playerWantsAHit;
        public string keepGoing { get; set; }
        public DeckOfCards cardDeck { get; set;  }

        public void NewGame()  // fire up the console
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Let's play Blackjack!!");
            Console.WriteLine();
            Console.WriteLine("Hit enter to continue...");
            keepGoing = Console.ReadLine();
        }


        public string StartTheHand(string participant)  //deal the first two cards
        {
            gameStage = participant;
            GetACard();
            var card1 = newCard;
            GetACard();
            var card2 = newCard;
            Console.WriteLine("Here are the first two cards which have a total of " + CardTotal);
            Console.WriteLine(card1 + " and " + card2);
            Console.WriteLine("Hit enter to continue...");
            keepGoing = Console.ReadLine();
            return participant;
        }


        public string DecideNextPlayerMove()
        {   
            if (CardTotal > 21)
            {
                Console.WriteLine("You busted!!  I win!");
                Console.WriteLine("Hit enter to continue...");
                keepGoing = Console.ReadLine();
                gameStage = "handOver";                
            }  else
            {
                if (CardTotal == 21)
                {
                    Console.WriteLine("You win!!");
                    Console.WriteLine("Hit enter to continue...");
                    keepGoing = Console.ReadLine();
                    gameStage = "handOver";
                }
                else
                {
                    playerWantsAHit = true;
                    OfferPlayerAHit();
                }
            }
            return gameStage;
        }


        public string DecideNextDealerMove(int playerCardTotal)
        {
            if (CardTotal < playerCardTotal)
            {
                GetACard();
                Console.WriteLine("Here is my next card: " + newCard);
                Console.WriteLine("I now have a total of " + CardTotal);
                Console.WriteLine("Hit enter to continue...");
                keepGoing = Console.ReadLine();
            };

            if (CardTotal > 21)
            {
                Console.WriteLine("I busted!! You win!!");
                Console.WriteLine("Hit enter to continue...");
                keepGoing = Console.ReadLine();
                gameStage = "handOver";
            }
            else
            {
                if (CardTotal >= playerCardTotal)
                {
                    Console.WriteLine("I Win!!");
                    Console.WriteLine("Hit enter to continue...");
                    keepGoing = Console.ReadLine();
                    gameStage = "handOver";
                }
            }
            return gameStage;
        }


        public string GetACard()  //get the next card from the deck and add the card totals. Return the 'best' total
        {
            newCard = cardDeck.Deal1Card();
            MyHand.Add(newCard);
            MinCardTotal = 0;
            MaxCardTotal = 0;
            foreach (var card in MyHand)
            {
                MinCardTotal += card.rankValue;
                if (card.rank == "Ace")
                {
                    MaxCardTotal = MinCardTotal + 10;
                } else {                 
                    MaxCardTotal = MinCardTotal;
                }
            }
            if (MaxCardTotal < 22)
            {
                CardTotal = MaxCardTotal;
            }   else {
                CardTotal = MinCardTotal;
            }
            return CardTotal.ToString();
        }


        public string playerResponse;  
        //prompt the player for input and capture the response
        public string AskPlayerForNextMove(string question)
        {
            var WaitingForResponse = true;
            while (WaitingForResponse) {
                Console.WriteLine();
                Console.Write(question);
                playerResponse = Console.ReadLine();
                playerResponse = playerResponse.ToLower();
                if (playerResponse == "y" || playerResponse == "n") 
                {
                    WaitingForResponse = false;
                }
            };
            return playerResponse;
        }

        public void OfferPlayerAHit()
        {
            while (playerWantsAHit)
            {
                var question = "Would you like another card?  y or n:  ";
                AskPlayerForNextMove(question);
                if (playerResponse == "y")
                {
                    //deal another card
                    GetACard();
                    if (CardTotal > 21)
                    {
                        playerWantsAHit = false;
                    }
                    Console.WriteLine("Here is your next card: " + newCard);
                    Console.WriteLine("You now have a total of " + CardTotal);
                    Console.WriteLine("Hit enter to continue...");
                    keepGoing = Console.ReadLine();
                }  else
                {
                    playerWantsAHit = false;
                    gameStage = "dealer";
                }
            }
            
        }

        //The constructor
        public PlayTheHand(DeckOfCards cardDeck)
        {
            this.cardDeck = cardDeck;
        } 
    }
}
