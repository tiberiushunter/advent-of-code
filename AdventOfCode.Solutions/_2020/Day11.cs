using AdventOfCode.Domain.Interfaces;
using AdventOfCode.Solutions.Helpers;

namespace AdventOfCode.Solutions._2020;

public class Day11 : IDay
{
	private int _maxHeight;
	private int _maxWidth;

	public string Title => "Seating System";

	public string PartA(string input)
	{
		var parsedInput = InputHelper.ToStringArray(input);

		_maxHeight = parsedInput.Length;
		_maxWidth = parsedInput[0].Length;

		var seats = GenerateSeats(parsedInput);

		int ruleEmptyAdj = 9;
		int ruleOccupiedAdj = 4;

		while (true)
		{
			int totalChanges = 0;

			for (int x = 0; x < _maxHeight; x++)
			{
				for (int y = 0; y < _maxWidth; y++)
				{
					int count = 0;
					int outOfBounds = 0;

					for (int i = -1; i <= 1; i++)
					{
						for (int j = -1; j <= 1; j++)
						{
							int dx = x + i;
							int dy = y + j;

							if (!CoordsInBounds(dx, dy) || dx == x && dy == y)
							{
								outOfBounds++;
								continue;
							}

							if (seats[x, y] == Seat.Empty)
							{
								count += seats[dx, dy] == Seat.Empty || seats[dx, dy] == Seat.NextOccupied || seats[dx, dy] == Seat.Floor ? 1 : 0;
							}
							else if (seats[x, y] == Seat.Occupied)
							{
								count += seats[dx, dy] == Seat.Occupied || seats[dx, dy] == Seat.NextEmpty ? 1 : 0;
							}
						}
					}

					if (seats[x, y] == Seat.Empty && (count + outOfBounds) >= ruleEmptyAdj)
					{
						seats[x, y] = Seat.NextOccupied;
						totalChanges++;
					}
					else if (seats[x, y] == Seat.Occupied && count >= ruleOccupiedAdj)
					{
						seats[x, y] = Seat.NextEmpty;
						totalChanges++;
					}
				}
			}

			seats = CalibrateSeats(seats);

			if (totalChanges == 0)
			{
				break;
			}
		}

		return TotalOccupiedSeats(seats).ToString();
	}

	public string PartB(string input)
	{
		var parsedInput = InputHelper.ToStringArray(input);

		_maxHeight = parsedInput.Length;
		_maxWidth = parsedInput[0].Length;

		var seats = GenerateSeats(parsedInput);

		int ruleEmptyAdj = 9;
		int ruleOccupiedAdj = 5;

		while (true)
		{
			int totalChanges = 0;
			for (int x = 0; x < _maxHeight; x++)
			{
				for (int y = 0; y < _maxWidth; y++)
				{
					int count = 0;
					int outOfBounds = 0;

					for (int i = -1; i <= 1; i++)
					{
						for (int j = -1; j <= 1; j++)
						{
							int dx = x + i;
							int dy = y + j;

							if (!CoordsInBounds(dx, dy) || dx == x && dy == y)
							{
								outOfBounds++;
								continue;
							}

							if (seats[dx, dy] == Seat.Floor)
							{
								char direction = ' ';

								if (i > 0 && j == 0)
									direction = Direction.Up;
								else if (i < 0 && j == 0)
									direction = Direction.Down;
								else if (j > 0 && i == 0)
									direction = Direction.Right;
								else if (j < 0 && i == 0)
									direction = Direction.Left;
								else if (i > 0 && j < 0)
									direction = Direction.UpperLeft;
								else if (i > 0 && j > 0)
									direction = Direction.UpperRight;
								else if (i < 0 && j < 0)
									direction = Direction.LowerLeft;
								else if (i < 0 && j > 0)
									direction = Direction.LowerRight;

								if (seats[x, y] == Seat.Empty || seats[x, y] == Seat.Occupied)
									count += VisiblyAdjacentSeatCheck(x, y, direction, seats[x, y], seats);

							}
							else if (seats[x, y] == Seat.Empty)
							{
								count += seats[dx, dy] == Seat.Empty
									|| seats[dx, dy] == Seat.NextOccupied
									|| seats[dx, dy] == Seat.Floor ? 1 : 0;
							}
							else if (seats[x, y] == Seat.Occupied)
							{
								count += seats[dx, dy] == Seat.Occupied
									|| seats[dx, dy] == Seat.NextEmpty ? 1 : 0;
							}
						}
					}

					if (seats[x, y] == Seat.Empty && (count + outOfBounds) >= ruleEmptyAdj)
					{
						seats[x, y] = Seat.NextOccupied;
						totalChanges++;
					}
					else if (seats[x, y] == Seat.Occupied && count >= ruleOccupiedAdj)
					{
						seats[x, y] = Seat.NextEmpty;
						totalChanges++;
					}
				}
			}

			seats = CalibrateSeats(seats);

			if (totalChanges == 0)
			{
				break;
			}
		}

		return TotalOccupiedSeats(seats).ToString();
	}

