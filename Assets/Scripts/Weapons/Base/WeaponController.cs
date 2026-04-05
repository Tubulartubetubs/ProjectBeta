using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public WeaponScriptableObject weaponStats;
    float currCooldown;

    protected PlayerMovement playerMovement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        playerMovement = FindFirstObjectByType<PlayerMovement>();
        currCooldown = weaponStats.MaxCooldown;
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
        currCooldown = weaponStats.MaxCooldown;
    }
}
