namespace Valhalla.Messages.Configuration;

public class EventBusConfiguration
{
#if NET8_0_OR_GREATER
	private readonly List<Action<EventBus>> m_RegisterActions = [];
#else
	private readonly List<Action<EventBus>> m_RegisterActions = new();
#endif

	public EventBusConfiguration RegisterEventSource<TEventData>(string id)
	{
		m_RegisterActions.Add(eventBus => eventBus.RegisterEventSource<TEventData>(id));

		return this;
	}

	internal void ConfigEventBus(EventBus eventBus)
	{
		foreach (var action in m_RegisterActions)
			action(eventBus);
	}
}
