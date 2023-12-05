namespace AdventOfCode.Domain.Exceptions;

public class InvalidYearException : Exception
{
	public int Year { get; set; }

	public InvalidYearException() { }
	public InvalidYearException(string message) : base(message) { }
	public InvalidYearException(string message, Exception innerException) : base(message, innerException) { }
	public InvalidYearException(string message, int year)
	: this(message)
	{
		Year = year;
	}
}
