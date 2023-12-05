using Microsoft.Extensions.Configuration;

namespace AdventOfCode.Client.Settings;
public class AdventOfCodeConfiguration : IAdventOfCodeConfiguration
{
	private readonly IConfigurationSection _configuration;
	public AdventOfCodeConfiguration(IConfigurationSection configuration)
	{
		_configuration = configuration;
	}

	public string Domain => $"{_configuration["Domain"]}";
	public string SessionToken => $"{_configuration["SessionToken"]}";
}
