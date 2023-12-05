namespace AdventOfCode.Solutions.Tests._2020;

public class Day10Tests : DayTests
{
	[Test]
	public async Task PartA()
	{
		// Arrange
		string expected = "2201";

		// Act
		var solution = await _solverService.SolveDay(2020, 10);

		// Assert
		solution.PartA.Solution.Should().Be(expected);
	}

	[Test]
	public async Task PartB()
	{
		// Arrange
		string expected = "169255295254528";

		// Act
		var solution = await _solverService.SolveDay(2020, 10);

		// Assert
		solution.PartB.Solution.Should().Be(expected);
	}
}