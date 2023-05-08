using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IMovable
{

    [SerializeField] private float _rotationSpeed;
    public float MovementSpeed =>  _movementSpeed;
    [SerializeField] private float _movementSpeed = 4f;

    public void Move(Vector3 direction)
    {
        transform.Translate(direction * _movementSpeed * Time.deltaTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        _rotationSpeed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        //Move fwd and bkw
        Move(Vector3.forward * Input.GetAxis("Vertical"));

        Move(Vector3.right * Input.GetAxis("Horizontal"));

    }
}
