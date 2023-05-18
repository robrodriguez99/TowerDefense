using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdRotation : ICommand
{
    private IRotable _rotable;
    private Vector3 _direction;

    public CmdRotation(IRotable rotable, Vector3 direction)
    {
        _rotable = rotable;
        _direction = direction;
    }

    public void Execute()
    {
        _rotable.Rotation(_direction);
    }
}
