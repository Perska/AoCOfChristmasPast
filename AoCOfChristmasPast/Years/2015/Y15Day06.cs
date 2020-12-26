using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AoC2020
{
	partial class Program
	{
		static void Y15Day06(List<string> input)
		{
			Regex regex = new Regex(@"(turn off|turn on|toggle) (\d+),(\d+) through (\d+),(\d+)");
			bool[,] lights = new bool[1000, 1000];
			int[,] lights2 = new int[1000, 1000];
			int on = 0;
			int bright = 0;
			foreach (var item in input)
			{
				Match match;
				if ((match = regex.Match(item)).Success)
				{
					int x = int.Parse(match.Groups[2].Value), y = int.Parse(match.Groups[3].Value), x2 = int.Parse(match.Groups[4].Value), y2 = int.Parse(match.Groups[5].Value);
					switch (match.Groups[1].Value)
					{
						case "turn off":
							for (int i = y; i <= y2; i++)
							{
								for (int j = x; j <= x2; j++)
								{
									lights[j, i] = false;
									lights2[j, i] = Math.Max(lights2[j, i] - 1, 0);
								}
							}
							break;
						case "turn on":
							for (int i = y; i <= y2; i++)
							{
								for (int j = x; j <= x2; j++)
								{
									lights[j, i] = true;
									lights2[j, i]++;
								}
							}
							break;
						case "toggle":
							for (int i = y; i <= y2; i++)
							{
								for (int j = x; j <= x2; j++)
								{
									lights[j, i] = !lights[j, i];
									lights2[j, i] += 2;
								}
							}
							break;
						default:
							break;
					}
				}
			}
			for (int i = 0; i < 1000; i++)
			{
				for (int j = 0; j < 1000; j++)
				{
					if (lights[j, i]) on++;
					bright += lights2[j, i];
				}
			}
			Console.WriteLine(on);
			Console.WriteLine(bright);
		}
	}
}
