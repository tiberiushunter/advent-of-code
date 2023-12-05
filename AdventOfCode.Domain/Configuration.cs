using AdventOfCode.Domain.Interfaces;
using AdventOfCode.Domain.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode.Domain;
public static class Configuration
{
	public static IServiceCollection AddDomainServices(this IServiceCollection services)
	{
		services.AddSingleton<ITimerProvider, TimerProvider>();
		services.AddScoped<IDateTimeProvider, DateTimeProvider>();

		return services;
	}
}
