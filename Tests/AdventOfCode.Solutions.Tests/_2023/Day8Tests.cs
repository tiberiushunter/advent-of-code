namespace AdventOfCode.Solutions.Tests._2023;

public class Day8Tests : DayTests
{
	[Test]
	public async Task PartA()
	{
		// Arrange
		string expected = "18727";

		// Act
		var solution = await _solverService.SolveDay(2023, 8);

		// Assert
		solution.PartA.Solution.Should().Be(expected);
	}

	[Test]
	public async Task PartB()
	{
		// Arrange
		string expected = "18024643846273";

		// Act
		var solution = await _solverService.SolveDay(2023, 8);

		// Assert
		solution.PartB.Solution.Should().Be(expected);
	}
}