namespace Valhalla.Messages;

internal interface IEventSourceContainer
{
	string Id { get; }

	IEventSource<TData>? GetEventSource<TData>();
}