using System;

namespace Calculation
{
	interface ICalculation
	{
		double Perform(double x);
	}
	class Add : ICalculation
	{
		public Add(double num) => Num = num;
		public double Perform(double x) => x + Num;

		public double Num { get; }
	}
	class Multiply : ICalculation
	{
		public Multiply(double num) => Num = num;
		public double Perform(double x) => x * Num;

		public double Num { get; }
	}
	class Program
	{
		static double Calculate(double x, ICalculation calc1, ICalculation calc2) => calc2.Perform(calc1.Perform(x));
		static void Main()
		{
			double[] array = new double[3];
			for (int i = 0; i < 2; i++)
			{
				do
					Console.Write($"Enter number {i + 1}: ");
				while (!double.TryParse(Console.ReadLine(), out array[i]));
			}
			Console.WriteLine($"(A+B)*C = {Calculate(array[0], new Add(array[1]), new Multiply(array[2]))}");
		}
	}
}
