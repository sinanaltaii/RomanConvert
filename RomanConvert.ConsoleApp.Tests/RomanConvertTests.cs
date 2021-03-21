using NUnit.Framework;

namespace RomanConvert.ConsoleApp.Tests
{
	public class RomanConvertTests
	{
		[SetUp]
		public void Setup()
		{
		}

		[TestCase(1, "I")]
		[TestCase(2, "II")]
		[TestCase(4, "IV")]
		[TestCase(500, "D")]
		[TestCase(1000, "M")]
		[TestCase(1954, "MCMLIV")]
		[TestCase(1990, "MCMXC")]
		[TestCase(2008, "MMVIII")]
		[TestCase(2014, "MMXIV")]
		public void Test(int value, string expected)
		{
			Assert.AreEqual(expected, Program.Solution(value));
		}
	}
}