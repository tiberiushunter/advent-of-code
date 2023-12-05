namespace AdventOfCode.Solutions.Tests._2023;

public class Day3Tests : DayTests
{
	[Test]
	public async Task PartA()
	{
		// Arrange
		string expected = "559667";

		// Act
		var solution = await _solverService.SolveDay(2023, 3);

		// Assert
		solution.PartA.Solution.Should().Be(expected);
	}

	[Test]
	public async Task PartB()
	{
		// Arrange
		string expected = "86841457";

		// Act
		var solution = await _solverService.SolveDay(2023, 3);

		// Assert
		solution.PartB.Solution.Should().Be(expected);
	}
}