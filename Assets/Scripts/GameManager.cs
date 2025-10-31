using UnityEngine;
using UnityEngine.SceneManagement;
public enum GameState {WaitingToStart, Running, Ended }
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState gameState;

    private void Awake()
    {

        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
        gameState = GameState.WaitingToStart;
    }

    private void Update()
    {
        if (gameState == GameState.Running)
        {
            return;
        }
        if (Input.anyKeyDown)
        {
            if (gameState == GameState.WaitingToStart)
            {
                gameState = GameState.Running;
            }
            else if(gameState == GameState.Ended)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            
        }
    }
}
