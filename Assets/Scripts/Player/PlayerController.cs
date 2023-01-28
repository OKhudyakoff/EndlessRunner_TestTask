using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;

    [SerializeField]
    private PlayerInputHandler playerInput;
    [SerializeField]
    private float jumpForce, fallForce, runSpeed, multiplier, aceclerationTime;

    private Vector2 playerVelocity;
    private bool freeze = false;


    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        InvokeRepeating("AccelerateSpeed", aceclerationTime, aceclerationTime);
    }


    private void FixedUpdate()
    {
        if(playerInput.JumpInput)
        {
            playerVelocity = Vector2.right * runSpeed + Vector2.up * jumpForce;
        }
        else
        {
            playerVelocity = Vector2.right * runSpeed + Vector2.down * fallForce;
        }
        if(!freeze) playerRigidbody.velocity = playerVelocity;
    }

    public void Init(Difficulty difficulty)
    {
        multiplier = difficulty.GetMultiplier();
        runSpeed = difficulty.GetPlayerStartSpeed();
        aceclerationTime = difficulty.GetAccelerationTime();
    }

    public void Freeze()
    {
        freeze = true;
        playerRigidbody.velocity = Vector2.zero;
        playerRigidbody.gravityScale = 0;
    }

    private void AccelerateSpeed()
    {
        runSpeed *= multiplier;
    }
}
