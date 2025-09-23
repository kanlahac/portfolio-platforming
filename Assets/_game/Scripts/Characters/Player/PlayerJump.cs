using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using Tools;

namespace Characters.Player
{
    [RequireComponent(typeof(Rigidbody))]
    sealed class PlayerJump : MonoBehaviour
    {
        [SerializeField] private Transform _model;
        [SerializeField] private CharacterData _characterData;
        [SerializeField] private InputActionReference _jumpAction;
        [SerializeField] private ConstraintsProfile _jumpingConstraints;
        private Rigidbody _rigidbody;
        private Animator _animator;


        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animator = _model.GetComponent<Animator>();
        }


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
            if (_characterData.IsGrounded)
            {
                _rigidbody.constraints = _jumpingConstraints.profile;

                _model.DOShakeScale(0.2f, 0.25f, 5);

                _rigidbody.AddForce(Vector3.up * _characterData.RuntimeStats.JumpForce, ForceMode.VelocityChange);

                GamepadTools.Vibrate(0.75f, 0.75f, 0.1f);
            }
        }

    }
}