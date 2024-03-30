using System;

namespace ServiceLocator.Events
{
    public class EventController<T>
    {
        public event Action<T> baseEvent;
        public void AddListener(Action<T> listener) => baseEvent += listener;
        public void RemoveListener(Action<T> listener) => baseEvent -= listener;
        public void InvokeEvent(T type) => baseEvent?.Invoke(type);
    }

    public class EventController
    {
        public event Action baseEvent;
        public void AddListener(Action listener) => baseEvent += listener;
        public void RemoveListener(Action listener) => baseEvent -= listener;
        public void InvokeEvent() => baseEvent?.Invoke();
    }
}