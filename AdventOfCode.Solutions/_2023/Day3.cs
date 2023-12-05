using AdventOfCode.Domain.Interfaces;
using AdventOfCode.Solutions.Helpers;

namespace AdventOfCode.Solutions._2023;

public class Day3 : IDay
{
	public string Title => "Gear Ratios";

	public string PartA(string input)
	{
		var engineSchematic = InputHelper
			.ToStringArray(input);

		int maxX = engineSchematic[0].Length - 1;
		int maxY = engineSchematic.Length - 1;

		int sumOfPartNumbers = 0;

		foreach ((int x, int y) in from X in Enumerable.Range(0, engineSchematic[0].Length)
								   from Y in Enumerable.Range(0, engineSchematic.Length)
								   where _symbols.Contains(engineSchematic[X][Y])
								   select (X, Y))
		{
			var partNumbers = boundaryCoords
				.Select(nearBy => (nX: nearBy.x + x, nY: nearBy.y + y))
				.Where(nearBy => nearBy.nX >= 0 && nearBy.nX <= maxX
								&& nearBy.nY >= 0 && nearBy.nY <= maxY)
					.Select(s => FindPartNumber(engineSchematic[s.nX], s.nY))
					.Where(num => num > 0)
					.ToHashSet();

			sumOfPartNumbers += partNumbers.Sum();
		}

		return sumOfPartNumbers.ToString();
	}

	public string PartB(string input)
	{
		var engineSchematic = InputHelper
			.ToStringArray(input);

		int maxX = engineSchematic[0].Length - 1;
		int maxY = engineSchematic.Length - 1;

		int sumOfGearRatiosNumbers = 0;

		foreach ((int x, int y) in from X in Enumerable.Range(0, engineSchematic[0].Length)
								   from Y in Enumerable.Range(0, engineSchematic.Length)
								   where _symbols.Contains(engineSchematic[X][Y])
								   select (X, Y))
		{
			var partNumbers = boundaryCoords
				.Select(nearBy => (nX: nearBy.x + x, nY: nearBy.y + y))
				.Where(nearBy => nearBy.nX >= 0 && nearBy.nX <= maxX
								&& nearBy.nY >= 0 && nearBy.nY <= maxY)
					.Select(s => FindPartNumber(engineSchematic[s.nX], s.nY))
						.Where(num => num > 0)
						.ToHashSet();

			if (engineSchematic[x][y] == '*' && partNumbers.Count == 2)
			{
				sumOfGearRatiosNumbers += partNumbers.Aggregate((x, y) => x * y);
			}
		}

		return sumOfGearRatiosNumbers.ToString();
	}

	private int FindPartNumber(string input, int index)
	{
		if (!char.IsAsciiDigit(input[index])) { return -1; }

		int partNumberStartIndex = input.LastIndexOfAny(_allSymbols, index) + 1;
		int partNumberEndIndex = input.IndexOfAny(_allSymbols, partNumberStartIndex);

		if (partNumberEndIndex == -1)
		{
			partNumberEndIndex = input.Length;
		}

		if (int.TryParse(input[partNumberStartIndex..partNumberEndIndex], out int partNumber))
		{
			return partNumber;
		}

		return -1;
	}

	private List<(int x, int y)> boundaryCoords =
		[
			(-1, 1),
			(0, 1),
			(1, 1),
			(-1, 0),
			(1, 0),
			(-1, -1),
			(0, -1),
			(1, -1),
		];

	private readonly char[] _symbols =
	[
		'*',
		'#',
		'+',
		'$',
		'-',
		'%',
		'&',
		'/',
		'@',
		'='
	];

	private readonly char[] _allSymbols =
	[
		'*',
		'#',
		'+',
		'$',
		'-',
		'%',
		'&',
		'/',
		'@',
		'=',
		'.'
	];
}
