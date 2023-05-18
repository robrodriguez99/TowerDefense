using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraderController : MonoBehaviour, ITrader
{
    public int Gold => _gold;
    [SerializeField] private int _gold = 0;

    public void Buy(int amount)
    {
       _gold -= amount;
    }

}
