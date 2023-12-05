using AdventOfCode.Domain.Interfaces;
using AdventOfCode.Solutions.Helpers;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions._2020;

public class Day2 : IDay
{
	private readonly Regex _passwordRegex = new Regex(@"(\d+)-(\d+) (.): (\w+)");

	public string Title => "Password Philosophy";

	public string PartA(string input)
	{
		var listOfPasswords = InputHelper.ToStringArray(input);

		int numberOfPasswords = 0;

		foreach (string password in listOfPasswords)
		{
			Match match = _passwordRegex.Match(password);

			if (match.Success)
			{
				int count = 0;
				for (int i = 0; i < match.Groups[4].Length; i++)
				{
					if (match.Groups[4].Value[i] == match.Groups[3].Value[0])
					{
						count++;
					}
				}
				if (count >= int.Parse(match.Groups[1].Value) && count <= int.Parse(match.Groups[2].Value))
				{
					numberOfPasswords++;
				}
			}
		}

		return numberOfPasswords.ToString();
	}

	public string PartB(string input)
	{
		var listOfPasswords = InputHelper.ToStringArray(input);

		int numberOfValidPasswords = 0;

		foreach (string password in listOfPasswords)
		{
			Match match = _passwordRegex.Match(password);

			if (match.Success)
			{
				if (match.Groups[4].Value[int.Parse(match.Groups[1].Value) - 1] == match.Groups[3].Value[0] ^ match.Groups[4].Value[int.Parse(match.Groups[2].Value) - 1] == match.Groups[3].Value[0])
				{
					numberOfValidPasswords++;
				}
			}
		}

		return numberOfValidPasswords.ToString();
	}
}
