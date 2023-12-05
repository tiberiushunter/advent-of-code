namespace AdventOfCode.Solutions.Tests._2020;

public class Day7Tests : DayTests
{
	[Test]
	public async Task PartA()
	{
		// Arrange
		string expected = "222";

		// Act
		var solution = await _solverService.SolveDay(2020, 7);

		// Assert
		solution.PartA.Solution.Should().Be(expected);
	}

	[Test]
	public async Task PartB()
	{
		// Arrange
		string expected = "13264";

		// Act
		var solution = await _solverService.SolveDay(2020, 7);

		// Assert
		solution.PartB.Solution.Should().Be(expected);
	}
}