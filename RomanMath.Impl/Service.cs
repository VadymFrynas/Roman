using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RomanMath.Impl
{
	public static class Service
	{
		/// <summary>
		/// See TODO.txt file for task details.
		/// Do not change contracts: input and output arguments, method name and access modifiers
		/// </summary>
		/// <param name="expression"></param>
		/// <returns></returns>
		private static bool CheckInput(string expression)
		{
			bool CheckResult = true;
			string MathSymbol = "*+-";
			string Check = "IVXLCDM+-* ";
			if (expression == null || expression == " " || expression == "")
			{
				CheckResult = false;
			}
			else
			{
				for (int i = 0; i < expression.Length - 1; i++)
				{
					if (MathSymbol.IndexOf(expression[0]) != -1 || MathSymbol.IndexOf(expression[expression.Length - 1]) != -1)
					{
						CheckResult = false;
					}
					else if (Check.IndexOf(expression[i]) == -1)
					{
						CheckResult = false;
					}
					else if (MathSymbol.IndexOf(expression[i]) != -1 && MathSymbol.IndexOf(expression[i + 1]) != -1)
					{
						CheckResult = false;

					}


				}
			}
			return CheckResult;

		}
		private static int MathAction(int firstDigit, int secondDigit, char math)
		{
			int Result = 0;
			switch (math)
			{
				case '*':
					{
						Result = firstDigit * secondDigit;
						break;
					}
				case '+':
					{
						Result = firstDigit + secondDigit;
						break;
					}
				case '-':
					{
						Result = firstDigit - secondDigit;
						break;
					}
			}
			return Result;

		}
		public static int Evaluate(string expression)
		{

			bool CheckResult = CheckInput(expression);
			if (!CheckResult)
			{
				return -1;
			}
			else
			{
				char[] ExpressionAsArray = expression.ToCharArray();
				int CheckPoint = 0;
				List<char> Math = new List<char>();
				List<char[]> RomanDigit = new List<char[]>();
				List<int> FinalArabianDigit = new List<int>();
				for (int i = 0; i < expression.Length; i++)
				{
					if (expression[i] == '*' || expression[i] == '+' || expression[i] == '-')
					{
						char[] TempRes = new char[i - CheckPoint];
						Array.Copy(ExpressionAsArray, CheckPoint, TempRes, 0, i - CheckPoint);
						CheckPoint = i + 1;
						RomanDigit.Add(TempRes);
						Math.Add(expression[i]);
					}
					if (i == expression.Length - 1)
					{
						char[] TempRes = new char[i + 1 - CheckPoint];
						Array.Copy(ExpressionAsArray, CheckPoint, TempRes, 0, i - CheckPoint + 1);
						CheckPoint = i + 1;
						RomanDigit.Add(TempRes);
					}

				}
				FinalArabianDigit = ArabianDigitConverting.NumberConvert(RomanDigit);
				int FinalResult = FinalArabianDigit[0];
				for (int i = 0; i < Math.Count; i++)
				{
					FinalResult = MathAction(FinalResult, FinalArabianDigit[i + 1], Math[i]);
				}
				return FinalResult;
			}
		}
	}
}
