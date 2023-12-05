using AdventOfCode.Domain.Interfaces;
using AdventOfCode.Solutions.Helpers;

namespace AdventOfCode.Solutions._2020;

public class Day5 : IDay
{
	public string Title => "Binary Boarding";

	public string PartA(string input)
	{
		var seats = GenerateSeats(InputHelper.ToStringArray(input));

		return seats.Max().ToString();
	}

	public string PartB(string input)
	{
		var seats = GenerateSeats(InputHelper.ToStringArray(input));

		seats = seats.OrderBy(c => c).ToArray();

		int emptySeat = Enumerable
			.Range(seats.First(), seats.Last() - seats.First() + 1)
			.Except(seats).ToArray()[0];

		return emptySeat.ToString();
	}

	private int[] GenerateSeats(string[] input)
	{
		var seats = new int[input.Length];

		for (int i = 0; i < input.Length; i++)
		{
			int[,] rowRange = new int[1, 2] { { 0, 127 } };
			int[,] colRange = new int[1, 2] { { 0, 7 } };

			int row = BinarySearchPartition(rowRange, input[i].Substring(0, 7), 'F');
			int col = BinarySearchPartition(colRange, input[i].Substring(7, 3), 'L');

			seats[i] = (row * 8) + col;
		}

		return seats;
	}

	private static int BinarySearchPartition(int[,] range, string input, char lowerPart)
	{
		int result = -1;

		for (int i = 0; i < input.Length; i++)
		{
			if (input[i] == lowerPart)
			{
				range[0, 1] = (range[0, 1] - (range[0, 1] - range[0, 0]) / 2) - 1;

				if (i == input.Length - 1)
				{
					result = range[0, 1];
				}
			}
			else
			{
				range[0, 0] = (range[0, 0] + (range[0, 1] - range[0, 0]) / 2) + 1;

				if (i == input.Length - 1)
				{
					result = range[0, 0];
				}
			}
		}
		return result;
	}
}
