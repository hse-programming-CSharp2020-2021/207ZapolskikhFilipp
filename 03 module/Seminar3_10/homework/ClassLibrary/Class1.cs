using System.Linq;

namespace ClassLibrary
{
	public class Street
	{
		// Количество домов.
		public static int operator ~(Street street) => street.Houses.Length;
		// Есть ли хотя бы один дом с цифрой 7 в номере.
		public static bool operator !(Street street) => street.Houses.Any(x => x.ToString().Contains('7'));
		public override string ToString() => $"{Name} {string.Join(' ', Houses)}";

		public string Name { init; get; }
		public int[] Houses { init; get; }
	}
}
