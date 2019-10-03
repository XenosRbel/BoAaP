using System;
using Utils;

namespace Laba9
{
	class Task1 : ICommand
	{
		public void Execute()
		{
			Console.WriteLine($"{this.GetType().FullName}\n");

			BinaryTree<int> binaryTree = null;

			var key = string.Empty;

			ShowMenu();

			while (key != "-q")
			{
				key = Console.ReadLine();
				switch (key)
				{
					case "1":
						Console.WriteLine("Введите корневой элемент:\t");
						var val = Console.ReadLine();
						binaryTree = new BinaryTree<int>(Convert.ToInt32(val), null);
						break;
					case "2":
						Console.WriteLine("Введите элемент:\t");
						val = Console.ReadLine();

						binaryTree.Add(Convert.ToInt32(val));
						break;
					case "3":
						Console.WriteLine("Введите ключ для поиска:\t");
						val = Console.ReadLine();

						var searchResult = binaryTree.Search(Convert.ToInt32(val));
						searchResult.ToString();
						break;
					case "4":
						Console.WriteLine("Введите ключ для удаления:\t");
						val = Console.ReadLine();

						var result = binaryTree.Remove(Convert.ToInt32(val));
						if (result)
						{
							Console.WriteLine("Элемент удален успешно!");
						}
						else
						{
							Console.WriteLine("Элемент не удален успешно");
						}
						break;
					case "5":
						binaryTree.PrintTree();
						break;
					case "6":
						var startC = 0;
						var resOfC = binaryTree.Count(ref startC);
						Console.WriteLine($"Содержит {resOfC} узлов имеющих двух потомков, включая корень");
						break;
					case "-d":
						binaryTree = new BinaryTree<int>(8, null);
						binaryTree.Add(3);
						binaryTree.Add(10);
						binaryTree.Add(1);
						binaryTree.Add(6);
						binaryTree.Add(4);
						binaryTree.Add(7);
						binaryTree.Add(14);
						binaryTree.Add(16);
						break;
					case "-h":
					case "help":
						ShowMenu();
						break;
					default:
						break;
				}

				Console.WriteLine("Введите команду:");
			}

			Console.ReadKey();
		}

		private static void ShowMenu()
		{
			Console.WriteLine("Введите команду:");
			Console.WriteLine("Создание дерева - 1\n" +
				"Добавление новой записи - 2\n" +
				"Поиск информации по заданному ключу - 3\n" +
				"Удаление информации с заданным ключом - 4\n" +
				"Вывод информации - 5\n" +
				"Определить число узлов в дереве, имеющих двух потомков. - 6\n" +
				"Выход - \"-q\"\n");
		}
	}
}
