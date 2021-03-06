using System;
using System.Collections.Generic;

namespace Advent_of_Code_2021
{
    class GiantSquid
    {
        static void Main(string[] args)
        {
            foreach (List<Dictionary<int, bool>> bingoCard in ParseBingoCards(InputString()))
            {
                foreach (Dictionary<int, bool> line in bingoCard)
                {
                    foreach (int key in line.Keys)
                    {
                        Console.WriteLine(line[key]);
                    }
                }
            }
            // Console.WriteLine(ParseBingoNumbers(InputString()));
        }

        // parses the bingo numbers rolled from raw input
        public static List<int> ParseBingoNumbers(string rawData)
        {
            List<int> bingoNumberList = new List<int>(); 

            // split string input by newline
            string[] splitData = rawData.Split('\n');

            // split 0th string by comma
            string[] bingoNumbers = splitData[0].Split(',');
            
            // add each element to a new list
            foreach (string bingoNumber in bingoNumbers)
            {
                bingoNumberList.Add(Int32.Parse(bingoNumber));
            }
            return bingoNumberList;
        }

        // parses the numbers in bingo cards into dictionaries of dictionaries
        public static List<List<Dictionary<int, bool>>> ParseBingoCards (string rawData)
        {
            // List of bingo cards, with rows of dicts,
            // holding key value pairs of selected and unselected numbers
            List<List<Dictionary<int, bool>>> bingoCardList = new List<List<Dictionary<int, bool>>>();
            List<Dictionary<int, bool>> completeBingoCard = new List<Dictionary<int, bool>>();


            // Splitting input by newline
            string[] cardRows = rawData.Split('\n');

            // Splitting new strings by whitespace, converting to ints
            foreach (string cardRow in cardRows)
            {
                Dictionary<int, bool> bingoNumbersandStatus = new Dictionary<int, bool>();

                if (cardRow == cardRows[0] || cardRow != null)
                {
                    continue;
                }
                string[] parsedCardRow = cardRow.Split(' ');
                foreach (string number in parsedCardRow)
                {
                    // convert each element to integer, bool for selected or not
                    bingoNumbersandStatus.Add(Int32.Parse(number), false);
                }

                if (completeBingoCard.Count < 5)
                {
                    completeBingoCard.Add(bingoNumbersandStatus);
                }
                else
                {
                    bingoCardList.Add(completeBingoCard);
                    completeBingoCard.Clear();
                }
            }

            return bingoCardList;
        }

