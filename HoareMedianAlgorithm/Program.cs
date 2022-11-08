namespace HoareMedianAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 10, 21, 33, 14, 5, 6, 8, 3, 12, 21, 17, 3 };

            int valueOnNthPosition = Hoare(arr, 5);

            Console.WriteLine(valueOnNthPosition);
        }

        private static int Hoare(int[] arr, int v)
        {
            int l=1, r=arr.Length-1, i, j, w, x;

            while(l < r)
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
                    }
                } while (i > j);

                if (j < v)
                    l = i;
                if (v < i)
                    r = j;
            }

            return arr[v];
        }
    }
}