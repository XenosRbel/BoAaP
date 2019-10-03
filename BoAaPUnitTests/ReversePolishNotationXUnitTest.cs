using Laba9;
using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace BoAaPUnitTests
{
	public class ReversePolishNotationXUnitTest
	{
		[Theory]
		[MemberData(nameof(ArrayData))]
		public void Calculate(string expression, double a, double b, double c, double d, double e, string expected) 
		{

			var exp = CreateNormalExpression(expression, a, b, c, d, e);
			var actual = ReversePolishNotation.Calculate(exp);

			expected = expected.Replace(".", ",");

			Assert.Equal(expected, actual.ToString("N3"));
		}

		public static IEnumerable<object[]> ArrayData()
		{
			yield return new object[] { "a / (b - c) * (d + e)", 8.6, 2.4, 5.1, 0.3, 7.9, "-26.119" };
			yield return new object[] { "a * (b - c) / (d + e)", 0.5, 6.1, 8.9, 2.4, 7.3, "-0.144" };
		}

		public string CreateNormalExpression(string expression, double a, double b, double c, double d, double e) 
		{
			var result = string.Empty;
			var chars = expression.ToCharArray().Select(v => Convert.ToString(v)).ToArray();

			for (int i = 0; i < chars.Length; i++)
			{
				switch (chars[i])
				{
					case "a":
						chars[i] = a.ToString();
						continue;
					case "b":
						chars[i] = b.ToString();
						continue;
					case "c":
						chars[i] = c.ToString();
						continue;
					case "d":
						chars[i] = d.ToString();
						continue;
					case "e":
						chars[i] = e.ToString();
						continue;
					default:
						continue;
				}
			}
			result = string.Join("", chars);
			return result;
		}
	}
}
