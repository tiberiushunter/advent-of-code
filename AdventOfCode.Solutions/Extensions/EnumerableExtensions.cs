namespace AdventOfCode.Solutions.Extensions;
public static class EnumerableExtensions
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

	public static IEnumerable<T> InfiniteSelect<T>(this IEnumerable<T> source)
	{
		while (true)
		{
			foreach (T item in source)
			{
				yield return item;
			}
		}
	}
}
