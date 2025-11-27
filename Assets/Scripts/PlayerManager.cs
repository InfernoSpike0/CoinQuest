using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] Rigidbody player;
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float fireRate = 0.5f;
    [SerializeField] GameObject projectilePrefab;
    int score = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            Instantiate(projectilePrefab, transform.position + transform.forward, transform.rotation);
        }
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(horizontal, 0f, vertical);
        transform.Translate(move * Time.fixedDeltaTime * speed, Space.World);
    }

    void OnCollisionEnter(Collision collision)
    {
        //isGrounded = true;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            score += 1;
            Debug.Log("Score: " + score);
        }
    }
}