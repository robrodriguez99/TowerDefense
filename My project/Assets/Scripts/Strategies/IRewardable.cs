using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRewardable 
{
    int Gold { get; }

    void Earn(int amount);
}
