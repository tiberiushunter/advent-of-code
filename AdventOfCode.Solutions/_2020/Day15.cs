using AdventOfCode.Domain.Interfaces;

namespace AdventOfCode.Solutions._2020;

public class Day15 : IDay
{
	public string Title => "Rambunctious Recitation";

	public string PartA(string input)
	{
		var startingNumbers = input
			.Split(',')
			.Select(n => int.Parse(n))
			.ToArray();

		return GetSpokenNumberAtTurn(startingNumbers, 2020).ToString();
	}

	public string PartB(string input)
	{
		var startingNumbers = input
			.Split(',')
			.Select(n => int.Parse(n))
			.ToArray();

		return GetSpokenNumberAtTurn(startingNumbers, 30000000).ToString();
	}

	private int GetSpokenNumberAtTurn(int[] startingNumbers, int numberOfTurns)
	{
		int[] spokenNumbers = new int[numberOfTurns];
		int currentNumber = 0;

		for (int i = 0; i < startingNumbers.Length - 1; i++)
		{
			spokenNumbers[startingNumbers[i]] = i + 1;
			currentNumber = startingNumbers[i + 1];
		}

		for (int i = startingNumbers.Length - 1; i < numberOfTurns - 1; i++)
		{
			int spokenNumber = spokenNumbers[currentNumber];
			spokenNumbers[currentNumber] = i + 1;
			currentNumber = spokenNumber == 0 ? 0 : i + 1 - spokenNumber;
		}

		return currentNumber;
	}
}
