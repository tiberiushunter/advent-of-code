using AdventOfCode.Domain.Entities;

namespace AdventOfCode.Domain.Interfaces;

public interface IPuzzleSolverService
{
	Task<DaySolution> SolveDay(int year, int day);
	Task<IList<DaySolution>> SolveYear(int year);
	Task<IList<IList<DaySolution>>> SolveAll();
}
