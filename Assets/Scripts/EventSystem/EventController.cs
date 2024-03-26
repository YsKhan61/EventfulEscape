using System;

public class EventController
{
    public event Action BaseEvent;

    public void Subscribe(Action action) => BaseEvent += action;

    public void Unsubscribe(Action action) => BaseEvent -= action;

    public void Invoke() => BaseEvent?.Invoke();
}