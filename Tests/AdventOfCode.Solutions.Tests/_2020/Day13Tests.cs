namespace AdventOfCode.Solutions.Tests._2020;

public class Day13Tests : DayTests
{
	[Test]
	public async Task PartA()
	{
		// Arrange
		string expected = "153";

		// Act
		var solution = await _solverService.SolveDay(2020, 13);

		// Assert
		solution.PartA.Solution.Should().Be(expected);
	}

	[Test]
	public async Task PartB()
	{
		// Arrange
		string expected = "471793476184394";

		// Act
		var solution = await _solverService.SolveDay(2020, 13);

		// Assert
		solution.PartB.Solution.Should().Be(expected);
	}
}