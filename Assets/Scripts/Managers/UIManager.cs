using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject UIPrefab;

    private void Awake()
    {
        Instance = this;
    }

    public void Init()
    {
        Instantiate(UIPrefab);
    }
}