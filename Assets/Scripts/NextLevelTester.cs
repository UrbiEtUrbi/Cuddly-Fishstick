using UnityEngine;

public class NextLevelTester : MonoBehaviour
{
   public void OnTriggerEnter2D(Collider2D other)
   {
        LevelManager.Instance.LoadNextLevel();
   } 
}
