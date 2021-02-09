using System;
using System.Collections.Generic;
using System.Linq;

namespace LinkedListAndStack
{
	class Program
	{
		static LinkedList<int> Example1(int n) => new LinkedList<int>(Array.ConvertAll(n.ToString().ToCharArray(), x => x - '0'));
		static Stack<int> Example2(int n) => new Stack<int>(Array.ConvertAll(n.ToString().ToCharArray(), x => x - '0').Reverse());
		static void Main()
		{
			int n;
			do
				Console.Write("Enter N: ");
			while (!int.TryParse(Console.ReadLine(), out n) || n < 0);
			LinkedList<int> list = Example1(n);
			Stack<int> stack = Example2(n);
			foreach (int i in list)
				Console.Write($"{i} ");
			Console.WriteLine();
			foreach (int i in stack)
				Console.Write($"{i} ");
		}
	}
}
