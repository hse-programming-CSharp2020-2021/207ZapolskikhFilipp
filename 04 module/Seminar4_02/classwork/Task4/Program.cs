#pragma warning disable SYSLIB0011 // Тип или член устарел
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;

namespace Task4
{
	[Serializable, DataContract]
	public class ConsoleSymbol
	{
		public ConsoleSymbol() { }
		public ConsoleSymbol(char symb, int x, int y)
		{
			Symbol = symb;
			X = x;
			Y = y;
		}
		public override string ToString() => $"{Symbol}({X},{Y})";

		[DataMember]
		public char Symbol { get; set; }
		[DataMember]
		public int X { get; set; }
		[DataMember]
		public int Y { get; set; }
	}
	[Serializable, DataContract]
	public class ColorConsoleSymbol : ConsoleSymbol
	{
		public ColorConsoleSymbol() { }
		public ColorConsoleSymbol(char symb, int x, int y, ConsoleColor color) : base(symb, x, y) => Color = color;
		public override string ToString() => $"{Symbol}({X},{Y},{Color})";

		[DataMember]
		public ConsoleColor Color { get; set; }
	}
	class Program
	{
		static ConsoleSymbol[] array;

		static void Print(ConsoleSymbol[] css)
		{
			foreach (ConsoleSymbol symbol in css)
				Console.Write(symbol + " ");
			Console.WriteLine();
			Console.WriteLine();
		}
		static void BinaryFormat()
		{
			BinaryFormatter formatter = new();
			using (FileStream stream = new("data.bin", FileMode.Create))
				formatter.Serialize(stream, array);
			ConsoleSymbol[] array2;
			using (FileStream stream = File.OpenRead("data.bin"))
				array2 = (ConsoleSymbol[])formatter.Deserialize(stream);
			Print(array2);
		}
		static void XmlFormat()
		{
			XmlSerializer formatter = new(typeof(ConsoleSymbol[]), new Type[] { typeof(ColorConsoleSymbol) });
			using (FileStream stream = new("data.xml", FileMode.Create))
				formatter.Serialize(stream, array);
			ConsoleSymbol[] array2;
			using (FileStream stream = File.OpenRead("data.xml"))
				array2 = (ConsoleSymbol[])formatter.Deserialize(stream);
			Print(array2);
		}
		static void JsonFormat()
		{
			File.WriteAllText("data.json", JsonSerializer.Serialize(array));
			Print(JsonSerializer.Deserialize<ConsoleSymbol[]>(File.ReadAllText("data.json")));
		}
		static void DataContractFormat()
		{
			DataContractSerializer formatter = new(typeof(ConsoleSymbol[]), new Type[] { typeof(ColorConsoleSymbol) });
			using (FileStream stream = new("data.contract.xml", FileMode.Create))
				formatter.WriteObject(stream, array);
			ConsoleSymbol[] array2;
			using (FileStream stream = File.OpenRead("data.contract.xml"))
				array2 = (ConsoleSymbol[])formatter.ReadObject(stream);
			Print(array2);
		}
		static void Main()
		{
			Random rnd = new();
			array = new ConsoleSymbol[10];
			for (int i = 0; i < array.Length; i++)
			{
				if (rnd.Next(2) == 0)
					array[i] = new((char)('A' + rnd.Next(26)), rnd.Next(200), rnd.Next(100));
				else
					array[i] = new ColorConsoleSymbol((char)('A' + rnd.Next(26)), rnd.Next(200), rnd.Next(100),
						(ConsoleColor)rnd.Next(16));
			}
			BinaryFormat();
			XmlFormat();
			JsonFormat();
			DataContractFormat();
		}
	}
}
