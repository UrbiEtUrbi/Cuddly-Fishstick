using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }

    private List<GameObject> enemies = new List<GameObject>();

    public UnityEvent OnWaveComplete;



    private void Awake()
    {
        Instance = this;
    }

    public void RegisterEnemy(GameObject enemy)
    {
        enemies.Add(enemy);
    }

    public void UnregisterEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
        if(enemies.Count == 0)
        {
            OnWaveComplete.Invoke();
        }
    }

    public void CheckWinCondition()
    {
        if (enemies.Count == 0)
        {
            Debug.Log("All enemies defeated! You win!");
            // Trigger win condition
        }
    }
}