using System;
using System.IO;

namespace Task1
{
    class ColorPoint
    {
        public static string[] colors = { "Red", "Green", "DarkRed", "Magenta", "DarkSeaGreen", "Lime", "Purple", "DarkGreen", "DarkOrange", "Black", "BlueViolet", "Crimson", "Gray", "Brown", "CadetBlue" };
        public double x, y;
        public string color;
        public override string ToString()
        {
            string format = "{0:F3}    {1:F3}    {2}";
            return string.Format(format, x, y, color);
        }
    }
    class Program
    {
        static Random gen = new Random();
        public static void Main()
        {
            string path = @"..\..\..\MyTest.txt";
            int N = 10; // Количество создаваемых объектов (число строк в файле)
            using (StreamWriter writer = new StreamWriter(path))
            {
                ColorPoint one;
                for (int i = 0; i < N; i++)
                {
                    int j = gen.Next(0, ColorPoint.colors.Length);
					one = new ColorPoint { x = gen.NextDouble(), y = gen.NextDouble(), color = ColorPoint.colors[j] };
					writer.WriteLine(one.ToString());
                }
            }
            Console.WriteLine("Записаны {0} строк в текстовый файл: \n{1}", N, path);
        }
    } // class Program
}
