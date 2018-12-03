using System.Collections.Generic;
using UnityEngine;

namespace GEV
{
    public class EventSystem : EventSystem<EventListener> { }

    public abstract class EventSystem<T> : MonoBehaviour
        where T : IEventListener
    {
        [HideInInspector]
        public List<T> listeners = new List<T>();

        private void OnEnable()
        {
            foreach (var listener in listeners)
            {
                listener.Register();
            }
        }

        private void OnDisable()
        {
            foreach (var listener in listeners)
            {
                listener.Unregister();
            }
        }


    }
}
