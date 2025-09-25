using DG.Tweening;
using UnityEngine;

namespace Characters.Npc
{
    sealed class MageSkeleton : MonoBehaviour
    {
        [SerializeField] private InternalEvent _activateSkeletonsEvent;
        [SerializeField] private InternalEvent _desactivateSkeletonsEvent;
        [SerializeField] private RockLaunch _rockLaunch;
        private Animator _animator;
        private bool _isActive;


        private void Awake()
        {
            _animator = GetComponent<Animator>();

            transform.localScale = Vector3.zero;
        }


        private void OnEnable()
        {
            _activateSkeletonsEvent.Event += ActivateSkeleton;
            _desactivateSkeletonsEvent.Event += DesactivateSkeleton;
        }


        private void OnDisable()
        {
            _activateSkeletonsEvent.Event -= ActivateSkeleton;
            _desactivateSkeletonsEvent.Event -= DesactivateSkeleton;
        }


        private void ActivateSkeleton()
        {
            if (_isActive == true) return;

            _isActive = true;

            DOVirtual.DelayedCall(Random.Range(0f, 0.75f), () =>
            {
                _animator.SetTrigger("Spawn");

                transform.localScale = Vector3.one;
            });
        }


        private void DesactivateSkeleton()
        {
            if (_isActive == false) return;

            _isActive = false;

            _animator.SetTrigger("Die");

            DOVirtual.DelayedCall(1.08f, () =>
            {
                transform.localScale = Vector3.zero;
            });
        }


        public void SpawnEnd()
        {
            _animator.SetTrigger("Spellcast");
            _rockLaunch.Cast();
        }


        public void SpellCastEnd()
        {
            _rockLaunch.Launch(transform.forward, 10f);
            
            DOVirtual.DelayedCall(1.5f, SpawnEnd);
        }
    }
}
