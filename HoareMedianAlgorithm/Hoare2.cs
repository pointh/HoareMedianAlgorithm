namespace HoareMedianAlgorithm
{
    public static class Hoare2
    {
        static Random rnd = new Random();

        public static List<int> Hoare(List<int> data, int n)
        {
            if (data.Count == 1)
                return data;

            List<int> less = new List<int>(),
                more = new List<int>(),
                pivots = new List<int>();

            int pivotPosition = rnd.Next(0, data.Count - 1);

            int pivot = data[pivotPosition];

            foreach (int x in data)
            {
                if (x < pivot)
                    less.Add(x);
                else if (x > pivot)
                    more.Add(x);
                else
                    pivots.Add(x);
            }

            Helpers.ShowActualLists(less, pivots, more, n);

            if (n < less.Count)
                return Hoare(less, n);
            if (n < less.Count + pivots.Count)
                return new List<int> { pivots[0] }; // musí vrátit list
            else
                return Hoare(more, n - less.Count - pivots.Count);
        }
    }
}