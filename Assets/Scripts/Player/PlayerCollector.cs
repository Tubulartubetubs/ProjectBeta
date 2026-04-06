using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    PlayerStats playerStats;
    CircleCollider2D collectorCollider;
    public float pullSpeed;

    private void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        collectorCollider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        collectorCollider.radius = playerStats.CurrCollectionRadius;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            collision.transform.position = Vector2.MoveTowards(collision.transform.position, transform.position, pullSpeed * Time.deltaTime);
        }
    }
}
