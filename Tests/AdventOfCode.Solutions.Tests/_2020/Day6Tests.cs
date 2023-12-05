namespace AdventOfCode.Solutions.Tests._2020;

public class Day6Tests : DayTests
{
	[Test]
	public async Task PartA()
	{
		// Arrange
		string expected = "6782";

		// Act
		var solution = await _solverService.SolveDay(2020, 6);

		// Assert
		solution.PartA.Solution.Should().Be(expected);
	}

	[Test]
	public async Task PartB()
	{
		// Arrange
		string expected = "3596";

		// Act
		var solution = await _solverService.SolveDay(2020, 6);

		// Assert
		solution.PartB.Solution.Should().Be(expected);
	}
}