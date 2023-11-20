namespace Valhalla.Messages;

public interface IEventSource<TEventData>
{
	IObservable<TEventData> Observable { get; }

	Task<bool> PublishAsync(TEventData eventData, CancellationToken cancellationToken = default);
}
