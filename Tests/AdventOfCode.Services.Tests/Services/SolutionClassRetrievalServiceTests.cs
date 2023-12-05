using AdventOfCode.Domain.Exceptions;
using AdventOfCode.Domain.Interfaces;

namespace AdventOfCode.Services.Tests.Services;

public class SolutionClassRetrievalServiceTests
{
	private ISolutionClassRetrievalService _retrievalService;

	[SetUp]
	public void Setup()
	{
		_retrievalService = new SolutionClassRetrievalService();
	}

	[Test]
	public void GivenSolutionToRetrieve_WhenSolutionNotFound_ThenSolutionClassForDayNotFoundExceptionThrown()
	{
		// Arrange
		var day = 1;
		var year = 2014;

		// Act
		var solutionClass = () => _retrievalService.FindSolutionForDay(year, day);

		// Assert
		var exception = solutionClass
			.Should()
			.Throw<SolutionClassForDayNotFoundException>()
			.WithMessage($"Solution for Day: {day} in {year} can't be found.");
	}

	[Test]
	public void GivenDayToSolve_WhenSolveDay_ThenSolutionIsReturned()
	{
		// Arrange
		var day = 1;
		var year = 2020;

		// Act
		var solutionClass = _retrievalService.FindSolutionForDay(year, day);

		// Assert
		solutionClass.Should().NotBeNull();
		solutionClass.Should().BeOfType<Solutions._2020.Day1>();
	}
}