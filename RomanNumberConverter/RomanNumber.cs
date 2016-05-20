using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanNumberConverter
{
	public class RomanNumber
	{
		private readonly int _number;

		private readonly IDictionary<int, string>[] _digitsMap = new IDictionary<int, string>[]
		{
			new Dictionary<int, string>
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
			},
			new Dictionary<int, string>
			{
				{1, "X"},
				{2, "XX"},
				{3, "XXX"},
				{4, "XL"},
				{5, "L"},
				{6, "LX"},
				{7, "LXX"},
				{8, "LXXX"},
				{9, "XC"},
			},
			new Dictionary<int, string>
			{
				{1, "C"},
				{2, "CC"},
				{3, "CCC"},
				{4, "CD"},
				{5, "D"},
				{6, "DC"},
				{7, "DCC"},
				{8, "DCCC"},
				{9, "CM"},
			},
			new Dictionary<int, string>
			{
				{1, "M"},
				{2, "MM"},
				{3, "MMM"},
			}
		};

		public RomanNumber(int number)
		{
			if (number < 1 || number > 3999)
				throw new ArgumentException("number");

			_number = number;
		}

		public IEnumerable<int> Digits()
		{
			var number = _number;

			while (number > 0)
			{
				var digit = number % 10;
				number /= 10;
				yield return digit;
			}
		} 

		public override string ToString()
		{
			var number = _number;
			var result = string.Empty;
			var position = 0;

			while (number > 0)
			{
				var digit = number % 10;
				number /= 10;
				if (digit > 0)
				{
					result = _digitsMap[position][digit] + result;
				}
				position++;
			}

			return result;
		}

		public string ToString2()
		{
			var mappedDigits = Digits()
				.Select(MapDigit)
				.ToList();

			mappedDigits.Reverse();

			return string.Join("", mappedDigits);
		}

		private string MapDigit(int digit, int index)
		{
			return (digit > 0) ? _digitsMap[index][digit] : string.Empty;
		}
	}
}
