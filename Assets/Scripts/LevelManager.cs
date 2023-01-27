using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    [SerializeField]
    private LevelData levelData;
    [SerializeField]
    private Difficulty difficulty;

    private PlayerController player;
    [SerializeField]
    private CameraControll playerCameraPrefab;
    [SerializeField]
    private ChunkSpawner chunkSpawner;
    [SerializeField]
    private FinishMenuUI finishMenuUI;

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
    }

    public void StartGame()
    {
        finishMenuUI.gameObject.SetActive(false);
        levelData.NewAttempt();
        difficulty = levelData.difficulty;
        this.player = Instantiate(levelData.PlayerPrefab, Vector3.zero, Quaternion.identity);
        this.player.Init(difficulty);
        Instantiate(playerCameraPrefab);
        chunkSpawner.Init(levelData);
        InvokeRepeating("Accelerate", 15f, 15f);
    }

    public Transform GetPlayerInstance() => player.transform;

    public LevelData GetLevelData() => levelData;

    public void FinishGame()
    {
        player.Freeze();
        levelData.NewScore(currentScore);
        finishMenuUI.gameObject.SetActive(true);
        finishMenuUI.ShowInfo(currentScore);
    }

    private void Accelerate()
    {
        player.ChangeSpeed();
    }
}
