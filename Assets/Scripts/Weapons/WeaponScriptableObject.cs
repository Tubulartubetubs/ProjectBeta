using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScriptableObject", menuName = "Scriptable Objects/Weapon")]
public class WeaponScriptableObject : ScriptableObject
{
    [Header("Weapon Stats")]
    [SerializeField]
    GameObject weapon;
    public GameObject Weapon { get => weapon; private set => weapon = value; }

    [SerializeField]
    float damage;
    public float Damage { get => damage; private set => damage = value; }

    [SerializeField]
    float speed;
    public float Speed { get => speed; private set => speed = value; }

    [SerializeField]
    float maxCooldown;
    public float MaxCooldown { get => maxCooldown; private set => maxCooldown = value; }

    [SerializeField]
    int pierce;
    public int Pierce { get => pierce; private set => pierce = value; }
}
