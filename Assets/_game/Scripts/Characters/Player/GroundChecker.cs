using UnityEngine;

namespace Characters.Player
{
    public class GroundChecker : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private CharacterData _charracterData;
        [SerializeField] private Vector3 _groundCheckOffset;
        [SerializeField] private float _groundCheckerRadius;

        private bool _isGrounded;


        private void Update()
        {
            Vector3 groundCheckerPosition = transform.position + _groundCheckOffset;

            _isGrounded = Physics.CheckSphere(
                groundCheckerPosition,
                _groundCheckerRadius,
                _groundLayer
            );

            _charracterData.Info.IsGrounded = _isGrounded;
            _animator.SetBool("Grounded", _isGrounded);
        }


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position + _groundCheckOffset, _groundCheckerRadius);
        }
    }
}