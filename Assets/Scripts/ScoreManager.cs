using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    int score = 0;
    public static ScoreManager instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        scoreText.text = score.ToString() + " points";
    }
    public void AddPoint() 
    {
        score += 1;
        scoreText.text = score.ToString() + " points";
    }
}
