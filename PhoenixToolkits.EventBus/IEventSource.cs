namespace Valhalla.Messages;

internal interface IEventSource<TEventData> : IEventPublisher<TEventData>
{
	IObservable<TEventData> Observable { get; }
}
