using System;
using System.Linq;
using Utils;

namespace Laba4
{
	class Task2 : ICommand
	{
		public void Execute()
		{
			Console.WriteLine($"{this.GetType().FullName}\n");

			var matrix = LabUtils.GetRandomIntListOfLists(3, -5, 5).ToList();						
			matrix.MatrixToConsoleOutput();

			Console.WriteLine();

			matrix.FindColumnWithoutNegElem(3);
		}		
	}
}
