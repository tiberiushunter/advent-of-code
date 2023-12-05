using AdventOfCode.Domain.Interfaces;
using AdventOfCode.Solutions.Helpers;
using System.Collections;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions._2020;

public class Day14 : IDay
{
	private readonly Regex _maskRegex = new Regex(@"mask = ([01X]+)");
	private readonly Regex _memRegex = new Regex(@"mem\[([0-9]+)\] = ([0-9]+)");

	public string Title => "Docking Data";

	public string PartA(string input)
	{
		var memoryInstructions = InputHelper.ToStringArray(input);
		var memory = new Dictionary<long, BitArray>();
		var bAMaskTrue = new BitArray(36);
		var bAMaskFalse = new BitArray(36);

		for (int i = 0; i < memoryInstructions.Length; i++)
		{
			Match matchMask = _maskRegex.Match(memoryInstructions[i]);
			if (matchMask.Success)
			{
				for (int j = 0; j < matchMask.Groups[1].Length; j++)
				{
					switch (matchMask.Groups[1].Value[j])
					{
						case '1':
							bAMaskTrue.Set(j, true);
							break;
						case '0':
							bAMaskFalse.Set(j, true);
							break;
					}
				}
			}
			else
			{
				continue;
			}

			for (int j = i + 1; j < memoryInstructions.Length; j++)
			{
				if (memoryInstructions[j].StartsWith("mask"))
				{
					break;
				}
				else
				{
					Match matchMem = _memRegex.Match(memoryInstructions[j]);

					if (matchMem.Success)
					{
						int memAddress = int.Parse(matchMem.Groups[1].Value);
						long value = long.Parse(matchMem.Groups[2].Value);

						var result = GetBitArrayFromInt36(value).Or(bAMaskTrue).And(bAMaskFalse.Not());
						bAMaskFalse.Not();

						memory[memAddress] = result;
					}
				}
			}
			bAMaskTrue = new BitArray(36);
			bAMaskFalse = new BitArray(36);
		}

		long sumOfAllMemoryAddresses = 0;

		var memoryAddresses = memory.Keys.ToArray();
		for (int i = 0; i < memoryAddresses.Length; i++)
		{
			sumOfAllMemoryAddresses += GetLongFromBitArray(memory.GetValueOrDefault(memoryAddresses[i]));
		}

		return sumOfAllMemoryAddresses.ToString();
	}

	public string PartB(string input)
	{
		var memoryInstructions = InputHelper.ToStringArray(input);
		var memory = new Dictionary<long, BitArray>();
		var memAddresses = new HashSet<long>();

		var bAMaskTrue = new BitArray(36);
		var bAMaskFalse = new BitArray(36);
		var bAMaskFloating = new BitArray(36);

		for (int i = 0; i < memoryInstructions.Length; i++)
		{
			Match matchMask = _maskRegex.Match(memoryInstructions[i]);

			var floatPositions = new List<int>();

			if (matchMask.Success)
			{
				for (int j = 0; j < matchMask.Groups[1].Length; j++)
				{
					switch (matchMask.Groups[1].Value[j])
					{
						case '1':
							bAMaskTrue.Set(j, true);
							break;
						case '0':
							bAMaskFalse.Set(j, true);
							break;
						case 'X':
							bAMaskFloating.Set(j, true);
							floatPositions.Add(j);
							break;
					}
				}
			}
			else
			{
				continue;
			}

			for (int j = i + 1; j < memoryInstructions.Length; j++)
			{
				if (memoryInstructions[j].StartsWith("mask"))
				{
					break;
				}
				else
				{
					Match matchMem = _memRegex.Match(memoryInstructions[j]);

					if (matchMem.Success)
					{
						long memAddress = long.Parse(matchMem.Groups[1].Value);
						long value = long.Parse(matchMem.Groups[2].Value);

						var result = GetBitArrayFromInt36(memAddress).Or(bAMaskTrue).And(bAMaskFloating.Not());
						bAMaskFloating.Not();

						memAddresses = [];

						result = CalculateMemoryAddresses(0, floatPositions, result, memAddresses);

						for (int h = 0; h < memAddresses.Count; h++)
						{
							memory[memAddresses.ElementAt(h)] = GetBitArrayFromInt36(value);
						}
					}
				}
			}

			bAMaskTrue = new BitArray(36);
			bAMaskFalse = new BitArray(36);
			bAMaskFloating = new BitArray(36);
		}

		long sumOfAllMemoryAddresses = 0;
		var memoryAddresses = memory.Keys.ToArray();

		for (int i = 0; i < memoryAddresses.Length; i++)
		{
			sumOfAllMemoryAddresses += GetLongFromBitArray(memory.GetValueOrDefault(memoryAddresses[i]));
		}

		return sumOfAllMemoryAddresses.ToString();
	}

	private static BitArray CalculateMemoryAddresses(int position, List<int> floatPositions, BitArray bits, HashSet<long> memoryAddresses)
	{
		while (position < floatPositions.Count)
		{
			SwitchBitAtPosition(bits, floatPositions[position]);
			memoryAddresses.Add(GetLongFromBitArray(bits));

			if (position != floatPositions.Count - 1)
			{
				bits = CalculateMemoryAddresses(position + 1, floatPositions, bits, memoryAddresses);
				SwitchBitAtPosition(bits, floatPositions[position]);
				memoryAddresses.Add(GetLongFromBitArray(bits));
				position++;
			}
			else
			{
				break;
			}
		}

		return bits;
	}

	private static void SwitchBitAtPosition(BitArray bitArray, int position)
	{
		bitArray.Set(position, !bitArray.Get(position));
	}

	private static long GetLongFromBitArray(BitArray bitArray)
	{
		long value = 0L;
		long pow = 1L;

		for (int i = bitArray.Length - 1; i >= 0; i--)
		{
			value += ((bitArray.Get(i) ? 1L : 0L) * pow);
			pow *= 2L;
		}

		return value;
	}

	public static BitArray GetBitArrayFromInt36(long value)
	{
		var bitArray = new BitArray(36);

		for (int i = 35; i >= 0; i--)
		{
			long mask = 1L << i;
			bitArray.Set(35 - i, (value & mask) != 0 ? true : false);
		}

		return bitArray;
	}
}
