using System;
using System.Collections.Generic;
using System.Linq;

namespace DeckOfCardsConsoleApp
{
    class Deck
    {
        public Deck()
        {
            for (var i = 2; i < 15; i++)
            {
                foreach (SuitEnum suit in Enum.GetValues(typeof(SuitEnum)))
                {
                    Cards.Add(new Card
                    {
                        Value = i,
                        Suit = suit,
                        Name = GetName(i, suit)
                    });
                }
            }
        }

        public List<Card> Cards { get; } = new List<Card>();

        public bool Shuffle()
        {
            if (!Cards.Any()) return false;

            var random = new Random(DateTime.Now.Millisecond);
            for (var idx = Cards.Count - 1; idx >= 0; idx--)
            {
                var newPositionIdx = random.Next(idx + 1);
                SwapCardPosition(idx, newPositionIdx);
            }

            return true;
        }

        public Card DealOneCard()
        {
            if (!Cards.Any()) return null;

            var cardsToDeal = Cards[0];
            Cards.RemoveAt(0);
            return cardsToDeal;
        }
        
        private string GetName(int value, SuitEnum suit)
        {
            var suitName = Enum.GetName(typeof(SuitEnum), suit);

            if (value >= 2 && value <= 10)
                return $"{value} {suitName}";

            var newVal = string.Empty;
            switch (value)
            {
                case 11:
                    newVal = "J";
                    break;
                case 12:
                    newVal = "Q";
                    break;
                case 13:
                    newVal = "K";
                    break;
                case 14:
                    newVal = "A";
                    break;
            }
            return $"{newVal} {suitName}";
        }

        private void SwapCardPosition(int currentPosition, int newPosition)
        {
            var tempCard = Cards[currentPosition];
            Cards[currentPosition] = Cards[newPosition];
            Cards[newPosition] = tempCard;
        }
    }
}
