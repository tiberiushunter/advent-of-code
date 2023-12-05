using AdventOfCode.Domain.Interfaces;

namespace AdventOfCode.Solutions._2021;
public class Day2 : IDay
{
	public string Title => "Dive!";

	public string PartA(string input)
	{
		var listInput = input.Split('\n')
				.Select(line => line.Split(' '))
				.Select(arg => new KeyValuePair<string, int>(arg[0], Convert.ToInt32(arg[1])))
				.ToList();
		int horizontalPosition = 0;
		int depth = 0;

		foreach (var command in listInput)
		{
			switch (command.Key)
			{
				case Direction.Forward:
					horizontalPosition -= command.Value;
					break;

				case Direction.Up:
					depth += command.Value;
					break;

				case Direction.Down:
					depth -= command.Value;
					break;
			}
		}

		int result = horizontalPosition * depth;

		return result.ToString();
	}

	public string PartB(string input)
	{
		var listInput = input.Split('\n')
				.Select(line => line.Split(' '))
				.Select(arg => new KeyValuePair<string, int>(arg[0], Convert.ToInt32(arg[1])))
				.ToList();

		int horizontalPosition = 0;
		int depth = 0;
		int aim = 0;

		foreach (var command in listInput)
		{
			switch (command.Key)
			{
				case Direction.Forward:
					horizontalPosition += command.Value;
					depth += aim * command.Value;
					break;

				case Direction.Up:
					aim -= command.Value;
					break;

				case Direction.Down:
					aim += command.Value;
					break;
			}
		}

		int result = horizontalPosition * depth;

		return result.ToString();
	}

	internal sealed class Direction
	{
		public const string Forward = "forward";
		public const string Up = "up";
		public const string Down = "down";
	}
}
