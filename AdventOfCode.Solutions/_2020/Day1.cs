using AdventOfCode.Domain.Interfaces;
using AdventOfCode.Solutions.Helpers;

namespace AdventOfCode.Solutions._2020;

public class Day1 : IDay
{
	public string Title => "Report Repair";

	public string PartA(string input)
	{
		var listOfExpenses = InputHelper.ToInt(input).ToArray();

		for (int i = 0; i < listOfExpenses.Length; i++)
		{
			for (int j = 1; j < listOfExpenses.Length; j++)
			{
				if (listOfExpenses[i] + listOfExpenses[j] == 2020)
				{
					return (listOfExpenses[i] * listOfExpenses[j]).ToString();
				}
			}
		}

		return string.Empty;
	}

	public string PartB(string input)
	{
		var listOfExpenses = InputHelper.ToInt(input).ToArray();

		for (int i = 0; i < listOfExpenses.Length; i++)
		{
			for (int j = 1; j < listOfExpenses.Length; j++)
			{
				for (int k = 2; k < listOfExpenses.Length; k++)
				{
					if (listOfExpenses[i] + listOfExpenses[j] + listOfExpenses[k] == 2020)
					{
						return (listOfExpenses[i] * listOfExpenses[j] * listOfExpenses[k]).ToString();
					}
				}
			}
		}

		return string.Empty;
	}
}
