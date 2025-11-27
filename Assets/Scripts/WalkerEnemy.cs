using Unity.VisualScripting;
using UnityEngine;

public class WalkerEnemy : Enemy
{
    [SerializeField] float walkPointRange;
    Vector3 walkPoint;
    bool walkPointSet;
    float randomZ;
    float randomX;

    private void GetWalkPoint()
    {
        randomZ = Random.Range(-walkPointRange, walkPointRange);
        randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        walkPointSet = true;
    }

    private void MoveToWalkPoint()
    {
        Vector3 newPos = Vector3.MoveTowards(transform.position, walkPoint, walkerSpeed * Time.deltaTime);
        
        rb.MovePosition(newPos);

        if (Vector3.Distance(transform.position, walkPoint) < 0.5f)
        {
            walkPointSet = false;
        }
    }

    private void Update()
    {
        if (!walkPointSet)
        {
            GetWalkPoint();
        }

        MoveToWalkPoint();
    }

}
