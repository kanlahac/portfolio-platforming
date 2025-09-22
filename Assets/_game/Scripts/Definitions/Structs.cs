using UnityEngine;


[System.Serializable]
public struct CharacterInfo
{
    public string Name;
    public float DeathHeight;
    public bool IsGrounded;
    public bool IsMoving;
}


[System.Serializable]
public struct CharacterInitialStats
{
    public float MovementSpeed;
    public float JumpForce;
}


[System.Serializable]
public struct CharacterRuntimeStats
{
    public float MovementSpeed;
    public float JumpForce;
}
