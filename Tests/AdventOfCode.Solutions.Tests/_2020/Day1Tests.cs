namespace AdventOfCode.Solutions.Tests._2020;

public class Day1Tests : DayTests
{
	[Test]
	public async Task PartA()
	{
		// Arrange
		string expected = "270144";

		// Act
		var solution = await _solverService.SolveDay(2020, 1);

		// Assert
		solution.PartA.Solution.Should().Be(expected);
	}

	[Test]
	public async Task PartB()
	{
		// Arrange
		string expected = "261342720";

		// Act
		var solution = await _solverService.SolveDay(2020, 1);

		// Assert
		solution.PartB.Solution.Should().Be(expected);
	}
}