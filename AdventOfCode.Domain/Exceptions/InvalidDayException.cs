namespace AdventOfCode.Domain.Exceptions;

public class InvalidDayException : Exception
{
	public int Day { get; }

	public InvalidDayException() { }
	public InvalidDayException(string message) : base(message) { }
	public InvalidDayException(string message, Exception innerException) : base(message, innerException) { }
	public InvalidDayException(string message, int day)
		: this(message)
	{
		Day = day;
	}
}
