using DG.Tweening;
using Tools;
using UnityEngine;

namespace World.Decorations
{
    sealed class ShakeOnTouch : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            transform.DOShakeScale(0.25f, 40);

            GamepadTools.Vibrate(0.2f, 0.2f, 0.1f);
        }
    }
}