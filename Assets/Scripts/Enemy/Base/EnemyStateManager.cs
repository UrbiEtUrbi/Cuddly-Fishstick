using UnityEngine;

public enum EnemyState {
    Idleing,
    Searching,
    Attacking,
    Moving,
    Dying }

public class EnemyStateManager 
{
    public EnemyState CurrentState { get; private set; }

    public void SetState(EnemyState newState)
    {
        CurrentState = newState;
    }
}