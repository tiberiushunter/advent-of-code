using AdventOfCode.Domain.Interfaces;
using AdventOfCode.Solutions.Helpers;

namespace AdventOfCode.Solutions._2015;

public class Day2 : IDay
{
	public string Title => "I Was Told There Would Be No Math";

	public string PartA(string input)
	{
		var parsedInput = InputHelper.ToStringArray(input);
		var totalWrappingPaper = 0;

		foreach (var boxDimensions in parsedInput)
		{
			var dimensions = boxDimensions
				.Split('x')
				.Select(x => int.Parse(x))
				.ToList();

			var sides = new List<int>
			{
				dimensions.ElementAt(0) * dimensions.ElementAt(1),
				dimensions.ElementAt(1) * dimensions.ElementAt(2),
				dimensions.ElementAt(2) * dimensions.ElementAt(0),
			};

			totalWrappingPaper +=
				2 * sides.ElementAt(0)
				+ (2 * sides.ElementAt(1))
				+ (2 * sides.ElementAt(2));

			totalWrappingPaper += sides.Min();
		}

		return totalWrappingPaper.ToString();
	}

	public string PartB(string input)
	{
		var parsedInput = InputHelper.ToStringArray(input);
		var totalRibbonLength = 0;

		foreach (var boxDimensions in parsedInput)
		{
			var dimensions = boxDimensions
				.Split('x')
				.Select(x => int.Parse(x))
				.ToList();

			totalRibbonLength +=
				dimensions.ElementAt(0)
				* dimensions.ElementAt(1)
				* dimensions.ElementAt(2);

			dimensions.Remove(dimensions.Max());

			totalRibbonLength +=
				dimensions.First() * 2
				+ dimensions.Last() * 2;
		}

		return totalRibbonLength.ToString();
	}
}
