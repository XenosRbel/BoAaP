using System;
using System.Collections.Generic;
using Utils;

namespace Laba8
{
	class Task1 : ICommand
	{
		public void Execute()
		{
			Console.WriteLine($"{this.GetType().FullName}\n");

			var linkedList = new LinkedList<int>{ 0, 1 ,2, 3, 4, 5, 6, 7, 8, 9};

			Console.WriteLine(string.Join(" ", linkedList));

			RemoveEachSecondElem(linkedList);
		}

		private void RemoveEachSecondElem(LinkedList<int> ts)
		{
			var failedItem = new List<int>();

			for (int i = 0; i < ts.Count; i++)
			{
				if ((i + 1) % 2 == 0)
				{
					var val = ts.GetByIndex(i);
					failedItem.Add(val);
				}
			}

			for (int i = 0; i < failedItem.Count; i++)
			{
				ts.Remove(failedItem[i]);

				Console.WriteLine(string.Join(" ", ts));
			}
		}
	}
}