        public static string InputString()
        {
            return "94,21,58,16,4,1,44,6,17,48,20,92,55,36,40,63,62,2,47,7,46,72,85,24,66,49,34,56,98,41,84,23,86,64,28,90,39,97,73,81,12,69,35,26,75,8,32,77,52,50,5,96,14,31,70,60,29,71,9,68,19,65,99,57,54,61,33,91,27,78,43,95,42,3,88,51,53,30,89,87,93,74,18,15,80,38,82,79,0,22,13,67,59,11,83,76,10,37,25,45\n\n49 74 83 34 40\n87 16 57 75  3\n68 94 77 78 89\n56 38 29 26 60\n41 42 45 19  1\n\n42 35 10 20  9\n49 39 40 41 73\n 3 48 91 81 88\n59 55 82 58 71\n61 51 17 26 72\n\n31 49 21 84 83\n18 86 53 75 29\n85  2 51 76 52\n48 28 24 69 12\n 5 87 67 95 82\n\n54 21  0 63 13\n84 29 27 12 82\n55 86 33 90 95\n72 96 24 88 37\n38 51 35 46 50\n\n24  1 23 62 97\n53 72 99 59 81\n54 26 93 63 20\n79 41  2 86 98\n84 13 87 33 96\n\n36 85 51 32 84\n41 70 65 86 73\n94 28 80 81 59\n96 82  7 10 83\n 8 21 29 91 16\n\n56 36 87 10 35\n 8 90 37 22 96\n24 82 30 50 86\n70 52 55 51 57\n26 41 61 46 65\n\n 6 28 71 21 50\n61 92 19 17 79\n85 69 63 32 41\n 8 36 37 38 83\n13 45 88 77 78\n\n55 61 34 72 65\n 8 92 39 27 86\n69 16 66 94 53\n35 41 50  1 42\n31 43  3 85 59\n\n55 78 47 85 50\n80 15 98 42 63\n 2 68 37 24 45\n 8 99 33 89 20\n35 28 60  5 34\n\n76  4 33 91  0\n98 97 39 51  5\n43 86 58 63 93\n16 67 88 50 19\n 2 68 17 26 89\n\n20 57 93 41 35\n76  7 14 58 54\n85 51 24 40 38\n47 13 82 29 10\n 9 21  8 87 17\n\n65 82 87 15 49\n43 37 53  6 93\n89 83 66 84 33\n58 41 44  8 91\n23  1 73  5 26\n\n 2 27 51 80  5\n88 17 32 75  0\n10 38 78 56 25\n48 11 63 73 50\n57  9 67 86 31\n\n35 47 63  9 13\n12 14 82 37 32\n49 74 79 90 10\n22 50 41 46 15\n39 56 19 42 21\n\n 6 48  3  2 95\n57 40 86  4 21\n 1 23 65 76 90\n47 63 29 58 49\n77 36 71 55 83\n\n31  1 98 47 99\n85 56 81 29 76\n14 46 12 62 83\n86 45 74 73 32\n17  9 59 26 21\n\n89 72 83 48  3\n81 34 27 42 41\n90 22 95 85 36\n44 45 31 73 57\n19 60 50 29 75\n\n93  2 26 35 39\n91  7 85 69 62\n55  4 27 57 10\n92 44 30 73 22\n 6 58 16 36  9\n\n 6 42 55 24  8\n19 43  2 21 90\n99 89 48 60 58\n72 87  1 66 63\n53 16 71 20 28\n\n98 82  4 29 95\n40 63 71 64 96\n41 76 93 58 66\n30 36 28 59 74\n92  1 91 39 65\n\n96 78 45 44  3\n53 29 75 51 64\n19 84 41 30 60\n86 47 99 71 42\n95 23 40 43 22\n\n70 26  4 34 15\n66 51 12 16 36\n28 11 77 61 87\n27 75 38 65 31\n 6 33 56 10 76\n\n 9 74 75 61 55\n63 49 29 48 44\n65 12 45 17 31\n43 71 88 96 57\n20 42 34 99 21\n\n15 11 32 26 51\n23 20 19 14 82\n75 60  0 18 59\n30 66 40 57 47\n77 44 37 80 61\n\n 3 40 26 25 33\n18 80 72 28 16\n 9 46 50 91 93\n88 13 52  1 65\n70 27 78 43 39\n\n35 77  7 49 72\n59  8 87 60 15\n38 81 71 24 20\n50 54 94 31 75\n68  2 11 27 64\n\n45 39 55 51 30\n56  0  2 28 10\n43 32 46 80 98\n15 82 17 92 89\n73 62 93 33 40\n\n21 94 54 29 24\n40 35 73 43 77\n80 14  2 76 31\n17 11  8 42 45\n46 78 59 99 55\n\n92 24  9 39  4\n55 20 17 65 99\n67 86 72  6 38\n53 51 27 63 93\n48 95 83 66 85\n\n26 68 60 15 41\n32 55 33 71 63\n92 22 70 20 78\n85 89 29 27 84\n98 91 36 23  6\n\n77 71 11 12 24\n98 85 36 29 35\n80 51 88 25 81\n23  9 33 61 48\n 5 66 94 54 10\n\n89 67 34 98 57\n 4 20 80 83 28\n63 77 66  5 47\n 8 36 43 45 41\n81 18 90 91 15\n\n20 93 58 27 99\n45 47 59  9 23\n25 71 14 48 62\n95  7 69 41 90\n53  1 10 98 70\n\n 1  4 67 24 48\n53 88 77 70 86\n99 30 23 61 27\n82 95 73 37 78\n47 92 13 94  0\n\n94  8 19 74 24\n10 60  2 65 18\n31 22 16 25 32\n75  4 86 55 26\n93 47 98 43 44\n\n58 39 34 69 79\n88 78 85 84 23\n89 63 29 28 40\n37 83 56 74 32\n24 73 61  7 35\n\n46 35 27 49 81\n92 41 33 64  5\n13  6 96 66 85\n76  3 19 17  2\n82 30 88  0 39\n\n46  2  1 82 72\n 9 14 36 95 70\n56 65 13 35 28\n38 59 62 21 19\n99 77 16 52  8\n\n74 94 50 56  7\n60 18 83 87 21\n85 42 64 53 40\n43 30 67 41 68\n32 63 97 82  9\n\n 6 16 58 70 86\n42 28 51 38 54\n88 46 90 83 36\n65 24 95 63 52\n94 25 84  5 71\n\n10 84  5 18 34\n76 46 82 49 98\n74 99 29 11 41\n42 92 20 64 39\n91 85 79 32 52\n\n67 68 72 43 14\n86  5 24 40 70\n57 12 92  0 98\n60 58 15 13  2\n17 51  6  3 74\n\n50 27 68 12 80\n79 26 17 59 86\n57 29 82 70 71\n93  6 78 39 24\n72 53 23 49 98\n\n69 27 19 18 54\n 6 38 34 41 49\n17 94 93 25 86\n 1 45 60 44 62\n31 72 59 83 36\n\n45 33 42 91 39\n 6 77 32 21 27\n 9 92 30  2 43\n89 79 86 11 83\n23 94 76 65  1\n\n78 16 22 80 75\n42 61  8 35 93\n62 59 66 79 13\n44 77  7 87 68\n74 14 52 65 19\n\n60 24 88  7 29\n95 33 36 81 71\n67 39  2 49 37\n78 25 28 35 93\n20  3 12 99  6\n\n49 99 87 89 85\n86 63 42 38 68\n46 19 94 60 65\n18 51  8  0  3\n64 77 23 35 16\n\n95 22 33 57 64\n12 37 75  6 74\n76 16 86 15 48\n70 99 24 19 52\n47 65 46 32  8\n\n82 71 28 64 46\n88 90 85 69 84\n33 86  7 27 10\n45 48  0 31 99\n37  4 77 29 49\n\n69 33 73 50 26\n24 41 15 91 78\n95 47 70 23 19\n80 14 60 56  3\n55 58  8 43 16\n\n64 76 70  0  4\n58 26 95 88 53\n 1 45 50 97 93\n30 65 31  6 81\n12 11 74 68 94\n\n13 14 60 87 56\n69  3 64 29 57\n24 86 78 21 15\n33 25 70 67 38\n22 73 11 50 96\n\n73 15 22 78 63\n48 51  6 39 20\n11 91 12  0 65\n 2 90 19 64 43\n42 89 71 10 31\n\n48  5 78 25 89\n82 57 32 80 60\n13 21 88 76 65\n38 72 53  4 51\n 0 31 20 17 36\n\n41 71 27 24 58\n 3 54 43 36 75\n 7  1 39 59 95\n99 97 18 40 96\n50 61 49 69 31\n\n58 93 37 23 25\n88 81 45 50 33\n76 97  4 21 72\n56  2 98 78 51\n32 17 19 29  6\n\n73 91 87 49 74\n99 45 24 76 77\n44 67  3 60 27\n36 62 94 96 57\n 0 16 48 54 92\n\n90  7 66 65  1\n27 42  3 11 26\n63 95 69 53 29\n43 12 52 37 96\n84 13 41 36 35\n\n10  5 54  4 16\n51 17 22 49  3\n86 65 40 58 47\n71 69 20  7 98\n75 57 97 74 35\n\n31 53 17 88 12\n74 39 59 82 68\n46 23 13 28 76\n 0 89 48 43 37\n34 50 86 19 66\n\n70 82 88 32  9\n 7 15 38 56 62\n91 25 49 78 77\n40 42 44 79 18\n 1 84 28 73 97\n\n67 38 62 93 81\n 1 63 17 86 90\n55 66  6 39 13\n72 80  5 70 11\n30 71 96 14 73\n\n73 29 93 64 48\n 9 41 70 57 46\n33 92 78 82 91\n90  4 87 43 56\n83 28 59 85  8\n\n23 99 26  4 56\n79 39 31 82 92\n17 20 44 70 35\n48 71 95 53  1\n97 24 41 91 87\n\n93 61 95 53 27\n54 49 74 16 82\n30 17 59 64 79\n 4 28 36  9 38\n58 80 44 85 45\n\n92 28 76 97 45\n93 34  3 75 81\n15 14 67 64 80\n 1 68 84 83 25\n19 20 56 78 58\n\n98 38 94 26 30\n32 66 59 41 52\n40 37 73 18 39\n58  4 55 19 27\n62 69 51 44 77\n\n48  4  3 60 11\n81 76 10  0 80\n41 93 25 53 49\n14 21 85 38 45\n 5 89 12 98 74\n\n10 18 21 71 94\n14 64 44 83 47\n78 11  5 29  6\n56 36 85 73 26\n62 30 35  7 39\n\n32 31 71 52 12\n62 35 44 95 68\n67 29 15 85  9\n27 72 58 21 93\n11 54 40 41 37\n\n 7 45 74 17  9\n99 16 84 63 61\n44 21 59 69 66\n11 39 80 19 72\n89 58 81 42 87\n\n91 84 78  7 95\n24  3 85 20 16\n29 38 52 41 21\n37 23 56 73 54\n11 47  5 65 51\n\n93 94 24 74 88\n 9 72 82  6 73\n92 12 97 34 71\n35  3  0  2 19\n55 38 67 26 50\n\n56 22 52 96 72\n21 67 65 37 64\n99 76 51 39 24\n90  4 57 75 47\n40 32 44 83 34\n\n90 58 56 43 94\n99 61 95 18 72\n86 20 47 89 53\n97 38  0 39 93\n85 98 62 21  5\n\n68 20 23  1 63\n37 97 47 30 70\n66 35 46 36  2\n29 87 82 59 10\n12  5 39 73 99\n\n 1 82 87 52 42\n65 74 46 92 56\n25 29 26 34 51\n20 10 39 81 32\n12 11 89 18 27\n\n94 36 29 72 10\n34 47 77 83 18\n38 76  6 48 97\n41 90 61 69 78\n14 74 66 55 33\n\n78 25  8 24 74\n60 53 80 50 48\n66 92 55 17  3\n77 95 18 35 34\n 5 11 70  1 82\n\n58 91  5 63 35\n99 37 76 90 73\n20 50 67 61 17\n13 62 54 32 21\n47 30 94 68 49\n\n16  1 38 84 56\n53 79 14 17 47\n23 97 61 24 65\n83 89  4 29 90\n94 57 50 22 31\n\n 9 50 63 65 17\n 8 22 66  4 19\n89 71 24 70 68\n47  1 56  6 40\n62 46 75 43 37\n\n 2 15 10 18 14\n45 34 35 77 20\n76 55 48 28 26\n80 65 68 19 84\n 1 94 40 85 11\n\n80 47 69 78 37\n88 10 95 86 96\n28 14 98 20 35\n16  6  8 50 38\n51 26 53  9 54\n\n93 75 53  1 16\n30 66 76 19 51\n69 22 28 31  7\n15 36 96 17 97\n92 23 45 26 48\n\n96 13 63 81 65\n39 47 48  5 31\n64 20 95 61 60\n 4 83 55 97 14\n92 45 88 99 79\n\n11 35 56 27 50\n85 40 71 88 99\n59 39 84 44 43\n22 19 10 12 98\n13  7 76 23 21\n\n94 67 79 35 47\n83 77  3 11 15\n74 10 70 14 44\n76  5 80 46 71\n20 36 53 88 40\n\n34 24 12 63 47\n32 96 67 40 82\n42  7 87 61 10\n70 14 65 88 74\n92  9 53 60 56\n\n43 38 91 30 72\n20  3 64 80 32\n90 37 28  4 14\n96 11  6 84 68\n58 60 45 61 47\n\n45 11 65 41 46\n29 33 56 26  3\n21 90 42 96 27\n94 17 32 92 25\n43 99 36 70 87\n\n52 99 88 76 66\n75 81 48  2 96\n55 59 39 97 34\n77 37  6 82 47\n64 29 32 19 86\n\n 4 20 57 61  8\n28 33 42 30 86\n34 65 14 40 46\n43 49 37 22 39\n71 18 11 85 92\n\n68 51 39 93  1\n 9 82 35 67 81\n 3 12 29  6 83\n58 73 97 26 20\n 2 28 99 64 77\n\n88 41 91 98 89\n82  1 37 10 14\n52 44 90 34 21\n76 27 43 54 49\n31 84 46 57 77\n\n73 99 79 76 43\n82 17 14 68 87\n39 53 21  7 81\n94 45 35 48 32\n67 49 62 63 23\n\n99  0 85 12 83\n30 45 67 76 87\n 7 39 57 66 98\n13 82 46 28 24\n25 15 90 68 51\n\n69 30 73 61 99\n12 13  7 53 20\n 8 18 28 82 67\n95 79 96 51 29\n56 31 92 54 57\n";
        }
    }
}
