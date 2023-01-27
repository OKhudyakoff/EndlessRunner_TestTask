using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public Transform spawnPosition;
    public SpriteRenderer line1;
    public SpriteRenderer line2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            ChunkSpawner.Instance.SpawnNewChunk();
        }
    }

    public Vector2 GetSpawnPosition() => spawnPosition.position;

    public void Init(int length)
    {
        line1.size = new Vector2(length, 1);
        line2.size = new Vector2(length, 1);
        spawnPosition.position =  new Vector3(spawnPosition.position.x + length, 0, 0);
    }
}
