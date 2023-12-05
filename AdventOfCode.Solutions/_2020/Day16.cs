using AdventOfCode.Domain.Interfaces;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions._2020;

public class Day16 : IDay
{
	private readonly Regex _regexFields = new Regex(@"(.*): ([0-9]*)-([0-9]*) or ([0-9]*)-([0-9]*)");

	public string Title => "Ticket Translation";

	public string PartA(string input)
	{
		var parsedInput = input.Split("\n\n");
		var fields = GenerateFields(parsedInput);
		var nearByTickets = GenerateNearByTickets(parsedInput);

		return TicketScanningErrorRate(fields, nearByTickets).ToString();
	}

	public string PartB(string input)
	{
		var parsedInput = input.Split("\n\n");
		var fields = GenerateFields(parsedInput);
		var myTicket = GenerateMyTicket(parsedInput);
		var nearByTickets = GenerateNearByTickets(parsedInput);

		TicketScanningErrorRate(fields, nearByTickets).ToString();

		long answer = 1;

		var fieldKeys = fields.Values.ToArray();
		var keys = new List<List<int>>();
		for (int i = 0; i < fieldKeys.Length; i++)
		{
			var currentValues = new List<int>
			{
				myTicket[i]
			};

			foreach (int[] ticket in nearByTickets)
			{
				currentValues.Add(ticket[i]);
			}

			var currentField = new List<int>();

			for (int j = 0; j < fieldKeys.Length; j++)
			{
				var notInField = currentValues.Except(fieldKeys[j]).ToArray();

				if (notInField.Length == 0)
				{
					currentField.Add(j);
				}
			}
			keys.Add(currentField);
		}

		int[] fieldOrder = keys.Select((x, y) => x.Count).ToArray();

		keys.Sort((x, y) => x.Count.CompareTo(y.Count));

		for (int i = 0; i < keys.Count; i++)
		{
			if (i >= 1)
			{
				string field = fields
					.ElementAt(keys[i]
					.Except(keys[i - 1])
					.ToArray()[0]).Key;

				if (field.StartsWith("departure "))
				{
					for (int j = 0; j < fieldOrder.Length; j++)
					{
						if (fieldOrder[j] == i + 1)
						{
							answer *= myTicket[j];
						}
					}
				}
			}
		}

		return answer.ToString();
	}

	private Dictionary<string, int[]> GenerateFields(string[] input)
	{
		var fields = new Dictionary<string, int[]>();

		string[] rawFields = input[0].Split("\n");
		for (int i = 0; i < rawFields.Length; i++)
		{
			Match m = _regexFields.Match(rawFields[i]);
			if (m.Success)
			{
				int startA = int.Parse(m.Groups[2].Value);
				int endA = int.Parse(m.Groups[3].Value);

				int startB = int.Parse(m.Groups[4].Value);
				int endB = int.Parse(m.Groups[5].Value);

				int[] range = Enumerable.Range(startA, endA - startA + 1)
					.Concat(Enumerable.Range(startB, endB - startB + 1))
					.ToArray();

				fields.Add(m.Groups[1].Value, range);
			}
		}

		return fields;
	}

	private static int[] GenerateMyTicket(string[] input)
	{
		return input[1].Split("\n")[1]
			.Split(",")
			.Select(n => int.Parse(n))
			.ToArray();
	}

	private List<int[]> GenerateNearByTickets(string[] input)
	{
		var nearbyTickets = new List<int[]>();

		string[] rawNearbyTickets = input[2].Split("\n");

		for (int i = 1; i < rawNearbyTickets.Length; i++)
		{
			nearbyTickets.Add(rawNearbyTickets[i]
				.Split(",")
				.Select(n => int.Parse(n))
				.ToArray());
		}

		return nearbyTickets;
	}

	private int TicketScanningErrorRate(Dictionary<string, int[]> fields, List<int[]> nearByTickets)
	{
		int errorRate = 0;
		var fieldKeys = fields.Values.ToArray();
		var invalidTickets = new List<int[]>();
		var allValidValues = new HashSet<int>();

		foreach (int[] field in fieldKeys)
		{
			allValidValues = allValidValues.Concat(field).ToHashSet();
		}

		foreach (int[] ticket in nearByTickets)
		{
			int tempErrorRate = ticket.Except(allValidValues).Sum();

			if (tempErrorRate > 0 || ticket.Contains(0))
			{
				errorRate += tempErrorRate;
				invalidTickets.Add(ticket);
			}
		}

		for (int i = 0; i < invalidTickets.Count; i++)
		{
			nearByTickets.Remove(invalidTickets[i]);
		}

		return errorRate;
	}
}
