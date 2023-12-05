namespace AdventOfCode.Solutions.Tests._2020;

public class Day18Tests : DayTests
{
	[Test]
	public async Task PartA()
	{
		// Arrange
		string expected = "4491283311856";

		// Act
		var solution = await _solverService.SolveDay(2020, 18);

		// Assert
		solution.PartA.Solution.Should().Be(expected);
	}

	[Test]
	public async Task PartB()
	{
		// Arrange
		string expected = "68852578641904";

		// Act
		var solution = await _solverService.SolveDay(2020, 18);

		// Assert
		solution.PartB.Solution.Should().Be(expected);
	}
}