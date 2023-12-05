using AdventOfCode.Domain.Interfaces;
using AdventOfCode.Solutions.Helpers;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions._2023;

public class Day1 : IDay
{
	public string Title => "Trebuchet?!";

	public string PartA(string input)
	{
		var corruptedCalibrationValues = InputHelper
			.ToStringArray(input)
			.ToList();

		int sumOfCalibrationValues = 0;

		foreach (var instruction in corruptedCalibrationValues)
		{
			var parsedInstruction = Regex.Replace(instruction, @"[A-z]", "", RegexOptions.Compiled);

			if (parsedInstruction.Length > 1)
			{
				sumOfCalibrationValues += int.Parse(
					parsedInstruction[0]
					+ parsedInstruction[^1].ToString());
			}
			else
			{
				sumOfCalibrationValues += int.Parse(parsedInstruction[0] + parsedInstruction[0].ToString());
			}
		}

		return sumOfCalibrationValues.ToString();
	}

	public string PartB(string input)
	{
		var corruptedCalibrationValues = InputHelper
			.ToStringArray(input)
			.ToList();

		int sumOfCalibrationValues = 0;

		var textNumbers = new Dictionary<int, string>()
		{
			{ 1, "one" },
			{ 2, "two" },
			{ 3, "three" },
			{ 4, "four" },
			{ 5, "five" },
			{ 6, "six" },
			{ 7, "seven" },
			{ 8, "eight" },
			{ 9, "nine" }
		};

		foreach (var instruction in corruptedCalibrationValues)
		{
			string parsedInstruction = instruction;

			foreach (var textNumber in textNumbers)
			{
				parsedInstruction = parsedInstruction.Replace(textNumber.Value, textNumber.Value + textNumber.Key + textNumber.Value);
			}

			parsedInstruction = Regex.Replace(parsedInstruction, @"[A-z]", "", RegexOptions.Compiled);

			if (parsedInstruction.Length > 1)
			{
				sumOfCalibrationValues += int.Parse(
					parsedInstruction[0]
					+ parsedInstruction[^1].ToString());
			}
			else
			{
				sumOfCalibrationValues += int.Parse(parsedInstruction[0] + parsedInstruction[0].ToString());
			}
		}

		return sumOfCalibrationValues.ToString();
	}

}
