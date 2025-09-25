using UnityEngine;

namespace Characters.Player
{
    [RequireComponent(typeof (CharacterController))]
    sealed class ResetPosition : MonoBehaviour
    {
        [SerializeField] CharacterData _characterData;
        [SerializeField] float _deathHeight;
        private CharacterController _characterController;


        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }


        private void Update()
        {
            if (transform.position.y < _deathHeight)
            {
                _characterController.enabled = false;

                transform.position = _characterData.ResetPosition;

                _characterController.enabled = true;
            }
        }
    }
}
