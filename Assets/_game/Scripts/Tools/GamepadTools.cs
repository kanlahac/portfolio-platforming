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
    }
}
