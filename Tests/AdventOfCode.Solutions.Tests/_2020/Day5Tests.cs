namespace AdventOfCode.Solutions.Tests._2020;

public class Day5Tests : DayTests
{
	[Test]
	public async Task PartA()
	{
		// Arrange
		string expected = "801";

		// Act
		var solution = await _solverService.SolveDay(2020, 5);

		// Assert
		solution.PartA.Solution.Should().Be(expected);
	}

	[Test]
	public async Task PartB()
	{
		// Arrange
		string expected = "597";

		// Act
		var solution = await _solverService.SolveDay(2020, 5);

		// Assert
		solution.PartB.Solution.Should().Be(expected);
	}
}