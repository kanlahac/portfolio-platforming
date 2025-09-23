using DG.Tweening;
using UnityEngine;

namespace Ui
{
    sealed class DiegeticUi : MonoBehaviour
    {
        [HideInInspector] public bool IsActive;


        private void Awake()
        {
            transform.localScale = Vector3.zero;
        }


        private void Update()
        {
            transform.LookAt(Camera.main.transform);
        }


        public void ShowUi()
        {
            transform.DOScale(Vector3.one, .25f)
                .SetEase(Ease.OutBounce);

            IsActive = true;
        }


        public void ShowUi(float timer)
        {
            transform.DOScale(Vector3.one, .25f)
                .SetEase(Ease.OutBounce);

            DOVirtual.DelayedCall(timer, HideUi);
             
            IsActive = true;
        }


        public void HideUi()
        {
            transform.DOScale(Vector3.zero, .25f)
                .SetEase(Ease.InBounce);
            
            IsActive = false;
        }
    }
}