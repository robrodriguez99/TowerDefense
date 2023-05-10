using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LifetimeController))]
public class PlayerBullet : MonoBehaviour, IBullet, IMovable
{
    private LifetimeController _lifetimeController;

    public float MovementSpeed => _movementSpeed;
    [SerializeField] private float _movementSpeed = 30f;

    public float Lifetime => _lifetime = 10f;

    [SerializeField] private float _lifetime;

    public void Travel() => Move(Vector3.forward);

    // Start is called before the first frame update
    void Start()
    {
        _lifetimeController = GetComponent<LifetimeController>();
        _lifetimeController.SetLifetime(_lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        Move(Vector3.forward);
        if (_lifetimeController.isLifetimeOver()) Destroy(this.gameObject);
    }

    public void Move(Vector3 direction)
    {
        transform.Translate(direction * _movementSpeed * Time.deltaTime);
    }
}
