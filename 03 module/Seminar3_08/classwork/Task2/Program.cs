using System;
using System.Collections.Generic;

namespace Task2
{
	struct Person
	{
		public Person(string name, string surname, int age)
		{
			Name = name;
			Surname = surname;
			Age = age;
		}
		public override string ToString() => $"{Name} {Surname}, {Age} years";

		public string Name { get; }
		public string Surname { get; }
		public int Age { get; }
	}
	class ElectronicQueue
	{
		Queue<Person> queue = new Queue<Person>();

		public Person Dequeue() => queue.Dequeue();
		public void Enqueue(Person person) => queue.Enqueue(person);
		public Person Peek() => queue.Peek();
		public Person[] ToArray() => queue.ToArray();

		public int Count => queue.Count;
	}
	class Program
	{
		static void Main()
		{
			ElectronicQueue queue = new ElectronicQueue();
			Person[] array = new Person[]
			{
				new Person("Arthur", "Levinson", 70),
				new Person("Tim", "Cook", 60),
				new Person("Jeff", "Williams", 58)
			};
			queue.Enqueue(array[0]);
			queue.Enqueue(array[1]);
			queue.Dequeue();
			queue.Enqueue(array[2]);
			Array.ForEach(queue.ToArray(), person => Console.WriteLine(person));
		}
	}
}
