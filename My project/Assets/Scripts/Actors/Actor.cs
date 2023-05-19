using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public ActorStats ActorStats => _actorStats;
    [SerializeField] protected ActorStats _actorStats;

    public LifeController lifeController;

    protected virtual void Start()
    {
        lifeController = GetComponent<LifeController>();
    }
}
