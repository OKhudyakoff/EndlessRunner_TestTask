using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public bool JumpInput; //{ get; private set; }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            JumpInput = true;
        }
        if(context.canceled)
        {
            JumpInput = false;
        }
    }
}
