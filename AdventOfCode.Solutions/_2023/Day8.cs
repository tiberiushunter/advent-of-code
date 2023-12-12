using AdventOfCode.Domain.Interfaces;
using AdventOfCode.Solutions.Extensions;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions._2023;

public class Day8 : IDay
{
	public string Title => "Haunted Wasteland";

	public string PartA(string input)
	{
		var parsedInput = input.Split("\n\n");

		var instructions = parsedInput[0].ToCharArray();

		var network = parsedInput[1]
			.Split("\n")
			.Select(line => Regex.Match(line, @"([A-Z]+) = \(([A-Z]+), ([A-Z]+)\)", RegexOptions.Compiled))
			.ToDictionary(match => match.Groups[1].Value, match => (match.Groups[2].Value, match.Groups[3].Value));

		var currentNode = "AAA";
		int counter = 0;

		foreach (var instruction in instructions.InfiniteSelect())
		{
			counter++;
			switch (instruction)
			{
				case 'L':
					currentNode = network[currentNode].Item1;
					break;
				case 'R':
					currentNode = network[currentNode].Item2;
					break;
			}

			if (currentNode == "ZZZ")
			{
				break;
			}
		}

		return counter.ToString();
	}

	public string PartB(string input)
	{
		var parsedInput = input.Split("\n\n");

		var instructions = parsedInput[0].ToCharArray();

		var network = parsedInput[1]
			.Split("\n")
			.Select(line => Regex.Match(line, @"([A-Z]+) = \(([A-Z]+), ([A-Z]+)\)", RegexOptions.Compiled))
			.ToDictionary(match => match.Groups[1].Value, match => (match.Groups[2].Value, match.Groups[3].Value));

		var currentNodes = network.Where(a => a.Key.EndsWith("A")).Select(a => a.Key).ToList();
		var minimumStepsForEachPath = new long[currentNodes.Count];

		int counter = 0;

		foreach (var instruction in instructions.InfiniteSelect())
		{
			counter++;

			switch (instruction)
			{
				case 'L':
					for (int i = 0; i < currentNodes.Count; i++)
					{
						currentNodes[i] = network[currentNodes[i]].Item1;
					}
					break;
				case 'R':
					for (int i = 0; i < currentNodes.Count; i++)
					{
						currentNodes[i] = network[currentNodes[i]].Item2;
					}
					break;
			}

			for (int i = 0; i < currentNodes.Count; i++)
			{
				if (currentNodes[i].EndsWith('Z') && minimumStepsForEachPath[i] == 0)
				{
					minimumStepsForEachPath[i] = counter;
				}
			}

			if (minimumStepsForEachPath.All(a => a > 0))
			{
				break;
			}
		}

		return minimumStepsForEachPath.Aggregate((a, b) => a * b / GreatestCommonDivisor(a, b)).ToString();
	}

	private static long GreatestCommonDivisor(long x, long y)
	{
		if (y == 0) { return x; }

		return GreatestCommonDivisor(y, x % y);
	}
}
