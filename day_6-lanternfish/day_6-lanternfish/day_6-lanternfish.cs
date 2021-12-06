using System;
using System.Collections.Generic;

namespace day_6_lanternfish
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lanternfishData = ParseInput(InputString());

            // hard coded for 256 days for the problem, previously was 80
            // should be dynamic
            for (int day = 0; day < 256; day++)
            {
                int newLanternfishCount = 0;
                // iterate through lantern fish, checking for spawning
                for (int x = 0; x < lanternfishData.Count; x++)
                {
                    if (lanternfishData[x] == 0)
                    {
                        lanternfishData[x] = 6;
                        // tally respawn, will add at end of day
                        newLanternfishCount += 1; 
                    }
                    else
                    {
                        lanternfishData[x] -= 1;

                    }
                }
                for (int x = 0; x < newLanternfishCount; x++)
                {
                    lanternfishData.Add(8);
                }
            }
            Console.WriteLine(lanternfishData.Count);
        }
        public static List<int> ParseInput(string inputString)
        {
            List<int> parsedList = new List<int>();
            string[] arrayOfDigits = inputString.Split(",");
            foreach (string digit in arrayOfDigits)
            {
                parsedList.Add(Int32.Parse(digit));
            }
            return parsedList;
        }

        public static string InputString()
        {
            return "2,4,1,5,1,3,1,1,5,2,2,5,4,2,1,2,5,3,2,4,1,3,5,3,1,3,1,3,5,4,1,1,1,1,5,1,2,5,5,5,2,3,4,1,1,1,2,1,4,1,3,2,1,4,3,1,4,1,5,4,5,1,4,1,2,2,3,1,1,1,2,5,1,1,1,2,1,1,2,2,1,4,3,3,1,1,1,2,1,2,5,4,1,4,3,1,5,5,1,3,1,5,1,5,2,4,5,1,2,1,1,5,4,1,1,4,5,3,1,4,5,1,3,2,2,1,1,1,4,5,2,2,5,1,4,5,2,1,1,5,3,1,1,1,3,1,2,3,3,1,4,3,1,2,3,1,4,2,1,2,5,4,2,5,4,1,1,2,1,2,4,3,3,1,1,5,1,1,1,1,1,3,1,4,1,4,1,2,3,5,1,2,5,4,5,4,1,3,1,4,3,1,2,2,2,1,5,1,1,1,3,2,1,3,5,2,1,1,4,4,3,5,3,5,1,4,3,1,3,5,1,3,4,1,2,5,2,1,5,4,3,4,1,3,3,5,1,1,3,5,3,3,4,3,5,5,1,4,1,1,3,5,5,1,5,4,4,1,3,1,1,1,1,3,2,1,2,3,1,5,1,1,1,4,3,1,1,1,1,1,1,1,1,1,2,1,1,2,5,3";
        }
    }
}
