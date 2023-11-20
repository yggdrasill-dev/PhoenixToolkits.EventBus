using System.Reactive.Linq;
using Valhalla.Messages;

namespace PhoenixToolkits.Messages;

public class EventSourceTests
{
	[Fact]
	public async Task 送入的訊息可以透過Observable取得()
	{
		// Arrange
		var sut = new EventSource<Guid>();

		var message = Guid.NewGuid();

		// Act
		await sut.PublishAsync(message);
		var actual = await sut.Observable.FirstAsync();

		// Assert
		Assert.Equal(message, actual);
	}
}
