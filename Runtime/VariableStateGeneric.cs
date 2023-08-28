using System;

public abstract class VariableStateGeneric<TVariable,TValue> : VariableState where TVariable : VariableStateGeneric<TVariable, TValue>
{
    public TValue Value { get; protected set; }

    public event Action<TValue, StateBehaviour> OnValueChanged;

    public VariableStateGeneric(TValue value)
    {
        Value = value;
        Update(this);
    }
    public VariableStateGeneric(string key, TValue value)
    {
        KEY = key;
        Value = value;
        Update(key,this);
    }

    public void Update(TValue value, StateBehaviour state)
    {
        SetValue(value, state);
        OnValueChanged.Invoke(Value, state);
    }

    protected abstract void SetValue(TValue value, StateBehaviour state);
}
