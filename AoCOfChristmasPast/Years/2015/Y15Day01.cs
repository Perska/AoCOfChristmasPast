using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020
{
	partial class Program
	{
		[UseSRL]
		static void Y15Day01(List<string> input)
		{
			string full = "";
			foreach (string item in input)
			{
				full += item;
			}
			int floor = 0, basementAt = 0;
			for (int i = 0; i < full.Length; i++)
			{
				floor += full[i] == '(' ? 1 : -1;
				if (floor == -1 && basementAt == 0) basementAt = i + 1;
			}
			Console.WriteLine($"Part 1: {floor}, Part 2: {basementAt}");
		}
	}
}
