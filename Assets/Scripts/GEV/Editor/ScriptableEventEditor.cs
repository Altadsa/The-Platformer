using UnityEditor;
using UnityEngine;

namespace GEV
{
    [CustomEditor(typeof(ScriptableEvent))]
    public class ScriptableEventEditor : Editor
    {

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            ScriptableEvent _event = (ScriptableEvent)target;

            if (GUILayout.Button("Raise"))
            {
                _event.Raise();
            }
        }
    } 
}
