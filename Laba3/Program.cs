using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Laba3
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
