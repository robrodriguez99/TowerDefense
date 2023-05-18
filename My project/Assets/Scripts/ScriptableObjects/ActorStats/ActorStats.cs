using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName = "ActorStats", menuName ="Stats/Actors/BasicActor", order = 0)]
public class ActorStats : ScriptableObject
{
    [SerializeField] private StatValues _statValues;

    public int MaxLife => _statValues.MaxLife;

    public float MovementSpeed => _statValues.MovementSpeed;

    public float RotationSpeed => _statValues.RotationSpeed;

}

[System.Serializable]
public struct StatValues
{
    public int MaxLife;
    public float MovementSpeed;
    public float RotationSpeed;
}
