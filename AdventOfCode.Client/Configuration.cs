using AdventOfCode.Client.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode.Client;
public static class Configuration
{
	public static IServiceCollection AddAdventOfCodeClient(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddTransient<IAdventOfCodeClient, AdventOfCodeClient>();
		services.AddSingleton<IAdventOfCodeConfiguration, AdventOfCodeConfiguration>();

		var adventOfCodeConfiguration = new AdventOfCodeConfiguration(configuration.GetSection("AdventOfCodeClient"));

		services.AddHttpClient("AdventOfCode", client =>
		{
			client.BaseAddress = new Uri(adventOfCodeConfiguration.Domain);
			client.DefaultRequestHeaders.Add("Cookie", $"session={adventOfCodeConfiguration.SessionToken}");
		});

		return services;
	}
}
