using AdventOfCode.Domain.Common;
using AdventOfCode.Domain.Exceptions;
using AdventOfCode.Domain.Interfaces;
using AdventOfCode.Services.Services;
using AdventOfCode.Services.Tests.Builders;
using AdventOfCode.Tests.Utils;
using Microsoft.Extensions.Logging;
using Moq;

namespace AdventOfCode.Services.Tests.Services;

public class PuzzleSolverServiceTests
{
	private IPuzzleSolverService _solverService;
	private Mock<IInputRetrievalService> _mockInputRetrievalService;
	private Mock<ISolutionClassRetrievalService> _mockSolutionClassRetrievalService;
	private Mock<ITimerProvider> _mockTimerProvider;
	private Mock<IDay> _mockSolutionClass;
	private Mock<ILogger<PuzzleSolverService>> _mockLogger;
	private IDateTimeProvider _dateTimeProvider;

	[SetUp]
	public void Setup()
	{
		_mockInputRetrievalService = new Mock<IInputRetrievalService>();
		_mockSolutionClassRetrievalService = new Mock<ISolutionClassRetrievalService>();
		_mockTimerProvider = new Mock<ITimerProvider>();
		_mockSolutionClass = new Mock<IDay>();
		_dateTimeProvider = new FixedDateTimeProvider(new DateTime(2023, 11, 1));
		_mockLogger = new Mock<ILogger<PuzzleSolverService>>();

		_solverService = new PuzzleSolverService(
			_mockInputRetrievalService.Object,
			_mockSolutionClassRetrievalService.Object,
			_mockTimerProvider.Object,
			_dateTimeProvider,
			_mockLogger.Object
		);
	}

	[Test]
	public async Task GivenDayToSolve_WhenDayIsInvalid_ThenInvalidDayExceptonThrown()
	{
		// Arrange
		var day = 30;
		var year = 2020;

		// Act
		Func<Task> solution = async () => await _solverService.SolveDay(year, day);

		// Assert
		var exception = await solution
			.Should()
			.ThrowAsync<InvalidDayException>()
			.WithMessage($"Day {day} is invalid - Select a day between 1 and 25");
	}

	[Test]
	public async Task GivenDayToSolve_WhenYearIsInvalid_ThenInvalidYearExceptonThrown()
	{
		// Arrange
		var day = 1;
		var year = 2000;

		// Act
		Func<Task> solution = async () => await _solverService.SolveDay(year, day);

		// Assert
		var exception = await solution
			.Should()
			.ThrowAsync<InvalidYearException>()
			.WithMessage($"Year {year} is invalid - Select a year between 2015 and 2023");
	}

	[Test]
	public async Task GivenDayToSolve_WhenDayIsInTheFuture_ThenFutureDateExceptonThrown()
	{
		// Arrange
		var day = 1;
		var year = 2023;

		// Act
		Func<Task> solution = async () => await _solverService.SolveDay(year, day);

		// Assert
		var exception = await solution
			.Should()
			.ThrowAsync<FutureDateException>()
			.WithMessage($"Day {day} for {year} is invalid - Cannot solve a puzzle in the future");
	}

	[Test]
	public async Task GivenDayToSolve_WhenSolveDay_ThenSolutionIsReturned()
	{
		// Arrange
		var day = 1;
		var year = 2020;

		var puzzleInput = "ABCDEF";
		var partA = new PartBuilder().WithSolution("ABC").Build();
		var partB = new PartBuilder().WithSolution("DEF").Build();

		var expected = new DaySolutionBuilder()
			.WithPartA(partA)
			.WithPartB(partB)
			.Build();

		_mockInputRetrievalService
			.Setup(pirs => pirs.RetrievePuzzleInputForDay(year, day))
			.ReturnsAsync(puzzleInput);

		_mockSolutionClassRetrievalService
			.Setup(scrs => scrs.FindSolutionForDay(year, day))
			.Returns(_mockSolutionClass.Object);

		_mockSolutionClass
			.Setup(sc => sc.PartA(puzzleInput))
			.Returns("ABC");

		_mockSolutionClass
			.Setup(sc => sc.PartB(puzzleInput))
			.Returns("DEF");

		// Act
		var solution = await _solverService.SolveDay(year, day);

		// Assert
		_mockInputRetrievalService.VerifyAll();
		_mockSolutionClassRetrievalService.VerifyAll();
		_mockSolutionClass.VerifyAll();

		solution.Should().NotBeNull();
		solution.PartA.Solution.Should().Be("ABC");
		solution.PartB.Solution.Should().Be("DEF");
	}

