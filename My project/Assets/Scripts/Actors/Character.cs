using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IMovable, IRotable
{

    [SerializeField] private GameObject _bulletPrefab;
    public float RotationSpeed => _rotationSpeed;
    [SerializeField] private float _rotationSpeed = 15f;
    public float MovementSpeed =>  _movementSpeed;
    [SerializeField] private float _movementSpeed = 5f;

    public void Move(Vector3 direction)
    {
        transform.Translate(direction * _movementSpeed * Time.deltaTime);
    }

    public void Rotation(Vector3 direction)
    {
        transform.Rotate(direction * _rotationSpeed * Time.deltaTime);
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Move fwd and bkw
        Move(Vector3.forward * Input.GetAxis("Vertical"));
        Rotation(Vector3.up * Input.GetAxis("Horizontal"));
        //TODO ver ultimo param para container
        if(Input.GetAxis("Fire1") > 0) Instantiate(_bulletPrefab, transform.position, transform.rotation);
    }

}
