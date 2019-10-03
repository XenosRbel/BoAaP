using System;
using Utils;

namespace Laba9
{
	class Task2 : ICommand
	{
		public void Execute()
		{
			Console.WriteLine($"{this.GetType().FullName}\n");

			Console.Write("Введите выражение:\t");

			var exp = Console.ReadLine();
			var result = ReversePolishNotation.Calculate(exp);

			Console.WriteLine($"Результат:\t{result.ToString("N3")}");

			Console.ReadKey();
		}
	}
}
