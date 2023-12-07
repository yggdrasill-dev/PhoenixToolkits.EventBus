using Microsoft.Extensions.DependencyInjection.Extensions;
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

		services.TryAddSingleton<IEventBus>(sp =>
		{
			var eventBus = ActivatorUtilities.CreateInstance<EventBus>(sp);

			foreach (var config in sp.GetServices<EventBusConfiguration>())
				config.ConfigEventBus(eventBus);

			return eventBus;
		});

		return services
			.AddSingleton(configuration);
	}
}
