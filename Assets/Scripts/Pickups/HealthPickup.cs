using UnityEngine;

public class HealthPickup : Pickup, ICollectible
{
    public int healAmount;

    public void Collect()
    {
        PlayerStats player = FindFirstObjectByType<PlayerStats>();
        player.Heal(healAmount);
    }

    private void OnDestroy()
    {
        Collect();
    }
}
