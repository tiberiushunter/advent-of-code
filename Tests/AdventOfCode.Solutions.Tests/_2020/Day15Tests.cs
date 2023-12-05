namespace AdventOfCode.Solutions.Tests._2020;

public class Day15Tests : DayTests
{
	[Test]
	public async Task PartA()
	{
		// Arrange
		string expected = "447";

		// Act
		var solution = await _solverService.SolveDay(2020, 15);

		// Assert
		solution.PartA.Solution.Should().Be(expected);
	}

	[Test]
	public async Task PartB()
	{
		// Arrange
		string expected = "11721679";

		// Act
		var solution = await _solverService.SolveDay(2020, 15);

		// Assert
		solution.PartB.Solution.Should().Be(expected);
	}
}