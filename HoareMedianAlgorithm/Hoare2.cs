namespace HoareMedianAlgorithm
{
    internal class Hoare2
    {
        static Random rnd = new Random();

        private static List<int> Hoare(List<int> data, int n)
        {
            if (data.Count == 1)
                return data;

            List<int> less = new List<int>(data.Count),
                more = new List<int>(data.Count);

            int pivotPosition = rnd.Next(0, data.Count - 1);

            int pivot = data[pivotPosition];

            foreach (int x in data)
            {
                if (x < pivot)
                    less.Add(x);
                else if (x > pivot)
                    more.Add(x);
                else
                    continue;
            }

            if (less.Count == 0 && more.Count == 0)
                return Hoare(new List<int>() { pivot }, 1);

            if (less.Count < n)
                return Hoare(more, n - less.Count);
            else
                return Hoare(less, n);
        }
    }
}