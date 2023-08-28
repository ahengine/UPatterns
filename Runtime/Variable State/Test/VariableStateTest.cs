using UnityEngine;

public class VariableStateTest : MonoBehaviour
{
    private const string PLAYER_MOVE_SPEED_KEY = "PlayerMoveSpeed";
    private FloatVariableState moveSpeed;

    public void Set(FloatVariableState value) =>
        moveSpeed = value;

    private void Awake()
    {
        moveSpeed = VariableState.Get<FloatVariableState>(PLAYER_MOVE_SPEED_KEY);
        if(moveSpeed == null)
            moveSpeed = new FloatVariableState(PLAYER_MOVE_SPEED_KEY, 10);
        moveSpeed.Update(10, VariableState.StateBehaviour.Set);
    }
}
