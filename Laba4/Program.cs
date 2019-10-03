﻿using System.Collections.Generic;
using Utils;

namespace Laba4
{
	class Program
	{
		static void Main(string[] args)
		{
			var tasks = new List<ICommand>
			{
				new Task1(),
				new Task2()
			};

			tasks.ForEach(task => task.Execute());
		}
	}
}
