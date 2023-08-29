using UnityEngine;

namespace AHGenericPatterns.VariableStates
{
    public class IntVariableState : VariableStateGeneric<IntVariableState, int>
    {
        public Vector2Int Range { private set; get; } = new Vector2Int(-int.MaxValue, int.MaxValue);
        public void SetRange(Vector2Int range) =>
            Range = range;

        public IntVariableState(string key, int value) : base(key, value) { }

        protected override void SetValue(int value, StateBehaviour state)
        {
            switch (state)
            {
                case StateBehaviour.Set:
                    Value = Mathf.Clamp(value, Range.x, Range.y);
                    break;
                case StateBehaviour.Add:
                    Value += value;
                    if (Value > Range.y)
                        Value = Range.y;
                    break;
                case StateBehaviour.Mines:
                    Value -= value;
                    if (value < Range.x)
                        Value = Range.x;
                    break;
            }
        }
    }
}