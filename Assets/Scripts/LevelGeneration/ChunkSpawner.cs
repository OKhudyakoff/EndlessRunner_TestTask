using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawner : MonoBehaviour
{
    public static ChunkSpawner Instance { get; private set; }

    [SerializeField]
    private Chunk chunkPrefab;
    private ChunkPoolQueue chunkPool;

    [SerializeField]
    private Obstacle obstaclePrefab;
    private PoolMono<Obstacle> poolObstacle;

    [SerializeField]
    private int chunkCount, obstacleCount, length, chunkBeforeSpawnObstacle, currentChunkCount;

    private Vector2 lastSpawnPosition;

    private void Awake()
    {
        if(Instance != this && Instance != null)
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
        //Создаем стартовые чанки
        chunkPool = GetComponent<ChunkPoolQueue>();
        chunkPool.Init(chunkPrefab, chunkCount, length, this.transform);
        lastSpawnPosition = chunkPool.lastSpawnPosition;
        //Создаем пулл препятствий
        poolObstacle = new PoolMono<Obstacle>(obstaclePrefab, obstacleCount, this.transform, true);
        currentChunkCount = chunkBeforeSpawnObstacle;
    }

    public void SpawnNewChunk()
    {
        var newChunk = chunkPool.GetFreeElement();
        newChunk.transform.position = lastSpawnPosition;
        lastSpawnPosition = newChunk.spawnPosition.position;
        currentChunkCount += 1;

        if(currentChunkCount >= chunkBeforeSpawnObstacle)
        {
            Obstacle newObstacle = poolObstacle.GetFreeElement();
            int randPositionY = Random.Range(-3, 3);
            newObstacle.transform.position = new Vector3(newChunk.transform.position.x, randPositionY, 0);
        }
    }
}
