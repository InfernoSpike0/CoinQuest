using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed = 5f;
    [SerializeField] float fireRate = 0.5f;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float hp = 100f;

    float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Aim With Mouse
        Vector3 mousePos = GetMouseWorldXZ();
        Vector3 lookDir = mousePos - transform.position;
        lookDir.y = 0f;

        if (lookDir.sqrMagnitude > 0.001f)
            transform.rotation = Quaternion.LookRotation(lookDir);

        // Shooting
        if (Input.GetMouseButton(0))
        {
            if (timer <= 0f)
            {
                Instantiate(
                    projectilePrefab,
                    transform.position + transform.forward,
                    transform.rotation
                );

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
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 move = new Vector3(horizontal, 0f, vertical).normalized;

        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);

        timer -= Time.fixedDeltaTime; // Fire Rate Timer
    }

    Vector3 GetMouseWorldXZ()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, transform.position);

        if (plane.Raycast(ray, out float distance))
            return ray.GetPoint(distance);

        return transform.position;
    }
    public void Damage(float damageTaken)
    {
        hp -= damageTaken;
        if(hp <= 0)
        {
            // Insert lose thigny here
            Debug.Log("bleh");
        }
    }
}