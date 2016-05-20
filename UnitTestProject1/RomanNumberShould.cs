using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumberConverter;

namespace UnitTestProject1
{
	[TestClass]
	public class RomanNumberShould
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void NotConvertInvalidNumbers()
		{
			var number = new RomanNumber(-1);
		}

		[TestMethod]
		public void ConvertOneDigitNumbers()
		{
			Assert.AreEqual(new RomanNumber(2).ToString(), "II");
			Assert.AreEqual(new RomanNumber(4).ToString(), "IV");
			Assert.AreEqual(new RomanNumber(8).ToString(), "VIII");
		}

		[TestMethod]
		public void ConvertTwoDigitsNumbers()
		{
			Assert.AreEqual(new RomanNumber(57).ToString(), "LVII");
			Assert.AreEqual(new RomanNumber(10).ToString(), "X");
			Assert.AreEqual(new RomanNumber(63).ToString(), "LXIII");
			Assert.AreEqual(new RomanNumber(99).ToString(), "XCIX");
		}

		[TestMethod]
		public void ConvertThreeDigitsNumbers()
		{
			Assert.AreEqual(new RomanNumber(123).ToString(), "CXXIII");
			Assert.AreEqual(new RomanNumber(444).ToString(), "CDXLIV");
			Assert.AreEqual(new RomanNumber(686).ToString(), "DCLXXXVI");
			Assert.AreEqual(new RomanNumber(999).ToString(), "CMXCIX");
		}

		[TestMethod]
		public void ConvertFourDigitsNumbers()
		{
			Assert.AreEqual(new RomanNumber(1999).ToString(), "MCMXCIX");
			Assert.AreEqual(new RomanNumber(2345).ToString(), "MMCCCXLV");
			Assert.AreEqual(new RomanNumber(1000).ToString(), "M");
			Assert.AreEqual(new RomanNumber(3999).ToString(), "MMMCMXCIX");
		}
	}
}
