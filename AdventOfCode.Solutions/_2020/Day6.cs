using AdventOfCode.Domain.Interfaces;

namespace AdventOfCode.Solutions._2020;

public class Day6 : IDay
{
	public string Title => "Custom Customs";

	public string PartA(string input)
	{
		var parsedInput = input
			.Split(new string[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries);

		int answerCount = 0;

		for (int i = 0; i < parsedInput.Length; i++)
		{
			answerCount += new string(parsedInput[i]
				.Replace("\n", "")
				.Distinct()
				.ToArray()).Count();
		}

		return answerCount.ToString();
	}

	public string PartB(string input)
	{
		var parsedInput = input
			.Split(new string[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries);

		int answerCount = 0;

		for (int i = 0; i < parsedInput.Length; i++)
		{
			string repeatedChars = new(parsedInput[i]
				.GroupBy(x => x)
				.Where(y => y
					.Count() > parsedInput[i]
					.Split("\n").Count() - 1)
				.Select(z => z.Key)
				.ToArray());

			answerCount += repeatedChars.Count();
		}

		return answerCount.ToString();
	}
}
