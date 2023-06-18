using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretIceBullet : TurretBullet
{
    public override void ApplyStatus(IStateful stateful)
    {
        new CmdApplyStatusEffect(stateful, "Ice").Execute();
    }
}
