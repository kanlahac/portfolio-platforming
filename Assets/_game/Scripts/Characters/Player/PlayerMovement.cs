using UnityEngine;
using UnityEngine.InputSystem;

namespace Characters.Player 
{
    sealed class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private CharacterData _characterData;
        [SerializeField] private Transform _modelTransform;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Animator _animator;
        [SerializeField] private InputActionReference _moveAction;
        [SerializeField] private ConstraintsProfile _movingConstraints;


        private void OnEnable() { _moveAction.action.Enable(); }
        private void OnDisable() { _moveAction.action.Disable(); }


        private void FixedUpdate()
        {
            Vector2 input = _moveAction.action.ReadValue<Vector2>();
            Vector3 horizontalMove = new Vector3(input.x, 0, input.y);

            horizontalMove = Vector3.ClampMagnitude(horizontalMove, 1f);

            Vector3 move = new Vector3(
                horizontalMove.x * _characterData.RuntimeStats.MovementSpeed,
                _rigidbody.linearVelocity.y,
                horizontalMove.z * _characterData.RuntimeStats.MovementSpeed
            );

            if (horizontalMove != Vector3.zero)
            {
                _rigidbody.constraints = _movingConstraints.profile;

                Quaternion targetRotation = Quaternion.LookRotation(horizontalMove);

                _modelTransform.rotation = Quaternion.Slerp(
                    _modelTransform.rotation,
                    targetRotation,
                    15f * Time.deltaTime
                );
            }

            _rigidbody.linearVelocity = move;

            _animator.SetFloat("Move", horizontalMove.magnitude);
            _characterData.Info.IsMoving = horizontalMove.magnitude > 0f;
        }
    }
}
