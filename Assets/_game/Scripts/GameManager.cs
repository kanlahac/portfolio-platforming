using UnityEngine;

sealed class GameManager : MonoBehaviour
{
    [SerializeField] private LevelData _levelData;


    private void Awake()
    {
        _levelData.ResetAll();
    }
}
