namespace AdventOfCode.Solutions.Tests._2023;

public class Day4Tests : DayTests
{
	[Test]
	public async Task PartA()
	{
		// Arrange
		string expected = "28750";

		// Act
		var solution = await _solverService.SolveDay(2023, 4);

		// Assert
		solution.PartA.Solution.Should().Be(expected);
	}

	[Test]
	public async Task PartB()
	{
		// Arrange
		string expected = "10212704";

		// Act
		var solution = await _solverService.SolveDay(2023, 4);

		// Assert
		solution.PartB.Solution.Should().Be(expected);
	}
}