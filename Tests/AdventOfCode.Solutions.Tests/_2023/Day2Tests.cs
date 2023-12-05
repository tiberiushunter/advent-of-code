namespace AdventOfCode.Solutions.Tests._2023;

public class Day2Tests : DayTests
{
	[Test]
	public async Task PartA()
	{
		// Arrange
		string expected = "2505";

		// Act
		var solution = await _solverService.SolveDay(2023, 2);

		// Assert
		solution.PartA.Solution.Should().Be(expected);
	}

	[Test]
	public async Task PartB()
	{
		// Arrange
		string expected = "70265";

		// Act
		var solution = await _solverService.SolveDay(2023, 2);

		// Assert
		solution.PartB.Solution.Should().Be(expected);
	}
}