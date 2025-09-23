using UnityEngine;

namespace Interactables
{
    sealed class InteractableDialog : MonoBehaviour, IInteractable
    {
        public void Interact()
        {
            Debug.Log("Interacting");
        }
    }
}
