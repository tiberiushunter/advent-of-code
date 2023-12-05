namespace AdventOfCode.Solutions.Tests._2020;

public class Day9Tests : DayTests
{
	[Test]
	public async Task PartA()
	{
		// Arrange
		string expected = "1721308972";

		// Act
		var solution = await _solverService.SolveDay(2020, 9);

		// Assert
		solution.PartA.Solution.Should().Be(expected);
	}

	[Test]
	public async Task PartB()
	{
		// Arrange
		string expected = "209694133";

		// Act
		var solution = await _solverService.SolveDay(2020, 9);

		// Assert
		solution.PartB.Solution.Should().Be(expected);
	}
}