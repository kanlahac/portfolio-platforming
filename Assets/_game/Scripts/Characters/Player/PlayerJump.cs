using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using Tools;

namespace Characters.Player
{
    [RequireComponent(typeof(CharacterController), typeof(CharacterController))]
    sealed class PlayerJump : MonoBehaviour
    {
        [SerializeField] private CharacterData _characterData;
        [SerializeField] private InputActionReference _jumpAction;
        private CharacterController _characterController;
        private IPlayerController _playerController;


        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _playerController = GetComponent<IPlayerController>();
        }


        private void OnEnable()
        {
            _jumpAction.action.performed += Jump;
        }


        private void OnDisable()
        {
            _jumpAction.action.performed -= Jump;
        }


        private void Jump(InputAction.CallbackContext context)
        {
            if (_characterController.isGrounded == false) return;

            _playerController.AddForce(Vector3.up, _characterData.RuntimeStats.JumpForce);
        }
    }
}