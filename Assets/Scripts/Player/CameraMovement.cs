using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target; // The target the camera will follow
    public Vector3 offset; // The offset from the target's position

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform; // Find the player by tag
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset; // Move the camera to follow the target with the specified offset
    }
}
