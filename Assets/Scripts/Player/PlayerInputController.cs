using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public float moveSpeed = 5f;
    
    PlayerStats playerStats;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerStats = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        Vector3 moveInput = new Vector3(playerMovement.moveInput.x, playerMovement.moveInput.y, 0);

        transform.position += moveInput * playerStats.CurrMoveSpeed * Time.deltaTime;
    }
}
