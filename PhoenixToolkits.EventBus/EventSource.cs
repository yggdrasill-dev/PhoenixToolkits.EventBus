using System.Threading.Tasks.Dataflow;

namespace Valhalla.Messages;

internal class EventSource<TEventData> : IEventSource<TEventData>
{
	private readonly BroadcastBlock<TEventData> m_Broadcast = new(null);

	public IObservable<TEventData> Observable => m_Broadcast.AsObservable();

	public Task<bool> PublishAsync(TEventData eventData, CancellationToken cancellationToken = default)
		=> m_Broadcast.SendAsync(eventData, cancellationToken);
}
