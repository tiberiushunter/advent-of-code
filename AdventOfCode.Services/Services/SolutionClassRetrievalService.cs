using AdventOfCode.Domain.Exceptions;
using AdventOfCode.Domain.Interfaces;

namespace AdventOfCode.Services;

public class SolutionClassRetrievalService : ISolutionClassRetrievalService
{
	public IDay FindSolutionForDay(int year, int day)
	{
		try
		{
			var type = Type.GetType($"AdventOfCode.Solutions._{year}.Day{day}, AdventOfCode.Solutions", true);
			var solutionObject = Activator.CreateInstance(type) as IDay;

			return solutionObject;
		}
		catch (TypeLoadException)
		{
			throw new SolutionClassForDayNotFoundException($"Solution for Day: {day} in {year} can't be found.", day, year);
		}
	}
}
