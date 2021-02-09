using System;
using System.Collections.Generic;

namespace LinkedList
{
	class Node
	{
		public int Data { get; set; }
		public Node Next { get; set; }
		public Node(int data)
		{
			Data = data;
		}
		public override string ToString()
		{
			return $"{Data}";
		}
	}

	class LinkedList
	{
		Node head;
		Node tail;

		public int Count { get; set; }

		public void Add(int data)
		{
			Node node = new Node(data);
			if (head == null)
				head = node;
			else
				tail.Next = node;
			tail = node;
			Count++;
		}
		public void AddFirst(int data)
		{
			Node node = new Node(data);

			node.Next = head;
			head = node;

			if (Count == 0)
				tail = head;

			Count++;
		}
		public void Clear()
		{
			Count = 0;
			head = null;
			tail = null;
		}
		public bool Contains(int data)
		{
			Node current = head;
			while (current != null)
			{
				if (current.Data == data)
					return true;
				current = current.Next;
			}
			return false;
		}
		public void Print()
		{
			Node current = head;
			int i = 1;
			while (current != null)
			{
				Console.WriteLine($"{i} - {current}");
				current = current.Next;
				i++;
			}
		}

		public Node Max()
		{
			Node current = head;
			Node max = null;
			while (current != null)
			{
				if (max == null || current.Data > max.Data)
					max = current;
				current = current.Next;
			}
			return max;
		}

		public Node Min()
		{
			Node current = head;
			Node max = null;
			while (current != null)
			{
				if (max == null || current.Data < max.Data)
					max = current;
				current = current.Next;
			}
			return max;
		}

		public Node Middle()
		{
			Node current = head;
			for (int i = 0; i < Count / 2; i++)
				current = current.Next;
			return current;
		}

		public bool Remove(int data)
		{
			Node previous = null;
			Node current = head;
			while (current != null)
			{
				if (current.Data == data)
				{
					if (previous != null)
						previous.Next = current.Next;
					if (head == current)
						head = current.Next;
					if (tail == current)
						tail = previous;
					--Count;
					return true;
				}
				previous = current;
				current = current.Next;
			}
			return false;
		}

		public void Reverse()
		{
			Node previous = null;
			Node current = head;
			Node next = head?.Next;
			tail = current;
			while (current != null)
			{
				current.Next = previous;
				previous = current;
				current = next;
				next = next?.Next;
			}
			head = previous;
		}
	}

	class MainClass
	{
		public static void Main()
		{
			LinkedList linkedList = new LinkedList();
			linkedList.Add(1);
			linkedList.Add(2);
			linkedList.AddFirst(3);
			linkedList.Add(4);
			linkedList.Remove(4);
			linkedList.Add(4);
			linkedList.Add(6);
			linkedList.Add(5);
			linkedList.Print();
			Console.WriteLine();
			linkedList.Reverse();
			linkedList.Print();
		}
	}
}