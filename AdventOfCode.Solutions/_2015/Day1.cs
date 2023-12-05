using AdventOfCode.Domain.Interfaces;

namespace AdventOfCode.Solutions._2015;

public class Day1 : IDay
{
	public string Title => "Not Quite Lisp";

	public string PartA(string input)
	{
		var currentFloor = 0;

		foreach (var direction in input)
		{
			switch (direction)
			{
				case '(':
					currentFloor++;
					break;
				case ')':
					currentFloor--;
					break;
			}
		}

		return currentFloor.ToString();
	}

	public string PartB(string input)
	{
		var currentFloor = 0;

		for (var i = 0; i < input.Length; i++)
		{
			if (currentFloor < 0) { return i.ToString(); }

			switch (input[i])
			{
				case '(':
					currentFloor++;
					break;
				case ')':
					currentFloor--;
					break;
			}
		}

		return string.Empty;
	}
}
