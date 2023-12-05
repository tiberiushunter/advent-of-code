namespace AdventOfCode.Solutions.Tests._2020;

public class Day14Tests : DayTests
{
	[Test]
	public async Task PartA()
	{
		// Arrange
		string expected = "18630548206046";

		// Act
		var solution = await _solverService.SolveDay(2020, 14);

		// Assert
		solution.PartA.Solution.Should().Be(expected);
	}

	[Test]
	public async Task PartB()
	{
		// Arrange
		string expected = "4254673508445";

		// Act
		var solution = await _solverService.SolveDay(2020, 14);

		// Assert
		solution.PartB.Solution.Should().Be(expected);
	}
}