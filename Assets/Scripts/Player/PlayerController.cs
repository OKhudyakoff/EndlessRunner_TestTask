using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;

    [SerializeField]
    private PlayerInputHandler playerInput;
    [SerializeField]
    private float jumpForce, fallForce, runSpeed, multiplier;

    private Vector2 playerVelocity;


    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        if(playerInput.JumpInput)
        {
            playerVelocity = Vector2.right * runSpeed + Vector2.up * jumpForce;
        }
        else
        {
            playerVelocity = Vector2.right * runSpeed + Vector2.down * fallForce;
        }

        playerRigidbody.velocity = playerVelocity;
    }

    public void ChangeSpeed()
    {
        jumpForce *= multiplier;
        fallForce *= multiplier;
    }
}
