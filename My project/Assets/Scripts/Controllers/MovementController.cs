using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovementController : MonoBehaviour, IMovable, IRotable
{
    private CharacterController _characterController;
    private ActorStats _actorStats;
    public float MovementSpeed => _actorStats.MovementSpeed;
    public float RotationSpeed => _actorStats.RotationSpeed;
    private float _verticalSpeed = 0f; // This will store the current vertical speed due to gravity
    private float _gravity = -9.81f; // You can adjust this to whatever feels right

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _actorStats = GetComponent<Actor>().ActorStats;
    }

    public void Move(Vector3 direction)
    {
        // Apply gravity
        if (_characterController.isGrounded)
        {
            _verticalSpeed = 0; // reset vertical speed if on the ground
        }
        else
        {
            _verticalSpeed += _gravity * Time.deltaTime;
        }

        Vector3 verticalMove = new Vector3(0, _verticalSpeed, 0);
        Vector3 horizontalMove = direction.z * MovementSpeed * Time.deltaTime * transform.forward;

        // Move takes into account both horizontal and vertical movement
        _characterController.Move(horizontalMove + verticalMove);
    }

    public void Rotation(Vector3 direction)
    {
        transform.Rotate(direction * RotationSpeed * Time.deltaTime);
    }
}
