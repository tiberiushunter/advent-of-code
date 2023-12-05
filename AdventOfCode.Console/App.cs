using AdventOfCode.Domain.Entities;
using AdventOfCode.Domain.Interfaces;
using System.Drawing;
using static Colorful.Console;

namespace AdventOfCode.Console;

public class App
{
	private readonly IPuzzleSolverService _solverService;

	public App(IPuzzleSolverService solverService)
	{
		_solverService = solverService;
	}

	public void Run(string[] args)
	{
		WriteLine(_welcomeText, Color.Green);
		SelectYear();
	}

	public async void SelectYear()
	{
		Write("Choose a year to solve (2015-2023) or press Enter to solve all years\t");

		string yearInput = ReadLine();

		if (int.TryParse(yearInput, out int yearSelected))
		{
			await SelectDay(yearSelected);
		}
		else
		{
			await SolveAll();
		}
	}

	private async Task SelectDay(int yearSelected)
	{
		Write("\nChoose a day to solve (1-25) or press Enter to solve all days\t");

		string dayInput = ReadLine();

		if (int.TryParse(dayInput, out int daySelected))
		{
			await SolveDay(yearSelected, daySelected);
		}
		else
		{
			await SolveYear(yearSelected);
		}
	}

	private async Task SolveDay(int year, int day)
	{
		try
		{
			var solution = await _solverService.SolveDay(year, day);
			PrintSolution(solution);
		}
		catch (Exception ex)
		{
			WriteLine($"{ex.Message}", Color.Red);
		}
	}

	private async Task SolveYear(int year)
	{
		LineBreak(Color.Green);
		WriteLine($" All Days for {year} Selected", Color.Green);
		LineBreak(Color.Green);

		var solutions = await _solverService.SolveYear(year);

		foreach (var solution in solutions)
		{
			try
			{
				PrintSolution(solution);
			}
			catch (Exception ex)
			{
				WriteLine($"{ex.Message}", Color.Red);
			}
		}

		var totalTime = solutions.Sum(s => s.PartA.ElapsedTime + s.PartB.ElapsedTime);

		LineBreak(Color.Yellow);
		WriteLine($" Total Execution Time for {year}: {totalTime}ms", Color.Yellow);
		LineBreak(Color.Yellow);
	}

	private async Task SolveAll()
	{
		LineBreak(Color.Green);
		WriteLine(" All Days for All Years Selected", Color.Green);
		LineBreak(Color.Green);

		var allSolutions = await _solverService.SolveAll();

		foreach (var solutionsInYear in allSolutions)
		{
			foreach (var solution in solutionsInYear)
			{
				try
				{
					PrintSolution(solution);
				}
				catch (Exception ex)
				{
					WriteLine($"{ex.Message}", Color.Red);
				}
			}
		}
		var totalTime = allSolutions
			.Sum(solutionYear =>
				solutionYear
					.Sum(solution => solution.PartA.ElapsedTime + solution.PartB.ElapsedTime));

		LineBreak(Color.Yellow);
		WriteLine($" Total Execution Time: {totalTime}ms", Color.Yellow);
		LineBreak(Color.Yellow);
	}

	private static void PrintSolution(DaySolution solution)
	{
		LineBreak(Color.MediumPurple);
		WriteLine($" {solution.Year} - Day {solution.Day}", Color.HotPink);
		LineBreak(Color.MediumPurple);

		WriteFormatted("Part 1:\t{0}\t", Color.LightBlue, Color.Gray, solution.PartA.Solution);
		WriteLineFormatted("({0})", Color.LightGreen, Color.Gray, solution.PartA.ElapsedTime + "ms");

		WriteFormatted("Part 2:\t{0}\t", Color.LightBlue, Color.Gray, solution.PartB.Solution);
		WriteLineFormatted("({0})", Color.LightGreen, Color.Gray, solution.PartB.ElapsedTime + "ms");
	}

	private static void LineBreak(Color colour, int length = 72)
	{
		WriteLine(new string('=', length), colour);
	}

	private string _welcomeText => @"

 █████╗ ██████╗ ██╗   ██╗███████╗███╗   ██╗████████╗     ██████╗ ███████╗     ██████╗ ██████╗ ██████╗ ███████╗
██╔══██╗██╔══██╗██║   ██║██╔════╝████╗  ██║╚══██╔══╝    ██╔═══██╗██╔════╝    ██╔════╝██╔═══██╗██╔══██╗██╔════╝
███████║██║  ██║██║   ██║█████╗  ██╔██╗ ██║   ██║       ██║   ██║█████╗      ██║     ██║   ██║██║  ██║█████╗  
██╔══██║██║  ██║╚██╗ ██╔╝██╔══╝  ██║╚██╗██║   ██║       ██║   ██║██╔══╝      ██║     ██║   ██║██║  ██║██╔══╝  
██║  ██║██████╔╝ ╚████╔╝ ███████╗██║ ╚████║   ██║       ╚██████╔╝██║         ╚██████╗╚██████╔╝██████╔╝███████╗
╚═╝  ╚═╝╚═════╝   ╚═══╝  ╚══════╝╚═╝  ╚═══╝   ╚═╝        ╚═════╝ ╚═╝          ╚═════╝ ╚═════╝ ╚═════╝ ╚══════╝
                                                                                                              
";
}
