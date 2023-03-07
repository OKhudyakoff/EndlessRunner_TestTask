using UnityEngine;

public class ChunkSpawner : MonoBehaviour
{
    [SerializeField]
    private Chunk chunkPrefab;
    private ChunkPoolQueue chunkPool;

    [SerializeField]
    private int chunkCount, length, chunkBeforeSpawnObstacle, currentChunkCount;

    private Vector2 lastSpawnPosition;

    public void Init(LevelData levelData)
    {
        this.chunkCount = levelData.GetChunkCount();
        this.length = levelData.GetChunkLength();
        this.chunkBeforeSpawnObstacle = levelData.GetChunkBeforeSpawnObstacles();
        CreateStartChunks();
    }

    private void CreateStartChunks()
    {
        //Создаем стартовые чанки
        chunkPool = GetComponent<ChunkPoolQueue>();
        chunkPool.Init(chunkPrefab, chunkCount, length, this.transform);
        lastSpawnPosition = chunkPool.lastSpawnPosition;

        currentChunkCount = chunkBeforeSpawnObstacle;
    }

    public void SpawnNewChunk()
    {
        var newChunk = chunkPool.GetFreeElement();
        newChunk.transform.position = lastSpawnPosition;
        lastSpawnPosition = newChunk.GetSpawnPosition();

        if(currentChunkCount >= chunkBeforeSpawnObstacle)
        {
            int randPositionY = Random.Range(-3, 3);
            newChunk.ShowObstacle(true, randPositionY);
            currentChunkCount = 0;
        }
        else
        {
            newChunk.ShowObstacle(false);
            currentChunkCount += 1;
        }
    }
}
