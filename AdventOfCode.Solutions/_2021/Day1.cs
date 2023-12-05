using AdventOfCode.Domain.Interfaces;
using AdventOfCode.Solutions.Helpers;

namespace AdventOfCode.Solutions._2021;
public class Day1 : IDay
{
	public string Title => "Sonar Sweep";

	public string PartA(string input)
	{
		var listOfDepths = InputHelper.ToInt(input).ToArray();
		int previousDepth = listOfDepths[0];
		int increaseDepthCount = 0;

		for (int i = 1; i < listOfDepths.Length; i++)
		{
			if (previousDepth < listOfDepths[i])
			{
				increaseDepthCount++;
			}
			previousDepth = listOfDepths[i];
		}
		return increaseDepthCount.ToString();
	}

	public string PartB(string input)
	{
		var listOfDepths = InputHelper.ToInt(input).ToArray();
		int previousCalculatedDepth = listOfDepths[0] + listOfDepths[1] + listOfDepths[2];
		int increaseDepthCount = 0;

		for (int i = 0; i < listOfDepths.Length - 2; i++)
		{
			var currentCalculatedDepth = listOfDepths[i] + listOfDepths[i + 1] + listOfDepths[i + 2];
			if (previousCalculatedDepth < currentCalculatedDepth)
			{
				increaseDepthCount++;
			}
			previousCalculatedDepth = currentCalculatedDepth;
		}
		return increaseDepthCount.ToString();
	}
}
