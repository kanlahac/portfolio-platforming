using UnityEngine;

namespace Characters.Player
{
    sealed class ResetPosition : MonoBehaviour
    {
        [SerializeField] CharacterData _characterData;
        [SerializeField] float _deathHeight;
        private Vector3 _resetPosition;


        private void OnCollisionEnter(Collision collision)
        {
            Transform platform = collision.transform;

            if (platform.CompareTag("Platform"))
            {
                _resetPosition = new Vector3(
                    platform.position.x,
                    platform.position.y + (platform.localScale.y / 2f) + 1,
                    platform.position.z
                );
            }
        }


        private void Update()
        {
            if (transform.position.y < _deathHeight)
            {
                transform.position = _resetPosition;
            }
        }
    }
}
