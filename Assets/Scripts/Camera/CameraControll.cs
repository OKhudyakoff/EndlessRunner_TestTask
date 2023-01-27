using UnityEngine;

public class CameraControll : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    private Vector3 currentPosition;

    private void Start()
    {
        currentPosition = transform.position;
    }

    private void Update()
    {
        currentPosition.x = player.position.x;
        transform.position = currentPosition;
    }
}
