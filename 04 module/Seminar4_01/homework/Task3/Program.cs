using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Task3
{
	delegate void Qdelegate(Quadratic qe);

	[Serializable]
	public class Quadratic
	{
		double a;
		public Quadratic() { }
		public Quadratic(double a, double b, double c)
		{
			A = a;
			B = b;
			C = c;
		}
		public override string ToString() => $"{Math.Round(A, 2)}x^2 " +
			$"{(B >= 0 ? '+' : '-')} {Math.Abs(Math.Round(B, 2))}x {(C >= 0 ? '+' : '-')} {Math.Abs(Math.Round(C, 2))}";

		public double A
		{
			get => a;
			set
			{
				if (value == 0)
					throw new ArgumentException("Equation is linear");
				a = value;
			}
		}
		public double B { get; set; }
		public double C { get; set; }
		public double Discriminant => B * B - 4 * A * C;
		public double X1 => (-B - Math.Sqrt(Discriminant)) / A / 2;
		public double X2 => (-B + Math.Sqrt(Discriminant)) / A / 2;
	}
	class Processing
	{
		static readonly Random gen = new();
		
		// Оценить дискриминант и для неотрицательного - вывести корни: 
		public static void SolutionReal(Quadratic eq)
		{
			if (eq.Discriminant < 0)
				return;
			Console.WriteLine(eq.ToString() + "  дискриминант = " + eq.Discriminant);
			Console.WriteLine("\tКорни: Х1={0,3:g3}  \tX2={1,3:g3}", eq.X1, eq.X2);
		}
		// Метод выводит на экран сведения об уравнении:
		public static void PrintEq(Quadratic eq) => Console.WriteLine(eq.ToString() + "  дискриминант = " + (eq.Discriminant).ToString("g3"));
		// Создать файл и записать в него объекты, применяя сериализацию.
		// Создать несколько объектов класса и записать их в файл: 
		static public void WriteFile(string nameFile, int numb)
		{
			using FileStream streamOut = new(nameFile, FileMode.Create);
			XmlSerializer formatOut = new(typeof(Quadratic[]));
			List<Quadratic> list = new();
			for (int j = 0; j < numb; j++)
			{
				try
				{
					// При А==0 - уравнение вырождается в линейное
					list.Add(new(gen.Next(-10, 11), gen.Next(-10, 11), gen.Next(-10, 11)));
					if (j == numb - 1)
						formatOut.Serialize(streamOut, list.ToArray());
				}
				catch (ArgumentException)
				{
					// Заменить вырожденное уравнение:
					j--;
					continue;
				}
			}

		}
		//  Метод читает из файла сериализованные объекты и "не знает" что с 
		//  ними делать:
		public static void Process(string fileName, Qdelegate qDel)
		{
			using FileStream streamIn = new(fileName, FileMode.Open);
			XmlSerializer formatIn = new(typeof(Quadratic[]));
			try
			{
				Quadratic[] eq = (Quadratic[])formatIn.Deserialize(streamIn);
				foreach (Quadratic q in eq)
					qDel(q);
			}
			catch { }
		}
	}
	class Program
	{
		static void Main()
		{
			Processing.WriteFile("equation.ser", 8);
			Console.WriteLine("Выполнена запись в режиме сериализации.");
			Console.WriteLine("Для вывода на экран нажмите любую клавишу.");
			Console.ReadKey(true);
			Console.WriteLine("В файле сведения о следующих уравнениях: ");
			// Обращение с использованием делегата:
			Processing.Process("equation.ser", new Qdelegate(Processing.PrintEq));
			Console.WriteLine("Для решения уравнений нажмите любую клавишу.");
			Console.ReadKey(true);
			Console.WriteLine("\r\nРешения уравнений с вещественными корнями: ");
			Processing.Process("equation.ser", new Qdelegate(Processing.SolutionReal));
			Console.WriteLine("Для завершения работы нажмите ENTER.");
			Console.ReadLine();
		}
	}
}
