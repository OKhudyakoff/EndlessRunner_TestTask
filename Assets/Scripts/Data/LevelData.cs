using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Data/LevelData")]
public class LevelData : ScriptableObject
{
    public PlayerController PlayerPrefab;
    public Difficulty difficulty;
    public int difficultyNumber = 0;
    public float maxScore = 0;
    public int ChunkCount, ChunkLength, ChunkBeforeSpawObstacles;
    [SerializeField]
    private int attempts = 0;

    public void NewAttempt()
    {
        attempts = PlayerPrefs.GetInt("attempts");
        attempts++;
        PlayerPrefs.SetInt("attempts", attempts);
    }

    public void NewScore(float newScore)
    {
        if (newScore > maxScore) maxScore = newScore;
    }

    public int GetAtttempts()
    {
        return PlayerPrefs.GetInt("attempts");
    }
}
