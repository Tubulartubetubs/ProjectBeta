using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemyScriptableObject enemyStats;

    float currMoveSpeed;
    float currHealth;
    float currDamage;

    void Awake()
    {
        currMoveSpeed = enemyStats.MoveSpeed;
        currHealth = enemyStats.MaxHealth;
        currDamage = enemyStats.Damage;
    }

    public void TakeDamage(float damage)
    {
        currHealth -= damage;
        if (currHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        // Handle enemy death (e.g., play animation, drop loot, etc.)
        Destroy(gameObject);
    }
}
