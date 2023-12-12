namespace AdventOfCode.Solutions.Tests._2023;

public class Day9Tests : DayTests
{
	[Test]
	public async Task PartA()
	{
		// Arrange
		string expected = "1974913025";

		// Act
		var solution = await _solverService.SolveDay(2023, 9);

		// Assert
		solution.PartA.Solution.Should().Be(expected);
	}

	[Test]
	public async Task PartB()
	{
		// Arrange
		string expected = "884";

		// Act
		var solution = await _solverService.SolveDay(2023, 9);

		// Assert
		solution.PartB.Solution.Should().Be(expected);
	}
}