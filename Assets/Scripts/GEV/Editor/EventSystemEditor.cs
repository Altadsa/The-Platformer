using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using System.Collections.Generic;


namespace GEV
{
    [CustomEditor(typeof(EventSystem))]
    public class EventSystemEditor : Editor
    {

        List<bool> foldouts = new List<bool>();

        EventSystem eventSystem;
        SerializedProperty listeners;

        ScriptableEvent assignedEvent;

        private void Awake()
        {
            eventSystem = (EventSystem)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            DrawEventAssignment();
            DrawListeners();
        }

        void DrawEventAssignment()
        {
            GUILayout.BeginVertical();
            GUILayout.Label("Add Event");
            assignedEvent = (ScriptableEvent)EditorGUILayout.ObjectField(
                assignedEvent, typeof(ScriptableEvent), false);
            if (GUILayout.Button("Add"))
            {
                if (assignedEvent)
                {
                    CreateListener(assignedEvent);
                    assignedEvent = null;
                }
            }
            GUILayout.EndVertical();
        }

        void DrawListeners()
        {
            serializedObject.Update();
            listeners = serializedObject.FindProperty("listeners");
            UpdateFoldouts(eventSystem.listeners);

            if (listeners.arraySize == 0)
            {
                GUILayout.Label("Add Listeners to System");
            }
            else
            {
                SerializedProperty sListener, sResponse, sEvent;
                string eventName;
                for (int i = 0; i < listeners.arraySize; i++)
                {
                    sListener = listeners.GetArrayElementAtIndex(i);
                    sResponse = sListener.FindPropertyRelative("response");
                    sEvent = sListener.FindPropertyRelative("_Event");
                    eventName = sEvent.objectReferenceValue.name;

                    GUILayout.BeginVertical();
                    GUILayout.BeginHorizontal();

                    foldouts[i] = EditorGUILayout.Foldout(foldouts[i], eventName, true);

                    if (i != 0 && GUILayout.Button("Move Up", GUILayout.Width(100)))
                    {
                        listeners.MoveArrayElement(i, i - 1);
                    }
                    if (i != listeners.arraySize - 1 && GUILayout.Button("Move Down", GUILayout.Width(100)))
                    {
                        listeners.MoveArrayElement(i, i + 1);
                    }
                    if (GUILayout.Button("Delete", GUILayout.Width(100)))
                    {
                        listeners.DeleteArrayElementAtIndex(i);
                        --i;
                    }

                    GUILayout.EndHorizontal();
                    GUILayout.EndVertical();

                    if (foldouts[i])
                    {
                        EditorGUILayout.PropertyField(sResponse);
                    }

                }
            }
            serializedObject.ApplyModifiedProperties();
        }

        void CreateListener(ScriptableEvent _event)
        {
            EventListener listener = new EventListener
            {
                _Event = _event
            };
            eventSystem.listeners.Add(listener);
        }

        void UpdateFoldouts(List<EventListener> listeners)
        {
            while (foldouts.Count < listeners.Count)
            {
                foldouts.Add(false);
            }
                
            while (foldouts.Count > listeners.Count)
            {
                foldouts.RemoveAt(foldouts.Count - 1);
            }
        }
    }
}
#endif
