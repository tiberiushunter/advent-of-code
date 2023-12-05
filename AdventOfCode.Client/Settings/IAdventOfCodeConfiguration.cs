namespace AdventOfCode.Client.Settings;
public interface IAdventOfCodeConfiguration
{
	string Domain { get; }
	string SessionToken { get; }
}
