using DG.Tweening;
using UnityEngine;
using Tools;

namespace Characters.Player
{
    sealed class GroundChecker : MonoBehaviour
    {
        [SerializeField] private Transform _model;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private CharacterData _charracterData;
        [SerializeField] private Vector3 _groundCheckOffset;
        [SerializeField] private float _groundCheckerRadius;
        private Animator _animator;
        private bool _isGrounded;
        private bool _lastState;


         private void Awake()
        {
            _animator = _model.GetComponent<Animator>();
        }


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

                GamepadTools.Vibrate(0.75f, 0.75f, 0.15f);
            }

            _charracterData.IsGrounded = _isGrounded;
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