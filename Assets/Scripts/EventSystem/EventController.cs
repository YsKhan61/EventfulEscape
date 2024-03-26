using System;

public class EventController
{
    public event Action BaseEvent;

    public void AddListener(Action action) => BaseEvent += action;

    public void RemoveListener(Action action) => BaseEvent -= action;

    public void Invoke() => BaseEvent?.Invoke();
}

public class EventController<T>
{
    public event Action<T> BaseEvent;

    public void AddListener(Action<T> action) => BaseEvent += action;

    public void RemoveListener(Action<T> action) => BaseEvent -= action;

    public void Invoke(T value) => BaseEvent?.Invoke(value);
}