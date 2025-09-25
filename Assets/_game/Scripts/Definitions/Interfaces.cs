using UnityEngine;

public interface IInteractable
{
    public void Interact();
}


public interface IPlayerController
{
    public void AddForce(Vector3 direction, float force);
}