using System;
using System.IO;

namespace RandomNumbers
{
	class Program
	{
		static void Main()
		{
			Random rnd = new Random();
			int[] array = new int[10];
			for (int i = 0; i < 10; i++)
				array[i] = rnd.Next();
			try
			{
				File.WriteAllText("file1.txt", string.Join(Environment.NewLine, array));
				using (FileStream stream = File.OpenWrite("file2.txt"))
				{
					foreach (int i in array)
						stream.Write(BitConverter.GetBytes(i));
				}
				using (StreamWriter writer = new StreamWriter("file3.txt"))
				{
					foreach (int i in array)
						writer.WriteLine(i);
				}
				using (BinaryWriter writer = new BinaryWriter(File.OpenWrite("file4.txt")))
				{
					foreach (int i in array)
						writer.Write(i);
				}

				for (int index = 1; index <= 3; index += 2)
				{
					using (StreamReader reader = new StreamReader($"file{index}.txt"))
					{
						string line;
						long sum = 0;
						while ((line = reader.ReadLine()) != null)
						{
							Console.WriteLine(line);
							int i = int.Parse(line);
							if (i % 2 == 0)
								sum += i;
						}
						Console.WriteLine($"Sum={sum}");
					}
				}
				for (int index = 2; index <= 4; index += 2)
				{
					using BinaryReader reader = new BinaryReader(File.OpenRead($"file{index}.txt"));
					long sum = 0;
					for (int i = 0; i < 10; i++)
					{
						int j = reader.ReadInt32();
						Console.Write($"{j} ");
						if (j % 2 == 0)
							sum += j;
					}
					Console.WriteLine();
					Console.WriteLine($"Sum={sum}");
				}
			}
			catch { }
		}
	}
}
