using UnityEngine;

public class MeleeWeaponBehavior : MonoBehaviour
{
    public WeaponScriptableObject weaponStats; // Reference to the weapon's stats

    PlayerStats player; // Reference to the player's stats

    public float destroyAfterSeconds; // Time after which the weapon will be destroyed

    protected float currDamage; // Current damage of the weapon
    protected float currSpeed; // Current speed of the weapon
    protected float currMaxCooldown; // Current maximum cooldown of the weapon
    protected int currPierce; // Current pierce value of the weapon

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        // Initialize the weapon's current stats based on the scriptable object
        currDamage = weaponStats.Damage * player.CurrStrength;
        currSpeed = weaponStats.Speed * player.CurrProjectileSpeed;
        currMaxCooldown = weaponStats.MaxCooldown - player.CurrCooldownReduction;
        currPierce = weaponStats.Pierce + player.CurrPierce;
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
        else if (collision.CompareTag("Breakable"))
        {
            BreakableProps breakableProps = collision.GetComponent<BreakableProps>();
            breakableProps.TakeDamage(currDamage);
        }
    }
}
