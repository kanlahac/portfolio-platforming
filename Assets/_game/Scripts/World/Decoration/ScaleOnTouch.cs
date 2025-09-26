using DG.Tweening;
using UnityEngine;

namespace World.Decorations
{
    sealed class ScaleOnTouch : MonoBehaviour
    {
        private bool _isActive;


        private void OnTriggerEnter(Collider other)
        {
            if (_isActive == true) return;

            transform.DOMoveY(transform.position.y - 0.3f, 0.15f)
                .SetLoops(2, LoopType.Yoyo);
                
            _isActive = true;
        }


        private void OnTriggerExit(Collider other)
        {
            if (_isActive == false) return;

            _isActive = false;
        }
    }

}