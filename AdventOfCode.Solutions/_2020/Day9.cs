using AdventOfCode.Domain.Interfaces;
using AdventOfCode.Solutions.Helpers;

namespace AdventOfCode.Solutions._2020;

public class Day9 : IDay
{
	public string Title => "Encoding Error";

	public string PartA(string input)
	{
		var inputArray = InputHelper.ToLong(input).ToArray();

		return FindInvalidNumber(inputArray, 25).ToString();
	}

	public string PartB(string input)
	{
		var inputArray = InputHelper.ToLong(input).ToArray();

		long partA = FindInvalidNumber(inputArray, 25);
		long answer = 0L;

		long[] contiguousRange;
		bool sumFound = false;
		int currentPreamble = 2;

		while (!sumFound)
		{
			for (int i = currentPreamble - 1; i < inputArray.Length; i++)
			{
				long total = 0;
				contiguousRange = new long[currentPreamble];

				for (int k = 0; k < currentPreamble; k++)
				{
					total += inputArray[i - k];
					contiguousRange[k] = inputArray[i - k];
				}

				if (partA == total)
				{
					var min = contiguousRange.OrderBy(p => p).First();
					var max = contiguousRange.OrderByDescending(p => p).First();

					answer = min + max;
					sumFound = true;
				}
			}
			currentPreamble++;
		}

		return answer.ToString();
	}

	private long FindInvalidNumber(long[] input, int preamble)
	{
		for (int i = preamble; i <= input.Length; i++)
		{
			bool sumFound = false;

			for (int j = i - preamble; j < i; j++)
			{
				for (int k = i - preamble; k < i; k++)
				{
					if (input[i] == input[j] + input[k])
					{
						sumFound = true;
					}
				}
			}

			if (!sumFound)
			{
				return input[i];
			}

		}
		return 0;
	}
}
