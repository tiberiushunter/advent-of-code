using AdventOfCode.Domain.Interfaces;
using AdventOfCode.Solutions.Helpers;

namespace AdventOfCode.Solutions._2020;

public class Day13 : IDay
{
	public string Title => "Shuttle Search";

	public string PartA(string input)
	{
		var busTimetable = InputHelper.ToStringArray(input);
		var earliestTimestamp = long.Parse(busTimetable[0]);

		busTimetable = busTimetable[1]
			.Split(",")
			.Where(x => x.Take(1)
			.All(char.IsDigit))
			.ToArray();

		var buses = new int[busTimetable.Length];

		for (int i = 0; i < busTimetable.Length; i++)
		{
			buses[i] = int.Parse(busTimetable[i]);
		}

		bool busFound = false;
		int busToTake = -1;
		int minsToWait = 0;
		int currentTimestamp = 0;

		while (!busFound)
		{
			for (int i = 0; i < buses.Length; i++)
			{
				if (currentTimestamp % buses[i] == 0)
				{
					if (currentTimestamp > earliestTimestamp)
					{
						busToTake = buses[i];
						minsToWait = currentTimestamp - (int)earliestTimestamp;
						busFound = true;
					}
				}
			}
			currentTimestamp++;
		}

		return (busToTake * minsToWait).ToString();
	}

	public string PartB(string input)
	{
		var busTimetable = InputHelper.ToStringArray(input);

		busTimetable = busTimetable[1].Split(",");

		var buses = new int[busTimetable.Length];

		for (int i = 0; i < busTimetable.Length; i++)
		{
			if (busTimetable[i] != "x")
			{
				buses[i] = int.Parse(busTimetable[i]);
			}
			else
			{
				buses[i] = 1;
			}
		}

		bool busChainFound = false;
		long currentTimestamp = 0L;
		long offset = 1;

		int[] chainedBusIDs = new int[buses.Length];

		while (!busChainFound)
		{
			for (int i = 0; i < buses.Length; i++)
			{
				if ((currentTimestamp + i) % buses[i] == 0)
				{
					if (chainedBusIDs[i] != i)
					{
						offset *= buses[i];
						chainedBusIDs[i] = i;
					}
				}
				else
				{
					break;
				}
			}
			if (chainedBusIDs[^1] > 0)
			{
				busChainFound = true;
			}
			else
			{
				currentTimestamp += offset;
			}
		}

		return currentTimestamp.ToString();
	}
}
