namespace Valhalla.Messages;

internal class EventBus : IEventBus
{
	private readonly Dictionary<string, IEventSourceContainer> m_EventSources = [];

	public void RegisterEventSource<TEventData>(string id)
	{
		var source = new EventSourceContainer<TEventData>(id);

		m_EventSources.Add(id, source);
	}

	public IEventSource<TEventData>? GetEventSource<TEventData>(string id)
		=> m_EventSources.TryGetValue(id, out var source)
			? source.GetEventSource<TEventData>()
			: null;
}
