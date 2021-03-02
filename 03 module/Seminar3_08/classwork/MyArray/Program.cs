using System;

namespace MyArray
{
	class MyArray<T>
	{
		T[] array;

		public MyArray(int length) => array = new T[length];
		public void Add(T item)
		{
			Array.Resize(ref array, array.Length + 1);
			array[^1] = item;
		}
		public void Remove(int index)
		{
			T[] newArray = new T[array.Length - 1];
			int i = 0;
			for (int j = 0; j < array.Length; j++)
			{
				if (j == index)
					continue;
				newArray[i++] = array[j];
			}
			array = newArray;
		}

		public T this[int index]
		{
			get => array[index];
			set => array[index] = value;
		}
		public int Length => array.Length;
	}
	class Program
	{
		static void Main()
		{
			MyArray<int> array = new MyArray<int>(5);
			for (int i = 0; i < 5; i++)
				array[i] = i;
			array.Remove(2);
			array.Remove(3);
			array.Add(6);
			for (int i = 0; i < array.Length; i++)
				Console.Write($"{array[i]} ");
		}
	}
}
