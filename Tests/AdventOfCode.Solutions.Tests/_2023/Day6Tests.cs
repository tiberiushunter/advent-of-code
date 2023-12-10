namespace AdventOfCode.Solutions.Tests._2023;

public class Day6Tests : DayTests
{
	[Test]
	public async Task PartA()
	{
		// Arrange
		string expected = "131376";

		// Act
		var solution = await _solverService.SolveDay(2023, 6);

		// Assert
		solution.PartA.Solution.Should().Be(expected);
	}

	[Test]
	public async Task PartB()
	{
		// Arrange
		string expected = "34123437";

		// Act
		var solution = await _solverService.SolveDay(2023, 6);

		// Assert
		solution.PartB.Solution.Should().Be(expected);
	}
}