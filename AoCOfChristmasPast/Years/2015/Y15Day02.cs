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
		static void Y15Day02(List<string> input)
		{
			Regex regex = new Regex(@"(?<l>\d+)x(?<w>\d+)x(?<h>\d+)");
			long paper = 0;
			long ribbon = 0;
			foreach (var item in input)
			{
				Match match;
				if (item != "" && (match = regex.Match(item)).Success)
				{
					int l = int.Parse(match.Groups["l"].Value);
					int w = int.Parse(match.Groups["w"].Value);
					int h = int.Parse(match.Groups["h"].Value);
					paper += 2 * l * w + 2 * w * h + 2 * h * l + Math.Min(l * w, Math.Min(w * h, h * l));
					ribbon += Math.Min(l * 2 + w * 2, Math.Min(w * 2 + h * 2, h * 2 + l * 2)) + l * w * h;
				}
			}
			Console.WriteLine(paper);
			Console.WriteLine(ribbon);
		}
	}
}
