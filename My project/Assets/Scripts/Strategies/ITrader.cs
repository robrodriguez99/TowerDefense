using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITrader 
{
    int Gold { get; }

    void Buy(int amount);
}
