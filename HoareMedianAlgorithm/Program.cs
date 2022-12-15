using System.Reflection;

namespace HoareMedianAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            int[] arr =  { 10, 21, 33, 14, 5, 6, 8, 3, 12, 21, 17, 3, 7, 1 };
            int[] arr2 = { 10, 21, 33, 14, 5, 6, 8, 3, 12, 21, 17, 3, 7, 1 };

            int searchPosition = 6;

            Helpers.ShowActualArray(arr, 0, arr.Length - 1, 0, arr.Length - 1, searchPosition-1, "start");
            Console.WriteLine($"Hoare1 : {searchPosition}. v poli pole je {Hoare1.HoareNthLowestElement(arr, searchPosition - 1)}\n");

            Console.WriteLine($"Hoare2 : {searchPosition}. v poli pole je {Hoare2.Hoare(arr.ToList(), searchPosition - 1)[0]}\n");
        }
    }
}