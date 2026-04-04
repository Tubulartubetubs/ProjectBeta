using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 moveInput { get; private set; }
    public Vector2 lastMovedVector;
    private void OnMove(InputValue inputValue)
    {
        moveInput = inputValue.Get<Vector2>();
        setLastMovedVector();
    }

    void setLastMovedVector()
    {
        if((moveInput.x != 0 || moveInput.y != 0))
        {
            lastMovedVector = moveInput;
        }
    }
}
