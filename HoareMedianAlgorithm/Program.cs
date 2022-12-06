using System.Reflection;

namespace HoareMedianAlgorithm
{
    internal class Program : Hoare2
    {
        static void Main(string[] args)
        {
            int i = 0;
            int[] arr = { 10, 21, 33, 14, 5, 6, 8, 3, 12, 21, 17, 3, 7, 1 };
            int searchPosition = 3;

            Helpers.ShowActualArray(arr, 0, arr.Length - 1, 0, arr.Length - 1, searchPosition-1, "start");
            Console.WriteLine($"{searchPosition}. v poli pole je {HoareNthLowestElement(arr, searchPosition-1)}\n");
        }

        private static int HoareNthLowestElement(int[] data, int n)
        {
            int left = 0, right = data.Length - 1;
            int idxLeft = left, idxRight = right;
            int temp, x;

            while (left < right)
            {
                //ShowActualArray(data, idxLeft, idxRight, left, right, n);

                x = data[n];  // prvek aktuálně na hledaném pořadí
                idxLeft = left;
                idxRight = right;
                do
                {

                    while (data[idxLeft] < x) // zvyšuj index zleva, dokud jsou vlevo prvky menší než x
                    {
                        idxLeft++;
                        //Helpers.ShowActualArray(data, idxLeft, idxRight, left, right, n, "posun zleva");
                    }

                    while (data[idxRight] > x)// snižuj index zprava, dokud jsou prvky vpravo od x větší než x
                    {
                        idxRight--;
                        //Helpers.ShowActualArray(data, idxLeft, idxRight, left, right, n, "posun zprava");
                    }


                    // tady idxLeft ukazuje na první prvek v data[idxLeft], který je větší než x
                    // a současně
                    // idxRight ukazuje na první prvek v data[indexRight], který je menší než x 
                    // idxLeft a idxRight ukazují tedy na prvky, které nejsou na správném místě z hlediska vztahu k x
                    // Všechny prvky na indexech pod x musejí být menší než x a 
                    // vechny prvky na indexex nad x musejí být větší než x.

                    // Proto je třeba prvky prohodit:
                    if (idxLeft <= idxRight)
                    {
                        temp = data[idxLeft];   // prohoď prvky
                        data[idxLeft] = data[idxRight];
                        data[idxRight] = temp;
                        idxLeft++;              // a posuň se v obou směrech (prvky na idxLeft a idxRight jsou už v pořádku 
                        idxRight--;

                        Helpers.ShowActualArray(data, idxLeft, idxRight, left, right, n, "<---------->");

                    }
                } while (idxLeft < idxRight); // dokud levý index idxLeft nepřeběhl nebo nedoběhl pravý index idxRight

                Helpers.ShowActualArray(data, idxLeft, idxRight, left, right, n, "překrytí indexů");

                if (idxRight < n)  // příliš mnoho prvků je za prvkem data[n]
                    left = idxLeft;  // hledáme v intervalu napravo od data[n]
                if (idxLeft > n)   // příliš mnoho prvků je před prvkem data[n]
                    right = idxRight; // hledáme v interval nalevo od data[n]

                Helpers.ShowActualArray(data, idxLeft, idxRight, left, right, n, "změna mezí");
            }
            return data[n];
        }
    }
}