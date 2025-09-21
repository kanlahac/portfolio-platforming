using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    [SerializeField] private CharacterStatsData _characterStatsData;
    [SerializeField] private Transform _modelTransform;
    private CharacterController _characterController;
    private Animator _animator;
    private InputAction _moveAction;
    private Vector2 _moveValue;
    

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = _modelTransform.GetComponent<Animator>();

        var playerInput = GetComponent<PlayerInput>();
        if (playerInput != null) _moveAction = playerInput.actions["Move"];
    }


    public void OnMove()
    {
        _moveValue = _moveAction.ReadValue<Vector2>();
    }
    

    public void OnMove(Vector2 moveFactor)
    {
        _moveValue = moveFactor;
    }


    private void Update()
    {
        Vector3 movement = transform.forward * _moveValue.y + transform.right * _moveValue.x;
        _characterController.Move(movement * _characterStatsData.Stats.MovementSpeed * Time.deltaTime);

        float movementMagnitude = movement.magnitude;

        if (movementMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);

            _modelTransform.rotation = Quaternion.Slerp(
                _modelTransform.rotation, 
                targetRotation, 
                10f * Time.deltaTime
            );
        }

        _animator.SetFloat("Speed", movementMagnitude);
    }
}
