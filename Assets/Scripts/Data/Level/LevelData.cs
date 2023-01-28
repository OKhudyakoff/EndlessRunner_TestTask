using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Data/LevelData")]
public class LevelData : ScriptableObject
{
    [SerializeField]
    private PlayerController playerPrefab;
    [SerializeField]
    private Difficulty difficulty;
    private int maxScore = 0;
    [SerializeField]
    private int chunkCount,chunkLength, chunkBeforeSpawnObstacles;
    public int difficultyNumber = 0;
    private int attempts = 0;

    public void NewAttempt()
    {
        attempts = PlayerPrefs.GetInt("attempts");
        attempts++;
        PlayerPrefs.SetInt("attempts", attempts);
    }

    public void SaveMaxScore(int newScore)
    {
        if (newScore > GetMaxScore())
        {
            PlayerPrefs.SetInt("maxScore", newScore);
        }
    }

    public int GetAtttempts() => PlayerPrefs.GetInt("attempts");
    public int GetMaxScore() => PlayerPrefs.GetInt("maxScore");
    public Difficulty GetDifficulty() => difficulty;
    public PlayerController GetPlayerPrefab() => playerPrefab;
    public int GetChunkCount() => chunkCount;
    public int GetChunkLength() => chunkLength;
    public int GetChunkBeforeSpawnObstacles() => chunkBeforeSpawnObstacles;
    public void SetDifficulty(Difficulty difficulty)
    {
        this.difficulty = difficulty;
    }


}
