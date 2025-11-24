using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject coin;
    [SerializeField] float coinFrequency = 2f;
    [SerializeField] GameObject enemy1;
    [SerializeField] GameObject enemy2;
    [SerializeField] float enemyFrequency = 5f;
    private float coinTime;
    private float enemyTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (coinTime >= coinFrequency)
        {
            Instantiate(coin, new Vector3(Random.Range(-2f, 2f), 1f, Random.Range(-2f, 2f)), Quaternion.identity);
            coinTime = 0f;
        }

        if (enemyTime >= enemyFrequency)
        {
            Instantiate(enemy1, new Vector3(Random.Range(-2f, 2f), 1f, Random.Range(-2f, 2f)), Quaternion.identity);
            enemyTime = 0f;
        }
    }
}
