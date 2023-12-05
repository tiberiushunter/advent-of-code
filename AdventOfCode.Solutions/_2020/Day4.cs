using AdventOfCode.Domain.Interfaces;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions._2020;

public class Day4 : IDay
{
	public string Title => "Passport Processing";

	public string PartA(string input)
	{
		var parsedInput = input
			.Split(new string[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries);

		int count = 0;
		for (int i = 0; i < parsedInput.Length; i++)
		{
			if (HasAllRequiredFields(parsedInput[i]))
			{
				count++;
			}
		}
		return count.ToString();
	}

	public string PartB(string input)
	{
		var parsedInput = input
			.Split(new string[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries);

		{
			int count = 0;
			string[] eclValidArr = ["amb", "blu", "brn", "gry", "grn", "hzl", "oth"];

			for (int i = 0; i < parsedInput.Length; i++)
			{
				if (HasAllRequiredFields(parsedInput[i]))
				{
					Dictionary<string, string> d = parsedInput[i].Replace("\n", " ").Split(' ')
						.Select(value => value.Split(':'))
						.ToDictionary(pair => pair[0], pair => pair[1]);

					int byr = int.Parse(d["byr"]);
					int iyr = int.Parse(d["iyr"]);
					int eyr = int.Parse(d["eyr"]);

					int.TryParse(d["hgt"].Substring(0, d["hgt"].Length - 2), out int hgt);

					if (byr >= 1920 && byr <= 2002 &&
						iyr >= 2010 && iyr <= 2020 &&
						eyr >= 2020 && eyr <= 2030)
					{
						if (d["hgt"].EndsWith("cm") && (hgt >= 150 && hgt <= 193) ||
							d["hgt"].EndsWith("in") && (hgt >= 59 && hgt <= 76))
						{
							if (Regex.Match(d["hcl"], "^#(?:[0-9a-fA-F]{3}){1,2}$").Success)
							{
								if (eclValidArr.Any(s => d["ecl"].Contains(s)))
								{
									if (d["pid"].Length == 9)
									{
										count++;
									}
								}
							}
						}
					}
				}
			}
			return count.ToString();
		}
	}

	private bool HasAllRequiredFields(string input)
	{
		if (input.Contains("byr:") &&
				input.Contains("iyr:") &&
				input.Contains("eyr:") &&
				input.Contains("hgt:") &&
				input.Contains("hcl:") &&
				input.Contains("ecl:") &&
				input.Contains("pid:"))
		{
			return true;
		}
		else { return false; }
	}
}
