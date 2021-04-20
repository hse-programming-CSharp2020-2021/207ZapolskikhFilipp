using System;

namespace Sandwich
{
	// хлеб
	class Bread
	{
		public static Sandwich operator +(Bread bread, Butter butter) => new() { Weight = bread.Weight + butter.Weight };

		public int Weight { get; set; } // масса
	}

	// масло
	class Butter
	{
		public int Weight { get; set; } // масса
	}

	// бутерброт
	class Sandwich
	{
		public int Weight { get; set; } // масса
	}
	class Program
	{
		static void Main()
		{
			Bread bread = new() { Weight = 80 };
			Butter butter = new() { Weight = 20 };
			Sandwich sandwich = bread + butter;
			Console.WriteLine(sandwich.Weight);  // 100
		}
	}
}
