using UnityEngine.Events;

namespace GEV
{
    public interface IEventListener
    {
        void Register();

        void Unregister();
    }

    [System.Serializable]
    public class EventListener : IEventListener
    {

        public ScriptableEvent _Event;

        public UnityEvent response;

        public void Register()
        {
            _Event.RegisterListener(this);
        }

        public void Unregister()
        {
            _Event.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            response.Invoke();
        }
    }

    [System.Serializable]
    public class UnityGameEvent : UnityEvent { }
}
