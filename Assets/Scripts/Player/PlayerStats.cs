using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public CharacterScriptableObject characterStats;

    float currHealth;
    float currRegen;
    float currMoveSpeed;
    float currStrength;
    float currProjectileSpeed;
    float currCollectionRadius;
    float currCooldownReduction;
    int currPierce;

    //xp
    [Header("XP/Level")]
    public int exp = 0;
    public int level = 1;
    public int expToNextLevel;

    [System.Serializable]
    public class LevelRange
    {
        public int startLevel;
        public int endLevel;
        public int expCapIncrease;
    }

    [Header("I-Frames")]
    public float invDuration;
    float invTimer;
    bool isInv;

    public List<LevelRange> levelRanges;

    public float CurrHealth { get => currHealth; set => currHealth = value; }
    public float CurrRegen { get => currRegen; set => currRegen = value; }
    public float CurrMoveSpeed { get => currMoveSpeed; set => currMoveSpeed = value; }
    public float CurrStrength { get => currStrength; set => currStrength = value; }
    public float CurrProjectileSpeed { get => currProjectileSpeed; set => currProjectileSpeed = value; }
    public float CurrCollectionRadius { get => currCollectionRadius; set => currCollectionRadius = value; }
    public float CurrCooldownReduction { get => currCooldownReduction; set => currCooldownReduction = value; }
    public int CurrPierce { get => currPierce; set => currPierce = value; }

    private void Awake()
    {
        CurrHealth = characterStats.MaxHealth-10;
        CurrCollectionRadius = characterStats.CollectionRadius;
        CurrRegen = characterStats.Regen;
        CurrMoveSpeed = characterStats.MoveSpeed;
        CurrStrength = characterStats.Strength;
        CurrProjectileSpeed = characterStats.ProjectileSpeed;
        CurrCollectionRadius = characterStats.CollectionRadius;
        CurrCooldownReduction = characterStats.CooldownReduction;
        CurrPierce = characterStats.Pierce;
    }

    void Start()
    {
        expToNextLevel = levelRanges[0].expCapIncrease;
    }

    private void Update()
    {
        if(invTimer > 0)
        {
            invTimer -= Time.deltaTime;
        }
        else
        {
            isInv = false;
        }

        HealOverTime(currRegen);
    }

    public void Heal(int amount)
    {
        if(CurrHealth < characterStats.MaxHealth)
        {
            CurrHealth += amount;
            if(CurrHealth > characterStats.MaxHealth)
            {
                CurrHealth = characterStats.MaxHealth;
            }
        }
    }

    public void IncreaseExperience(int amount)
    {
        exp += amount;
        CheckLevelUp();
    }

    void CheckLevelUp()
    {
        while (exp >= expToNextLevel)
        {
            exp -= expToNextLevel;
            level++;
            UpdateExpToNextLevel();
        }
    }

    void UpdateExpToNextLevel()
    {
        int experienceForNextLevel = 0; 
        foreach (LevelRange range in levelRanges)
        {
            if (level >= range.startLevel && level <= range.endLevel)
            {
                experienceForNextLevel = range.expCapIncrease;
                break;
            }
        }
        expToNextLevel += experienceForNextLevel;
    }

    public void TakeDamage(float amount)
    {
        if (!isInv)
        {
            CurrHealth -= amount;

            invTimer = invDuration;
            isInv = true;

            if (CurrHealth <= 0)
            {
                Die();
            }
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    void HealOverTime(float amount)
    {
            CurrHealth += amount * Time.deltaTime;
            if (CurrHealth > characterStats.MaxHealth)
            {
                CurrHealth = characterStats.MaxHealth;
            }
    }
}
