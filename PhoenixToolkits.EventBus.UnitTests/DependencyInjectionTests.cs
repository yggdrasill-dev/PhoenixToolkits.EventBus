using Microsoft.Extensions.DependencyInjection;
using Valhalla.Messages;

namespace PhoenixToolkits.Messages;

public class DependencyInjectionTests
{
	[Fact]
	public void 在DI中使用EventBus()
	{
		// Arrange
		var sp = new ServiceCollection()
			.AddEventBus(configuration => configuration
				.RegisterEventSource<Guid>("test"))
			.BuildServiceProvider();

		var sut = sp.GetRequiredService<IEventBus>();

		// Act
		var actual = sut.GetEventSource<Guid>("test");

		// Assert
		Assert.NotNull(actual);
	}
}
