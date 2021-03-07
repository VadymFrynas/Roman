using NUnit.Framework;
using RomanMath.Impl;

namespace RomanMath.Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void TestCheckInput1()
		{
			var result = Service.Evaluate("*V+I");
			Assert.AreEqual(-1, result);
		}
		[Test]
		public void TestCheckInput2()
		{
			var result = Service.Evaluate("V++I");
			Assert.AreEqual(-1, result);
		}
		[Test]
		public void TestCheckInput3()
		{
			var result = Service.Evaluate("*V+IP");
			Assert.AreEqual(-1, result);
		}
		[Test]
		public void TestCheckInput4()
		{
			var result = Service.Evaluate("V+I");
			Assert.AreEqual(6, result);
		}
		[Test]
		public void TestToArabicAllCases()
		{
			var result = Service.Evaluate("XXXIV-XVI+I+XIV+L-C-D+M");
			Assert.AreEqual(483, result);
		}



	}
}