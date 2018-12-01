using UnityEngine;

namespace Shamrock
{
    [CreateAssetMenu(menuName = "Shamrock/String Constant")]
    public class StringConstant : ScriptableObject
    {

        [SerializeField]
        string value;

        public string Value { get { return value; } }

    } 
}
