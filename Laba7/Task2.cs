using System;
using System.Collections.Generic;
using Utils;
using System.IO;
using System.Linq;

namespace Laba7
{
	class Task2 : ICommand
	{
		public Task2()
		{
			alphabet = new List<char>();
			alphabet = Enumerable.Range('A', 'z' - 'A' + 1)
				.Select(c => (char)c)
				.ToList();
			alphabet.AddRange(Enumerable.Range('А', 'я' - 'А' + 1).Select(c => (char)c));
		}

		public void Execute()
		{
			Console.WriteLine($"{this.GetType().FullName}\n");

			Console.WriteLine("Введите строку:");
			var inp = Console.ReadLine();
			Console.WriteLine($"Result input:\t{inp}");	

			var crpyted = CryptData(inp);
			Console.WriteLine($"Crypted data:\t{crpyted.Replace('\n', ' ')}");
			Console.WriteLine("Saving data...");
			SaveData(crpyted);
			Console.WriteLine("Saved!");

			Console.WriteLine("Loading data...");
			crpyted = LoadData();
			Console.WriteLine("Loaded!");

			Console.WriteLine("Restore data");
			inp = DecryptData(crpyted);
			Console.WriteLine("Restored");

			Console.WriteLine($"Result data:\t{inp}\n");
			Console.WriteLine("======Finish======");
			Console.ReadKey();
		}

		private readonly List<char> alphabet;

		private string LoadData()
		{
			var data = File.ReadAllText("Data.txt");

			return data;
		}

		private void SaveData(string data)
		{
			File.WriteAllText("Data.txt", data);
		}

		private string CryptData(string data)
		{
			var result = string.Empty;

			var chars = data.ToCharArray();
			for (int i = 0; i < chars.Length; i++)
			{
				var symIndex = alphabet.IndexOf(chars[i]);
				if (symIndex != -1)
				{
					result += symIndex;
					result += '\n';
				}
				else
				{
					result += chars[i];
				}
			}
			return result;
		}

		private string DecryptData(string data)
		{
			var result = string.Empty;

			var chars = data.Replace('\n', ' ').Split(' ');

			for (int i = 0; i < chars.Length; i++)
			{
				try
				{
					var symIndex = alphabet.Where((x, ind) => ind == Convert.ToInt32(chars[i])).First();
					result += symIndex;
				}
				catch (System.FormatException)
				{
					result += chars[i] == "" ? " " : chars[i];
				}
			}
			
			return result;
		}
	}
}
