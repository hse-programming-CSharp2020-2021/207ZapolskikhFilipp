namespace State
{
	class State
	{
		public static State operator +(State a, State b)
			=> new() { Area = a.Area + b.Area, Population = a.Population + b.Population };
		public static bool operator >(State a, State b) => a.Population > b.Population;
		public static bool operator <(State a, State b) => a.Population < b.Population;

		public decimal Population { get; set; } // население
		public decimal Area { get; set; }      // территори
	}
	class Program
	{
		static void Main()
		{
			State state1 = new() { Area = 1000000, Population = 20000000 };
			State state2 = new() { Area = 2000000, Population = 10000000 };
			State state3 = state1 + state2;
			bool isGreater = state1 > state2;
		}
	}
}
