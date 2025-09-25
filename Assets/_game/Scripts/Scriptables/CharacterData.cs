using UnityEngine;

namespace Characters
{
    [CreateAssetMenu(fileName = "CharacterData", menuName = "Scriptable Objects/Data/CharacterData")]
    public class CharacterData : ScriptableObject
    {
        public Vector3 ResetPosition;
        public CharacterInitialStats InitialStats;
        public CharacterRuntimeStats RuntimeStats;
    }
}
