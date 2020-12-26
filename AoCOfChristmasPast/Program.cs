using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020
{
	partial class Program
	{
		public delegate void DayProgram(List<string> input);

		public static List<List<DayProgram>> years = new List<List<DayProgram>>
		{
			new List<DayProgram>() // 2015
			{
				Y15Day01, Y15Day02, Y15Day03, Y15Day04, Y15Day05, Y15Day06
			}
		};

		public class UseSRLAttribute : Attribute
		{

		}

		static void Main()
		{
			bool keepGoing = true;

			//Console.WriteLine(SuperReadLine());
			while (keepGoing)
			{
				Console.WriteLine("Enter the year you want to run the program for (enter 0 to stop)");
				if (int.TryParse(Console.ReadLine(), out int year))
				{
					int selYear = year - 2014;
					List<DayProgram> days = null;
					if (year == 0)
					{
						keepGoing = false;
					}
					else if (1 <= selYear && selYear <= years.Count)
					{
						days = years[selYear - 1];
					}
					else
					{
						Console.WriteLine($"Program for Year {year} are not implemented.");
					}
					if (days != null)
					{
						while (true)
						{
							Console.WriteLine("Enter the day you want to run the program for");
							if (int.TryParse(Console.ReadLine(), out int day))
							{
								DayProgram program = null;
								if (day == 0)
								{
									break;
								}
								if (1 <= day && day <= days.Count)
								{
									program = days[day - 1];
								}
								else
								{
									Console.WriteLine($"Program for Day {day} is not implemented.");
								}

								if (program != null)
								{
									bool useSRL = program.Method.GetCustomAttributes(typeof(UseSRLAttribute), false).Any();
									List<string> input = new List<string>();
									Console.WriteLine("Please enter the program input. Once done, enter \"end\"\n(hint, right-click the window top bar for pasting)");
									while (true)
									{
										string line = useSRL ? SuperReadLine() : Console.ReadLine();
										if (line.Length == 254) Console.WriteLine("Line was 254 characters long... Coincidence or is SuperReadLine required?");
										if (line.ToLowerInvariant().StartsWith("end")) break;
										input.Add(line);
									}
									//input.RemoveAll(item => item.Length == 0);
									if (input.LastOrDefault() != "")
									{
										input.Add("");
									}
									program(input);
								}
							}
							else
							{
								Console.WriteLine("Not a valid number");
							}
						}
					}
				}
				else
				{
					Console.WriteLine("Not a valid number");
				}
				
				Console.WriteLine();
			}
		}

		static string SuperReadLine()
		{
			char key;
			StringBuilder input = new StringBuilder();
			int x = Console.CursorLeft, y = Console.CursorTop;
			while ((key = Console.ReadKey().KeyChar) != 13)
			{
				if (key == 8 && input.Length > 0)
				{
					input.Remove(input.Length - 1, 1);
					Console.SetCursorPosition((x + input.Length) % Console.BufferWidth, y + (x + input.Length) / Console.BufferWidth);
					Console.Write('\0');
					Console.SetCursorPosition((x + input.Length) % Console.BufferWidth, y + (x + input.Length) / Console.BufferWidth);
				}
				else if (key != 8 && key != 0)
				{
					input.Append(key);
				}
				else
				{
					Console.SetCursorPosition((x + input.Length) % Console.BufferWidth, y + (x + input.Length) / Console.BufferWidth);
				}
			}
			Console.SetCursorPosition(0, y + (x + input.Length) / Console.BufferWidth + 1);
			return input.ToString();
		}
	}
}
