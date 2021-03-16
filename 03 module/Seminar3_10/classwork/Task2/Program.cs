using System;
using System.IO;

namespace Task2
{
	class Program
	{
		static void Main()
		{
			string path = @"..\..\..\Numbers";
			Random rnd = new Random();
			using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(path)))
			{
				for (int i = 0; i < 10; i++)
					writer.Write(rnd.Next(1, 101));
			}

			using (BinaryReader reader = new BinaryReader(File.OpenRead(path)))
			{
				for (int i = 0; i < 10; i++)
					Console.Write($"{reader.ReadInt32()} ");
			}
			Console.WriteLine();

			while (true)
			{
				int num;
				do
					Console.Write("Enter new number: ");
				while (!int.TryParse(Console.ReadLine(), out num) || num < 1 || num > 100);
				int index = 0;
				int value = 0;
				using (BinaryReader reader = new BinaryReader(File.OpenRead(path)))
				{
					for (int i = 0; i < 10; i++)
					{
						int cur = reader.ReadInt32();
						if (value == 0 || Math.Abs(cur - num) < Math.Abs(cur - value))
						{
							index = i;
							value = cur;
						}
					}
				}
				using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(path)))
				{
					writer.Seek(index * 4, SeekOrigin.Begin);
					writer.Write(num);
				}
				using (BinaryReader reader = new BinaryReader(File.OpenRead(path)))
				{
					for (int i = 0; i < 10; i++)
						Console.Write($"{reader.ReadInt32()} ");
				}
				Console.WriteLine();
			}
		}
	}
}
