using AdventOfCode.Domain.Interfaces;
using AdventOfCode.Solutions.Helpers;

namespace AdventOfCode.Solutions._2020;

public class Day3 : IDay
{
	public string Title => "Toboggan Trajectory";

	public string PartA(string input)
	{
		var parsedInput = InputHelper.ToStringArray(input);

		return CalculateNumberOfTrees(parsedInput, 3, 1).ToString();
	}

	public string PartB(string input)
	{
		var parsedInput = InputHelper.ToStringArray(input);

		return (CalculateNumberOfTrees(parsedInput, 1, 1) *
			CalculateNumberOfTrees(parsedInput, 3, 1) *
			CalculateNumberOfTrees(parsedInput, 5, 1) *
			CalculateNumberOfTrees(parsedInput, 7, 1) *
			CalculateNumberOfTrees(parsedInput, 1, 2))
			.ToString();
	}
	private long CalculateNumberOfTrees(string[] input, int x, int y)
	{
		int numberOfTress = 0;

		for (int i = y; i < input.Length; i += y)
		{
			int mod = (x * i) % (input[i - 1].Length);

			if (input[i][mod] == '#')
			{
				numberOfTress++;
			}
		}
		return numberOfTress;
	}
}
