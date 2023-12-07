using System;
using System.Collections.Generic;

namespace AoC2023
{
    public class Gear
    {
        public bool bValidGear = false;
        public int gearRowIdx = 0;
        public int gearColIdx = 0;
    }
    public class DayThree
    {
        public static void Run()
        {
            RunNumberFirst();
            //RunSymbolFirst();
        }
        
        public static void RunNumberFirst()
        {
            string[] rows = Globals.GetInput("DayThree.txt");
            int partSum = 0;
            int ratioSum = 0;

            Dictionary<Tuple<int, int>, List<string>> gearRatios = new Dictionary<Tuple<int, int>, List<string>>();

            for (int rowIdx = 0; rowIdx < rows.Length; ++rowIdx)
            {
                string row = rows[rowIdx];
                int upIdx = Math.Max(0, rowIdx - 1);
                int downIdx = Math.Min(rows.Length - 1, rowIdx + 1);
                string currentNumber = "";
                bool bValidNumber = false;
                Gear gear = new Gear();
                for (int colIdx = 0; colIdx < row.Length; ++colIdx)
                {
                    char val = row[colIdx];
                    int leftIdx = Math.Max(0, colIdx - 1);
                    int rightIdx = Math.Min(row.Length - 1, colIdx + 1);
                    if (Char.IsNumber(val))
                    {
                        currentNumber += val;
                        /*
                        if (ValidChar(rows[upIdx][colIdx])      // Check 8
                            || ValidChar(rows[downIdx][colIdx]) // Check 2
                            || ValidChar(rows[rowIdx][leftIdx]) // Check 4
                            || ValidChar(rows[rowIdx][rightIdx]) // Check 6
                            || ValidChar(rows[downIdx][leftIdx]) // Check 1
                            || ValidChar(rows[downIdx][rightIdx]) // Check 3
                            || ValidChar(rows[upIdx][leftIdx]) // Check 7
                            || ValidChar(rows[upIdx][rightIdx]) // Check 9
                            )
                        */
                        if (ValidChar(rows, upIdx, colIdx, gear)      // Check 8
                            || ValidChar(rows, downIdx, colIdx, gear) // Check 2
                            || ValidChar(rows, rowIdx, leftIdx, gear) // Check 4
                            || ValidChar(rows, rowIdx, rightIdx, gear) // Check 6
                            || ValidChar(rows, downIdx, leftIdx, gear) // Check 1
                            || ValidChar(rows, downIdx, rightIdx, gear) // Check 3
                            || ValidChar(rows, upIdx, leftIdx, gear) // Check 7
                            || ValidChar(rows, upIdx, rightIdx, gear) // Check 9
                           )
                        {
                            bValidNumber = true;
                        }
                    }
                    else
                    {
                        if (bValidNumber)
                        {
                            Console.Out.WriteLine(currentNumber);
                            partSum += int.Parse(currentNumber);
                            if (gear.bValidGear)
                            {
                                var tuple = Tuple.Create(gear.gearRowIdx, gear.gearColIdx);
                                if (!gearRatios.ContainsKey(tuple))
                                {
                                    gearRatios.Add(tuple, new List<string>());
                                }
                                gearRatios[tuple].Add(currentNumber);
                            }
                        }
                        gear = new Gear();
                        currentNumber = "";
                        bValidNumber = false;
                    }
                }
                if (bValidNumber)
                {
                    Console.Out.WriteLine(currentNumber);
                    partSum += int.Parse(currentNumber);
                    if (gear.bValidGear)
                    {
                        var tuple = Tuple.Create(gear.gearRowIdx, gear.gearColIdx);
                        if (!gearRatios.ContainsKey(tuple))
                        {
                            gearRatios.Add(tuple, new List<string>());
                        }
                        gearRatios[tuple].Add(currentNumber);
                    }
                }
                //gear = new Gear();
                //currentNumber = "";
                //bValidNumber = false;
            }

            foreach (var shit in gearRatios)
            {
                var gearCords = shit.Key;
                List<string> nums = shit.Value;
                if (nums.Count == 2)
                {
                    ratioSum += int.Parse(nums[0]) * int.Parse(nums[1]);
                }
            }
            Console.Out.WriteLine(partSum);
            Console.Out.WriteLine(ratioSum);
        }
        
        /*
        public static void RunSymbolFirst()
        {
            string[] rows = Globals.GetInput("DayThree.txt");

            for (int rowIdx = 0; rowIdx < rows.Length; ++rowIdx)
            {
                string row = rows[rowIdx];
                int upIdx = Math.Max(0, rowIdx - 1);
                int downIdx = Math.Min(rows.Length, rowIdx + 1);
                for (int colIdx = 0; colIdx < row.Length; ++colIdx)
                {
                    char col = row[colIdx];
                    if (ValidChar(col))
                    {
                        // Check surrounding for numbers
                        int leftIdx = Math.Max(0, colIdx - 1);
                        int rightIdx = Math.Min(row.Length, colIdx + 1);
                        char left = row[leftIdx];
                        char right = row[rightIdx];
                    }
                }
            }
        }
        */

        //private static bool ValidChar(char character, Gear outGear)
        private static bool ValidChar(string[] rows, int rowIdx, int colIdx, Gear outGear)
        {
            char character = rows[rowIdx][colIdx];
            if (character != '.' && !Char.IsNumber(character))
            {
                if (character == '*')
                {
                    outGear.bValidGear = true;
                    outGear.gearRowIdx = rowIdx;
                    outGear.gearColIdx = colIdx;
                }
                return true;
            }
            return false;
            //return (character != '.' && !Char.IsNumber(character));
            //return character == '*';
        }
    }
}