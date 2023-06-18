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
    private float _gravity = -9.81f; 

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
        Vector3 horizontalMove = direction.z * MovementSpeed * Time.smoothDeltaTime * transform.forward +
                                 direction.x * MovementSpeed * Time.smoothDeltaTime * transform.right;

        // Move takes into account both horizontal and vertical movement
        _characterController.Move(horizontalMove + verticalMove);
    }


    public float minVerticalAngle = -90f;  // Minimum vertical angle
    public float maxVerticalAngle = 90f;   // Maximum vertical angle

    public void Rotation(Vector3 direction)
    {
        // Calculate the desired rotation based on the direction and rotation speed
        Quaternion desiredRotation = Quaternion.Euler(direction * RotationSpeed * Time.deltaTime);

        // Apply the desired rotation to the transform
        transform.rotation *= desiredRotation;

        // Get the current rotation in Euler angles
        Vector3 currentEulerAngles = transform.rotation.eulerAngles;

        // Clamp the vertical angle to the desired range
        float clampedVerticalAngle = Mathf.Clamp(currentEulerAngles.x, minVerticalAngle, maxVerticalAngle);

        // Apply the clamped vertical angle to the rotation
        transform.rotation = Quaternion.Euler(clampedVerticalAngle, currentEulerAngles.y, currentEulerAngles.z);
    }
}
