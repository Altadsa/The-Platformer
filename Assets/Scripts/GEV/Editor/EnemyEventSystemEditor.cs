using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using System.Collections.Generic;


namespace GEV
{
    [CustomEditor(typeof(EnemyEventSystem))]
    public class EnemyEventSystemEditor : Editor
    {

        List<bool> foldouts = new List<bool>();

        EnemyEventSystem eventSystem;
        SerializedProperty sListeners;

        EnemyEvent assignedEvent;

        private void Awake()
        {
            eventSystem = (EnemyEventSystem)target;
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
            assignedEvent = (EnemyEvent)EditorGUILayout.ObjectField(
                assignedEvent, typeof(EnemyEvent), false);
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
            sListeners = serializedObject.FindProperty("listeners");
            UpdateFoldouts(eventSystem.listeners);

            if (sListeners.arraySize == 0)
            {
                GUILayout.Label("Add Listeners to System");
            }
            else
            {
                SerializedProperty sListener, sResponse, sEvent;
                string eventName;
                for (int i = 0; i < sListeners.arraySize; i++)
                {
                    sListener = sListeners.GetArrayElementAtIndex(i);
                    sResponse = sListener.FindPropertyRelative("response");
                    sEvent = sListener.FindPropertyRelative("_Event");
                    eventName = sEvent.objectReferenceValue.name;

                    GUILayout.BeginVertical();
                    GUILayout.BeginHorizontal();

                    foldouts[i] = EditorGUILayout.Foldout(foldouts[i], eventName, true);

                    if (i != 0 && GUILayout.Button("Move Up", GUILayout.Width(100)))
                    {
                        sListeners.MoveArrayElement(i, i - 1);
                    }
                    if (i != sListeners.arraySize - 1 && GUILayout.Button("Move Down", GUILayout.Width(100)))
                    {
                        sListeners.MoveArrayElement(i, i + 1);
                    }
                    if (GUILayout.Button("Delete", GUILayout.Width(100)))
                    {
                        sListeners.DeleteArrayElementAtIndex(i);
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

        void CreateListener(EnemyEvent _event)
        {
            EnemyEventListener listener = new EnemyEventListener
            {
                _Event = _event
            };
            eventSystem.listeners.Add(listener);
        }

        void UpdateFoldouts(List<EnemyEventListener> listeners)
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
