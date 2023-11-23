﻿namespace Valhalla.Messages;

public interface IEventBus
{
	IEventPublisher<TEventData>? GetEventPublisher<TEventData>(string id);

	IObservable<TEventData>? GetEventObserable<TEventData>(string id);
}
