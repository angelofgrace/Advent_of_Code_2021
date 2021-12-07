using System;
using System.Collections.Generic;
using System.Linq;

namespace day_6_lanternfish
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<long, long> lanternfishData = ParseInput(InputString());

            long sum = 0;
            foreach (long value in LanternfishReproductionCycleStatus(lanternfishData).Skip(255).First().Values)
            {
                sum = (long)sum + (long)value;
            }
            Console.WriteLine(sum);

        // the commented code below is the brute force method,
        // as population grew exponentially, tracking became better implemented
        // by bracket, rather than by individual lanternfish

        /*  for (int day = 0; day < 256; day++)
            {
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
            } */
        }

        public static IEnumerable<Dictionary<long, long>> LanternfishReproductionCycleStatus(Dictionary<long, long> parsedInputDict)
        {
            while(true)
            {
                long newLanternfish = 0;
                long newCycleLanternfish = 0;
                for (int key = 0; key <= 8; key++)
                {
                    // switch statement with cases for each potential point in the cycle
                    switch (key)
                    {
                        case 0:
                            newLanternfish = parsedInputDict[0];
                            newCycleLanternfish = parsedInputDict[0];
                            parsedInputDict[0] = parsedInputDict[1];
                            break;
                        case 1:
                            parsedInputDict[1] = parsedInputDict[2];
                            break;
                        case 2:
                            parsedInputDict[2] = parsedInputDict[3];
                            break;
                        case 3:
                            parsedInputDict[3] = parsedInputDict[4];
                            break;
                        case 4:
                            parsedInputDict[4] = parsedInputDict[5];
                            break;
                        case 5:
                            parsedInputDict [5] = parsedInputDict[6];
                            break;
                        case 6:
                            parsedInputDict[6] = newCycleLanternfish + parsedInputDict[7];
                            break;
                        case 7:
                            parsedInputDict[7] = parsedInputDict[8];
                            break;
                    }
                }
                parsedInputDict[8] = newLanternfish;
                yield return parsedInputDict;
            }
        }

        public static Dictionary<long, long> ParseInput(string inputString)
        {
            Dictionary<long, long> lanternFishCount = new Dictionary<long, long>()
            {
                {0, 0},{1, 0},{2, 0},{3, 0},{4, 0},{5, 0},{6, 0},{7, 0},{8, 0}
            };
            string[] arrayOfDigits = inputString.Split(",");
            foreach (string digit in arrayOfDigits)
            {
                lanternFishCount[Int64.Parse(digit)] = lanternFishCount[Int64.Parse(digit)] + 1;
            }
            return lanternFishCount;
        }

        public static string InputString()
        {
            return "2,4,1,5,1,3,1,1,5,2,2,5,4,2,1,2,5,3,2,4,1,3,5,3,1,3,1,3,5,4,1,1,1,1,5,1,2,5,5,5,2,3,4,1,1,1,2,1,4,1,3,2,1,4,3,1,4,1,5,4,5,1,4,1,2,2,3,1,1,1,2,5,1,1,1,2,1,1,2,2,1,4,3,3,1,1,1,2,1,2,5,4,1,4,3,1,5,5,1,3,1,5,1,5,2,4,5,1,2,1,1,5,4,1,1,4,5,3,1,4,5,1,3,2,2,1,1,1,4,5,2,2,5,1,4,5,2,1,1,5,3,1,1,1,3,1,2,3,3,1,4,3,1,2,3,1,4,2,1,2,5,4,2,5,4,1,1,2,1,2,4,3,3,1,1,5,1,1,1,1,1,3,1,4,1,4,1,2,3,5,1,2,5,4,5,4,1,3,1,4,3,1,2,2,2,1,5,1,1,1,3,2,1,3,5,2,1,1,4,4,3,5,3,5,1,4,3,1,3,5,1,3,4,1,2,5,2,1,5,4,3,4,1,3,3,5,1,1,3,5,3,3,4,3,5,5,1,4,1,1,3,5,5,1,5,4,4,1,3,1,1,1,1,3,2,1,2,3,1,5,1,1,1,4,3,1,1,1,1,1,1,1,1,1,2,1,1,2,5,3";
        }
    }
}