using System;
using System.IO;
using System.Text;

namespace Task1
{
	class Program
	{
        static void Main(string[] args)
        {
            string path = @"Data.txt";
			int n;
			do Console.Write("Enter N: ");
			while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);

            // Создаем файл с данными
            if (!File.Exists(path))
				CreateFile(path, n);

			// Open the file to read from
			if (File.Exists(path))
			{
				string readText = File.ReadAllText(path);
				string[] stringValues = readText.Split(new char[] { ' ', '\n' });
				int[] arr = StringArrayToIntArray(stringValues);
				PrintArray(arr);
				Solve(arr);
				PrintArray(arr);
			}
		} // end of Main()

		private static void PrintArray(int[] arr)
		{
			foreach (int l in arr)
				Console.Write($"{l} ");
			Console.WriteLine();
		}

		private static void Solve(int[] arr)
		{
			int[] array1 = new int[arr.Length];
			int[] array2 = new int[arr.Length];
			int i = 0;
			int j = 0;
			for (int k = 0; k < arr.Length; k++)
			{
				if (arr[k] % 2 == 0)
					array1[i++] = k;
				else
					array2[j++] = k;
			}
			Array.Resize(ref array1, i);
			Array.Resize(ref array2, j);
			foreach (int l in array2)
				arr[l] = 0;
			PrintArray(array1);
			PrintArray(array2);
		}

		private static void CreateFile(string path, int n)
		{
			StringBuilder createText = new StringBuilder();
			Random rnd = new Random();
			for (int i = 0; i < n; i++)
			{
				createText.Append($"{rnd.Next(10, 100)} ");
				if ((i + 1) % 5 == 0)
					createText.Append(Environment.NewLine);
			}
			File.WriteAllText(path, createText.ToString(), Encoding.UTF8);
		}

		// преобразование массива строк в массив целых чисел
		public static int[] StringArrayToIntArray(string[] str)
        {
            int[] arr = null;
            if (str.Length != 0)
            {
                arr = new int[0];
                foreach (string s in str)
                {
                    int tmp;
                    if (int.TryParse(s, out tmp))
                    {
                        Array.Resize(ref arr, arr.Length + 1);
                        arr[arr.Length - 1] = tmp;
                    }
                } // end of foreach (string s in str)      
            }
            return arr;
        }
    }
}
