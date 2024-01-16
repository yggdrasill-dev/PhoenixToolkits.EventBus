using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using Valhalla.Messages;

namespace PhoenixToolkits.Messages;

public class EventSourceTests
{
    [Fact(Timeout = 1000)]
    public async Task 送入的訊息可以透過Observable取得()
    {
        // Arrange
        var sut = new EventSource<Guid>();

        var message = Guid.NewGuid();

        // Act
        var task = sut.Observable.FirstAsync().ToTask();
        _ = await sut.PublishAsync(message);
        var actual = await task;

        // Assert
        Assert.Equal(message, actual);
    }
}
