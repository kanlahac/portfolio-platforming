using DG.Tweening;
using UnityEngine;

namespace Characters.Player
{
    sealed class GroundChecker : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _model;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private CharacterData _charracterData;
        [SerializeField] private Vector3 _groundCheckOffset;
        [SerializeField] private float _groundCheckerRadius;

        private bool _isGrounded;
        private bool _lastState;


        private void Update()
        {
            Vector3 groundCheckerPosition = transform.position + _groundCheckOffset;

            _isGrounded = Physics.CheckSphere(
                groundCheckerPosition,
                _groundCheckerRadius,
                _groundLayer
            );

            if (_lastState == false && _isGrounded == true)
            {
                _model.DOScaleY(0.9f, 0.25f)
                    .SetEase(Ease.InBounce)
                    .SetLoops(2, LoopType.Yoyo);
            }

            _charracterData.Info.IsGrounded = _isGrounded;
            _animator.SetBool("Grounded", _isGrounded);

            _lastState = _isGrounded;
        }


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position + _groundCheckOffset, _groundCheckerRadius);
        }
    }
}