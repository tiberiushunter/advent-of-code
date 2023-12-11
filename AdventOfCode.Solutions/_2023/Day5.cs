using AdventOfCode.Domain.Interfaces;
using AdventOfCode.Solutions.Extensions;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions._2023;

public class Day5 : IDay
{
	public string Title => "If You Give A Seed A Fertilizer";

	public string PartA(string input)
	{
		var inputSections = input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);

		var seeds = Regex.Match(inputSections[0], @"seeds: ((?:(?:\d+) *)*)", RegexOptions.Compiled)
			.Groups[1]
			.Value
			.Split(' ')
			.Select(long.Parse);

		var seedToSoilMap = DeserializeInputToMap(inputSections[1]);
		var soilToFertilizerMap = DeserializeInputToMap(inputSections[2]);
		var fertilizerToWaterMap = DeserializeInputToMap(inputSections[3]);
		var waterToLightMap = DeserializeInputToMap(inputSections[4]);
		var lightToTemperatureMap = DeserializeInputToMap(inputSections[5]);
		var temperatureToHumidityMap = DeserializeInputToMap(inputSections[6]);
		var humidityToLocationMap = DeserializeInputToMap(inputSections[7]);

		var smallestLocation = long.MaxValue;

		foreach (var seed in seeds)
		{
			long soil = DestinationFromSourceNumber(seedToSoilMap, seed);
			long fetilizer = DestinationFromSourceNumber(soilToFertilizerMap, soil);
			long water = DestinationFromSourceNumber(fertilizerToWaterMap, fetilizer);
			long light = DestinationFromSourceNumber(waterToLightMap, water);
			long temperature = DestinationFromSourceNumber(lightToTemperatureMap, light);
			long humidity = DestinationFromSourceNumber(temperatureToHumidityMap, temperature);
			long location = DestinationFromSourceNumber(humidityToLocationMap, humidity);

			if (location < smallestLocation)
			{
				smallestLocation = location;
			}
		}

		return smallestLocation.ToString();
	}

	public string PartB(string input)
	{
		var inputSections = input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);

		var seedRanges = Regex.Match(inputSections[0], @"seeds: ((?:(?:\d+) *)*)", RegexOptions.Compiled)
			.Groups[1]
			.Value
			.Split(' ')
			.Select(long.Parse);

		var seeds = new List<long>();

		for (int i = 0; i < seedRanges.Count(); i += 2)
		{
			seeds.AddRange(EnumerableExtensions.LongRange(seedRanges.ElementAt(i), seedRanges.ElementAt(i + 1)));
		}

		var seedToSoil = DeserializeInputToMap(inputSections[1]);
		var soilToFertilizer = DeserializeInputToMap(inputSections[2]);
		var fertilizerToWater = DeserializeInputToMap(inputSections[3]);
		var waterToLight = DeserializeInputToMap(inputSections[4]);
		var lightToTemperature = DeserializeInputToMap(inputSections[5]);
		var temperatureToHumidity = DeserializeInputToMap(inputSections[6]);
		var humidityToLocation = DeserializeInputToMap(inputSections[7]);

		var smallestLocation = long.MaxValue;

		foreach (var seed in seeds)
		{
			long soil = DestinationFromSourceNumber(seedToSoil, seed);
			long fetilizer = DestinationFromSourceNumber(soilToFertilizer, soil);
			long water = DestinationFromSourceNumber(fertilizerToWater, fetilizer);
			long light = DestinationFromSourceNumber(waterToLight, water);
			long temperature = DestinationFromSourceNumber(lightToTemperature, light);
			long humidity = DestinationFromSourceNumber(temperatureToHumidity, temperature);
			long location = DestinationFromSourceNumber(humidityToLocation, humidity);

			if (location < smallestLocation)
			{
				smallestLocation = location;
			}
		};

		return smallestLocation.ToString();
	}

	private static long DestinationFromSourceNumber(List<(long, long, long)> sourceToDestinationMap, long source)
	{
		foreach ((long destinationRangeStart,
				 long sourceRangeStart,
				 long rangeLength) in sourceToDestinationMap
					.Select(x => (destinationRangeStart: x.Item1, sourceRangeStart: x.Item2, rangeLength: x.Item3))
					.Where(x => source >= x.sourceRangeStart && source <= x.sourceRangeStart + x.rangeLength))
		{
			return source + (destinationRangeStart - sourceRangeStart);
		}

		return source;
	}

	private static List<(long, long, long)> DeserializeInputToMap(string input)
	{
		var inputMapRegex = @"(?:(\d+) (\d+) (\d+))";

		return Regex.Matches(input, inputMapRegex, RegexOptions.Compiled)
			.Select(a => (
				destinationRangeStart: long.Parse(a.Groups[1].Value),
				sourceRangeStart: long.Parse(a.Groups[2].Value),
				rangeLength: long.Parse(a.Groups[3].Value)))
			.ToList();
	}
}
