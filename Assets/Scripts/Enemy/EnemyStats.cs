using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemyScriptableObject enemyStats;

    float currMoveSpeed;
    float currHealth;
    float currDamage;

    public float CurrMoveSpeed { get => currMoveSpeed; set => currMoveSpeed = value; }
    public float CurrHealth { get => currHealth; set => currHealth = value; }
    public float CurrDamage { get => currDamage; set => currDamage = value; }

    void Awake()
    {
        CurrMoveSpeed = enemyStats.MoveSpeed;
        CurrHealth = enemyStats.MaxHealth;
        CurrDamage = enemyStats.Damage;
    }

    public void TakeDamage(float damage)
    {
        CurrHealth -= damage;
        if (CurrHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        // Handle enemy death (e.g., play animation, drop loot, etc.)
        Destroy(gameObject);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerStats player = collision.gameObject.GetComponent<PlayerStats>();
            player.TakeDamage(CurrDamage);
        }
    }
}
