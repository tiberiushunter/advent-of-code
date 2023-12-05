namespace AdventOfCode.Solutions.Tests._2015;

public class Day3Tests : DayTests
{
	[Test]
	public async Task PartA()
	{
		// Arrange
		string expected = "2565";

		// Act
		var solution = await _solverService.SolveDay(2015, 3);

		// Assert
		solution.PartA.Solution.Should().Be(expected);
	}

	[Test]
	public async Task PartB()
	{
		// Arrange
		string expected = "2639";

		// Act
		var solution = await _solverService.SolveDay(2015, 3);

		// Assert
		solution.PartB.Solution.Should().Be(expected);
	}
}