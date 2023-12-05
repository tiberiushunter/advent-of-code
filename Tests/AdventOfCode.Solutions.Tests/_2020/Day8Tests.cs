namespace AdventOfCode.Solutions.Tests._2020;

public class Day8Tests : DayTests
{
	[Test]
	public async Task PartA()
	{
		// Arrange
		string expected = "2080";

		// Act
		var solution = await _solverService.SolveDay(2020, 8);

		// Assert
		solution.PartA.Solution.Should().Be(expected);
	}

	[Test]
	public async Task PartB()
	{
		// Arrange
		string expected = "2477";

		// Act
		var solution = await _solverService.SolveDay(2020, 8);

		// Assert
		solution.PartB.Solution.Should().Be(expected);
	}
}