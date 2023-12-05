using AdventOfCode.Domain.Interfaces;
using AdventOfCode.Solutions.Helpers;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions._2020;

public class Day12 : IDay
{
	private Regex _parsedInstructions = new Regex(@"([A-Z])([0-9]+)", RegexOptions.Compiled);

	public string Title => "Seating System";

	public string PartA(string input)
	{
		var headingInstructions = InputHelper.ToStringArray(input);

		int x = 0;
		int y = 0;

		int rotation = 90;

		foreach (string instruction in headingInstructions)
		{
			Match m = _parsedInstructions.Match(instruction);
			if (m.Success)
			{
				switch (m.Groups[1].Value[0])
				{
					case Heading.North:
						x += int.Parse(m.Groups[2].Value);
						break;

					case Heading.South:
						x -= int.Parse(m.Groups[2].Value);
						break;

					case Heading.East:
						y += int.Parse(m.Groups[2].Value);
						break;

					case Heading.West:
						y -= int.Parse(m.Groups[2].Value);
						break;

					case Heading.Left:
						rotation -= int.Parse(m.Groups[2].Value);
						rotation %= 360;
						if (rotation < 0)
						{
							rotation += 360;
						}
						break;

					case Heading.Right:
						rotation += int.Parse(m.Groups[2].Value);
						rotation %= 360;
						if (rotation < 0)
						{
							rotation += 360;
						}
						break;

					case Heading.Forward:
						if (rotation == 0)
						{
							x += int.Parse(m.Groups[2].Value);
						}
						else if (rotation == 90)
						{
							y += int.Parse(m.Groups[2].Value);
						}
						else if (rotation == 180)
						{
							x -= int.Parse(m.Groups[2].Value);
						}
						else if (rotation == 270)
						{
							y -= int.Parse(m.Groups[2].Value);
						}
						break;

					default:
						break;
				}
			}
		}

		return (Math.Abs(x) + Math.Abs(y)).ToString();
	}

	public string PartB(string input)
	{
		var headingInstructions = InputHelper.ToStringArray(input);

		int x = 0;
		int y = 0;

		int wayPointX = 10;
		int wayPointY = 1;
		int prevWayPointX;

		foreach (string instruction in headingInstructions)
		{
			Match m = _parsedInstructions.Match(instruction);
			if (m.Success)
			{
				int rotation;
				switch (m.Groups[1].Value[0])
				{
					case Heading.North:
						wayPointY += int.Parse(m.Groups[2].Value);
						break;

					case Heading.South:
						wayPointY -= int.Parse(m.Groups[2].Value);
						break;

					case Heading.East:
						wayPointX += int.Parse(m.Groups[2].Value);
						break;

					case Heading.West:
						wayPointX -= int.Parse(m.Groups[2].Value);
						break;

					case Heading.Left:
						rotation = int.Parse(m.Groups[2].Value);
						prevWayPointX = wayPointX;

						if (rotation == 90)
						{
							wayPointX = -wayPointY;
							wayPointY = prevWayPointX;
						}
						else if (rotation == 180)
						{
							wayPointX = -wayPointX;
							wayPointY = -wayPointY;
						}
						else if (rotation == 270)
						{
							wayPointX = wayPointY;
							wayPointY = -prevWayPointX;
						}
						break;

					case Heading.Right:
						rotation = int.Parse(m.Groups[2].Value);
						prevWayPointX = wayPointX;
						if (rotation == 90)
						{
							wayPointX = wayPointY;
							wayPointY = -prevWayPointX;
						}
						else if (rotation == 180)
						{
							wayPointX = -wayPointX;
							wayPointY = -wayPointY;
						}
						else if (rotation == 270)
						{
							wayPointX = -wayPointY;
							wayPointY = prevWayPointX;
						}
						break;

					case Heading.Forward:
						x += wayPointX * int.Parse(m.Groups[2].Value);
						y += wayPointY * int.Parse(m.Groups[2].Value);
						break;

					default:
						break;
				}
			}
		}

		return (Math.Abs(x) + Math.Abs(y)).ToString();
	}

	internal sealed class Heading
	{
		public const char North = 'N';
		public const char South = 'S';
		public const char East = 'E';
		public const char West = 'W';
		public const char Left = 'L';
		public const char Right = 'R';
		public const char Forward = 'F';
	}
}
