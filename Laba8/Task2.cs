using System;
using Utils;

namespace Laba8
{
	class Task2 : ICommand
	{
		public void Execute()
		{
			Console.WriteLine($"{this.GetType().FullName}\n");

			var linkedList = new DoubleLinkedList<string>();

			linkedList.Add("Bob");
			linkedList.Add("Bill");
			linkedList.Add("Tom");
			linkedList.Add("Kate");

			linkedList.ToRing();
			linkedList.PrintBack();

			Console.WriteLine();

			linkedList.PrintForward();


			linkedList.Remove("Bill");


			Console.ReadKey();
		}
	}
}