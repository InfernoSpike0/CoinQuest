using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // egal
    
    public Rigidbody rb;
    public float walkerSpeed = 3f;
    public float chaserSpeed = 6f;
    public float damage;
    float damageTick = 1.0f;
    float timer;
    public void Move(Vector3 target, float speed)
    {
        if (rb != null)
            rb.MovePosition(Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime));
    }
    
    void FixedUpdate()
    {
        timer -= Time.fixedDeltaTime;
    }
    void OnCollisionStay(Collision collision)
    {
        if(collision.collider.CompareTag("Player") && timer <= 0)
        {
            collision.collider.GetComponent<PlayerManager>().Damage(damage);
            timer = damageTick;
        }
    }
}
