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
        // Aim
        Vector3 mousePos = GetMouseWorldXZ();
        Vector3 lookDir = mousePos - transform.position;
        lookDir.y = 0f; // Flatten to XZ plane

        if (lookDir.sqrMagnitude > 0.001f)
        {
            transform.rotation = Quaternion.LookRotation(lookDir);
        }
        // Shooting
        if (Input.GetMouseButton(0))
        {
            if (timer <= 0)
            {
                Instantiate(projectilePrefab, transform.position + transform.forward, transform.rotation);
                timer = fireRate;
            }
        }

        // Making sure the player remains in the play area
        if(transform.position.y < 0f)
        {
            transform.position = new Vector3(0, 1, 0);
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
    Vector3 GetMouseWorldXZ()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, transform.position); // XZ plane at player's height

        if (plane.Raycast(ray, out float distance))
            return ray.GetPoint(distance);

        return transform.position;
    }
}