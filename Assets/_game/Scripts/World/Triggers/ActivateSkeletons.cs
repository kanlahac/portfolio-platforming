using UnityEngine;

namespace World.Triggers
{
    sealed class ActivateSkeletons : MonoBehaviour
    {
        [SerializeField] private InternalEvent _activateSkeletonsEvent;


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _activateSkeletonsEvent.Event.Invoke();
            }
        }
    }
}
