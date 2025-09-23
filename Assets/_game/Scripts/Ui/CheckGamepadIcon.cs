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
        [SerializeField] private string _sufix;


        private void Awake()
        {
            CheckCurrentGamepad(_playerInput.currentControlScheme);
        }


        private void OnEnable()
        {
            _playerInput.onControlsChanged += OnGamepadChange;
        }


        private void OnDisable()
        {
            _playerInput.onControlsChanged -= OnGamepadChange;
        }


        private void OnGamepadChange(PlayerInput playerInput)
        {
            CheckCurrentGamepad(playerInput.currentControlScheme);
        }


        private void CheckCurrentGamepad(string controlSchemeName)
        {

            if (controlSchemeName == "Gamepad")
            {
                InputDevice activeGamepad = Gamepad.current;

                if (activeGamepad == null) return;

                if (activeGamepad.name.Contains("DualShock") || activeGamepad.name.Contains("DualSense"))
                {
                    _textMeshPro.text = _prefix + " <sprite name=\"pt\"> " + _sufix;
                }
                else if (activeGamepad.name.Contains("SwitchProController"))
                {
                    _textMeshPro.text = _prefix + " <sprite name=\"nx\"> " + _sufix;
                }
                else
                {
                    _textMeshPro.text = _prefix + " <sprite name=\"xy\"> " + _sufix;
                }
            }
            else
            {
                _textMeshPro.text = _prefix + " <sprite name=\"e\"> " + _sufix;
            }
        }
    }
}
