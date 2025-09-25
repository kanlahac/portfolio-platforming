using UnityEngine;

namespace Characters
{
    [CreateAssetMenu(fileName = "CharacterData", menuName = "Scriptable Objects/Data/CharacterData")]
    public class CharacterData : ScriptableObject
    {
        public CharacterInitialStats InitialStats;
        public CharacterRuntimeStats RuntimeStats;
    }
}
