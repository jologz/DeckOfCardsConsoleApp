using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCardsConsoleApp
{
    public static class Game
    {
        public static void Start()
        {
            Console.WriteLine("***Let's deal a card - Ace high***");
            var deck = new Deck();
            deck.Shuffle();
            DealCardQuestion(deck);
        }

        static void DealCardQuestion(Deck deck)
        {
            Console.WriteLine("Deal a card? (Y)es / (N)o");
            if (Yes(Console.ReadLine()))
            {
                var thisCard = deck.DealOneCard();
                if (thisCard != null)
                {
                    Console.WriteLine("Your card: {0}", thisCard.Name);
                    DealCardQuestion(deck);
                }
                else
                {
                    NoMoreCardsOnDeck();
                }
            }
            else
            {
                ShuffleQuestion(deck);
            }
        }

        static void ShuffleQuestion(Deck deck)
        {
            Console.WriteLine("Do you want to shuffle before dealing? (Y)es / (N)o");
            if (Yes(Console.ReadLine()))
            {
                var success = deck.Shuffle();
                if (success)
                {
                    Console.WriteLine("The remaining cards are shuffled.");
                    DealCardQuestion(deck);
                }
                else
                {
                    NoMoreCardsOnDeck();
                }
            }
            else
            {
                QuitOrRestartQuestion();
            }
        }

        static void QuitOrRestartQuestion()
        {
            Console.WriteLine("Do you want to quit / restart? (Q)uit / (R)estart");
            if (string.Equals("R", Console.ReadLine()?.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Restarting...");
                Console.WriteLine("\n\n\n");
                Start();
            }
            else
            {
                Console.WriteLine("Game Over");
                Console.ReadLine();
            }
        }

        static void NoMoreCardsOnDeck()
        {
            Console.WriteLine("No more cards on deck.");
            QuitOrRestartQuestion();
        }

        static bool Yes(string answer)
        {
            return string.Equals("Y", answer?.Trim(), StringComparison.OrdinalIgnoreCase);
        }
    }
}
