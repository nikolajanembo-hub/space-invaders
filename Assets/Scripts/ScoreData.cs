using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreData", menuName = "Scriptable Objects/ScoreData")]
public class ScoreData : ScriptableObject
{
    public event Action<int> scoreChanged;
    private int score;
    public int Score { get { return score; } set { score = value; scoreChanged?.Invoke(score); } } 
}
