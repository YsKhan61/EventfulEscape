using System;

public class EventController
{
    public event Action BaseEvent;

    public void AddListener(Action action) => BaseEvent += action;

    public void RemoveListener(Action action) => BaseEvent -= action;

    public void Invoke() => BaseEvent?.Invoke();
}