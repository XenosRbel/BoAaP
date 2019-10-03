using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Laba3
{
	class Task1 : ICommand
	{
		private const double A = -0.1;
		private const double B = 2;
		private const double H = 0.1;

		public void Execute()
		{
			Console.WriteLine("Задание 1\n");

			X(A, B, H);

			var first = Y(A);
			var last = Y(A + H);

			if (first < last)
			{
				Console.WriteLine("Функция возрастает\n");
			}
			else
			{
				Console.WriteLine("Функция убывает\n");
			}
		}

		private double X(double a, double b, double h)
		{
			var x = 0d;

			var ind = 0;

			var xRes = new List<double>();
			for (double i = a; i < b; i += h)
			{
				ind++;
				x += Y(i);
				xRes.Add(x);

				var first = x;
				var last = Y(i - h);

				if (first > last)
				{
					Console.WriteLine($"index:{ind}\tX:{i}\tfunc:{x}\tФункция возрастает");
				}
				else
				{
					Console.WriteLine($"index:{ind}\tX:{i}\tfunc:{x}\tФункция убывает");
				}
			}

			Console.WriteLine($"min {xRes.Min()}\tmax {xRes.Max()}");

			return x;
		}

		private double Y(double x)
		{ 
			return 1 / (Math.Pow(x, 2) - x + 1);
		}
	}
}
