using Ui;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Characters.Player
{
    sealed class InteractChecker : MonoBehaviour
    {
        [SerializeField] private DiegeticUi _interactButton;
        [SerializeField] private InputActionReference _interactAction;
        private IInteractable _interactable;


        private void OnEnable()
        {
            _interactAction.action.performed += OnInteract;
        }


        private void OnDisable()
        {
            _interactAction.action.performed -= OnInteract;
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IInteractable interactable))
            {
                _interactButton.ShowUi();

                _interactable = interactable;
            }
        }


        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out IInteractable interactable))
            {
                if (_interactable != interactable) return;

                _interactButton.HideUi();

                _interactable = null;
            }
        }


        private void OnInteract(InputAction.CallbackContext context)
        {
            if (_interactable != null) _interactable.Interact();
        }
    }
}
