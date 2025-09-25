using DG.Tweening;
using UnityEngine;

namespace Characters.Npc
{
    sealed class RockLaunch : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private Vector3 _initialPosition;
        private Vector3 _direction;


        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();

            transform.localScale = Vector3.zero;
            _initialPosition = transform.localPosition;
        }


        private void Update()
        {
            if (transform.localScale == Vector3.zero) return;

            transform.Rotate(Vector3.one * 50f * Time.deltaTime, Space.Self);
        }


        public void Cast()
        {
            transform.localPosition = _initialPosition;
            _rigidbody.linearVelocity = Vector3.zero;

            transform.DOKill();
            transform.DOScale(70f, 2.15f)
                .SetEase(Ease.Linear);
        }


        public void Launch(Vector3 direction, float force)
        {
            _direction = direction.normalized;

            _rigidbody.AddForce(_direction * force, ForceMode.VelocityChange);

            transform.DOScale(0f, 1.5f)
                .SetEase(Ease.InCirc);
        }


        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.TryGetComponent(out IPlayerController playerController))
            {
                playerController.AddForce(_direction, 30f);
            }
        }
    }
}
