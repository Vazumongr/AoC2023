using System;
using System.IO;

namespace AoC2023
{
    public class Globals
    {
        public static string workingDirectory = Environment.CurrentDirectory;
        public static string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
        public static string inputDirectory = projectDirectory+"/Inputs/";

        public static string[] GetInput(string fileName)
        {
            return File.ReadAllLines(inputDirectory + fileName);
        }
        
        public static void TimeTest(Action<string[]> function, string[] input)
        {
            DateTime start = DateTime.Now;
            function(input);
            Console.WriteLine(DateTime.Now - start);
        }
    }
}