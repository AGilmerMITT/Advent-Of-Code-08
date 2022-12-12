namespace Advent_Of_Code_08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool collectingData = true;
            List<string> strings = new();
            List<bool[]> bools = new();
            while (collectingData)
            {
                string input = GetInput("Tree row please:");
                if (input == "")
                {
                    break;
                }
                strings.Add(input);
                bool[] row = new bool[input.Length];
                Array.Fill(row, false);

                bools.Add(row);
            }


            Console.WriteLine("Input complete.  Running scan...");
            CheckVisibilityFromLeft(strings, bools);
            CheckVisibilityFromRight(strings, bools);
            CheckVisibilityFromTop(strings, bools);
            CheckVisibilityFromBottom(strings, bools);
            PrintVisbility(bools);
            int visibleTrees = GetTotalVisibility(bools);
            Console.WriteLine($"Total visible trees: {visibleTrees}");
        }

        static string GetInput(string prompt)
        {
            bool validResult = false;
            string? input = null;
            while (!validResult)
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine();
                if (input != null)
                {
                    validResult = true;
                }
            }

            return input!;
        }

        static void PrintVisbility(List<bool[]> visibilityRows)
        {
            foreach (bool[] row in visibilityRows)
            {
                Console.WriteLine(string.Join("", row.Select(b => b ? "T" : "F")));
            }
        }

        static int GetTotalVisibility(List<bool[]> bools)
        {
            int result = 0;
            foreach (bool[] row in bools)
            {
                foreach (bool b in row)
                {
                    if (b)
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        static void CheckVisibilityFromLeft(List<string> treeRows, List<bool[]> visibilityRows)
        {
            for (int i = 0; i < treeRows.Count; i++)
            {
                int highestTree = -1;
                for (int j = 0; j < treeRows[i].Length; j++)
                {
                    int thisTree = int.Parse(treeRows[i][j].ToString());
                    if (thisTree > highestTree)
                    {
                        highestTree = thisTree;
                        visibilityRows[i][j] = true;
                    }
                }
            }
        }

        static void CheckVisibilityFromRight(List<string> treeRows, List<bool[]> visibilityRows)
        {
            for (int i = 0; i < treeRows.Count; i++)
            {
                int highestTree = -1;
                for (int j = treeRows[i].Length - 1; j >= 0; j--)
                {
                    int thisTree = int.Parse(treeRows[i][j].ToString());
                    if (thisTree > highestTree)
                    {
                        highestTree = thisTree;
                        visibilityRows[i][j] = true;
                    }
                }
            }
        }

        static void CheckVisibilityFromTop(List<string> treeRows, List<bool[]> visibilityRows)
        {
            for (int col = 0; col < treeRows[0].Length; col++)
            {
                int highestTree = -1;
                for (int row = 0; row < treeRows.Count; row++)
                {
                    int thisTree = int.Parse(treeRows[row][col].ToString());
                    if (thisTree > highestTree)
                    {
                        highestTree = thisTree;
                        visibilityRows[row][col] = true;
                    }
                }
            }
        }

        static void CheckVisibilityFromBottom(List<string> treeRows, List<bool[]> visibilityRows)
        {
            for (int col = 0; col < treeRows[0].Length; col++)
            {
                int highestTree = -1;
                for (int row = treeRows.Count - 1; row >= 0; row--)
                {
                    int thisTree = int.Parse(treeRows[row][col].ToString());
                    if (thisTree > highestTree)
                    {
                        highestTree = thisTree;
                        visibilityRows[row][col] = true;
                    }
                }
            }
        }
    }
}