using UnityEngine;

public class ProjectileWeaponBehavior : MonoBehaviour
{

    protected Vector3 direction;
    Vector3 playerMovement;
    public float destroyAfterSeconds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
        //playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().lastMovedVector;
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
}
