using UnityEngine;

[CreateAssetMenu(fileName = "SpellBookData", menuName = "Scriptable Objects/Data/SpellBookData")]
public class SpellBookData : ScriptableObject
{
    public SpellBookTexts Left;
    public SpellBookTexts Right;
}
