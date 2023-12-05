using AdventOfCode.Domain.Common;
using AdventOfCode.Domain.Entities;
using AdventOfCode.Domain.Exceptions;
using AdventOfCode.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace AdventOfCode.Services.Services;

public class PuzzleSolverService : IPuzzleSolverService
{

	private readonly IInputRetrievalService _puzzleInputRetrievalService;
	private readonly ISolutionClassRetrievalService _solutionClassRetrievalService;
	private readonly ITimerProvider _solverTimer;
	private readonly IDateTimeProvider _dateTimeProvider;
	private readonly ILogger<PuzzleSolverService> _logger;

	public PuzzleSolverService(
		IInputRetrievalService puzzleInputRetrievalService,
		ISolutionClassRetrievalService solutionClassRetrievalService,
		ITimerProvider solverTimer,
		IDateTimeProvider dateTimeProvider,
		ILogger<PuzzleSolverService> logger)
	{
		_puzzleInputRetrievalService = puzzleInputRetrievalService;
		_solutionClassRetrievalService = solutionClassRetrievalService;
		_solverTimer = solverTimer;
		_dateTimeProvider = dateTimeProvider;
		_logger = logger;
	}

	public async Task<DaySolution> SolveDay(int year, int day)
	{
		ValidateDate(day, year);

		var puzzleInput = await _puzzleInputRetrievalService.RetrievePuzzleInputForDay(year, day);
		var puzzleSolution = _solutionClassRetrievalService.FindSolutionForDay(year, day);

		_solverTimer.Start();
		string result = puzzleSolution.PartA(puzzleInput);
		_solverTimer.Stop();

		var partA = new Part()
		{
			ElapsedTime = _solverTimer.ElapsedTime(),
			Solution = result
		};

		_solverTimer.Start();
		result = puzzleSolution.PartB(puzzleInput);
		_solverTimer.Stop();

		var partB = new Part()
		{
			ElapsedTime = _solverTimer.ElapsedTime(),
			Solution = result
		};

		var solution = new DaySolution()
		{
			Day = day,
			Year = year,
			PartA = partA,
			PartB = partB,
		};

		return solution;
	}

	public async Task<IList<DaySolution>> SolveYear(int year)
	{
		List<DaySolution> solutions = [];

		for (int day = Constants.MinDay; day <= Constants.MaxDay; day++)
		{
			try
			{
				solutions.Add(await SolveDay(year, day));
			}
			catch (SolutionClassForDayNotFoundException ex)
			{
				_logger.LogDebug(ex.Message);
			}
			catch (FutureDateException ex)
			{
				_logger.LogDebug(ex.Message);
			}
		}

		return solutions;
	}

	public async Task<IList<IList<DaySolution>>> SolveAll()
	{
		List<IList<DaySolution>> solutions = [];

		for (int year = Constants.MinYear; year <= Constants.MaxYear; year++)
		{
			solutions.Add(await SolveYear(year));
		}

		return solutions;
	}

	private void ValidateDate(int day, int year)
	{
		if (day < Constants.MinDay || day > Constants.MaxDay)
		{
			throw new InvalidDayException($"Day {day} is invalid - Select a day between {Constants.MinDay} and {Constants.MaxDay}", day);
		}

		if (year < Constants.MinYear || year > Constants.MaxYear)
		{
			throw new InvalidYearException($"Year {year} is invalid - Select a year between {Constants.MinYear} and {Constants.MaxYear}", year);
		}

		if (new DateTime(year, 12, day) > _dateTimeProvider.GetNow().Date)
		{
			throw new FutureDateException($"Day {day} for {year} is invalid - Cannot solve a puzzle in the future", day, year);
		}
	}
}
