using System;
using System.Linq;
using Utils;

namespace Laba3
{
	class Task2 : ICommand
	{
		private const double A = 0.1;
		private const double B = 1d;
		private const double H = 0.1;

		private const double N = 1d;

		public void Execute()
		{
			Console.WriteLine("Задание 2\n");

			for (var i = A; i < B; i += H)
			{
				var y = Y(i);
				var s = S(i, N);

				Console.WriteLine($"Y:{y}\tX:{s}\t|Y-S|:{y - s}");
			}
		}

		private double Y(double x)
		{
			return (Math.Exp(x) - Math.Exp(-x)) / 2;
		}

		private double S(double x, double n)
		{
			var s = 0d;

			for (int k = 0; k < n; k++)
			{
				s += Math.Pow(x, 2 * k + 1) / LabUtils.Factorial(2 * k + 1);
			}

			return s;
		}	
	}
}
