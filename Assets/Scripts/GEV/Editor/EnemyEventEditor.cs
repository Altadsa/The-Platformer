using UnityEditor;
using UnityEngine;

namespace GEV
{
    [CustomEditor(typeof(EnemyEvent))]
    public class EnemyEventEditor : Editor
    {
        Enemy enemy;

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            EnemyEvent _event = (EnemyEvent)target;

            enemy = EditorGUILayout.ObjectField(enemy, typeof(Enemy), true) as Enemy;
            if (GUILayout.Button("Raise"))
            {
                _event.Raise(enemy);
            }
        }
    }
}
