namespace AdventOfCode.Solutions.Tests._2015;

public class Day1Tests : DayTests
{
	[Test]
	public async Task PartA()
	{
		// Arrange
		string expected = "74";

		// Act
		var solution = await _solverService.SolveDay(2015, 1);

		// Assert
		solution.PartA.Solution.Should().Be(expected);
	}

	[Test]
	public async Task PartB()
	{
		// Arrange
		string expected = "1795";

		// Act
		var solution = await _solverService.SolveDay(2015, 1);

		// Assert
		solution.PartB.Solution.Should().Be(expected);
	}
}