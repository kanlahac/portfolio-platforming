using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Scriptable Objects/Data/LevelData")]
public class LevelData : ScriptableObject
{
    public int Collectables;


    public void AddCollectable()
    {
        Collectables++;
    }


    public void ResetAll()
    {
        Collectables = 0;
    }
}
