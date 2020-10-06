using System;

namespace Task1
{
    class Program
    {
        static int[] GetArray(int n, int count)
        {
            int[] a = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < count; i++)
                a[i] = rnd.Next(10, 51);
            return a;
        }
        static void PrintArray(int[] a)
        {
            for (int i = 0; i < a.Length && a[i] > 0; i++)
                Console.Write(a[i] + " ");
            Console.WriteLine();
        }
        static void Solve(int[] a, int[] b, int len1)
        {
            int j = len1;
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i] % 2 == 0)
                {
                    a[j] = b[i];
                    j++;
                }
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Enter size of A: ");
            int len1 = int.Parse(Console.ReadLine());
            Console.Write("Enter size of B: ");
            int len2 = int.Parse(Console.ReadLine());
            int[] a = GetArray(len1 + len2, len1);
            int[] b = GetArray(len2, len2);
            Console.Write("A: ");
            PrintArray(a);
            Console.Write("B: ");
            PrintArray(b);
            Solve(a, b, len1);
            Console.Write("Modified A: ");
            PrintArray(a);
        }
    }
}
