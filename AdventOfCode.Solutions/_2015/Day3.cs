using AdventOfCode.Domain.Interfaces;

namespace AdventOfCode.Solutions._2015;

public class Day3 : IDay
{
	public string Title => "Perfectly Spherical Houses in a Vacuum";

	public string PartA(string input)
	{
		int x = 0;
		int y = 0;

		var positions = new List<(int, int)>
		{
			(x, y)
		};

		foreach (var direction in input)
		{
			var newPosition = Move(x, y, direction);

			x = newPosition.Item1;
			y = newPosition.Item2;

			positions.Add(newPosition);
		}

		int numberOfHousesDeliveredTo = positions
			.Distinct()
			.Count();

		return numberOfHousesDeliveredTo.ToString();
	}

	public string PartB(string input)
	{
		int santaX = 0;
		int santaY = 0;

		int robotX = 0;
		int robotY = 0;

		bool santasTurnToMove = true;

		var positions = new List<(int, int)>
		{
			(santaX, santaY),
			(robotX, robotY)
		};

		foreach (var direction in input)
		{
			if (santasTurnToMove)
			{
				var newPosition = Move(santaX, santaY, direction);

				santaX = newPosition.Item1;
				santaY = newPosition.Item2;

				positions.Add((santaX, santaY));
			}
			else
			{
				var newPosition = Move(robotX, robotY, direction);

				robotX = newPosition.Item1;
				robotY = newPosition.Item2;

				positions.Add((robotX, robotY));
			}

			santasTurnToMove = !santasTurnToMove;
		}

		int numberOfHousesDeliveredTo = positions
			.Distinct()
			.Count();

		return numberOfHousesDeliveredTo.ToString();
	}

	private (int, int) Move(int x, int y, char direction)
	{
		switch (direction)
		{
			case Direction.North:
				x++;
				break;
			case Direction.South:
				x--;
				break;
			case Direction.West:
				y--;
				break;
			case Direction.East:
				y++;
				break;
		}

		return (x, y);
	}

	internal sealed class Direction
	{
		public const char North = '^';
		public const char South = 'v';
		public const char West = '<';
		public const char East = '>';
	}
}