	private int TotalOccupiedSeats(int[,] seats)
	{
		int totalOccupiedSeats = 0;

		for (int i = 0; i < _maxHeight; i++)
		{
			for (int j = 0; j < _maxWidth; j++)
			{
				if (seats[i, j] == Seat.Occupied)
				{
					totalOccupiedSeats++;
				}
			}
		}

		return totalOccupiedSeats;
	}

	private int[,] CalibrateSeats(int[,] seats)
	{
		for (int i = 0; i < _maxHeight; i++)
		{
			for (int j = 0; j < _maxWidth; j++)
			{
				seats[i, j] = seats[i, j] == Seat.Floor
					? Seat.Floor
					: seats[i, j] == Seat.NextEmpty || seats[i, j] == Seat.Empty
						? Seat.Empty
						: Seat.Occupied;
			}
		}

		return seats;
	}

	private int[,] GenerateSeats(string[] input)
	{
		var seats = new int[_maxHeight, _maxWidth];

		for (int i = 0; i < _maxHeight; i++)
		{
			for (int j = 0; j < _maxWidth; j++)
			{
				seats[i, j] = input[i][j] == 'L' ? Seat.Empty : Seat.Floor;
			}
		}

		return seats;
	}

	private int VisiblyAdjacentSeatCheck(int x, int y, char direction, int seatType, int[,] seats)
	{
		int count = 0;

		if (seatType == Seat.Empty)
			count++;

		switch (direction)
		{
			case Direction.Up:
				if (x + 1 >= 0)
				{
					x++;
				}
				else
				{
					return count;
				}
				break;
			case Direction.Down:
				if (x - 1 < _maxHeight)
				{
					x--;
				}
				else
				{
					return count;
				}
				break;
			case Direction.Right:
				if (y + 1 < _maxWidth)
				{
					y++;
				}
				else
				{
					return count;
				}
				break;
			case Direction.Left:
				if (y - 1 >= 0)
				{
					y--;
				}
				else
				{
					return count;
				}
				break;
			case Direction.UpperLeft:
				if (x + 1 < _maxHeight && y - 1 >= 0)
				{
					x++;
					y--;
				}
				else
				{
					return count;
				}
				break;
			case Direction.UpperRight:
				if (x + 1 < _maxHeight && y + 1 < _maxWidth)
				{
					x++;
					y++;
				}
				else
				{
					return count;
				}
				break;
			case Direction.LowerLeft:
				if (x - 1 >= 0 && y - 1 >= 0)
				{
					x--;
					y--;
				}
				else
				{
					return count;
				}
				break;
			case Direction.LowerRight:
				if (x - 1 >= 0 && y + 1 < _maxWidth)
				{
					x--;
					y++;
				}
				else
				{
					return count;
				}
				break;
		}

		if (CoordsInBounds(x, y))
		{
			if (seats[x, y] == Seat.Floor)
			{
				count = VisiblyAdjacentSeatCheck(x, y, direction, seatType, seats);
			}
			else
			{
				if (seatType == Seat.Empty)
				{
					count = seats[x, y] == Seat.Empty || seats[x, y] == Seat.NextOccupied || seats[x, y] == Seat.Floor ? 1 : 0;
				}
				if (seatType == Seat.Occupied)
				{
					count = seats[x, y] == Seat.Occupied || seats[x, y] == Seat.NextEmpty ? 1 : 0;
				}
			}
		}

		return count;
	}

	private bool CoordsInBounds(int x, int y)
	{
		if (x >= 0 && y >= 0 && x < _maxHeight && y < _maxWidth)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	internal sealed class Seat
	{
		public const int Floor = -1;
		public const int Empty = 0;
		public const int Occupied = 1;
		public const int NextEmpty = 3;
		public const int NextOccupied = 4;
	}

	internal sealed class Direction
	{
		public const char Up = 'U';
		public const char Down = 'D';
		public const char Left = 'L';
		public const char Right = 'R';
		public const char UpperLeft = 'Q';
		public const char UpperRight = 'W';
		public const char LowerLeft = 'A';
		public const char LowerRight = 'S';
	}
}
