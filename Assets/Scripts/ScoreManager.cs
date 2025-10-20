using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    [SerializeField]private ScoreData data;
    public static ScoreManager instance;
    private void OnEnable()
    {
        data.scoreChanged += ShowScore;
    }
    private void OnDisable()
    {
        data.scoreChanged -= ShowScore;
    }

    private void Awake()
    {
        instance = this;
        data.LoadScore();
    }
    private void Start()
    {
        scoreText.text = data.Score.ToString() + " points";
    }
     public void ShowScore(int score) 
    {
        scoreText.text = score.ToString() + " points";
    }
    private void OnDestroy()
    {
        data.SaveScore();
    }
}
