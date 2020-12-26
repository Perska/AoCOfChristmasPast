using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020
{
	partial class Program
	{
		static void Y15Day05(List<string> input)
		{
			string[] IllegalSequences = new string[]
			{
				"ab", "cd", "pq", "xy"
			};

			List<string> niceStrings = new List<string>();
			List<string> niceStrings2 = new List<string>();
			foreach (var item in input)
			{
				if (item != "")
				{
					int vowelCount = item.Count(cha => "aeiou".Contains(cha));
					int doubleChars = 0;
					int noOverlapPair = 0;
					int repeatSandwich = 0;
					int illegalSequences = IllegalSequences.Count(str => item.Contains(str));

					for (int i = 1; i < item.Length; i++)
					{
						if (item[i - 1] == item[i]) doubleChars++;
						string findPair = item[i - 1].ToString() + item[i].ToString();
						if (item.Substring(0, i - 1).Contains(findPair) || item.Substring(i + 1).Contains(findPair))
						{
							noOverlapPair++;
						}
					}
					for (int i = 2; i < item.Length; i++)
					{
						if (item[i - 2] == item[i]) repeatSandwich++;
					}
					if (vowelCount >= 3 && doubleChars != 0 && illegalSequences == 0) niceStrings.Add(item);
					if (noOverlapPair != 0 && repeatSandwich != 0) niceStrings2.Add(item);
				}
			}

			Console.WriteLine(niceStrings.Count);
			Console.WriteLine(niceStrings2.Count);
		}
	}
}
