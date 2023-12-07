using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2023
{
    public class DayFive
    {
        public static void Run()
        {
            string[] input = Globals.GetInput("DayFive.txt");
            PartOne(input);
            PartTwo(input);
        }

        public static void PartOne(string[] input)
        {
            /**
             * DestinationRangeStart SourceRangeStart(Seed) RangeLength
             */
            string[] seeds = input[0].Split(':')[1].Trim().Split(' ');
            List<Tuple<long,long,long>>[] mappingFunctions = Enumerable.Range(0, 7).Select(_ => new List<Tuple<long,long,long>>()).ToArray();

            int mapFncIdx = -1;
            for (int i = 0; i < input.Length; ++i)
            {
                string line = input[i];
                if (line == "") continue;
                if (line[0] >= '0' && line[0] <= '9')
                {
                    string[] vals = line.Split(' ');
                    mappingFunctions[mapFncIdx].Add(Tuple.Create(long.Parse(vals[0]), long.Parse(vals[1]), long.Parse(vals[2])));
                }
                if (line.EndsWith(":"))
                {
                    mapFncIdx++;
                }
            }
            
            /**
             * Source value minus source range start
             * If difference is less than range - 1, it's mappable
             * Add difference to destination range start
             */

            long minLocation = long.MaxValue;

            foreach (string seed in seeds)
            {
                long seedValue = long.Parse(seed);
                foreach (List<Tuple<long,long,long>> funcs in mappingFunctions)
                {
                    foreach (Tuple<long, long, long> func in funcs)
                    {
                        long difference = seedValue - func.Item2;
                        if (difference >= 0 && difference < func.Item3)
                        {
                            seedValue = difference + func.Item1;
                            break;
                        }
                    }
                }

                minLocation = Math.Min(minLocation, seedValue);
            }
            Console.WriteLine(minLocation);
        }

        public static void PartTwo(string[] input)
        {
            
        }
    }
}