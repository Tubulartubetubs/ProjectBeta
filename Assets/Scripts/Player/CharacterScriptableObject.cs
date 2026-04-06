using UnityEngine;

[CreateAssetMenu(fileName = "CharacterScriptableObject", menuName = "Scriptable Objects/Characters")]
public class CharacterScriptableObject : ScriptableObject
{
    [Header("Character Stats")]
    [SerializeField]
    GameObject startingWeapon;
    public GameObject StartingWeapon { get => startingWeapon; private set => startingWeapon = value; }

    [SerializeField]
    float maxHealth;
    public float MaxHealth { get => maxHealth; private set => maxHealth = value; }

    [SerializeField]
    float regen;
    public float Regen { get => regen; private set => regen = value; }

    [SerializeField]
    float moveSpeed;
    public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }

    [SerializeField]
    float strength;
    public float Strength { get => strength; private set => strength = value; }

    [SerializeField]
    float projectileSpeed;
    public float ProjectileSpeed { get => projectileSpeed; private set => projectileSpeed = value; }

    [SerializeField]
    float collectionRadius;
    public float CollectionRadius { get => collectionRadius; private set => collectionRadius = value; }

    [SerializeField]
    float cooldownReduction;
    public float CooldownReduction { get => cooldownReduction; private set => cooldownReduction = value; }

    [SerializeField]
    int pierce;
    public int Pierce { get => pierce; private set => pierce = value; }
}
