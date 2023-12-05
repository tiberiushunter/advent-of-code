namespace AdventOfCode.Solutions.Tests._2020;

public class Day17Tests : DayTests
{
	[Test]
	public async Task PartA()
	{
		// Arrange
		string expected = "310";

		// Act
		var solution = await _solverService.SolveDay(2020, 17);

		// Assert
		solution.PartA.Solution.Should().Be(expected);
	}

	[Test]
	public async Task PartB()
	{
		// Arrange
		string expected = "2056";

		// Act
		var solution = await _solverService.SolveDay(2020, 17);

		// Assert
		solution.PartB.Solution.Should().Be(expected);
	}
}