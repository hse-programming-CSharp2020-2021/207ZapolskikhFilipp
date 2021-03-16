using System;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main()
        {
            BinaryWriter fOut = new BinaryWriter(new FileStream("../../../t.dat", FileMode.Create));
            for (int i = 0; i <= 10; i += 2)
                fOut.Write(i);
            fOut.Close();

            FileStream f = new FileStream("../../../t.dat", FileMode.Open);
            BinaryReader fIn = new BinaryReader(f);
            long n = f.Length / 4; int a;
            for (int i = 0; i < n; i++)
            {
                a = fIn.ReadInt32();
                Console.Write(a + " ");
            }

            Console.WriteLine("\nЧисла в обратном порядке:");
            f.Seek(4, SeekOrigin.End);
            for (int i = 0; i < n; i++)
			{
                f.Seek(-8, SeekOrigin.Current);
                Console.Write(fIn.ReadInt32() + " ");
			}

            f.Seek(0, SeekOrigin.Begin);
            fOut = new BinaryWriter(f);
            for (int i = 0; i < n; i++)
            {
                f.Position = i * 4;
                a = fIn.ReadInt32();
                fOut.Seek(i * 4, SeekOrigin.Begin);
                fOut.Write(a * 5);
            }

            Console.WriteLine("\nЧисла в прямом порядке:");
            f.Seek(0, SeekOrigin.Begin);
            for (int i = 0; i < n; i++)
            {
                if (i > 0)
                    f.Seek(4, SeekOrigin.Current);
                Console.Write(fIn.ReadInt32() + " ");
            }

            fIn.Close();
            fOut.Close();
            f.Close();
        }
    }
}
