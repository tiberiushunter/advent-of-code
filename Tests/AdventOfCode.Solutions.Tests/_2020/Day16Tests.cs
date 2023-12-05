namespace AdventOfCode.Solutions.Tests._2020;

public class Day16Tests : DayTests
{
	[Test]
	public async Task PartA()
	{
		// Arrange
		string expected = "21980";

		// Act
		var solution = await _solverService.SolveDay(2020, 16);

		// Assert
		solution.PartA.Solution.Should().Be(expected);
	}

	[Test]
	public async Task PartB()
	{
		// Arrange
		string expected = "1439429522627";

		// Act
		var solution = await _solverService.SolveDay(2020, 16);

		// Assert
		solution.PartB.Solution.Should().Be(expected);
	}
}