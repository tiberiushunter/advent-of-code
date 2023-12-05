using AdventOfCode.Client;
using AdventOfCode.Domain.Interfaces;
using AdventOfCode.Domain.Providers;
using AdventOfCode.Services;
using AdventOfCode.Services.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System.IO.Abstractions;

namespace AdventOfCode.Solutions.Tests;

public abstract class DayTests
{
	private protected IPuzzleSolverService _solverService;

	[SetUp]
	public void Setup()
	{
		var puzzleInputRetrievalService = new InputRetrievalService(
			new Mock<IAdventOfCodeClient>().Object,
			new FileSystem()
		);

		_solverService = new PuzzleSolverService(
			puzzleInputRetrievalService,
			new SolutionClassRetrievalService(),
			new TimerProvider(),
			new DateTimeProvider(),
			new Mock<ILogger<PuzzleSolverService>>().Object
		);
	}
}