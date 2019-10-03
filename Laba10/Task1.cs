using System;
using System.Linq;
using Utils;

namespace Laba10
{
	class Task1 : ICommand
	{
		public void Execute()
		{
			Console.WriteLine($"{this.GetType().FullName}\n");

			var arrayA = FillArray();
			var arrayB = FillArray();

			PrintReport(arrayA, nameof(arrayA));

			PrintReport(arrayB, nameof(arrayB));

			Console.ReadKey();
		}

		private void PrintReport(int[] array, string arrayName) 
		{
			var minVal = array.Min();
			var res = MultiplyArrayByValue(array, minVal);

			Console.WriteLine($"Минимально значение {arrayName} = {minVal}");
			Console.WriteLine($"Исходный массив {arrayName} = {string.Join(" ", array)}");
			Console.WriteLine($"Результирующий  массив {nameof(res)}_{arrayName} = {string.Join(" ", res)}\n");
		}

		private int[] FillArray()
		{
			Console.Write("Заполнить массив случайным образом? да/д или нет/н\t");
			var answer = Console.ReadLine().ToLower();

			switch (answer)
			{
				case "yes":
				case "y":
				case "д":
				case "да":
					Console.Write("Введите размер массива\t");
					var arraySize = Convert.ToInt32(Console.ReadLine());

					Console.WriteLine();

					return LabUtils.GetRandomIntList(arraySize, -5, 10).ToArray();
				case "no":
				case "n":
				case "н":
				case "нет":
					Console.WriteLine("Введите элементы массива через пробел\t");
					var stringArray = Console.ReadLine();

					var array = stringArray.Split(' ').Select(x => Convert.ToInt32(x));

					return array.ToArray();
				default:
					return null;
			}
		}

		private int[] MultiplyArrayByValue(int[] array, int val) 
		{
			var resArray = (int[])array.Clone();
			for (int i = 0; i < resArray.Length; i++)
			{
				resArray[i] = resArray[i] * val;
			}

			return resArray;
		}
	}
}
