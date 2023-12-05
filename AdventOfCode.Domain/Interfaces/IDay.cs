namespace AdventOfCode.Domain.Interfaces;

public interface IDay
{
	string Title { get; }
	string PartA(string input);
	string PartB(string input);
}
