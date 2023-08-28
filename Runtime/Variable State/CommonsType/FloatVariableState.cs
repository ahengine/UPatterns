public class FloatVariableState : VariableStateGeneric<FloatVariableState, float>
{
    public FloatVariableState(string key, float value) : base(key, value) { }

    protected override void SetValue(float value, StateBehaviour state)
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
                Value -= value;
                break;
        }
    }
}