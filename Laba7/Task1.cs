using Laba6;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Utils;
using System.IO;
using System.Diagnostics;
using System.Linq;

namespace Laba7
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
											new Subject("Химия", 4),
										},
										1002),
						};

			var key = string.Empty;

			ShowHead();

			while (key != "-q")
			{
				key = Console.ReadLine();
				switch (key)
				{
					case "1":
						SaveData(students);
						break;
					case "2":
						students = LoadData("Students.json");
						break;
					case "3":
						students.Add(Student.ConsoleInput());
						break;
					case "4":
						Console.WriteLine(string.Join("\n", students));
						break;
					case "5":
						Console.WriteLine("Введите Фамилию:");
						var lastName = Console.ReadLine();
						var student = students.First(x => string.Equals(x.LastName, lastName, StringComparison.OrdinalIgnoreCase));
						var result = students.Remove(student);

						Console.WriteLine(result ? "Удалено успешно!\n" : "Не удалено\n");
						break;
					case "6":
						Console.WriteLine("Введите Фамилию:");
						lastName = Console.ReadLine();
						student = students.First(x => string.Equals(x.LastName, lastName, StringComparison.OrdinalIgnoreCase));

						var newStudent = Student.ConsoleInput(student);
						students.Remove(student);
						students.Add(newStudent);
						break;
					case "-h":
					case "help":
						ShowHead();
						break;
					default:
						break;
				}

				Console.WriteLine("Введите команду:");
			}
		}

		private static void ShowHead()
		{
			Console.WriteLine("Введите команду:");
			Console.WriteLine("Сохранить список студентов - 1\n" +
				"Загрузить список студентов - 2\n" +
				"Добавить студента - 3\n" +
				"Просмотреть всех - 4\n" +
				"Удалить студента по фамилии - 5\n" +
				"Изменить данные о студенте - 6\n" +
				"Выход - \"-q\"\n");
		}

		private void SaveData(List<Student> students) 
		{
			var serdStudents = JsonConvert.SerializeObject(students, Formatting.Indented);
			File.WriteAllText("Students.json", serdStudents);

			Process.Start("Students.json");
		}

		private List<Student> LoadData(string filePath)
		{
			var data = File.ReadAllText(filePath);
			return JsonConvert.DeserializeObject<List<Student>>(data);
		}
	}
}
