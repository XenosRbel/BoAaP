using System;
using Utils;

namespace Laba5
{
	class Task1 : ICommand
	{
		public void Execute()
		{
			Console.WriteLine($"{this.GetType().FullName}\n");

			Input(out var a, "A");
			Input(out var b, "B");
			Input(out var h, "H");

			X(a, b, h);

			var first = Y(a);
			var last = Y(b + h);

			if (first < last)
			{
				Console.WriteLine("Функция возрастает\n");
			}
			else
			{
				Console.WriteLine("Функция убывает\n");
			}
		}

		private void Input(out double value, string argName)
		{
			Console.WriteLine($"Введите значение {argName}:\t");
			value = Convert.ToDouble(Console.ReadLine().Replace('.', ','));
		}

		private double X(double a, double b, double h)
		{
			var x = 0d;

			var ind = 0;

			for (double i = a; i < b; i += h)
			{
				ind++;
				x += Y(i);

				Console.WriteLine($"index:{ind}\tX:{i}\tfunc:{x}");
			}

			return x;
		}

		private double Y(double x)
		{
			return 1 / (Math.Pow(x, 2) - x + 1);
		}
	}
}
