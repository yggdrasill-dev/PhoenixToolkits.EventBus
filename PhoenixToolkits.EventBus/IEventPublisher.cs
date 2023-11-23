namespace Valhalla.Messages;

public interface IEventPublisher<TEventData>
{
	Task<bool> PublishAsync(TEventData eventData, CancellationToken cancellationToken = default);
}
