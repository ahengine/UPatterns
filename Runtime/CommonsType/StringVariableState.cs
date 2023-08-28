public class StringVariableState : VariableStateGeneric<StringVariableState, string>
{
    public StringVariableState(string key, string value) : base(key, value) { }

    protected override void SetValue(string value, StateBehaviour state)
    {
        switch (state)
        {
            case StateBehaviour.Set:
                Value = value;
                break;
            case StateBehaviour.Add:
                Value += value;
                break;
            case StateBehaviour.Mines:
                // Does not Support
                break;
        }
    }
}
