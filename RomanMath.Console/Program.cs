﻿using System;
using RomanMath.Impl;

namespace RomanMath.Console
{
	class Program
	{
		/// <summary>
		/// Use this method for local debugging only. The implementation should remain in RomanMath.Impl project.
		/// See TODO.txt file for task details.
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			var result = Service.Evaluate("X-V*III");
			if (result == -1) System.Console.WriteLine("Expression uncorrect");
			else System.Console.WriteLine(result);
			System.Console.ReadKey();
		}
	}
}
