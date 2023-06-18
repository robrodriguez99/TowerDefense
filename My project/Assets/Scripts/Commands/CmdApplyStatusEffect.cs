using UnityEngine;

public class CmdApplyStatusEffect : ICommand
{
    private IStateful _stateful;
    private string _status;

    public CmdApplyStatusEffect(IStateful stateful, string status)
    {
        _stateful = stateful;
        _status = status;
    }

    public void Execute() => _stateful.TakeStatusEffect(_status);
}
