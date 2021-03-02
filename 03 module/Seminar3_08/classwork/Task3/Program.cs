using System;
using System.Linq;

namespace Task3
{
	interface IFigure
	{
		double Area { get; }
	}
	class Square : IFigure
	{
		double length;

		public Square(double length) => Length = length;
		public override string ToString() => $"Square with length {Math.Round(Length, 3)} and area {Math.Round(Area, 3)}";

		public double Length
		{
			get => length;
			set
			{
				if (value <= 0)
					throw new ArgumentException();
				length = value;
			}
		}
		public double Area => Length * Length;
	}
	class Circle : IFigure
	{
		double radius;

		public Circle(double radius) => Radius = radius;
		public override string ToString() => $"Circle with radius {Math.Round(Radius, 3)} and area {Math.Round(Area, 3)}";

		public double Radius
		{
			get => radius;
			set
			{
				if (value <= 0)
					throw new ArgumentException();
				radius = value;
			}
		}
		public double Area => Math.PI * Radius * Radius;
	}
	class Program
	{
		static void Print<T>(T[] figures, double limit) where T : IFigure
		{
			foreach (T figure in figures.Where(x => x.Area > limit))
				Console.WriteLine(figure);
		}
		static void Main()
		{
			Random rnd = new Random();
			IFigure[] array = new IFigure[10];
			for (int i = 0; i < 10; i++)
			{
				if (rnd.Next(2) == 0)
					array[i] = new Square(rnd.NextDouble() * 10);
				else
					array[i] = new Circle(rnd.NextDouble() * 10);
			}
			Array.ForEach(array, Console.WriteLine);
			Console.WriteLine();
			Print(array, 50);
		}
	}
}
