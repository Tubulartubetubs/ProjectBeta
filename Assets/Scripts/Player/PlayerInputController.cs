using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public float moveSpeed = 5f;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        Vector3 moveInput = new Vector3(playerMovement.moveInput.x, playerMovement.moveInput.y, 0);

        transform.position += moveInput * moveSpeed * Time.deltaTime;
    }
}
