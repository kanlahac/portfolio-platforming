using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStats", menuName = "Scriptable Objects/Data/CharacterStats")]
public class CharacterStatsData : ScriptableObject
{
    public CharacterInfo Info;
    public CharacterStats Stats;
}
