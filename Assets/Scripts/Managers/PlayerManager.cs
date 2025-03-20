using UnityEngine;

public enum PlayerState {Alive, Dead, Damaged}

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    public GameObject playerPrefab;
    private GameObject player;
    private PlayerState playerState;

    public void Awake()
    {
        Instance = this;
    }

    public void SpawnPlayer(int level)
    {
        player = Instantiate(playerPrefab);
        player.transform.position = GameObject.FindWithTag("PlayerSpawn").transform.position;
        SetPlayerState(PlayerState.Alive);
        Debug.Log("Player Spawned on Level " + (level +1).ToString());
    }

    public PlayerState GetPlayerState()
    {
        return playerState;
    }

    private void SetPlayerState(PlayerState state)
    {
        playerState = state;
    }
}

