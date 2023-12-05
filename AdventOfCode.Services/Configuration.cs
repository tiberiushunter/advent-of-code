using AdventOfCode.Domain.Interfaces;
using AdventOfCode.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using System.IO.Abstractions;

namespace AdventOfCode.Services;
public static class Configuration
{
	public static IServiceCollection AddServices(this IServiceCollection services)
	{
		services.AddTransient<IPuzzleSolverService, PuzzleSolverService>();
		services.AddTransient<IInputRetrievalService, InputRetrievalService>();
		services.AddTransient<ISolutionClassRetrievalService, SolutionClassRetrievalService>();
		services.AddScoped<IFileSystem, FileSystem>();

		return services;
	}
}
