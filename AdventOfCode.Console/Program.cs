using AdventOfCode.Client;
using AdventOfCode.Console;
using AdventOfCode.Domain;
using AdventOfCode.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

var configuration = new ConfigurationBuilder()
	.AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true)
	.Build();

var logger = new LoggerConfiguration()
	.MinimumLevel.Warning()
	.WriteTo.Console()
	.CreateLogger();

using IHost host = CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;

try
{
	services.GetRequiredService<App>().Run(args);
}
catch (Exception e)
{
	Console.WriteLine(e.Message);
}

IHostBuilder CreateHostBuilder(string[] args)
{
	return Host.CreateDefaultBuilder()
		.ConfigureLogging((_) =>
		{
			_.ClearProviders();
			_.AddSerilog(logger);
		})
		.ConfigureServices((_, services) =>
		{
			services.AddLogging();
			services.AddSingleton<App>();
			services.AddServices();
			services.AddDomainServices();
			services.AddAdventOfCodeClient(configuration);
		});
}

host.Run();
