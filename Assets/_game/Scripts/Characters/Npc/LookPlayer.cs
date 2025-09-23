using UnityEngine;

namespace Characters.Npc
{
    sealed class LookPlayer : MonoBehaviour
    {
        [SerializeField] private Transform _objectToRotate;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private bool _blockYAxis;
        private Quaternion _initialRotation;
        private Transform _playerTransform;


        private void Awake()
        {
            _initialRotation = _objectToRotate.rotation;
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag("Player"))
            {
                _playerTransform = other.transform;
            }
        }


        private void OnTriggerExit(Collider other)
        {
            if (other.transform.CompareTag("Player"))
            {
                _playerTransform = null;
            }
        }


        private void Update()
        {
            if (_playerTransform != null)
            {
                Vector3 lookPosition = _playerTransform.position - _objectToRotate.position;
                if(_blockYAxis == true) lookPosition.y = 0;

                Quaternion lookDirection = Quaternion.LookRotation(lookPosition);

                HeadRotation(lookDirection);
            }
            else
            {
                HeadRotation(_initialRotation);
            }
        }


        private void HeadRotation(Quaternion direction)
        {
            _objectToRotate.rotation = Quaternion.Slerp(
                _objectToRotate.rotation,
                direction,
                _rotationSpeed * Time.deltaTime
            );
        }
    }
}
