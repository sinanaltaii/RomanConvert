using System;
using System.Collections.Generic;

namespace RomanConvert.ConsoleApp
{
	public class Program
	{
		static void Main(string[] args)
		{
			var actual = Solution(1954);
			const string expected = "MCMLIV";
			Console.WriteLine($"Are equal {actual.Equals(expected, StringComparison.Ordinal)}");
		}

		public static string Solution(int n)
		{
			var letters = new List<string>();
			var count = 1000;
			while (n > 0)
			{
				if (n / 1000 > 0)
				{
					var quotient = n / 1000;
					var digitValue = quotient * 1000;
					switch (digitValue)
					{
						case 4000:
							letters.Add("CD");
							n -= digitValue;
							continue;
						case 5000:
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
						letters.Add("M");
					}
					n -= digitValue;
				}
				else if (n / 100 > 0)
				{
					var quotient = n / 100;
					var digitValue = quotient * 100;
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

					const string hundred = "C";
					if (digitValue < 400)
					{
						for (var i = 0; i < quotient; i++)
						{
							letters.Add(hundred);
						}
					}
					else if (digitValue > 500)
					{
						var remainder = quotient % 5;
						var temp = "D";
						for (var i = 0; i < remainder; i++)
						{

							temp += hundred;
						}
						letters.Add(temp);
					}

					n -= digitValue;
				}
				else if (n / 10 > 0)
				{
					var quotient = n / 10;
					var digitValue = quotient * 10;
					switch (digitValue)
					{
						case 40:
							letters.Add("XL");
							n -= digitValue;
							continue;
						case 50:
							letters.Add("L");
							n -= digitValue;
							continue;
						case 90:
							letters.Add("XC");
							n -= digitValue;
							continue;
					}

					const string ten = "X";
					if (digitValue < 40)
					{
						for (var i = 0; i < quotient; i++)
						{
							letters.Add(ten);
						}
					}
					else if (digitValue > 50)
					{
						var remainder = quotient % 5;
						var temp = "L";
						for (var i = 0; i < remainder; i++)
						{

							temp += ten;
						}
						letters.Add(temp);
					}

					n -= digitValue;
				}
				else if (n / 1 > 0)
				{
					var quotient = n / 1;
					var digitValue = quotient * 1;
					switch (digitValue)
					{
						case 1:
							letters.Add("I");
							n -= digitValue;
							continue;
						case 2:
							letters.Add("II");
							n -= digitValue;
							continue;
						case 3:
							letters.Add("III");
							n -= digitValue;
							continue;
						case 4:
							letters.Add("IV");
							n -= digitValue;
							continue;
						case 5:
							letters.Add("V");
							n -= digitValue;
							continue;
						case 6:
							letters.Add("VI");
							n -= digitValue;
							continue;
						case 7:
							letters.Add("VII");
							n -= digitValue;
							continue;
						case 8:
							letters.Add("VIII");
							n -= digitValue;
							continue;
						case 9:
							letters.Add("IX");
							n -= digitValue;
							continue;
					}

					n -= quotient;
				}

				count /= 10;
			}

			var roman = string.Join(null, letters.ToArray());
			return roman;
		}
	}
}
