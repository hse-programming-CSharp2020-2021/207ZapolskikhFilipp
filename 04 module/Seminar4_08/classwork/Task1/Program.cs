using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task1
{
	class BankAccount
	{
		private readonly object thisLock = new();
		volatile int accountAmount;
		readonly Random r = new();
		public BankAccount(int sum)
		{
			accountAmount = sum;
		}
		int Buy(int sum)
		{
			if (accountAmount == 0)
				throw new InvalidOperationException($"Нулевой баланс...");
			// условие никогда не выполнится, пока вы не закомментируете lock.
			if (accountAmount < 0)
				throw new InvalidOperationException($"Отрицательный баланс");
			bool acquiredLock = false;
			try
			{
				Monitor.Enter(thisLock, ref acquiredLock);
				if (accountAmount >= sum)
				{
					Console.WriteLine($"Состояние счета: {accountAmount}");
					Console.WriteLine($" Поток: {Thread.CurrentThread.GetHashCode()}");
					Console.WriteLine($" Покупка на сумму: {sum}");
					accountAmount -= sum;
					Console.WriteLine($" Счет после пок.: {accountAmount}");
					return sum;
				}
				else
				{
					return 0; // не хватает денег - отказываем в покупке
				}
			}
			finally
			{
				Monitor.Exit(thisLock);
			}
		}
		public void DoTransactions()
		{
			try
			{
				while (true)
				{
					Buy(r.Next(1, 50));
					Thread.Sleep(r.Next(1, 10));
				}
			}
			catch (InvalidOperationException ex)
			{
				Console.WriteLine($"Обработано исключение: {ex.Message}. Поток завершает работу...");
			}
		}
	}
	class Program
	{
		static void Main()
		{
			Task[] tasks = new Task[10];
			BankAccount dep = new(1000);
			for (int i = 0; i < tasks.Length; i++)
				tasks[i] = Task.Run(dep.DoTransactions);
			Task.WaitAll(tasks);
		}
	}
}
