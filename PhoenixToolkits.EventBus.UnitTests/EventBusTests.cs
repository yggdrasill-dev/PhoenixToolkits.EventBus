using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valhalla.Messages;
using Xunit;
using Xunit.Sdk;

namespace PhoenixToolkits.Messages;

public class EventBusTests
{
	[Fact]
	public void 註冊EventSource後可以取得實體()
	{
		// Arrange
		var sut = new EventBus();

		sut.RegisterEventSource<Guid>("test");

		// Act
		var actual = sut.GetEventSource<Guid>("test");

		// Assert
		Assert.NotNull(actual);
	}

	[Fact]
	public void 如果沒有註冊EventSource會取得Null()
	{
		// Arrange
		var sut = new EventBus();

		// Act
		var actual = sut.GetEventSource<Guid>("test");

		// Assert
		Assert.Null(actual);
	}

	[Fact]
	public void 如果Id已經有註冊_取得型別指定不對也會取得Null()
	{
		// Arrange
		var sut = new EventBus();

		sut.RegisterEventSource<Guid>("test");

		// Act
		var actual = sut.GetEventSource<string>("test");

		// Assert
		Assert.Null(actual);
	}
}
