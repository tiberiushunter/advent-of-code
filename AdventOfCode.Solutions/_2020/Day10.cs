using AdventOfCode.Domain.Interfaces;
using AdventOfCode.Solutions.Helpers;

namespace AdventOfCode.Solutions._2020;

public class Day10 : IDay
{
	public string Title => "Adapter Array";

	public string PartA(string input)
	{
		var adaptorJolts = InputHelper
			.ToInt(input)
			.OrderBy(i => i)
			.ToArray();

		int oneJoltCount = adaptorJolts.First();
		int threeJoltCount = 1;

		int currentJolt = adaptorJolts.First();

		while (currentJolt != adaptorJolts.Last())
		{
			for (int i = 0; i < adaptorJolts.Length; i++)
			{
				if (currentJolt == adaptorJolts[i] - 1)
				{
					oneJoltCount++;
				}
				else if (currentJolt == adaptorJolts[i] - 3)
				{
					threeJoltCount++;
				}
				currentJolt = adaptorJolts[i];
			}
		}
		return (oneJoltCount * threeJoltCount).ToString();
	}

	public string PartB(string input)
	{
		var adaptorJolts = InputHelper
			.ToInt(input)
			.OrderBy(i => i)
			.ToArray();

		var adapterBranches = new Dictionary<int, long>
		{
			[adaptorJolts.Last()] = 0
		};

		long numOfBranches = 0;
		int index = 0;

		while (adaptorJolts[index] <= 3)
		{
			numOfBranches += 1 + CalculateTotalNumberOfBranches(adaptorJolts, index, adapterBranches);
			index++;
		}

		return numOfBranches.ToString();
	}

	private long CalculateTotalNumberOfBranches(int[] adapters, int currentIndex, Dictionary<int, long> adapterBranches)
	{
		int jolt = adapters[currentIndex];
		long count = 0;

		for (int i = currentIndex + 1; i < adapters.Length && adapters[i] - jolt <= 3; i++)
		{
			if (adapterBranches.TryGetValue(adapters[i], out long value))
			{
				count += value + 1;
			}
			else
			{
				count += CalculateTotalNumberOfBranches(adapters, i, adapterBranches) + 1;
			}
		}

		adapterBranches[jolt] = count - 1;

		return adapterBranches[jolt];
	}
}
