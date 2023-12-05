using AdventOfCode.Domain.Entities;

namespace AdventOfCode.Services.Tests.Builders;
public class PartBuilder
{
	private string? _solution;
	private double? _elaspsedTime;

	public PartBuilder WithSolution(string solution)
	{
		_solution = solution;
		return this;
	}

	public PartBuilder WithElapsedTime(double elapsedTime)
	{
		_elaspsedTime = elapsedTime;
		return this;
	}

	public Part Build()
	{
		return new Part
		{
			Solution = _solution ?? Guid.NewGuid().ToString(),
			ElapsedTime = _elaspsedTime ?? new Random().NextDouble()
		};
	}
}
