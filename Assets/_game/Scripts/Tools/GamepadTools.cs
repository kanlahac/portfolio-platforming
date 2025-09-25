using DG.Tweening;
using UnityEngine.InputSystem;

namespace Tools
{
    static public class GamepadTools
    {
        public static void Vibrate(float lowFreq, float highFreq, float duration)
        {
            if (Gamepad.current != null)
            {
                Gamepad.current.SetMotorSpeeds(lowFreq, highFreq);

                DOVirtual.DelayedCall(duration, () =>
                {
                    Gamepad.current.ResetHaptics();
                });
            }
        }


        public static void IncrementalVibrate(float maxLowFreq, float maxHighFreq, float duration, Ease ease)
        {
            if (Gamepad.current != null)
            {
                DOTween.To(
                    () => 0f,
                    (value) =>
                    {
                        float currentLowFreq = value * maxLowFreq;
                        float currentHighFreq = value * maxHighFreq;

                        Gamepad.current.SetMotorSpeeds(currentLowFreq, currentHighFreq);
                    },
                    1f,
                    duration
                )
                .SetEase(ease)
                .OnComplete(() =>
                {
                    Gamepad.current.ResetHaptics();
                });
            }
        }
    }
}
