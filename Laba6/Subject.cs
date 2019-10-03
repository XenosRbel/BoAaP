using System;
using System.Collections.Generic;
using System.Linq;

namespace Laba6
{
	public class Subject 
	{
		public Subject(string subjecName, int mark)
		{
			SubjecName = subjecName;
			Mark = mark;
		}

		public string SubjecName { get; set; }
		public int Mark { get; set; }

		public override string ToString()
		{
			return $"Предмет:\t{SubjecName};\tОтметка:\t{Mark}";
		}

		public static Subject ConsoleInput(Subject subject = null)
		{
			object inputValue;

			inputValue = Input("Введите название предмета:");
			var subjectName = string.IsNullOrWhiteSpace(
				(string)inputValue) ? subject.SubjecName : Convert.ToString(inputValue);

			inputValue = Input("Введите отметку:");
			var mark = string.IsNullOrWhiteSpace(
				(string)inputValue) ? subject.Mark : Convert.ToInt32(inputValue);

			return new Subject(subjectName, mark); 
		}

		public static List<Subject> ConsoleInputSubjects(List<Subject> subjects = null)
		{
			var key = string.Empty;
			subjects = subjects ?? new List<Subject>();

			ShowHead();

			while (key != "-q")
			{
				key = Console.ReadLine();
				switch (key)
				{
					case "1":
						subjects.Add(ConsoleInput());

						Console.WriteLine(string.Join("\n", subjects));
						Console.WriteLine();
						break;
					case "2":
						var subjectName = Convert.ToString(Input("Введите название предмета:"));
						var subject = subjects.First(x => string.Equals(x.SubjecName, subjectName, StringComparison.OrdinalIgnoreCase));
						var newSubject = ConsoleInput(subject);
						subjects.Remove(subject);

						subjects.Add(newSubject);
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

			return subjects;
		}

		private static void ShowHead()
		{
			Console.WriteLine("Введите команду:");
			Console.WriteLine("Добавить предмет - 1\n" +
				"Изменить предмет - 2\n" +
				"Выход - \"-q\"\n");
		}

		private static object Input(string message)
		{
			Console.WriteLine(message);
			var value = Console.ReadLine();

			return value;
		}
	}
}
