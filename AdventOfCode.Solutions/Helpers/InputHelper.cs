namespace AdventOfCode.Solutions.Helpers;
public static class InputHelper
{
	public static string[] ToStringArray(string input)
	{
		return input.Split('\n');
	}

	public static IEnumerable<int> ToInt(string input)
	{
		return ToStringArray(input)
			.Select(s => string.IsNullOrWhiteSpace(s) ? 0 : int.Parse(s));
	}

	public static IEnumerable<long> ToLong(string input)
	{
		return ToStringArray(input)
			.Select(s => string.IsNullOrWhiteSpace(s) ? 0 : long.Parse(s));
	}
}
