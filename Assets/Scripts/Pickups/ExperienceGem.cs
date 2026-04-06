using UnityEngine;

public class ExperienceGem : Pickup, ICollectible
{
    public int experienceAmount;

    public void Collect()
    {
        PlayerStats player = FindFirstObjectByType<PlayerStats>();
        player.IncreaseExperience(experienceAmount);
    }

    private void OnDestroy()
    {
        Collect();
    }
}
