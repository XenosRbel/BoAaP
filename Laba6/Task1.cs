using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Laba6
{
	class Task1 : ICommand
	{
		public void Execute()
		{
			Console.WriteLine($"{this.GetType().FullName}\n");

			var students = new List<Student>()
						{ new Student("Last Name 1",
										"First Name 1",
										Convert.ToDateTime("01.01.2000"),
										new List<Subject>()
										{	
											new Subject("Физика", 5),
											new Subject("Математика", 8),
											new Subject("Информатика", 8),
											new Subject("Химия", 4),
										},
										1001),
						new Student("Last Name 2",
										"First Name 2",
										Convert.ToDateTime("01.02.2000"),
										new List<Subject>()
										{
											new Subject("Физика", 9),
											new Subject("Математика", 4),
											new Subject("Информатика", 6),
											new Subject("Химия", 7),
										},
										1001),
						new Student("Last Name 3",
										"First Name 3",
										Convert.ToDateTime("05.01.2000"),
										new List<Subject>()
										{
											new Subject("Физика", 5),
											new Subject("Математика", 5),
											new Subject("Информатика", 4),
											new Subject("Химия", 9),
										},
										1002),
						new Student("Last Name 4",
										"First Name 4",
										Convert.ToDateTime("01.01.2000"),
										new List<Subject>()
										{
											new Subject("Физика", 9),
											new Subject("Математика", 9),
											new Subject("Информатика", 9),
											new Subject("Химия", 8),
										},
										1002),
						};

			Console.WriteLine($"{string.Join("\n", students)}");

			Console.WriteLine("Введите номер группы:");
			var groupNumber = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine("\n");
			Console.WriteLine($"Отличники\n{string.Join("\n", students.Where(s => s.GroupNumber == groupNumber && s.Subjects.All(sub => sub.Mark > 7)))}");
		}
	}
}
