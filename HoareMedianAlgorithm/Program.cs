namespace HoareMedianAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            int[] arr = { 10, 21, 33, 14, 5, 6, 8, 3, 12, 21, 17, 3, 7 };

#if DEBUG
            int arrSize = 0;
            do
            {
                int[] arrRefreshed = { 10, 21, 33, 14, 5, 6, 8, 3, 12, 21, 17, 3, 7};
                if (i == 0)
                {
                    arrSize = arrRefreshed.Length;
                }
                
                Console.WriteLine(String.Join(",\t", Enumerable.Range(0, arrSize).Select(x => x)));
                Console.WriteLine("".PadLeft(8*arrSize, '-'));
                Console.WriteLine(string.Join(",\t", arrRefreshed));

                int valueOnNthPosition = HoareNthLowesElement(arrRefreshed, i);
                Console.WriteLine($"{1+i++}. v pořadí je {valueOnNthPosition}\n");
            }
            while (i < arrSize);
#endif

            Console.WriteLine($"Medián prvního pole pole je {HoareNthLowesElement(arr, arr.Length/2)}\n");

            int[] arr2 = new int[10_000_000];
            Random r = new Random();
            for (int k = 0; k<arr2.Length; k++)
            {
                arr2[k] = r.Next();
            }

            Console.WriteLine($"{DateTime.Now.Second}:{DateTime.Now.Millisecond}");
            Console.WriteLine($"Medián druhého pole pole je {HoareNthLowesElement(arr2, arr2.Length / 2)}\n");

            //Array.Sort(arr2);
            //Console.WriteLine($"Medián druhého pole pole je {arr2[arr2.Length / 2]}\n");

            Console.WriteLine($"{DateTime.Now.Second}:{DateTime.Now.Millisecond}");

        }

        private static int HoareNthLowesElement(int[] data, int n)
        {
            int left = 0, right = data.Length - 1;
            int idxLeft = left, idxRight;
            int temp, x;

            while (left < right)
            {
                x = data[n];  // prvek aktuálně na hledaném pořadí
                idxLeft = left;
                idxRight = right;
                do
                {
                    while (data[idxLeft] < x) // zvyšuj index zleva, dokud jsou vlevo prvky menší než x
                    {
                        idxLeft++;
                    }
                    while (data[idxRight] > x)// snižuj index zprava, dokud jsou prvky vpravo od x větší než x
                    {
                        idxRight--; 
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
#if DEBUG
                        Console.WriteLine(string.Join(",\t", data));
#endif
                    }
                } while (idxLeft < idxRight);

                if (idxRight < n)  // příliš mnoho prvků je za prvkem data[n]
                    left = idxLeft;  // hledáme v intervalu napravo od data[n]
                if (idxLeft > n)   // příliš mnoho prvků je před prvkem data[n]
                    right = idxRight; // hledáme v interval nalevo od data[n]
            }
            return data[n];
        }
    }
}