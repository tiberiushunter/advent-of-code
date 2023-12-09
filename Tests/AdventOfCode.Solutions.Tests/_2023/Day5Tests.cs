namespace AdventOfCode.Solutions.Tests._2023;

public class Day5Tests : DayTests
{
	[Test]
	public async Task PartA()
	{
		// Arrange
		string expected = "26273516";

		// Act
		var solution = await _solverService.SolveDay(2023, 5);

		// Assert
		solution.PartA.Solution.Should().Be(expected);
	}

	[Test]
	public async Task PartB()
	{
		// Arrange
		string expected = "34039469";

		// Act
		var solution = await _solverService.SolveDay(2023, 5);

		// Assert
		solution.PartB.Solution.Should().Be(expected);
	}
}