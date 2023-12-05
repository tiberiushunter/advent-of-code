using Moq;
using Moq.Protected;
using System.Net;

namespace AdventOfCode.Client.IntegrationTests;

public class AdventOfCodeClientTests
{
	private Mock<IHttpClientFactory> _mockHttpClientFactory;

	[SetUp]
	public void Setup()
	{
		_mockHttpClientFactory = new Mock<IHttpClientFactory>();
	}

	[Test]
	public async Task GivenPuzzleForDayAvailable_WhenGetPuzzleForDay_ThenPuzzleInputReturned()
	{
		// Arrange
		string expectedResponse = "1,2,3,4,5";

		var httpClient = new HttpClient(GetRequestHandler(expectedResponse))
		{
			BaseAddress = new Uri("http://localhost")
		};

		_mockHttpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(httpClient);

		var adventOfCodeClient = new AdventOfCodeClient(_mockHttpClientFactory.Object);

		// Act
		var response = await adventOfCodeClient.GetPuzzleInputForDay(2020, 15);

		// Assert
		Assert.That(response, Is.EqualTo(expectedResponse));
	}

	private HttpMessageHandler GetRequestHandler(string response)
	{
		var mockMessageHandler = new Mock<HttpMessageHandler>();

		mockMessageHandler.Protected()
			.Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
			.ReturnsAsync(new HttpResponseMessage
			{
				StatusCode = HttpStatusCode.OK,
				Content = new StringContent(response)
			});

		return mockMessageHandler.Object;
	}
}