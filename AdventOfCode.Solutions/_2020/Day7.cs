using AdventOfCode.Domain.Interfaces;
using AdventOfCode.Solutions.Helpers;
using System.Text.RegularExpressions;
using System.Linq;

namespace AdventOfCode.Solutions._2020;

public class Day7 : IDay
{
	public string Title => "Handy Haversacks";

	public string PartA(string input)
	{
		var bags = GenerateBags(InputHelper.ToStringArray(input));

		int bagCount = 0;
		var suspects = new List<Bag>();

		foreach (var bag in bags)
		{
			suspects.AddRange(from innerBag in bag.InnerBags
							  where innerBag.Colour == "shiny gold"
							  select bag);
		}

		while (bagCount != suspects.Count)
		{
			bagCount = suspects.Count;
			foreach (var bag in bags)
			{
				foreach (var innerBag in bag.InnerBags)
				{
					for (int i = 0; i < suspects.Count; i++)
					{
						if (innerBag.Colour == suspects.ElementAt(i).Colour)
						{
							suspects.Add(bag);
						}
					}
				}
			}

			suspects = suspects.Distinct().ToList();
		}

		return bagCount.ToString();
	}

	public string PartB(string input)
	{
		var bags = GenerateBags(InputHelper.ToStringArray(input));

		int bagCount = 0;
		var nextLevelBags = new List<Bag>();
		var currentLevelBags = new List<Bag>();

		foreach (var bag in bags)
		{
			if (bag.Colour == "shiny gold")
			{
				for (int i = 0; i < bag.InnerBags.Count; i++)
				{
					var innerBag = bag.InnerBags[i];
					for (int j = 0; j < innerBag.InnerBags.Count; j++)
					{
						nextLevelBags.Add(innerBag);
						bagCount++;
					}
				}
			}
		}

		while (nextLevelBags.Count > 0)
		{
			foreach (var bag in bags)
			{
				for (int i = 0; i < nextLevelBags.Count; i++)
				{
					if (bag.Colour == nextLevelBags.ElementAt(i).Colour)
					{
						foreach (Bag innerBag in bag.InnerBags)
						{
							for (int j = 0; j < innerBag.InnerBags.Count; j++)
							{
								currentLevelBags.Add(innerBag);
								bagCount++;
							}
						}
					}
				}
			}

			nextLevelBags = currentLevelBags;
			currentLevelBags = [];
		}

		return bagCount.ToString();
	}

	private static List<Bag> GenerateBags(string[] input)
	{
		var bagRegex = new Regex(@"(\w+ \w+) bags contain ((?:\d+ \w+ \w+ bags?[\,\.] *)*)");

		var bags = new List<Bag>();

		foreach (string line in input)
		{
			var match = bagRegex.Match(line);
			if (match.Success)
			{
				string[] innerBags = match.Groups[2].Value.Split(",.".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
				var innerBagsList = new List<Bag>(innerBags.Length);

				for (int i = 0; i < innerBags.Length; i++)
				{
					string[] innerBagDetails = innerBags[i].Trim().Split(" ");

					var innerBagInnerBags = new List<Bag>();

					for (int j = 0; j < int.Parse(innerBagDetails[0]); j++)
					{
						innerBagInnerBags.Add(new Bag());
					}

					innerBagsList.Add(new Bag(innerBagDetails[1] + " " + innerBagDetails[2], innerBagInnerBags));
				}

				bags.Add(new Bag(match.Groups[1].Value, innerBagsList));
			}
		}
		return bags;
	}

	internal class Bag
	{
		public string? Colour { get; set; }
		public List<Bag> InnerBags { get; set; } = [];

		public Bag() { }

		public Bag(string colour, List<Bag> innerBags)
		{
			Colour = colour;
			InnerBags = innerBags;
		}
	}
}
