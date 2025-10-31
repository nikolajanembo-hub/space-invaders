using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI gameOver;
    [SerializeField] private TextMeshProUGUI gameStart;

    private void Update()
    {
        if (GameManager.instance.gameState == GameState.Ended && !gameOver.gameObject.activeInHierarchy)
        {
            gameOver.gameObject.SetActive(true);
        }
        else if (GameManager.instance.gameState != GameState.Ended && gameOver.gameObject.activeInHierarchy)
        {
            gameOver.gameObject.SetActive(false);
        }
        if (GameManager.instance.gameState == GameState.WaitingToStart && !gameStart.gameObject.activeInHierarchy)
        {
            gameStart.gameObject.SetActive(true);
        }
        else if (GameManager.instance.gameState != GameState.WaitingToStart && gameStart.gameObject.activeInHierarchy)
        {
            gameStart.gameObject.SetActive(false);
        }
    }
}
