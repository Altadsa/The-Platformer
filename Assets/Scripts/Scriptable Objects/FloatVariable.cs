using UnityEngine;

namespace Shamrock
{
    [CreateAssetMenu (menuName = "Shamrock/Float Variable")]
    public class FloatVariable : ScriptableObject
    {
        [SerializeField]
        float currentValue;

        public float Value { get { return currentValue; } set { currentValue = value; } }
    } 
}
