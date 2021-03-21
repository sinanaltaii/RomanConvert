using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RomanConvert.ConsoleApp
{
	public class Program
	{
		static void Main(string[] args)
		{
			var actual =  Solution(1954);
			const string expected = "MCMLIV";
			Console.WriteLine($"Are equal {actual.Equals(expected, StringComparison.Ordinal)}");
		}

		//[TestCase(1, "I")]
		//[TestCase(2, "II")]
		//[TestCase(4, "IV")]
		//[TestCase(500, "D")]
		//[TestCase(1000, "M")]
		//[TestCase(1954, "MCMLIV")]
		//[TestCase(1990, "MCMXC")]
		//[TestCase(2008, "MMVIII")]
		//[TestCase(2014, "MMXIV")]
		public static string Solution(int n)
		{
			var letters = new List<string>();
			var specialRomanValues = new Dictionary<int, string>()
			{
				{1, "I"},
				{2, "II"},
				{3, "III"},
				{4, "IV"},
				{5, "V"},
				{6, "VI"},
				{7, "VII"},
				{8, "VIII"},
				{9, "IX"},
				{10, "X"},
				{40, "XL"},
				{50, "L"},
				{100, "C"},
				{1000, "M" }
			};

			var count = 1000;
			while (n > 0)
			{
				if (n / 1000 > 0)
				{
					var quotient = n / 1000;
					var digitValue = quotient * 1000;
					var romanNumeral = specialRomanValues[digitValue];
					for (var i = 0; i < quotient; i++)
					{
						letters.Add(romanNumeral);
					}
					n -= digitValue;
				}
				else if (n / 100 > 0)
				{
					var quotient = n / 100;
					var digitValue = quotient * 100;
					var romanNumeral = specialRomanValues[digitValue];
					switch (digitValue)
					{
						case 400:
							letters.Add("CD");
							n -= digitValue;
							continue;
						case 500:
							letters.Add("D");
							n -= digitValue;
							continue;
						case 900:
							letters.Add("CM");
							n -= digitValue;
							continue;
					}

					for (var i = 0; i < quotient; i++)
					{
						letters.Add(romanNumeral);
					}

					letters.Add(romanNumeral);
					n -= quotient;
				}
				else if (n / 10 > 0)
				{
					var quotient = n / 10;
					var digitValue = quotient * 10;
					var romanNumeral = specialRomanValues[digitValue];
					switch (digitValue)
					{
						case 40:
							letters.Add("CD");
							n -= digitValue;
							continue;
						case 50:
							letters.Add("L");
							n -= digitValue;
							continue;
						case 90:
							letters.Add("CM");
							n -= digitValue;
							continue;
					}

					for (var i = 0; i < quotient; i++)
					{
						letters.Add(romanNumeral);
					}

					letters.Add(romanNumeral);
					n -= quotient;
				}
				else if (n / 1 > 0)
				{
					var quotient = n / 1;
					var digitValue = quotient * 1;
					var romanNumeral = specialRomanValues[digitValue];
					switch (digitValue)
					{
						case 4:
							letters.Add("IV");
							n -= digitValue;
							continue;
						case 5:
							letters.Add("V");
							n -= digitValue;
							continue;
						case 9:
							letters.Add("IX");
							n -= digitValue;
							continue;
					}

					for (var i = 0; i < quotient; i++)
					{
						letters.Add(romanNumeral);
					}

					letters.Add(romanNumeral);
					n -= quotient;

				}

				count /= 10;
			}
			
			var roman = string.Join(null, letters);
			return roman;
		}
	}
}
