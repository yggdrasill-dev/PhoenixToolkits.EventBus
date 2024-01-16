using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks.Dataflow;

namespace Valhalla.Messages;

internal class EventSource<TEventData> : IEventSource<TEventData>
{
	private readonly Subject<TEventData> m_Subject = new();

	public IObservable<TEventData> Observable => m_Subject.AsObservable();

	public Task<bool> PublishAsync(TEventData eventData, CancellationToken cancellationToken = default)
	{
		m_Subject.OnNext(eventData);

		return Task.FromResult(true);
	}
}
