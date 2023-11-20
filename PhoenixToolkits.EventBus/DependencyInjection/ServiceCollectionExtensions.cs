using Valhalla.Messages;
using Valhalla.Messages.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddEventBus(
		this IServiceCollection services,
		Action<EventBusConfiguration> configure)
	{
		ArgumentNullException.ThrowIfNull(configure, nameof(configure));

		var configuration = new EventBusConfiguration();
		configure?.Invoke(configuration);

		return services
			.AddSingleton<IEventBus>(sp =>
			{
				var eventBus = ActivatorUtilities.CreateInstance<EventBus>(sp);

				configuration.ConfigEventBus(eventBus);

				return eventBus;
			});
	}
}
