using System;
using System.Collections.Generic;

namespace Brackets2
{
	class Program
	{
		static readonly Dictionary<char, char> brackets = new Dictionary<char, char>{ {'(', ')' }, { '{', '}' }, { '[', ']' } };
		static bool Validate(string s)
		{
			Stack<char> stack = new Stack<char>();
			foreach (char c in s)
			{
				if (c == '(' || c == '{' || c == '[')
					stack.Push(c);
				else if (c == ')' || c == '}' || c == ']')
				{
					if (stack.Count == 0 || c != brackets[stack.Peek()])
						return false;
					stack.Pop();
				}
			}
			return stack.Count == 0;
		}
		static void Main() => Console.Write(Validate(Console.ReadLine()));
	}
}
