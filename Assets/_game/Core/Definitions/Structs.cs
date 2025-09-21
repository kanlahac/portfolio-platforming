using UnityEngine;


[System.Serializable]
public struct CharacterInfo
{
    public string Name;
    public CharacterType Type;
    public GameObject Prefab;
}


[System.Serializable]
public struct CharacterStats
{
    public float MovementSpeed;
    public float JumpForce;
}
