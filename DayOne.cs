using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace AoC2023
{
    public class DayOne
    {
        public static void Run()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            //string[] inputs = File.ReadAllLines(projectDirectory+"/Inputs/DayOne.txt");
            string[] inputs = Globals.GetInput("DayOne.txt");
            
            List<int> finalNumbers = new List<int>();
            int sum = 0;

            Dictionary<string, int> stringIntMapping = new Dictionary<string, int>()
            {
                {"one", 1},
                {"two", 2},
                {"three", 3},
                {"four", 4},
                {"five", 5},
                {"six", 6},
                {"seven", 7},
                {"eight", 8},
                {"nine", 9},
                {"1", 1},
                {"2", 2},
                {"3", 3},
                {"4", 4},
                {"5", 5},
                {"6", 6},
                {"7", 7},
                {"8", 8},
                {"9", 9},
            };

            foreach (string input in inputs)
            {
                List<char> numbers = new List<char>();
                int firstIdx = input.Length;
                int firstValue = 0; 
                int lastIdx = -1;
                int lastValue = 0;
                // Find first number
                foreach (var pair in stringIntMapping)
                {
                    int fIdx = input.IndexOf(pair.Key);
                    int lIdx = input.LastIndexOf(pair.Key);
                    if (fIdx < firstIdx && fIdx >= 0)
                    {
                        firstIdx = fIdx;
                        firstValue = pair.Value;
                    }

                    if (lIdx > lastIdx && lIdx >= 0)
                    {
                        lastIdx = lIdx;
                        lastValue = pair.Value;
                    }
                }

                sum += (firstValue * 10) + lastValue;
                Console.Out.WriteLine(firstValue + ", " + lastValue + ", " + sum);


                /*
                foreach (char character in input)
                {
                    if (Char.IsNumber(character))
                    {
                        numbers.Add(character);
                    }
                }

                string numStr = numbers[0].ToString() + numbers[numbers.Count - 1].ToString();

                int value = Int32.Parse(numStr);
                sum += value;
                finalNumbers.Add(value);
                Console.Out.WriteLine(sum);
                */
            }
        }
    }
}