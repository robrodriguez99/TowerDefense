using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransactionController : MonoBehaviour, ITrader, IRewardable
{
    public int Gold => _gold;
    [SerializeField] private int _gold = 0;

    public void Buy(int amount)
    {
       _gold -= amount;
        Debug.Log("Spent: " + amount + " Remaining: " + _gold);
    }

    public void Earn(int amount)
    {
       _gold += amount;
        Debug.Log("Earned: " + amount + " Remaining: " + _gold);

    }
}
