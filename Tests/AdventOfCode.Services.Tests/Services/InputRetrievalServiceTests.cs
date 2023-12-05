using AdventOfCode.Client;
using AdventOfCode.Domain.Interfaces;
using Moq;
using System.IO.Abstractions.TestingHelpers;
using System.Text;

namespace AdventOfCode.Services.Tests.Services;

public class InputRetrievalServiceTests
{
	private IInputRetrievalService _inputRetrievalService;
	private Mock<IAdventOfCodeClient> _mockAdventOfCodeClient;
	private MockFileSystem _fileSystem;

	[SetUp]
	public void Setup()
	{
		_mockAdventOfCodeClient = new Mock<IAdventOfCodeClient>();

		_fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>());

		_inputRetrievalService = new InputRetrievalService(
			_mockAdventOfCodeClient.Object,
			_fileSystem
		);
	}

	[Test]
	public async Task GivenInputToRetreive_WhenRetrieve_ThenInputForDayIsReturned()
	{
		// Arrange
		var expectedInput = Encoding.UTF8.GetBytes("ABC1234");
		var day = 1;
		var year = 2020;

		_mockAdventOfCodeClient
			.Setup(aocc => aocc.GetPuzzleInputForDay(year, day))
			.ReturnsAsync(expectedInput);

		// Act
		var input = await _inputRetrievalService.RetrievePuzzleInputForDay(year, day);

		// Assert
		input.Should().NotBeNull();
		input.Should().Be("ABC1234");
	}

	[Test]
	public async Task GivenInputNotSavedLocally_WhenRetrieveInputForDay_ThenInputSavedLocally()
	{
		// Arrange
		var expectedInput = Encoding.UTF8.GetBytes("ABC1234");
		var day = 1;
		var year = 2020;

		_mockAdventOfCodeClient
			.Setup(aocc => aocc.GetPuzzleInputForDay(year, day))
			.ReturnsAsync(expectedInput);

		var expectedFilePath = Path.Combine(
			Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
			@"AdventOfCode.Input",
			$"{year} - Day {day}.txt");

		// Act
		await _inputRetrievalService.RetrievePuzzleInputForDay(year, day);

		// Assert
		_fileSystem.GetFile(expectedFilePath).Should().NotBeNull();
		_fileSystem.GetFile(expectedFilePath).TextContents.Should().Be("ABC1234");
	}

	[Test]
	public async Task GivenInputLocallySaved_WhenRetrieveInputForDay_ThenLocallySavedInputReturned()
	{
		// Arrange
		var expectedInput = "ABC1234";
		var day = 1;
		var year = 2020;

		var expectedFilePath = Path.Combine(
			Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
			@"AdventOfCode.Input",
			$"{year} - Day {day}.txt");

		_fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>()
		{
			{ expectedFilePath, new MockFileData(expectedInput) },
		});

		_inputRetrievalService = new InputRetrievalService(
			_mockAdventOfCodeClient.Object,
			_fileSystem
		);

		// Act
		var result = await _inputRetrievalService.RetrievePuzzleInputForDay(year, day);

		// Assert
		result.Should().Be(expectedInput);
	}
}