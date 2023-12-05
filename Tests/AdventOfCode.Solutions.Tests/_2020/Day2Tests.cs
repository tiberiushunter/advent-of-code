namespace AdventOfCode.Solutions.Tests._2020;

public class Day2Tests : DayTests
{
	[Test]
	public async Task PartA()
	{
		// Arrange
		string expected = "500";

		// Act
		var solution = await _solverService.SolveDay(2020, 2);

		// Assert
		solution.PartA.Solution.Should().Be(expected);
	}

	[Test]
	public async Task PartB()
	{
		// Arrange
		string expected = "313";

		// Act
		var solution = await _solverService.SolveDay(2020, 2);

		// Assert
		solution.PartB.Solution.Should().Be(expected);
	}
}