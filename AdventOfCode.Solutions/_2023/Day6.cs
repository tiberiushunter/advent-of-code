using AdventOfCode.Domain.Interfaces;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions._2023;

public class Day6 : IDay
{
	public string Title => "Wait For It";

	public string PartA(string input)
	{
		var times = ParseValues(input.Split("\n")[0]);
		var distances = ParseValues(input.Split("\n")[1]);

		var numberOfWaysToBeatRace = new List<int>();

		for (var i = 0; i < times.Count; i++)
		{
			numberOfWaysToBeatRace.Add(NumberOfWaysToBeatRace(times[i], distances[i]));
		}

		return numberOfWaysToBeatRace.Aggregate((a, x) => a * x).ToString();
	}

	public string PartB(string input)
	{
		var totalTime = ParseValueWithKerningIssues(input.Split("\n")[0]);
		var totalDistance = ParseValueWithKerningIssues(input.Split("\n")[1]);

		return CalculateNumberOfWaysToBeatRace(totalTime, totalDistance).ToString();
	}

	private static int CalculateNumberOfWaysToBeatRace(long totalTime, long totalDistance)
	{
		var maximumTime = Math.Floor(totalTime + Math.Sqrt(Math.Pow(totalTime, 2) - 4 * totalDistance) / 2f);
		var minimumTime = Math.Ceiling(totalTime - Math.Sqrt(Math.Pow(totalTime, 2) - 4 * totalDistance) / 2f);

		return (int)(maximumTime - minimumTime + 1);
	}

	private int NumberOfWaysToBeatRace(long totalTime, long totalDistance)
	{
		int numberOfWaysToBeatRace = 0;

		for (long i = 0; i <= totalTime; i++)
		{
			if (SimulateRace(totalTime, totalDistance, i))
			{
				numberOfWaysToBeatRace++;
			}
		}

		return numberOfWaysToBeatRace;
	}

	private static bool SimulateRace(long totalTime, long totalDistance, long secondsHoldingButton)
	{
		long speed = secondsHoldingButton;
		long distance = 0;

		for (long i = secondsHoldingButton; i < totalTime; i++)
		{
			distance += speed;

			if (distance > totalDistance)
			{
				return true;
			}
		}

		return false;
	}

	private List<int> ParseValues(string input)
	{
		return _inputMatcher.Matches(input)
			.Select(item => int.Parse(item.Value))
			.ToList();
	}

	private long ParseValueWithKerningIssues(string input)
	{
		return long.Parse(_inputMatcher.Match(input.Replace(" ", ""))
			.Groups[1]
			.Value);
	}

	private readonly Regex _inputMatcher = new Regex(@"(\d+)", RegexOptions.Compiled);
}
