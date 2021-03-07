using System;
using System.Collections.Generic;
using System.Text;

namespace RomanMath.Impl
{
	class ArabianDigitConverting
	{

		private static int ToArabic(char[] RomanDigit)
		{
			int FinalDigit = 0;
			int[] TempArabicArray = new int[RomanDigit.Length];
			for (int i = 0; i < RomanDigit.Length; i++)
			{
				switch (RomanDigit[i])
				{
					case 'I':
						{
							TempArabicArray[i] = 1;
							break;
						}
					case 'V':
						{
							TempArabicArray[i] = 5;
							break;
						}
					case 'X':
						{
							TempArabicArray[i] = 10;
							break;
						}
					case 'L':
						{
							TempArabicArray[i] = 50;
							break;
						}
					case 'C':
						{
							TempArabicArray[i] = 100;
							break;
						}
					case 'D':
						{
							TempArabicArray[i] = 500;
							break;
						}
					case 'M':
						{
							TempArabicArray[i] = 1000;
							break;
						}
				}
			}
			for (int i = 0; i < TempArabicArray.Length; i++)
			{
				if (TempArabicArray.Length - i == 1)
				{
					FinalDigit += TempArabicArray[i];
					break;
				}
				else if (TempArabicArray.Length - i == 2)
				{
					if (TempArabicArray[i] < TempArabicArray[i + 1]) FinalDigit += TempArabicArray[i + 1] - TempArabicArray[i];
					else FinalDigit += TempArabicArray[i] + TempArabicArray[i + 1];
					break;
				}
				else
				{
					if (TempArabicArray[i] == TempArabicArray[i + 1])
					{
						FinalDigit += TempArabicArray[i] + TempArabicArray[i++];
						while (i < TempArabicArray.Length - 1 && TempArabicArray[i + 1] == TempArabicArray[i])
						{
							FinalDigit += TempArabicArray[i + 1];
							i++;
						}
					}
					else
					{
						if (TempArabicArray[i] > TempArabicArray[i + 1])
						{
							FinalDigit += TempArabicArray[i];
						}
						else
						{
							FinalDigit += TempArabicArray[i + 1] - TempArabicArray[i];
							i++;
						}

					}

				}
			}
			return FinalDigit;
		}
		public static List<int> NumberConvert(List<char[]> RomanDigit)
		{

			List<int> ArabicDigit = new List<int>();
			foreach (var item in RomanDigit)
			{
				ArabicDigit.Add(ToArabic(item));
			}

			return ArabicDigit;
		}


	}
}

