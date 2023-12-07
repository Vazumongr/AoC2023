using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;

namespace AoC2023
{
    public class DayTwo
    {
        public static void Run()
        {
            int idSum = 0;
            int powerSum = 0;
            string[] games = Globals.GetInput("DayTwo.txt");
            
            Dictionary<string, int> colorLimits = new Dictionary<string, int>()
            {
                {"red", 12},
                {"green", 13},
                {"blue", 14},
            };

            foreach (string game in games)
            {
                string[] firstSplit = game.Split(':');
                string gameIdStr = firstSplit[0].Split(' ')[1];
                int gameId = int.Parse(gameIdStr);
                bool bBreak = false;

                Dictionary<string, int> colorMaxes = new Dictionary<string, int>()
                {
                    {"red", 0},
                    {"green", 0},
                    {"blue", 0},
                };

                string[] rounds = firstSplit[1].Split(';');
                foreach (string round in rounds)
                {
                    string[] counts = round.Split(',');
                    foreach (string count in counts)
                    {
                        string[] vals = count.Trim().Split(' ');
                        int num = int.Parse(vals[0]);
                        colorMaxes[vals[1]] = Math.Max(num, colorMaxes[vals[1]]);
                        
                        /** Color Limit **/
                        /*
                        if (int.Parse(vals[0]) > colorLimits[vals[1]])
                        {
                            bBreak = true;
                            break;
                        }
                        */
                    }
                    //if (bBreak) break;
                }
                //if (bBreak) continue;

                //idSum += gameId;
                int product = 1;
                foreach (int max in colorMaxes.Values)
                {
                    product *= max;
                }

                powerSum += product;
            }
            Console.Out.WriteLine(powerSum);
        }
    }
}