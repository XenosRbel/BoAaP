using System;
using System.Collections.Generic;
using System.Linq;

namespace Laba6
{
	public class Student
	{
		public Student(string lastName, string firstName, DateTime birthDate, List<Subject> subjects, int groupNumber)
		{
			LastName = lastName;
			FirstName = firstName;
			BirthDate = birthDate;
			Subjects = subjects;
			GroupNumber = groupNumber;
		}

		public string LastName { get; set; }
		public string FirstName { get; set; }
		public DateTime BirthDate { get; set; }
		public List<Subject> Subjects { get; set; }
		public int GroupNumber { get; set; }

		public override string ToString()
		{
			return $"Фамилия:\t{LastName}\n" +
				$"Имя:\t{FirstName}\n" +
				$"День рождения:\t{BirthDate.ToShortDateString()}\n" +
				$"Предметы:\n{string.Join("\n", Subjects)}\n" +
				$"Номер группы:\t{GroupNumber}\n" +
				$"Средний балл:\t{Subjects.Select(s => s.Mark).Average()}\n";
		}

		public static Student ConsoleInput(Student student = null)
		{
			object inputValue;

			inputValue = Input("Введите Фамилию:");
			var lastName = string.IsNullOrWhiteSpace(
				(string)inputValue) ? student.LastName : Convert.ToString(inputValue);

			inputValue = Input("Введите Имя:");
			var firstName = string.IsNullOrWhiteSpace(
				(string)inputValue) ? student.FirstName : Convert.ToString(inputValue);

			inputValue = Input("Введите день рождения:");
			var birthDate = string.IsNullOrWhiteSpace(
				(string)inputValue) ? student.BirthDate : Convert.ToDateTime(inputValue);

			Console.WriteLine("Ввод предметов:");
			var subjects = Subject.ConsoleInputSubjects(student.Subjects);

			inputValue = Input("Введите номер группы:");
			var groupNumber = string.IsNullOrWhiteSpace(
				(string)inputValue) ? student.GroupNumber : Convert.ToInt32(inputValue);

			return new Student(lastName, firstName, birthDate, subjects, groupNumber); 
		}

		public static Student EditStudent(Student student)
		{
			Console.WriteLine("Введите");
			return student;
		}

		private static object Input(string message)
		{
			Console.WriteLine(message);
			var value = Console.ReadLine();

			return value;
		}
	}
}
