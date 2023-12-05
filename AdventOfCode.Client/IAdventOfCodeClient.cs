namespace AdventOfCode.Client;

public interface IAdventOfCodeClient
{
	Task<byte[]> GetPuzzleInputForDay(int year, int day);
}
