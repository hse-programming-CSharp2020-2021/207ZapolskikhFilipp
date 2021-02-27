using System;
using System.Diagnostics.CodeAnalysis;

namespace Task3
{
	struct PointS
	{
		public double X { get; }
		public double Y { get; }
		public PointS(double x, double y)
		{
			X = x;
			Y = y;
		}
		public override string ToString() => $"({X}, {Y})";
		public static double Distance(PointS p1, PointS p2)
		{
			double dx = p1.X - p2.X;
			double dy = p1.Y - p2.Y;
			return Math.Sqrt(dx * dx + dy * dy);
		}
	}
	struct CircleS : IComparable<CircleS>
	{
		PointS center;
		double radius;

		public CircleS(double x, double y, double radius)
		{
			center = new PointS(x, y);
			this.radius = radius;
		}
		public override string ToString() => $"Circle with center {Center} and radius {Math.Round(Radius, 3)}";
		public int CompareTo([AllowNull] CircleS other) => Radius.CompareTo(other.Radius);

		public PointS Center
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
		public double Length => 2 * Math.PI * Radius;
	}
	class Program
	{
		static void Main()
		{
			Random rnd = new Random();
			CircleS[] array = new CircleS[10];
			for (int i = 0; i < 10; i++)
				array[i] = new CircleS(rnd.Next(1000), rnd.Next(1000), rnd.NextDouble() * 10);
			Array.ForEach(array, x => Console.WriteLine(x));
			Console.WriteLine();
			Array.Sort(array);
			Array.ForEach(array, x => Console.WriteLine(x));
		}
	}
}
