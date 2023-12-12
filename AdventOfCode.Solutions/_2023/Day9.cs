using AdventOfCode.Domain.Interfaces;
using AdventOfCode.Solutions.Helpers;

namespace AdventOfCode.Solutions._2023;

public class Day9 : IDay
{
	public string Title => "Mirage Maintenance";

	public string PartA(string input)
	{
		var instructions = InputHelper.ToStringArray(input);

		long sumOfExtrapolatedValues = 0L;

		foreach (var line in instructions)
		{
			var parsedLine = line.Split(' ').Select(int.Parse).ToList();

			var dataset = GenerateDataset(parsedLine);

			for(int i = 1; i < dataset.Count; i++)
			{
				dataset
					.ElementAt(i)
					.Add(dataset.ElementAt(i).Last() + dataset.ElementAt(i - 1).Last());
			}

			sumOfExtrapolatedValues += dataset.Last().Last();
		}

		return sumOfExtrapolatedValues.ToString();
	}

	public string PartB(string input)
	{
		var instructions = InputHelper.ToStringArray(input);

		long sumOfExtrapolatedValues = 0L;

		foreach (var line in instructions)
		{
			var parsedLine = line.Split(' ').Select(int.Parse).ToList();

			var dataset = GenerateDataset(parsedLine);

			for (int i = 1; i < dataset.Count; i++)
			{
				dataset
					.ElementAt(i)
					.Insert(0, dataset.ElementAt(i).First() - dataset.ElementAt(i - 1).First());
			}

			sumOfExtrapolatedValues += dataset.Last().First();
		}

		return sumOfExtrapolatedValues.ToString();
	}

	private static List<List<int>> GenerateDataset(List<int> firstLine)
	{
		var dataset = new List<List<int>>
		{
			firstLine
		};

		while (dataset.Last().Any(x => x != 0))
		{
			dataset.Add(GenerateNextLine(dataset.Last()));
		}

		dataset.Reverse();
		dataset.First().Add(0);

		return dataset;
	}

	private static List<int> GenerateNextLine(List<int> line)
	{
		var nextLine = new List<int>();

		for (int i = 0; i < line.Count - 1; i++)
		{
			nextLine.Add(line[i + 1] - line[i]);
		}

		return nextLine;
	}
}
