using AdventOfCode.Domain.Interfaces;
using AdventOfCode.Solutions.Helpers;

namespace AdventOfCode.Solutions._2020;

public class Day8 : IDay
{
	public string Title => "Handheld Halting";

	public string PartA(string input)
	{
		var instructions = InputHelper.ToStringArray(input);

		var gameBoy = new GameBoy(instructions);
		gameBoy.Boot();
		int acc = gameBoy.Accumulator;

		return acc.ToString();
	}

	public string PartB(string input)
	{
		var instructions = InputHelper.ToStringArray(input);

		int acc = 0;

		string[] modifiedInput = (string[])instructions.Clone();

		for (int i = 0; i < modifiedInput.Length; i++)
		{
			if (modifiedInput[i].StartsWith("jmp"))
			{
				modifiedInput[i] = modifiedInput[i].Replace("jmp", "nop");
			}
			else if (modifiedInput[i].StartsWith("nop"))
			{
				modifiedInput[i] = modifiedInput[i].Replace("nop", "jmp");
			}
			else
			{
				continue;
			}

			var gameBoy = new GameBoy(modifiedInput);
			gameBoy.Boot();

			if (gameBoy.BootComplete)
			{
				acc = gameBoy.Accumulator;
				break;
			}

			modifiedInput = (string[])instructions.Clone();
		}

		return acc.ToString();
	}

	internal class GameBoy
	{
		public string[] BootCode { get; set; }
		public int Accumulator { get; set; } = 0;
		public bool BootComplete { get; set; } = false;

		public GameBoy(string[] input)
		{
			BootCode = input;
		}

		public void Boot()
		{
			int line = 0;
			HashSet<int> visited = [];

			while (!BootComplete)
			{
				if (!visited.Add(line))
				{
					break;
				}

				if (line >= BootCode.Length)
				{
					BootComplete = true;
				}
				else
				{
					string[] command = BootCode[line].Split(" ");
					switch (command[0])
					{
						case "acc":
							Accumulate(int.Parse(command[1]));
							line++;
							break;

						case "jmp":
							line = Jump(int.Parse(command[1]), line);
							break;

						case "nop":
							line++;
							break;
					}
				}
			}
		}

		private void Accumulate(int value)
		{
			Accumulator += value;
		}

		private int Jump(int value, int line)
		{
			return value += line;
		}
	}
}
