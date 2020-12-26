using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020
{
	partial class Program
	{
		static void Y15Day04(List<string> input)
		{
			string orig = input[0];
			int num = 0;
			int winner5 = -1;
			int winner6 = -1;
			while (true)
			{
				string hash = GetMD5(orig + num.ToString());
				if (winner5 == -1 && hash.StartsWith("00000"))
				{
					winner5 = num;
				}
				if (winner6 == -1 && hash.StartsWith("000000"))
				{
					winner6 = num;
				}
				if (winner5 != -1 && winner6 != -1)
				{
					break;
				}
				num++;
			}
			Console.WriteLine(winner5);
			Console.WriteLine(winner6);
		}

		static string GetMD5(string input)
		{
			byte[] str = Encoding.ASCII.GetBytes(input);
			System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
			byte[] hash = md5.ComputeHash(str);
			string ret = "";
			foreach (byte num in hash)
			{
				ret += num.ToString("X2");
			}
			return ret;
		}
	}
}
