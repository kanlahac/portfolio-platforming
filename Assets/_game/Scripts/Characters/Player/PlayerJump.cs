using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Characters.Player
{
    sealed class PlayerJump : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _model;
        [SerializeField] private CharacterData _characterData;
        [SerializeField] private InputActionReference _jumpAction;
        [SerializeField] private ConstraintsProfile _jumpingConstraints;


        private void OnEnable()
        {
            _jumpAction.action.Enable();
            _jumpAction.action.performed += OnJump;
        }

        
        private void OnDisable()
        {
            _jumpAction.action.Disable();
            _jumpAction.action.performed -= OnJump;
        }


        private void OnJump(InputAction.CallbackContext context)
        {
            if (_characterData.Info.IsGrounded)
            {
                _rigidbody.constraints = _jumpingConstraints.profile;

                _model.DOShakeScale(0.2f, 0.25f, 5);

                _rigidbody.AddForce(Vector3.up * _characterData.RuntimeStats.JumpForce, ForceMode.VelocityChange);
            }
        }
             
    }
}