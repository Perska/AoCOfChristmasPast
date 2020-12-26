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
		static void Y15Day03(List<string> input)
		{
			Dictionary<(int X, int Y), int> houses = new Dictionary<(int X, int Y), int>();
			Dictionary<(int X, int Y), int> houses2 = new Dictionary<(int X, int Y), int>();
			string full = "";
			foreach (var item in input)
			{
				if (item != "") full += item;
			}
			int X = 0, Y = 0;
			int X1 = 0, Y1 = 0;
			int X2 = 0, Y2 = 0;
			DropPresent(houses, X, Y);
			DropPresent(houses2, X1, Y1);
			DropPresent(houses2, X2, Y2);
			for (int i = 0; i < full.Length; i++)
			{
				if (i % 2 == 0)
				{
					switch (full[i])
					{
						case '>':
							X++;
							X1++;
							break;
						case 'v':
							Y++;
							Y1++;
							break;
						case '<':
							X--;
							X1--;
							break;
						case '^':
							Y--;
							Y1--;
							break;
						default:
							break;
					}
					DropPresent(houses2, X1, Y1);
				}
				else
				{
					switch (full[i])
					{
						case '>':
							X++;
							X2++;
							break;
						case 'v':
							Y++;
							Y2++;
							break;
						case '<':
							X--;
							X2--;
							break;
						case '^':
							Y--;
							Y2--;
							break;
						default:
							break;
					}
					DropPresent(houses2, X2, Y2);
				}
				DropPresent(houses, X, Y);
			}

			Console.WriteLine(houses.Count);
			Console.WriteLine(houses2.Count);

			void DropPresent(Dictionary<(int X, int Y), int> set, int x, int y)
			{
				set.TryGetValue((x, y), out int presents);
				set[(x, y)] = presents + 1;
			}
		}
	}
}
