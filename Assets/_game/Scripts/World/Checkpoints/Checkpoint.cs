using Characters;
using UnityEngine;

namespace World.Checkpoints
{
    sealed class Checkpoint : MonoBehaviour
    {
        [SerializeField] private CharacterData _characterData;
        [SerializeField] private Renderer _indicator;
        [SerializeField] private Material _activeMaterial;
        [SerializeField] private Material _inactiveMaterial;


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && _characterData.ResetPosition != transform.position)
            {
                _characterData.ResetPosition = transform.position;
                _indicator.material = _activeMaterial;
            }
        }


        private void Update()
        {
            if (_characterData.ResetPosition != transform.position && _indicator.material != _inactiveMaterial)
            {
                _indicator.material = _inactiveMaterial;
            }
        }
    }
}