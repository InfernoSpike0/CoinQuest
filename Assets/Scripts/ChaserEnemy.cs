using UnityEngine;

public class ChaserEnemy : Enemy
{
    [SerializeField] GameObject player;
    Vector3 playerPosition;


    private void Update()
    {
        float playerPositionX = player.transform.position.x;
        float playerPositionZ = player.transform.position.z;

        playerPosition = new Vector3 (playerPositionX, transform.position.y, playerPositionZ);

        transform.position = Vector3.MoveTowards(transform.position, playerPosition, chaserSpeed * Time.deltaTime);
    }
}
