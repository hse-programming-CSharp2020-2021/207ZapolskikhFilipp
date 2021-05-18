using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
	interface IVocal
	{
		void DoSound();
	}
	abstract class Animal : IVocal
	{
		static int lastId = 0;

		public Animal(string name, bool isTakenCare)
		{
			Id = ++lastId;
			Name = name;
			IsTakenCare = isTakenCare;
		}
		public abstract void DoSound();
		public override string ToString() => $"{Name}, Id: {Id}, IsTakenCare: {IsTakenCare}";

		public int Id { get; set; }
		public string Name { get; set; }
		public bool IsTakenCare { get; set; }
	}
	class Mammal : Animal
	{
		int paws;

		public Mammal(string name, bool isTakenCare, int paws) : base(name, isTakenCare) => Paws = paws;
		public override string ToString() => $"Mammal {base.ToString()}, Paws: {Paws}";
		public override void DoSound() => Console.WriteLine("я млекопитающие, би-би-би");

		public int Paws
		{
			get => paws;
			set
			{
				if (value < 1 || value > 20)
					throw new ArgumentException("Некорректное число лап");
				paws = value;
			}
		}
	}
	class Bird : Animal
	{
		int speed;

		public Bird(string name, bool isTakenCare, int speed) : base(name, isTakenCare) => Speed = speed;
		public override string ToString() => $"Bird {base.ToString()}, Speed: {Speed}";
		public override void DoSound() => Console.WriteLine("я птичка, пип-пип-пип");

		public int Speed
		{
			get => speed;
			set
			{
				if (value < 1 || value > 100)
					throw new ArgumentException("Некорректная скорость");
				speed = value;
			}
		}
	}
	class Zoo : IEnumerable<Animal>
	{
		public Zoo(int n) => Animals = new Animal[n];
		public IEnumerator<Animal> GetEnumerator() => Animals.Cast<Animal>().GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => Animals.GetEnumerator();

		public Animal[] Animals { get; set; }
	}
	class Program
	{
		static void Main()
		{
			int n;
			do
				Console.Write("Enter count of animals: ");
			while (!int.TryParse(Console.ReadLine(), out n) || n < 1);
			Zoo zoo = new(n);
			Random rnd = new();
			for (int i = 0; i < n; i++)
				zoo.Animals[i] = rnd.Next(2) == 0 ? new Mammal(rnd.Next(10000, 100000).ToString(), rnd.Next(2) == 0, rnd.Next(1, 21))
												: new Bird(rnd.Next(10000, 100000).ToString(), rnd.Next(2) == 0, rnd.Next(1, 101));
			foreach (Animal animal in zoo)
			{
				Console.WriteLine(animal);
				animal.DoSound();
			}
			Console.WriteLine();
			MakeQueries(zoo);
		}
		static void MakeQueries(Zoo zoo)
		{
			var query1 = zoo.OfType<Bird>().Where(bird => bird.IsTakenCare);
			Console.WriteLine("Query 1:");
			foreach (Bird bird in query1)
				Console.WriteLine(bird);
			Console.WriteLine();

			var query2 = zoo.OfType<Mammal>().Where(mammal => !mammal.IsTakenCare);
			Console.WriteLine("Query 2:");
			foreach (Mammal mammal in query2)
				Console.WriteLine(mammal);
		}
	}
}
