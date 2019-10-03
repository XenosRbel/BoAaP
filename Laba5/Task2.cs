using System;
using Utils;

namespace Laba5
{
	class Task2 : ICommand
	{
		private int N = 5;
		private int K = 2;

		public void Execute()
		{
			Console.WriteLine($"{this.GetType().FullName}\n");
			Console.WriteLine($"Способ через функцию\n");

			var c = N.Fact() / (K.Fact() * (N - K).Fact());
			Console.WriteLine($"Результат по формуле числа сочетаний:\t{c}");

			Console.WriteLine($"Способ через рекурсию\n");
			Console.WriteLine($"Результат по формуле числа сочетаний через рекурсию:\t{C(N, K)}");
		}

		private double C(int n, int k)
		{
			var result = Factorial(n) / (Factorial(k) * Factorial(n - k));
			return result;
		}

		static int Factorial(int x)
		{
			if (x == 0)
			{
				return 1;
			}
			else
			{
				return x * Factorial(x - 1);
			}
		}
	}
}
