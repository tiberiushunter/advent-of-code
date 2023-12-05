namespace AdventOfCode.Solutions.Tests._2023;

public class Day1Tests : DayTests
{
	[Test]
	public async Task PartA()
	{
		// Arrange
		string expected = "55123";

		// Act
		var solution = await _solverService.SolveDay(2023, 1);

		// Assert
		solution.PartA.Solution.Should().Be(expected);
	}

	[Test]
	public async Task PartB()
	{
		// Arrange
		string expected = "55260";

		// Act
		var solution = await _solverService.SolveDay(2023, 1);

		// Assert
		solution.PartB.Solution.Should().Be(expected);
	}
}