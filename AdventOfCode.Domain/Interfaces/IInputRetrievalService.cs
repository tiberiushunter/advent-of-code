namespace AdventOfCode.Domain.Interfaces;

public interface IInputRetrievalService
{
	Task<string> RetrievePuzzleInputForDay(int year, int day);
}
