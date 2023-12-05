using AdventOfCode.Domain.Interfaces;

namespace AdventOfCode.Domain.Providers;

public class DateTimeProvider : IDateTimeProvider
{
	public DateTime GetNow() => DateTime.UtcNow;
}
