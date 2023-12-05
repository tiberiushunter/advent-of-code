using AdventOfCode.Domain.Interfaces;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions._2023;

public class Day4 : IDay
{
	public string Title => "Scratchcards";

	public string PartA(string input)
	{
		var scratchCards = Regex.Matches(input, @"Card +\d*: +((?:(?:\d+) *)*)\| +((?:(?:\d+) *)*)", RegexOptions.Compiled);
		double points = 0;

		foreach (Match scratchCard in scratchCards)
		{
			var winningNumbers = scratchCard
				.Groups[1]
				.Value
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse);

			var numbers = scratchCard
				.Groups[2]
				.Value
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse);

			int matches = numbers.Intersect(winningNumbers).Count();

			if (matches > 0)
			{
				points += Math.Pow(2, matches) / 2;
			}
		}

		return points.ToString();
	}

	public string PartB(string input)
	{
		var scratchCards = Regex
			.Matches(input, @"Card +(\d*): +((?:(?:\d+) *)*)\| +((?:(?:\d+) *)*)", RegexOptions.Compiled)
			.ToList();

		var scratchCardCache = new Dictionary<int, List<Match>>();

		for (int i = 0; i < scratchCards.Count; i++)
		{
			int cardNumber = int.Parse(scratchCards.ElementAt(i).Groups[1].Value);

			if (scratchCardCache.ContainsKey(cardNumber))
			{
				scratchCards.AddRange(scratchCardCache[cardNumber]);
			}
			else
			{
				var winningNumbers = scratchCards.ElementAt(i)
					.Groups[2]
					.Value
					.Split(' ', StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse);

				var numbers = scratchCards.ElementAt(i)
					.Groups[3]
					.Value
					.Split(' ', StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse);

				int matches = numbers.Intersect(winningNumbers).Count();

				if (matches > 0)
				{
					var newScratchCards = new List<Match>();

					for (int j = 1; j <= matches; j++)
					{
						newScratchCards
							.Add(scratchCards
								.Where(card => int.Parse(card.Groups[1].Value) == cardNumber + j)
								.First());
					}

					scratchCards.AddRange(newScratchCards);
					scratchCardCache.Add(cardNumber, newScratchCards);
				}
			}
		}

		return scratchCards.Count.ToString();
	}
}
