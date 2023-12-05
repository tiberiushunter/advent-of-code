namespace AdventOfCode.Domain.Exceptions;

public class SolutionClassForDayNotFoundException : Exception
{
	public int Day { get; set; }
	public int Year { get; set; }

	public SolutionClassForDayNotFoundException() { }
	public SolutionClassForDayNotFoundException(string message) : base(message) { }
	public SolutionClassForDayNotFoundException(string message, Exception innerException) : base(message, innerException) { }
	public SolutionClassForDayNotFoundException(string message, int day, int year)
	: this(message)
	{
		Day = day;
		Year = year;
	}
}
