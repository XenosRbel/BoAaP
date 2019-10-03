using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Laba4
{
	class Task1 : ICommand
	{
		public void Execute()
		{
			Console.WriteLine($"{this.GetType().FullName}\n");

			var array = LabUtils.GetRandomIntList(10, -5, 5).ToList();

			var indFirstZeroElem = array.FindIndex(x => x == 0);

			if (indFirstZeroElem == -1)
			{
				Console.WriteLine("Элемент равный 0 не найден\n");
				return;
			}

			var result = array.Skip(indFirstZeroElem + 1)
				.Select(x => Math.Abs(x))
				.Sum();

			Console.WriteLine($"Массив\n{string.Join(",", array)}\n");
			Console.WriteLine($"Сумма элементов массива по модулю равна:\t{result}\n");
		}
	}
}