	[Test]
	public async Task GivenYearToSolve_WhenSolveYear_ThenAllSolutionsForYearAreReturned()
	{
		// Arrange
		var year = 2020;

		var puzzleInput = "ABCDEF";
		var partA = new PartBuilder().WithSolution("ABC").Build();
		var partB = new PartBuilder().WithSolution("DEF").Build();

		var expected = new DaySolutionBuilder()
			.WithPartA(partA)
			.WithPartB(partB)
			.Build();

		_mockInputRetrievalService
			.Setup(pirs => pirs.RetrievePuzzleInputForDay(year, It.IsAny<int>()))
			.ReturnsAsync(puzzleInput);

		_mockSolutionClassRetrievalService
			.Setup(scrs => scrs.FindSolutionForDay(year, It.IsAny<int>()))
			.Returns(_mockSolutionClass.Object);

		_mockSolutionClass
			.Setup(sc => sc.PartA(puzzleInput))
			.Returns("ABC");

		_mockSolutionClass
			.Setup(sc => sc.PartB(puzzleInput))
			.Returns("DEF");

		// Act
		var solutions = await _solverService.SolveYear(year);

		// Assert
		_mockInputRetrievalService.VerifyAll();
		_mockSolutionClassRetrievalService.VerifyAll();
		_mockSolutionClass.VerifyAll();

		solutions.Should().NotBeNull();
		solutions.Should().HaveCount(25);
		solutions.First().PartA.Solution.Should().Be("ABC");
		solutions.First().PartB.Solution.Should().Be("DEF");
		solutions.Last().PartA.Solution.Should().Be("ABC");
		solutions.Last().PartB.Solution.Should().Be("DEF");
	}

	[Test]
	public async Task GivenAllSolutions_WhenSolveAll_ThenAllSolutionsForAllYearsAreReturned()
	{
		// Arrange
		var expectedNumberOfYears = Constants.MaxYear - Constants.MinYear + 1;

		var puzzleInput = "ABCDEF";
		var partA = new PartBuilder().WithSolution("ABC").Build();
		var partB = new PartBuilder().WithSolution("DEF").Build();

		var expected = new DaySolutionBuilder()
			.WithPartA(partA)
			.WithPartB(partB)
			.Build();

		_mockInputRetrievalService
			.Setup(pirs => pirs.RetrievePuzzleInputForDay(It.IsAny<int>(), It.IsAny<int>()))
			.ReturnsAsync(puzzleInput);

		_mockSolutionClassRetrievalService
			.Setup(scrs => scrs.FindSolutionForDay(It.IsAny<int>(), It.IsAny<int>()))
			.Returns(_mockSolutionClass.Object);

		_mockSolutionClass
			.Setup(sc => sc.PartA(puzzleInput))
			.Returns("ABC");

		_mockSolutionClass
			.Setup(sc => sc.PartB(puzzleInput))
			.Returns("DEF");

		// Act
		var solutions = await _solverService.SolveAll();

		// Assert
		_mockInputRetrievalService.VerifyAll();
		_mockSolutionClassRetrievalService.VerifyAll();
		_mockSolutionClass.VerifyAll();

		solutions.Should().NotBeNull();
		solutions.Should().HaveCount(expectedNumberOfYears);
	}
}