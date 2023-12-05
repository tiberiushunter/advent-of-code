namespace AdventOfCode.Domain.Interfaces;

public interface ISolutionClassRetrievalService
{
	IDay FindSolutionForDay(int year, int day);
}
