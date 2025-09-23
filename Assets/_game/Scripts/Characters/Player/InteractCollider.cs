using Ui;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Characters.Player
{
    sealed class InteractCollider : MonoBehaviour
    {
        [SerializeField] private DiegeticUi _interactButton;
        [SerializeField] private InputActionReference _interactAction;
        private IInteractable _interactable;


        private void OnEnable()
        {
            _interactAction.action.Enable();
            _interactAction.action.performed += OnInteract;
        }


        private void OnDisable()
        {
            _interactAction.action.Disable();
            _interactAction.action.performed -= OnInteract;
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IInteractable interactable))
            {
                _interactable = interactable;
                _interactButton.ShowUi();
            }
        }


        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out IInteractable interactable))
            {
                if (interactable == _interactable)
                {
                    _interactable = null;
                    _interactButton.HideUi();
                }
            }
        }


        private void OnInteract(InputAction.CallbackContext context)
        {
            if (_interactable != null) _interactable.Interact();
        }
    }
}
