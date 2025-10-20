using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[CreateAssetMenu(fileName = "ScoreData", menuName = "Scriptable Objects/ScoreData")]
public class ScoreData : ScriptableObject
{
    public event Action<int> scoreChanged;
    private int score;
    private const string SCORE_ID = "ScoreValue";
    public int Score { get { return score; } set { score = value; scoreChanged?.Invoke(score); } }
    public void LoadScore()
    {
        if (PlayerPrefs.HasKey(SCORE_ID))
        {
            score = PlayerPrefs.GetInt(SCORE_ID);
        }
        else
        {
            score = 0;
        }
    }
    public void SaveScore()
    {
        PlayerPrefs.SetInt(SCORE_ID, score);
    }
    
}
