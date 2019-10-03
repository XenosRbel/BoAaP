using System;
using System.Linq;
using Utils;

namespace Laba10
{
	class Task2 : ICommand
	{
		public void Execute()
		{
			Console.WriteLine($"{this.GetType().FullName}\n");

			var matrix = FillArray();

			matrix.MatrixToConsoleOutput();

			var maxElem = matrix.Max();
			Console.WriteLine($"Максимальный элемент матрицы = {maxElem}\n");

			var sum = matrix.SumPosUntilMax();
			Console.WriteLine($"Сумма положительных элементов матрицы, расположенных до максимального элемента равна:\t {sum}");

			Console.ReadKey();
		}

		private int[,] FillArray()
		{
			Console.Write("Заполнить массив случайным образом? да/д или нет/н\t");
			var answer = Console.ReadLine().ToLower();

			switch (answer)
			{
				case "yes":
				case "y":
				case "д":
				case "да":
					Console.Write("Введите количество строк\t");
					var n = Convert.ToInt32(Console.ReadLine());

					Console.Write("Введите количество столбцов\t");
					var m = Convert.ToInt32(Console.ReadLine());

					var array = LabUtils.RandomFillMatrix(n, m, -4, 6);

					return array;
				case "no":
				case "n":
				case "н":
				case "нет":
					Console.Write("Введите количество строк\t");
					n = Convert.ToInt32(Console.ReadLine());

					Console.Write("Введите количество столбцов\t");
					m = Convert.ToInt32(Console.ReadLine());

					array = LabUtils.ManualFillMatrix(n,m);

					return array;
				default:
					return null;
			}
		}
	}
}
