using System;

namespace задание_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr ={1,4,6,8 };
            first( ref arr);

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            Console.WriteLine("=========================");
            last(ref arr);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            Console.WriteLine("=========================");
            forindex(ref arr);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            Console.WriteLine("=========================");
            insert(ref arr);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
        static void first (ref int[] arr) 
        {
            int[] kfirst = new int[arr.Length + 1];
            kfirst[0] = 666;
            for (int i = 0,j = 1; i < arr.Length; i++,j++)
                kfirst[j] = arr[i];
            arr = kfirst;
        }
        static void last(ref int[] arr) 
        {
            int[] klast = new int[arr.Length + 1];
            klast[klast.Length-1] = 666;
            for (int i = 0, j = 0; i < arr.Length; i++, j++)
                klast[j] = arr[i];
            arr = klast;
        }
        static void forindex(ref int[] arr)
        {
            int[] kindex = new int[arr.Length + 1];
            int chislo = 666;
            int index = 2;
            for (int i = 0,j=0; i < arr.Length; i++,j++)
            {
                if (j!= index)
                    kindex[j] = arr[i];
                else
                {
                    kindex[j] = chislo;
                    i--;
                }
            }
            arr = kindex;
        }
        static void insert(ref int[] arr) 
        {
            int[] kinsert = new int[arr.Length-1];
            int index = 3;
            //kinsert[index] = 0;

            for (int i = 0; i < index; i++)
            {
                kinsert[i] = arr[i];
            }
            for (int i = index,j = index; i <=kinsert.Length-1; i++, j++)
            {
                kinsert[j] = arr[i+1];
            }
            arr = kinsert;
        }
    }
}
