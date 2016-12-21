using BlackJack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Program
    {
        

        public static void Main(string[] args)
        {
            var gameStage = "";
            var cardDeck = new DeckOfCards();


            while (gameStage != "gameOver")
            {
                cardDeck.ShuffleTheDeck();
                var player = new PlayTheHand(cardDeck);
                player.NewGame();   //fire up the console
                gameStage = (player.StartTheHand("player"));  //get the first 2 cards
                while (gameStage == "player")
                {
                    gameStage = (player.DecideNextPlayerMove());
                }
                
                if (gameStage == "handOver")
                {
                    continue;
                }   else
                {
                    var dealer = new PlayTheHand(cardDeck);
                    Console.WriteLine();
                    Console.WriteLine("OK, now it's my turn.");
                    Console.WriteLine("Hit enter to continue...");
                    Console.ReadLine();
                    dealer.StartTheHand("dealer");
                    while (gameStage != "handOver")
                    {
                        gameStage = (dealer.DecideNextDealerMove(player.CardTotal));
                    }
                }
                
            }
        }
    }
}
