using AdventOfCode.Domain.Entities;

namespace AdventOfCode.Services.Tests.Builders;
public class DaySolutionBuilder
{
	private Part? _partA;
	private Part? _partB;

	public DaySolutionBuilder WithPartA(Part partA)
	{
		_partA = partA;
		return this;
	}

	public DaySolutionBuilder WithPartB(Part partB)
	{
		_partB = partB;
		return this;
	}

	public DaySolution Build()
	{
		return new DaySolution
		{
			PartA = _partA ?? new PartBuilder().Build(),
			PartB = _partB ?? new PartBuilder().Build()
		};
	}
}
