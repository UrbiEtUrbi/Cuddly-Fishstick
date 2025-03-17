using UnityEngine;

public enum EnemyState { Idleing, Attacking, Moving, Dying }

public class EnemyStateManager : MonoBehaviour
{
    public EnemyState CurrentState { get; private set; }

    public void SetState(EnemyState newState)
    {
        CurrentState = newState;
    }
}