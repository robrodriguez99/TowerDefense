using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifetimeController : MonoBehaviour
{

    private float _lifetime = 5f;
    private float _currentLifetime;

    // Start is called before the first frame update
    void Start()
    {
        _currentLifetime = _lifetime;
    }

    // Update is called once per frame
    void Update() => _currentLifetime -= Time.deltaTime;

    public bool isLifetimeOver() => _currentLifetime <= 0;

    public void SetLifetime(float value) => _lifetime = value;
}
