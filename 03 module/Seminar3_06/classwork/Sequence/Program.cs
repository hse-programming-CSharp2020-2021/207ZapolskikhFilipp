using System;

namespace Sequence
{
	interface ISequence
	{
		double GetElement(int index);
	}
	class ArithmeticProgression : ISequence
	{
		public ArithmeticProgression(double a, double d)
		{
			A = a;
			D = d;
		}
		public double GetElement(int index) => A + D * (index - 1);

		public double A { get; }
		public double D { get; }
	}
	class GeometricProgression : ISequence
	{
		public GeometricProgression(double b, double q)
		{
			B = b;
			Q = q;
		}
		public double GetElement(int index) => B * Math.Pow(Q, index - 1);

		public double B { get; }
		public double Q { get; }
	}
	class Program
	{
		static double Sum(ISequence sequence, int count)
		{
			double sum = 0;
			for (int i = 1; i <= count; i++)
				sum += sequence.GetElement(i);
			return sum;
		}
		static void Main()
		{
			Console.WriteLine(Sum(new ArithmeticProgression(3, 5), 10));
		}
	}
}
