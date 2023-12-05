namespace AdventOfCode.Solutions.Tests._2015;

public class Day2Tests : DayTests
{
	[Test]
	public async Task PartA()
	{
		// Arrange
		string expected = "1606483";

		// Act
		var solution = await _solverService.SolveDay(2015, 2);

		// Assert
		solution.PartA.Solution.Should().Be(expected);
	}

	[Test]
	public async Task PartB()
	{
		// Arrange
		string expected = "3842356";

		// Act
		var solution = await _solverService.SolveDay(2015, 2);

		// Assert
		solution.PartB.Solution.Should().Be(expected);
	}
}