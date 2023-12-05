namespace AdventOfCode.Client;

public class AdventOfCodeClient : IAdventOfCodeClient
{
	private readonly IHttpClientFactory _httpClientFactory;

	public AdventOfCodeClient(IHttpClientFactory httpClientFactory)
	{
		_httpClientFactory = httpClientFactory;
	}

	public async Task<byte[]> GetPuzzleInputForDay(int year, int day)
	{
		var httpClient = _httpClientFactory.CreateClient("AdventOfCode");

		var response = await httpClient.GetByteArrayAsync($"{year}/day/{day}/input");

		return response;
	}
}
