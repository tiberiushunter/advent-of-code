namespace AdventOfCode.Domain.Exceptions;

public class FutureDateException : Exception
{
	public int Day { get; }
	public int Year { get; }

	public FutureDateException() { }
	public FutureDateException(string message) : base(message) { }
	public FutureDateException(string message, Exception innerException) : base(message, innerException) { }
	public FutureDateException(string message, int day, int year)
		: this(message)
	{
		Day = day;
		Year = year;
	}
}
