using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Ui
{
    sealed class CheckGamepadIcon : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private TextMeshProUGUI _textMeshPro;
        [SerializeField] private string _prefix;
        [SerializeField] private string _xboxButtonName;
        [SerializeField] private string _playStationButtonName;
        [SerializeField] private string _nintendoButtonName;
        [SerializeField] private string _pcButtonName;
        [SerializeField] private string _touchButtonName;
        [SerializeField] private string _sufix;


        private void Awake()
        {
            CheckCurrentGamepad(_playerInput);
        }


        private void OnEnable()
        {
            _playerInput.onControlsChanged += CheckCurrentGamepad;
        }


        private void OnDisable()
        {
            _playerInput.onControlsChanged -= CheckCurrentGamepad;
        }


        private void CheckCurrentGamepad(PlayerInput playerInput)
        {
            if (playerInput.currentControlScheme == "Gamepad")
            {
                InputDevice activeGamepad = Gamepad.current;

                if (activeGamepad == null) return;

                if (activeGamepad.name.Contains("DualShock") || activeGamepad.name.Contains("DualSense"))
                {
                    _textMeshPro.text = _prefix + " <sprite name=\"" + _playStationButtonName + "\"> " + _sufix;
                }
                else if (activeGamepad.name.Contains("SwitchProController"))
                {
                    _textMeshPro.text = _prefix + " <sprite name=\"" + _nintendoButtonName + "\"> " + _sufix;
                }
                else
                {
                    _textMeshPro.text = _prefix + " <sprite name=\"" + _xboxButtonName + "\"> " + _sufix;
                }
            }
            else if (playerInput.currentControlScheme == "Keyboard&Mouse")
            {
                _textMeshPro.text = _prefix + " <sprite name=\"" + _pcButtonName + "\"> " + _sufix;
            }
            else
            {
                _textMeshPro.text = _prefix + " <sprite name=\"" + _touchButtonName + "\"> " + _sufix;
            }
        }
    }
}
