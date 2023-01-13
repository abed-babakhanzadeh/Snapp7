using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.Securities
{
	public static class CheckNationalCode
	{
		public static bool CheckCode(string code)
		{
			code ??= "0000000000";
			var digitString = new[] {"0000000000", "1111111111", "2222222222", "3333333333", "4444444444",
				"5555555555" ,"6666666666", "7777777777", "8888888888", "9999999999" };

			if (digitString.Contains(code))
			{
				return false;
			}

			var strCode = code.ToCharArray();

			int j = 10;
			var b = 0;

			for (int i = 0; i < 9; i++)
			{
				b += Convert.ToInt32(strCode[i].ToString()) * j;
				j--;
			}

			var a = Convert.ToInt32(strCode[9].ToString());
			var c = b % 11;

			return (((c<2) && (a==c)) || ((c>=2) && ((11-c)==a)));
		}
	}
}
