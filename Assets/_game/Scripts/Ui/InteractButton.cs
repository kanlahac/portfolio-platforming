using DG.Tweening;
using UnityEngine;

namespace Ui
{
    sealed class InteractButton : MonoBehaviour
    {
        private void Awake()
        {
            transform.localScale = Vector3.zero;
        }


        private void Update()
        {
            transform.LookAt(Camera.main.transform);
        }


        public void ShowButton()
        {
            transform.DOScale(Vector3.one, .25f)
                .SetEase(Ease.OutBounce);
        }


        public void HideButton()
        {
            transform.DOScale(Vector3.zero, .25f)
                .SetEase(Ease.InBounce);
        }
    }
}