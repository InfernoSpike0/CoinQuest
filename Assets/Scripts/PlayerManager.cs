using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    private Rigidbody player;
    [SerializeField] float speed = 5f;
    [SerializeField] float fireRate = 0.5f;
    [SerializeField] GameObject projectilePrefab;
    public int score = 0;
    float timer;

    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if(timer <= 0)
            {
                Instantiate(projectilePrefab, transform.position + transform.forward, transform.rotation);
                timer = fireRate;
            }
        }
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(horizontal, 0f, vertical);
        transform.Translate(move * Time.fixedDeltaTime * speed, Space.World);
        timer -= Time.fixedDeltaTime;
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