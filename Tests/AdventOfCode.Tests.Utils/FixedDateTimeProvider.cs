using AdventOfCode.Domain.Interfaces;

namespace AdventOfCode.Tests.Utils;

public class FixedDateTimeProvider : IDateTimeProvider
{
	private readonly DateTime _fixedDateTime;

	public FixedDateTimeProvider(DateTime fixedDateTime)
	{
		_fixedDateTime = fixedDateTime;
	}

	public DateTime GetNow() => _fixedDateTime;
}
