namespace AdventOfCode.Solutions.Tests._2020;

public class Day12Tests : DayTests
{
	[Test]
	public async Task PartA()
	{
		// Arrange
		string expected = "2057";

		// Act
		var solution = await _solverService.SolveDay(2020, 12);

		// Assert
		solution.PartA.Solution.Should().Be(expected);
	}

	[Test]
	public async Task PartB()
	{
		// Arrange
		string expected = "71504";

		// Act
		var solution = await _solverService.SolveDay(2020, 12);

		// Assert
		solution.PartB.Solution.Should().Be(expected);
	}
}