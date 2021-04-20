using System;

namespace Matrix2
{
	class Matrix2
	{
		public Matrix2(double a, double b, double c, double d)
		{
			A = a;
			B = b;
			C = c;
			D = d;
		}
		public Matrix2(double a, double d) : this(a, 0, 0, d) { }
		public Matrix2(Matrix2 other) : this(other.A, other.B, other.C, other.D) { }
		public double Det() => A * D - B * C;
		public Matrix2 Inverse()
		{
			double det = Det();
			if (det == 0)
				throw new InvalidOperationException("Нельзя обратить вырожденную матрицу");
			return new Matrix2(D, -B, -C, A) / det;
		}
		public Matrix2 Transpose() => new(A, C, B, D);
		public static Matrix2 operator +(Matrix2 a, Matrix2 b) => new(a.A + b.A, a.B + b.B, a.C + b.C, a.D + b.D);
		public static Matrix2 operator -(Matrix2 a, Matrix2 b) => new(a.A - b.A, a.B - b.B, a.C - b.C, a.D - b.D);
		public static Matrix2 operator *(Matrix2 a, Matrix2 b) => new(a.A * b.A + a.B * b.C, a.A * b.B + a.B * b.D,
																	  a.C * b.A + a.D * b.C, a.C * b.B + a.D * b.D);
		public static Matrix2 operator *(Matrix2 a, double b) => new(a.A * b, a.B * b, a.C * b, a.D * b);
		public static Matrix2 operator /(Matrix2 a, double b)
		{
			if (b == 0)
				throw new ArgumentException("На ноль делить нельзя");
			return a * (1 / b);
		}
		public static bool operator true(Matrix2 a) => a.Det() > 0;
		public static bool operator false(Matrix2 a) => a.Det() <= 0;
		public override string ToString() => $"[{A} {B}; {C} {D}]";

		public double A { get; }
		public double B { get; }
		public double C { get; }
		public double D { get; }
	}
	class Program
	{
		static void Main()
		{
			Matrix2 a = new(1, 2, 3, 4);
			Matrix2 b = new(5, 6, 7, 8);
			Console.WriteLine($"a: {a}");
			Console.WriteLine($"b: {b}");
			Console.WriteLine($"a + b: {a + b}");
			Console.WriteLine($"det(a): {a.Det()}");
			Console.WriteLine($"a^(-1): {a.Inverse()}");
			Console.WriteLine($"a * a^(-1): {a * a.Inverse()}");
			Console.WriteLine($"a': {a.Transpose()}");
			Console.WriteLine($"a * b: {a * b}");
			Console.WriteLine($"a * 3: {a * 3}");
		}
	}
}
