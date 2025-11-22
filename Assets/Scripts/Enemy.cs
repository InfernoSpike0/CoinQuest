using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float walkerSpeed = 3f;
    [SerializeField] Material walkerMaterial;
    [SerializeField] float chaserSpeed = 6f;
    [SerializeField] Material chaserMaterial;
    [SerializeField] Transform target;
    [SerializeField] float typeThreshold = 0.5f; // Threshold to determine enemy type. Used for testing.
    float enemyType;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float enemyType = Random.Range(0f, 1f);
        if (enemyType >= typeThreshold)
        {
            GetComponent<Renderer>().material = walkerMaterial;
        }
        else
        {
            GetComponent<Renderer>().material = chaserMaterial;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        if (enemyType >= typeThreshold)
        {
            transform.Translate(Vector3.forward * Time.fixedDeltaTime * walkerSpeed);
        }
        else
        {
            transform.Translate(Vector3.forward * Time.fixedDeltaTime * chaserSpeed);
        }
    }
}
