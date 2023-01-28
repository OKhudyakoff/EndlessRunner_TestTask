using System.Collections.Generic;
using UnityEngine;

public class ChunkPoolQueue: MonoBehaviour
{
    private Chunk prefab;

    private Transform container;

    public Vector2 lastSpawnPosition { get; private set; }

    private Queue<Chunk> pool;

    public void Init(Chunk prefab, int count, int length, Transform container)
    {
        this.prefab = prefab;
        this.container = container;
        lastSpawnPosition = new Vector2(-1 * (count * length) / 2, 0);

        this.CreatePool(count, length);
    }

    private void CreatePool(int count, int length)
    {
        this.pool = new Queue<Chunk>(count);

        for (int i = 0; i < count; i++)
        {
            this.CreateObject(length);
        }
    }

    private Chunk CreateObject(int length,bool isActivityDefault = true)
    {
        Chunk createdObject = Transform.Instantiate(this.prefab, lastSpawnPosition, Quaternion.identity, this.container);
        createdObject.Init(length); //Задаем размер чанка
        lastSpawnPosition = createdObject.GetSpawnPosition(); //Запоминаем позицию для следующего спавна
        createdObject.gameObject.SetActive(isActivityDefault);
        this.pool.Enqueue(createdObject);
        return createdObject;
    }

    public Chunk GetFreeElement()
    {
        Chunk element = pool.Peek();
        pool.Enqueue(pool.Dequeue());
        return element;
    }
}
