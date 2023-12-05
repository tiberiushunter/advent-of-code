using AdventOfCode.Domain.Interfaces;
using AdventOfCode.Solutions.Helpers;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions._2023;

public class Day2 : IDay
{
	public string Title => "Cube Conundrum";

	public string PartA(string input)
	{
		var listOfGames = InputHelper
			.ToStringArray(input);

		var maxCubeColours = new Dictionary<CubeColor, int>()
		{
			{ CubeColor.Red, 12 },
			{ CubeColor.Green, 13 },
			{ CubeColor.Blue, 14 },
		};

		var validGames = new List<int>();

		for (int i = 1; i < listOfGames.Length + 1; i++)
		{
			var sets = Regex.Replace(listOfGames[i - 1], @"Game \d*: ", "", RegexOptions.Compiled)
				.Split(';');
			bool validGame = true;

			foreach (var set in sets)
			{
				var cubes = set.Split(',', StringSplitOptions.TrimEntries);

				foreach (var cube in cubes)
				{
					var matches = Regex.Match(cube, @"(\d*) (\w*)", RegexOptions.Compiled);

					int numberOfCubes = int.Parse(matches.Groups[1].Value);
					Enum.TryParse(matches.Groups[2].Value, true, out CubeColor cubeColour);

					if (numberOfCubes > maxCubeColours[cubeColour])
					{
						validGame = false;
					};
				}
			}
			if (validGame)
			{
				validGames.Add(i);
			}
		}

		return validGames.Sum().ToString();
	}

	public string PartB(string input)
	{
		var listOfGames = InputHelper
			.ToStringArray(input);

		var powerOfCubes = new List<int>();

		for (int i = 1; i < listOfGames.Length + 1; i++)
		{
			var sets = Regex.Replace(listOfGames[i - 1], @"Game \d*: ", "", RegexOptions.Compiled)
				.Split(';');

			var maxCubeColours = new Dictionary<CubeColor, int>()
			{
				{ CubeColor.Red, 0 },
				{ CubeColor.Green, 0 },
				{ CubeColor.Blue, 0 },
			};

			foreach (var set in sets)
			{
				var cubes = set.Split(',', StringSplitOptions.TrimEntries);

				foreach (var cube in cubes)
				{
					var matches = Regex.Match(cube, @"(\d*) (\w*)", RegexOptions.Compiled);

					int numberOfCubes = int.Parse(matches.Groups[1].Value);
					Enum.TryParse(matches.Groups[2].Value, true, out CubeColor cubeColour);

					if (numberOfCubes > maxCubeColours[cubeColour])
					{
						maxCubeColours[cubeColour] = numberOfCubes;
					};
				}
			}

			powerOfCubes.Add(
				maxCubeColours[CubeColor.Red]
				* maxCubeColours[CubeColor.Blue]
				* maxCubeColours[CubeColor.Green]
			);
		}

		return powerOfCubes.Sum().ToString();
	}

	private enum CubeColor
	{
		Red,
		Blue,
		Green
	}
}
