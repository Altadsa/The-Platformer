using System.Collections.Generic;
using UnityEngine;

namespace GEV
{
    [CreateAssetMenu(menuName = "GEV/Enemy Event")]
    public class EnemyEvent : ScriptableObject
    {
        List<EnemyEventListener> eventListeners = new List<EnemyEventListener>();

        public void RegisterListener(EnemyEventListener listener)
        {
            if (!eventListeners.Contains(listener))
            {
                eventListeners.Add(listener);
            }
        }

        public void UnregisterListener(EnemyEventListener listener)
        {
            if (eventListeners.Contains(listener))
            {
                eventListeners.Remove(listener);
            }
        }

        public void Raise(Enemy enemy)
        {
            foreach (EnemyEventListener listener in eventListeners)
            {
                listener.OnEventRaised(enemy);
            }
        }

    }
}
