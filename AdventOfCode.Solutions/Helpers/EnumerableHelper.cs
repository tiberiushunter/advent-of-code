namespace AdventOfCode.Solutions.Helpers;
public static class EnumerableHelper
{
	public static IEnumerable<long> LongRange(long start, long length)
	{
		var limit = start + length;

		while (start < limit)
		{
			yield return start;
			start++;
		}
	}
}
