namespace AdventOfCode.Solutions.Tests._2021;

public class Day2Tests : DayTests
{
	[Test]
	public async Task PartA()
	{
		// Arrange
		string expected = "2039912";

		// Act
		var solution = await _solverService.SolveDay(2021, 2);

		// Assert
		solution.PartA.Solution.Should().Be(expected);
	}

	[Test]
	public async Task PartB()
	{
		// Arrange
		string expected = "1942068080";

		// Act
		var solution = await _solverService.SolveDay(2021, 2);

		// Assert
		solution.PartB.Solution.Should().Be(expected);
	}
}