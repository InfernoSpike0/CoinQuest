using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // egal
    
    public Rigidbody rb;
    public float walkerSpeed = 3f;
    public float chaserSpeed = 6f;

    public void Move(Vector3 target, float speed)
    {
        if (rb != null)
            rb.MovePosition(Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime));
    }
}
