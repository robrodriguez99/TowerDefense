using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour, IMovable, IRotable
{

    public float MovementSpeed => GetComponent<ActorStats>().MovementSpeed;

    public float RotationSpeed => GetComponent<ActorStats>().RotationSpeed;

    public void Move(Vector3 direction)
    {
        transform.Translate(direction * MovementSpeed * Time.deltaTime);
    }

    public void Rotation(Vector3 direction)
    {
        transform.Rotate(direction * RotationSpeed * Time.deltaTime);
    }

    // Start is called before the first frame update
}
