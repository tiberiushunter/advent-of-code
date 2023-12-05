namespace AdventOfCode.Solutions.Tests._2020;

public class Day11Tests : DayTests
{
	[Test]
	public async Task PartA()
	{
		// Arrange
		string expected = "2093";

		// Act
		var solution = await _solverService.SolveDay(2020, 11);

		// Assert
		solution.PartA.Solution.Should().Be(expected);
	}

	[Test]
	public async Task PartB()
	{
		// Arrange
		string expected = "1862";

		// Act
		var solution = await _solverService.SolveDay(2020, 11);

		// Assert
		solution.PartB.Solution.Should().Be(expected);
	}
}