using UnityEngine;

namespace Characters.Player
{
    public class ResetPosition : MonoBehaviour
    {
        [SerializeField] CharacterData _characterData;
        private Vector3 _resetPosition;


        private void OnCollisionEnter(Collision collision)
        {
            Transform platform = collision.transform;

            if (platform.CompareTag("Platform"))
            {
                _resetPosition = new Vector3(
                    platform.position.x,
                    platform.position.y + 1,
                    platform.position.z
                );
            }
        }


        private void Update()
        {
            if (transform.position.y < _characterData.Info.DeathHeight)
            {
                transform.position = _resetPosition;
            }
        }
    }
}
