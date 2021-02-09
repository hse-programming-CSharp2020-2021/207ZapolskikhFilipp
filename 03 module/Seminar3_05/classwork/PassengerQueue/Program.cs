using System;
using System.Collections.Generic;

namespace PassengerQueue
{
    /// <summary>
    /// Пассажир
    /// </summary>
    public class Passenger
    {
        static readonly Random rnd = new Random();
        public Passenger()
		{
            Age = rnd.Next(10, 80);
            IsOld = Age > 65;
            Name = rnd.Next(1000, 10000).ToString();
            LastName = "";
		}
        public bool IsOld { get; }
        public string Name { get; }
        public string LastName { get; }
        public int Age { get; }
        public override string ToString() => $"#{Name}, {Age} years";
    }
    /// <summary>
    /// Пассажир с детьми
    /// </summary>
    public class PassengerWithChildren : Passenger
    {
        static readonly Random rnd = new Random();
        public PassengerWithChildren()
		{
            IsNewBorn = rnd.Next(8) == 0;
            NumberOfChildren = rnd.Next(1, 4);
		}
        public bool IsNewBorn { get; }
        public int NumberOfChildren { get; }
        public override string ToString() => $"{base.ToString()}, {NumberOfChildren} children";
    }
    /// <summary>
    /// Очередь на посадку состоит из двух подочередей: обычной и приоритетной
    /// Пассажиры приоритетной очереди обслуживаются вне очереди
    /// </summary>
    public class PassengerQueue
    {
        // if passenger is ordinary we use ordinaryQueue
        Queue<Passenger> ordinaryQueue = new Queue<Passenger>();
        // if passenger is old or with newborns we use priorityQueue
        Queue<Passenger> priorityQueue = new Queue<Passenger>();

        public void AddToQueue(Passenger newPassenger)
        {
            if (newPassenger.Age > 65 || newPassenger is PassengerWithChildren && ((PassengerWithChildren)newPassenger).IsNewBorn) priorityQueue.Enqueue(newPassenger);
            else ordinaryQueue.Enqueue(newPassenger);
        }
        public void StartServingQueue()
        {
            while (ordinaryQueue.Count > 0 || priorityQueue.Count > 0)
			{
                if (priorityQueue.Count > 0 && priorityQueue.Count <= 3)
				{
                    while (priorityQueue.Count > 0)
					{
                        Console.WriteLine(priorityQueue.Peek());
                        priorityQueue.Dequeue();
					}
				}
                else
				{
                    if (priorityQueue.Count > 0)
					{
                        Console.WriteLine(priorityQueue.Peek());
                        priorityQueue.Dequeue();
                    }
                    if (ordinaryQueue.Count > 0)
                    {
                        Console.WriteLine(ordinaryQueue.Peek());
                        ordinaryQueue.Dequeue();
                    }
                }
			}
        }
	}

    class MainClass
    {
        public static void Main()
        {
            Random rnd = new Random();
            Passenger[] passengers = new Passenger[10];
            PassengerQueue queue = new PassengerQueue();
            for (int i = 0; i < 10; i++)
			{
                if (rnd.Next(5) == 0)
                    passengers[i] = new PassengerWithChildren();
                else
                    passengers[i] = new Passenger();
                queue.AddToQueue(passengers[i]);
			}
            queue.StartServingQueue();
        }
    }
}
