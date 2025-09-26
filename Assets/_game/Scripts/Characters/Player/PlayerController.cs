using UnityEngine;
using UnityEngine.InputSystem;

namespace Characters.Player
{
    [RequireComponent(typeof(CharacterController))]
    sealed class PlayerController : MonoBehaviour, IPlayerController
    {
        [SerializeField] private InputActionReference _moveAction;
        [SerializeField] private CharacterData _characterData;
        [SerializeField] private Transform _model;
        [SerializeField] private Animator _animator;
        private Vector3 _externalForces;
        private CharacterController _characterController;
        private float _gravitySpeed;


        private void OnEnable()
        {
            _moveAction.action.Enable();
        }


        private void OnDisable()
        {
            _moveAction.action.Disable();
        }


        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }


        private void Update()
        {
            Vector2 moveInput = _moveAction.action.ReadValue<Vector2>();
            Vector3 move = new Vector3(
                moveInput.x,
                0f,
                moveInput.y
            );

            if (move != Vector3.zero)
            {
                Quaternion lookTarget = Quaternion.LookRotation(move);

                _model.rotation = Quaternion.Slerp(
                    _model.rotation,
                    lookTarget,
                    15f * Time.deltaTime
                );
            }

            _gravitySpeed += _characterData.RuntimeStats.GravityForce * Time.deltaTime;

            if (_characterController.isGrounded && _gravitySpeed < 0) _gravitySpeed = -7.0f;

            Vector3 gravityMove = new Vector3(0f, _gravitySpeed, 0f);
            Vector3 finalMove = (move * _characterData.RuntimeStats.MovementSpeed) + _externalForces + gravityMove;

            _characterController.Move(finalMove * Time.deltaTime);

            _externalForces = Vector3.Lerp(
                _externalForces,
                Vector3.zero,
                5f * Time.deltaTime
            );

            _animator.SetFloat("Move", Vector3.ClampMagnitude(move, 1f).magnitude);
            _animator.SetBool("Grounded", _characterController.isGrounded);

        }


        public void AddForce(Vector3 direction, float force)
        {
            _externalForces += direction.normalized * force;
        }
    }
}
