using System;
using System.Linq;

namespace AoC2023
{
    public class DayFour
    {
        public static void Run()
        {
            string[] cards = Globals.GetInput("DayFour.txt");

            //PartOne(cards);
            //PartTwo(cards);
            Globals.TimeTest(PartTwo, cards);
        }

        public static void PartOne(string[] input)
        {
            int cardsSum = 0;
            foreach (string card in input)
            {
                int pointValue = 1;
                //int pointScalar = 1;
                int cardValue = 0;
                string[] cardSplit = card.Trim().Split(':');
                string[] numberSplit = cardSplit[1].Trim().Split('|');
                string[] validNumbers = numberSplit[0].Trim().Split(' ');
                string[] myNumbers = numberSplit[1].Trim().Split(' ');
                foreach (string myNum in myNumbers)
                {
                    if (myNum != "" && validNumbers.Contains(myNum))
                    {
                        cardValue = pointValue;
                        pointValue *= 2;
                    }
                }
                cardsSum += cardValue;
                Console.Out.WriteLine(cardValue);
            }
            Console.Out.WriteLine(cardsSum);
        }

        public static void PartTwo(string[] input)
        {
            // Populate card counts
            int[] cardCopyCount = new int[input.Length];
            for (int i = 0; i < cardCopyCount.Length; ++i)
            {
                cardCopyCount[i] = 1;
            }
            
            // Iterate over cards
            for (int i = 0; i < input.Length; ++i)
            {
                // Iterate card cardCopyCount[i] amount of times
                for (int j = 0; j < cardCopyCount[i]; ++j)
                {
                    int offset = 1;
                    string card = input[i];
                    string[] cardSplit = card.Trim().Split(':');
                    string[] numberSplit = cardSplit[1].Trim().Split('|');
                    string[] validNumbers = numberSplit[0].Trim().Split(' ');
                    string[] myNumbers = numberSplit[1].Trim().Split(' ');
                    foreach (string myNum in myNumbers)
                    {
                        if (myNum != "" && validNumbers.Contains(myNum))
                        {
                            cardCopyCount[i + offset++]++;
                        }
                    }
                }
            }

            int totalCardCount = 0;
            for (int i = 0; i < cardCopyCount.Length; ++i)
            {
                totalCardCount += cardCopyCount[i];
            }
            Console.WriteLine(totalCardCount);
        }
    }
}