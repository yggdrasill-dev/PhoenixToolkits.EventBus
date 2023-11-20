namespace Valhalla.Messages;

public interface IEventBus
{
	IEventSource<TEventData>? GetEventSource<TEventData>(string id);
}
