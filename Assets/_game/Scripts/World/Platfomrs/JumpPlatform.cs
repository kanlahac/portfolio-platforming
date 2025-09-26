using Tools;
using UnityEngine;

namespace World.Platforms
{
    sealed class JumpPlatform : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.TryGetComponent(out IPlayerController playerController))
            {
                playerController.AddForce(new Vector3(0f, 0.3f, -1f), 200f);

                GamepadTools.Vibrate(0.75f, 0.75f, 0.2f);
            }
        }
    }
}
