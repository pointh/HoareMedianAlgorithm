namespace HoareMedianAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 10, 21, 33, 14, 5, 6, 8, 3, 12, 21, 17 };
            int[] cpy;

            for (int i = 0; i < arr.Length; i++)
            {
                int valueOnNthPosition = Hoare((int[])arr.Clone(), i);
                Console.WriteLine(valueOnNthPosition);
            }
        }

        private static int Hoare(int[] arr, int v)
        {
            int l=0, r=arr.Length-1, i=0, j, w, x;

            Console.WriteLine(string.Join(", ", arr));

            while (l < r)
            {
                x = arr[v];
                i = l;
                j = r;
                do
                {
                    while (arr[i] < x)
                    {
                        i++;
                    }
                    while (arr[j] > x)
                    {
                        j--;
                    }

                    if (i < j)
                    {
                        w = arr[i];
                        arr[i] = arr[j];
                        arr[j] = w;
                        i++;
                        j--;
                        Console.WriteLine(string.Join(", ", arr));
                    }
                } while (i < j);
                Console.ReadLine();

                if (j < v)
                    l = i;
                if (v < i)
                    r = j;
                if (i == j)
                {
                    Console.WriteLine($"{v}. v pořadí je na indexu {i}");
                    Console.ReadLine();
                }
            }

            return arr[i];
        }
    }
}