using UnityEngine;
using UnityEngine.InputSystem;

sealed class GameManager : MonoBehaviour
{
    [SerializeField] private LevelData _levelData;
    [SerializeField] private PlayerInput _playerInput;

    [Space, Header("Internal Events")]
    [SerializeField] private InternalEvent _switchInputMap;
    

    private void Awake()
    {
        _levelData.ResetAll();
    }


    private void OnEnable()
    {
        _switchInputMap.Event += SwitchInputMap;
    }


    private void OnDisable()
    {
        _switchInputMap.Event -= SwitchInputMap;
    }


    private void SwitchInputMap()
    {
        InputActionMap currentMap = _playerInput.currentActionMap;

        if (currentMap.name == "Player")
        {
            _playerInput.SwitchCurrentActionMap("UI");
        }
        else
        {
            _playerInput.SwitchCurrentActionMap("Player");
        }
    }
}
