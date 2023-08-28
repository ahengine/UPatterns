public class BoolVariableState : VariableStateGeneric<BoolVariableState, bool>
{
    public BoolVariableState(string key, bool value) : base(key, value) { }

    protected override void SetValue(bool value, StateBehaviour state)
    {
        switch (state)
        {
            case StateBehaviour.Set:
                Value = value;
                break;
            case StateBehaviour.Add:
                // Does not Support
                break;
            case StateBehaviour.Mines:
                // Does not Support
                break;
        }
    }
}

