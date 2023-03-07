using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    [Header("Data")]
    [SerializeField]
    private LevelData levelData;
    [SerializeField]
    private Difficulty difficulty;
    [Header("Prefabs")]
    private PlayerController player;
    [SerializeField]
    private CameraControll playerCameraPrefab;
    [Header("ObjectsOnScene")]
    [SerializeField]
    private ChunkSpawner chunkSpawner;
    [SerializeField]
    private FinishMenuUI finishMenuUI;
    [SerializeField]
    private TMP_Text currentScoreText;

    private int currentScore;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        StartGame();
    }

    private void Update()
    {
        currentScore = (int)player.transform.position.x;
        currentScoreText.SetText(currentScore.ToString());
    }

    public void StartGame()
    {
        Application.targetFrameRate = 60;

        finishMenuUI.gameObject.SetActive(false);
        levelData.NewAttempt();
        difficulty = levelData.GetDifficulty();
        this.player = Instantiate(levelData.GetPlayerPrefab(), Vector3.zero, Quaternion.identity);
        this.player.Init(difficulty);
        Instantiate(playerCameraPrefab);
        chunkSpawner.Init(levelData);
    }

    public Transform GetPlayerInstance() => player.transform;

    public LevelData GetLevelData() => levelData;

    public ChunkSpawner GetChunkSpawner() => chunkSpawner;

    public void FinishGame()
    {
        player.Freeze();
        levelData.SaveMaxScore(currentScore);
        finishMenuUI.gameObject.SetActive(true);
        finishMenuUI.ShowInfo(currentScore);
    }
}
