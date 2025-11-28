using UnityEngine;

public class ChaserEnemy : Enemy
{
    [SerializeField] GameObject player;
    Vector3 playerPosition;
    void Start()
    {
        damage = 5f;
    }
    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        float playerPositionX = player.transform.position.x;
        float playerPositionZ = player.transform.position.z;

        playerPosition = new Vector3 (playerPositionX, transform.position.y, playerPositionZ);

        Move(playerPosition, chaserSpeed);
    }
}
