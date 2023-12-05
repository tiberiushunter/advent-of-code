namespace AdventOfCode.Solutions.Tests._2020;

public class Day3Tests : DayTests
{
	[Test]
	public async Task PartA()
	{
		// Arrange
		string expected = "262";

		// Act
		var solution = await _solverService.SolveDay(2020, 3);

		// Assert
		solution.PartA.Solution.Should().Be(expected);
	}

	[Test]
	public async Task PartB()
	{
		// Arrange
		string expected = "2698900776";

		// Act
		var solution = await _solverService.SolveDay(2020, 3);

		// Assert
		solution.PartB.Solution.Should().Be(expected);
	}
}