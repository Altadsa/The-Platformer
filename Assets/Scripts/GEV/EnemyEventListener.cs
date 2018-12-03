using UnityEngine.Events;

namespace GEV
{
    [System.Serializable]
    public class EnemyEventListener : IEventListener
    {

        public EnemyEvent _Event;

        public UnityEventEnemy response;

        public void Register()
        {
            _Event.RegisterListener(this);
        }

        public void Unregister()
        {
            _Event.UnregisterListener(this);
        }

        public void OnEventRaised(Enemy enemy)
        {
            response.Invoke(enemy);
        }
    }

    [System.Serializable]
    public class UnityEventEnemy : UnityEvent<Enemy> { }
}
