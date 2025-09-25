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

            float randomLow = Random.Range(0.05f, 0.25f);
            float randomHigh = Random.Range(0.05f, 0.25f);

            GamepadTools.Vibrate(randomLow, randomHigh, 0.1f);
        }
    }
}