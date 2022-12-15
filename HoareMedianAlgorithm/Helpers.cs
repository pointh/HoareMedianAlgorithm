namespace HoareMedianAlgorithm
{
    internal class Helpers
    {
        public static void ShowActualArray(int[] data, int leftIndex, int rightIndex, int spanLeft, int spanRight, int order, string comment)
        {
            const int posWidth = 5;

            char[] indexLabel = "".PadRight(posWidth * (data.Length + 2 + posWidth + comment.Length)).ToCharArray();

            for (int i = 0; i < data.Length; i++)
            {
                if (i == order)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                if (i == leftIndex) { Console.ForegroundColor = ConsoleColor.Yellow; }
                if (i == rightIndex) { Console.ForegroundColor = ConsoleColor.Yellow; }

                if (i >= spanLeft && i <= spanRight) { Console.BackgroundColor = ConsoleColor.DarkGray; }

                Console.Write($"{data[i],posWidth}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.WriteLine();

            string leftIndexLabel = $"{leftIndex}^";
            leftIndexLabel.CopyTo(0, indexLabel, posWidth * leftIndex + posWidth - 2, leftIndexLabel.Length);

            string rightIndexLabel = $"|{rightIndex}";
            rightIndexLabel.CopyTo(0, indexLabel, posWidth * rightIndex + posWidth - 1, rightIndexLabel.Length);

            comment.CopyTo(0, indexLabel, data.Length * posWidth + 10, comment.Length);

            Console.WriteLine(indexLabel);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void ShowActualLists(List<int> less, List<int> pivots, List<int> more, int n)
        {
            Console.Write("Less:" + string.Join(",", less) + "::");
            Console.Write("Pivots:" + string.Join(",", pivots) + "::");
            Console.WriteLine("More:" + string.Join(",", more) + "::" + n);
        }

    }

}