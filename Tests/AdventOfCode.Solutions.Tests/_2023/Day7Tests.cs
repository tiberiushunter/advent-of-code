namespace AdventOfCode.Solutions.Tests._2023;

public class Day7Tests : DayTests
{
	[Test]
	public async Task PartA()
	{
		// Arrange
		string expected = "247961593";

		// Act
		var solution = await _solverService.SolveDay(2023, 7);

		// Assert
		solution.PartA.Solution.Should().Be(expected);
	}

	[Test]
	public async Task PartB()
	{
		// Arrange
		string expected = "248750699";

		// Act
		var solution = await _solverService.SolveDay(2023, 7);

		// Assert
		solution.PartB.Solution.Should().Be(expected);
	}
}