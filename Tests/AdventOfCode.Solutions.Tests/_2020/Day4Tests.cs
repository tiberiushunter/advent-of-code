namespace AdventOfCode.Solutions.Tests._2020;

public class Day4Tests : DayTests
{
	[Test]
	public async Task PartA()
	{
		// Arrange
		string expected = "235";

		// Act
		var solution = await _solverService.SolveDay(2020, 4);

		// Assert
		solution.PartA.Solution.Should().Be(expected);
	}

	[Test]
	public async Task PartB()
	{
		// Arrange
		string expected = "194";

		// Act
		var solution = await _solverService.SolveDay(2020, 4);

		// Assert
		solution.PartB.Solution.Should().Be(expected);
	}
}