using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils
{
	public static class LabUtils
	{
		public static IList<int> GetRandomIntList(int listSize, int minValue, int maxValue)
		{
			var rnd = new Random();
			return Enumerable.Range(0, listSize)
				.Select(value => rnd.Next(minValue, maxValue))
				.ToList();
		}

		public static List<List<int>> GetRandomIntListOfLists(int listSize, int minValue, int maxValue)
		{	
			var rnd = new Random();
			return Enumerable.Range(0, listSize)
				.Select(value => Enumerable.Range(0, listSize)
				.Select(x => rnd.Next(minValue, maxValue)).ToList())
				.ToList();
		}

		public static int[][] GetIntMatrix(string stringMatrix)
		{
			var matrixInts = stringMatrix.Split('\n')
				.Select(x => x.Split(' ')
								.Select(y => Convert.ToInt32(y))
								.ToArray()
						)
				.ToArray();

			return matrixInts;
		}

		/// <summary>
		/// Создает матризу размером n*m при ручном заполнении
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="n">Количество строк</param>
		/// <param name="m">Количество столбцов</param>
		/// <returns>Возвращает заполненную матрицу</returns>
		public static int[,] ManualFillMatrix(int n, int m)
		{
			var res = new int[n, m];

			for (int i = 0; i < n; i++)
			{
				Console.WriteLine("Введите элементы первой строки:\t");

				for (int j = 0; j < m; j++)
				{
					res[i, j] = Convert.ToInt32(Console.ReadLine());
				}
			}

			return res;
		}

		public static int[,] RandomFillMatrix(int n, int m, int minValue, int maxValue)
		{
			var res = new int[n, m];
			var rnd = new Random();

			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					res[i, j] = rnd.Next(minValue, maxValue);
				}
			}

			return res;
		}

		public static void MatrixToConsoleOutput(this List<List<int>> listOfList)
		{
			listOfList.ForEach(i => Console.WriteLine(string.Join("\t", i)));
		}

		public static void MatrixToConsoleOutput(this int[,] matrix)
		{
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					Console.Write($"{matrix[i,j]}\t");
				}
				Console.WriteLine();
			}
			Console.WriteLine();
		}

		public static void FindColumnWithoutNegElem(this List<List<int>> listOfList, int colLength, int rowLength = 0) 
		{
			rowLength = rowLength == 0 ? listOfList.Count : rowLength;

			var tranparent = new List<List<int>>();

			for (int j = 0; j < colLength; j++)
			{
				var tmp = new List<int>();

				for (int i = 0; i < rowLength; i++)
				{
					tmp.Add(listOfList[i][j]);
				}

				tranparent.Add(tmp);
			}
;
			var ind = tranparent.FindIndex(item => item.All(value => value > 0));

			if (ind != -1)
			{
				Console.WriteLine($"{ind+1}-й столбец не имеет отрицательных элементов.\n");
			}
			else
			{
				Console.WriteLine("В этом массиве нет столбцов с неотрицательными элементами.\n");
			}
		}

		public static double Factorial(int number)
		{
			return Enumerable.Range(1, number).Aggregate((i, j) => i * j);
		}

		public static int Fact(this int number)
		{
			return Enumerable.Range(1, number).Aggregate((i, j) => i * j);
		}

		public static int Sum(this int[,] source)
		{
			_ = source ?? throw new ArgumentNullException(nameof(source));

			var sum = 0;

			for (int i = 0; i < source.GetLength(0); i++)
			{
				for (int j = 0; j < source.GetLength(1); j++)
				{
					sum += source[i, j];
				}
			}
			return sum;
		}

		public static int Sum(this int[,] source, Predicate<int> predicate)
		{
			_ = source ?? throw new ArgumentNullException(nameof(source));
			_ = predicate ?? throw new ArgumentNullException(nameof(predicate));

			var sum = 0;

			for (int i = 0; i < source.GetLength(0); i++)
			{
				for (int j = 0; j < source.GetLength(1); j++)
				{
					if (predicate.Invoke(source[i, j]))
					{
						sum += source[i, j];
					}					
				}
			}
			return sum;
		}

		public static int SumPosUntilMax(this int[,] source)
		{
			_ = source ?? throw new ArgumentNullException(nameof(source));

			var sum = 0;
			var max = source.Max();

			for (int i = 0; i < source.GetLength(0); i++)
			{
				for (int j = 0; j < source.GetLength(1); j++)
				{
					var item = source[i, j];
					if (item < 0) continue;

					if (item == max)
					{
						return sum;
					}
					else
					{
						sum += item;
					}
				}
			}
			return sum;
		}

		public static int Max(this int[,] source)
		{
			_ = source ?? throw new ArgumentNullException(nameof(source));

			var num = 0;
			var flag = false;

			for (int i = 0; i < source.GetLength(0); i++)
			{
				for (int j = 0; j < source.GetLength(1); j++)
				{
					var item = source[i, j];

					if (flag)
					{
						if (item > num)
						{
							num = item;
						}
					}
					else
					{
						num = item;
						flag = true;
					}
				}
			}

			if (flag)
			{
				return num;
			}

			throw new Exception("No Elements");
		}
	}
}
