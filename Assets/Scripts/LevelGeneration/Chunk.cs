using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPosition;
    [SerializeField]
    private SpriteRenderer line1, line2;
    [SerializeField]
    private Transform obstacle;
    private ChunkSpawner chunkSpawner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            chunkSpawner.SpawnNewChunk();
        }
    }

    public Vector2 GetSpawnPosition() => this.spawnPosition.position;

    public void Init(int length, ChunkSpawner chunkSpawner)
    {
        line1.size = new Vector2(length, 1);
        line2.size = new Vector2(length, 1);
        this.chunkSpawner = chunkSpawner;
        obstacle.gameObject.SetActive(false);
        spawnPosition.position =  new Vector3(this.spawnPosition.position.x + length, 0, 0);
    }

    public void ShowObstacle(bool visible, int y = 0)
    {
        obstacle.gameObject.SetActive(visible);
        obstacle.position = new Vector3(this.transform.position.x, y, 0);
    }
}
