using System;
using UnityEngine;
using UnityEngine.Events;

public abstract class GameEventBase<T1, T2> : GameEventBase
{
    [Serializable] protected class MyEvent : UnityEvent<T1, T2> { }
    protected new MyEvent Event = new MyEvent();

    public void Invoke(T1 value1, T2 value2)
    {
        Event.Invoke(value1, value2);
        Invoke();
    }

    public void AddListener(UnityAction<T1, T2> action) => Event.AddListener(action);

    public void RemoveListener(UnityAction<T1, T2> action) => Event.RemoveListener(action);

    public new void RemoveAll()
    {
        Event.RemoveAllListeners();
        base.RemoveAll();
    }
}

public abstract class GameEventBase<T> : GameEventBase
{
    [Serializable] protected class MyEvent : UnityEvent<T> { }
    protected new MyEvent Event = new MyEvent();

    public void Invoke(T value)
    {
        Event.Invoke(value);
        Invoke();
    }

    public void AddListener(UnityAction<T> action) => Event.AddListener(action);

    public void RemoveListener(UnityAction<T> action) => Event.RemoveListener(action);

    public new void RemoveAll()
    {
        Event.RemoveAllListeners();
        base.RemoveAll();
    }
}

public abstract class GameEventBase : ScriptableObject
{
    protected UnityEvent Event;

    public void Invoke() => Event.Invoke();

    public void AddListener(UnityAction action) => Event.AddListener(action);

    public void RemoveListener(UnityAction action) => Event.RemoveListener(action);

    public void RemoveAll() => Event.RemoveAllListeners();
}