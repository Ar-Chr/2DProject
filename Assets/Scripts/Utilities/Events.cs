using System;
using UnityEngine.Events;

public class Events
{
    public interface IGameEvent<T1, T2>
    {
        void Invoke(T1 value1, T2 value2);
        void AddListener(Action<T1, T2> action);
        void RemoveListener(Action<T1, T2> action);
        void RemoveAll();
    }

    public interface IGameEvent<T>
    {
        void Invoke(T value);
        void AddListener(Action<T> action);
        void RemoveListener(Action<T> action);
        void RemoveAll();
    }

    public interface IGameEvent
    {
        void Invoke();
        void AddListener(Action action);
        void RemoveListener(Action action);
        void RemoveAll();
    }
}
