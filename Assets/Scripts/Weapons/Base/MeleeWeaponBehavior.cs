using UnityEngine;

public class MeleeWeaponBehavior : MonoBehaviour
{
    public WeaponScriptableObject weaponStats; // Reference to the weapon's stats

    public float destroyAfterSeconds; // Time after which the weapon will be destroyed

    protected float currDamage; // Current damage of the weapon
    protected float currSpeed; // Current speed of the weapon
    protected float currMaxCooldown; // Current maximum cooldown of the weapon
    protected int currPierce; // Current pierce value of the weapon

    private void Awake()
    {
        // Initialize the weapon's current stats based on the scriptable object
        currDamage = weaponStats.Damage;
        currSpeed = weaponStats.Speed;
        currMaxCooldown = weaponStats.MaxCooldown;
        currPierce = weaponStats.Pierce;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds); // Schedule the destruction of the weapon after the specified time
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyStats enemyStats = collision.GetComponent<EnemyStats>();
            enemyStats.TakeDamage(currDamage);
        }
    }
}
