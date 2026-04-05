using UnityEngine;

public class ProjectileWeaponBehavior : MonoBehaviour
{
    public WeaponScriptableObject weaponStats;

    protected Vector3 direction;
    public float destroyAfterSeconds;

    protected float currDamage;
    protected float currSpeed;
    protected float currMaxCooldown;
    protected int currPierce;

    void Awake()
    {
        currDamage = weaponStats.Damage;
        currSpeed = weaponStats.Speed;
        currMaxCooldown = weaponStats.MaxCooldown;
        currPierce = weaponStats.Pierce;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    public void DirectionChecker(Vector3 dir)
    {
        direction = dir;

        float dirx = direction.x;
        float diry = direction.y;

        Vector3 scale = transform.localScale;
        Vector3 rotation = transform.rotation.eulerAngles;

        if(direction.x  > 0)
        {
            if(direction.y == 0)
            {
                rotation = new Vector3(0, 0, -45);
            }
            else if(direction.y > 0)
            {
                rotation = new Vector3(0, 0, 0);
            }
            else if (direction.y < 0)
            {
                rotation = new Vector3(0, 0, -90);
            }
        }
        else if (direction.x < 0)
        {
            if (direction.y == 0)
            {
                rotation = new Vector3(0, 0, 135);
            }
            else if (direction.y > 0)
            {
                rotation = new Vector3(0, 0, 90);
            }
            else if (direction.y < 0)
            {
                rotation = new Vector3(0, 0, -180);
            }
        }
        else
        {
            if(direction.y < 0)
            {
                rotation = new Vector3(0, 0, -135);
            }
            else if (direction.y > 0)
            {
                rotation = new Vector3(0, 0, 45);
            }
        }

        transform.rotation = Quaternion.Euler(rotation);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyStats enemyStats = collision.GetComponent<EnemyStats>();
            enemyStats.TakeDamage(currDamage);
            currPierce--;
            if (currPierce <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
