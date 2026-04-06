using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    EnemyStats enemyStats;
    Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyStats = GetComponent<EnemyStats>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, enemyStats.CurrMoveSpeed * Time.deltaTime);
    }
}
