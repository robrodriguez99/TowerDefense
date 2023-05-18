using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public ActorStats ActorStats => _actorStats;
    [SerializeField] private ActorStats _actorStats;

    public LifeController _lifeController;

    protected virtual void Start()
    {
        _lifeController = GetComponent<LifeController>();
    }
}
