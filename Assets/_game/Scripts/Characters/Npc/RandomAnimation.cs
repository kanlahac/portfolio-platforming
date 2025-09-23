using System.Collections;
using UnityEngine;

namespace Characters.Npc
{
    sealed class RandomAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private float _minWaitTime;
        [SerializeField] private float _maxWaitTime;
        [SerializeField] private int _animationsQuantity;


        private void Start()
        {
            StartCoroutine(ChangeAnimationRoutine());
        }


        private IEnumerator ChangeAnimationRoutine()
        {
            while (true)
            {
                float waitTime = Random.Range(_minWaitTime, _maxWaitTime);
                yield return new WaitForSeconds(waitTime);

                int index = Random.Range(1, _animationsQuantity + 1);
                _animator.SetInteger("Index", index);

                yield return new WaitForSeconds(0.2f);

                _animator.SetInteger("Index", 0);
            }
        }
    }
}