using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public GameObject weapon;
    public float damage;
    public float speed;
    float currCooldown;
    public float maxCooldown;
    public int pierce;

    protected PlayerMovement playerMovement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        playerMovement = FindFirstObjectByType<PlayerMovement>();
        currCooldown = maxCooldown;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        currCooldown -= Time.deltaTime;
        if (currCooldown < 0) {
            Attack();
        }
    }

    protected virtual void Attack()
    {
        currCooldown = maxCooldown;
    }
}
