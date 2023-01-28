using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Data/LevelData")]
public class LevelData : ScriptableObject
{
    public PlayerController PlayerPrefab;
    public Difficulty difficulty;
    public int difficultyNumber = 0;
    public int maxScore = 0;
    public int ChunkCount, ChunkLength, ChunkBeforeSpawObstacles;
    private int attempts = 0;

    public void NewAttempt()
    {
        attempts = PlayerPrefs.GetInt("attempts");
        attempts++;
        PlayerPrefs.SetInt("attempts", attempts);
    }

    public void SaveMaxScore(int newScore)
    {
        if (newScore > maxScore)
        {
            maxScore = newScore;
            PlayerPrefs.SetInt("maxScore", maxScore);
        }
    }

    public int GetAtttempts()
    {
        return PlayerPrefs.GetInt("attempts");
    }
}
