using UnityEngine;

public class KnifeBehavior : ProjectileWeaponBehavior
{

    KnifeController knifeController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        knifeController = FindFirstObjectByType<KnifeController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * knifeController.speed * Time.deltaTime;
    }
}
