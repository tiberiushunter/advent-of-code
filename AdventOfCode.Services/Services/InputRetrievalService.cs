using AdventOfCode.Client;
using AdventOfCode.Domain.Interfaces;
using System.IO.Abstractions;
using System.Text;

namespace AdventOfCode.Services;

public class InputRetrievalService : IInputRetrievalService
{
	private readonly IAdventOfCodeClient _adventOfCodeClient;
	private readonly IFileSystem _fileSystem;
	private readonly bool _underTest;

	public InputRetrievalService(IAdventOfCodeClient adventOfCodeClient, IFileSystem fileSystem)
	{
		_adventOfCodeClient = adventOfCodeClient;
		_fileSystem = fileSystem;
	}

	public async Task<string> RetrievePuzzleInputForDay(int year, int day)
	{
		var solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

		string puzzleFolderPath = Path.Combine(solutionFolder, @"AdventOfCode.Input");

		if (!_fileSystem.Directory.Exists(puzzleFolderPath))
		{
			_fileSystem.Directory.CreateDirectory(puzzleFolderPath);
		}

		string puzzleFilePath = Path.Combine(puzzleFolderPath, $"{year} - Day {day}.txt");

		if (_fileSystem.File.Exists(puzzleFilePath))
		{
			var inputData = await _fileSystem.File.ReadAllTextAsync(puzzleFilePath);

			return inputData.Trim();
		}

		var puzzleInput = await _adventOfCodeClient.GetPuzzleInputForDay(year, day);

		await SaveInputLocally(puzzleFilePath, puzzleInput);

		return Encoding.UTF8.GetString(puzzleInput, 0, puzzleInput.Length).Trim();
	}

	private async Task SaveInputLocally(string puzzleFilePath, byte[] puzzleInput)
	{
		using Stream outputFile = _fileSystem.FileStream.New(puzzleFilePath, FileMode.Create);

		await outputFile.WriteAsync(puzzleInput, 0, puzzleInput.Length);
	}
}
