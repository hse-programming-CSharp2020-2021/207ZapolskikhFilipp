using System;

namespace Task2
{
	struct Coords
	{
		public double X { get; }
		public double Y { get; }
		public Coords(double x, double y)
		{
			X = x;
			Y = y;
		}
		public override string ToString() => $"({X}, {Y})";
	}
	class Circle
	{
		Coords center;
		double radius;

		public Circle(double x, double y, double radius)
		{
			Center = new Coords(x, y);
			Radius = radius;
		}
		public override string ToString() => $"Circle with center {Center} and radius {Radius}";

		public Coords Center
		{
			get => center;
			set => center = value;
		}
		public double Radius
		{
			get => radius;
			set
			{
				if (value < 0)
					throw new ArgumentException("Incorrect radius");
				radius = value;
			}
		}
	}
	class Program
	{
		static void Main()
		{
			try
			{
				Console.WriteLine(new Circle(1, 2, 3));
				Console.WriteLine(new Circle(0, 0, -6));
			}
			catch
			{
				Console.WriteLine("Radius can't be negative");
			}
		}
	}
}
