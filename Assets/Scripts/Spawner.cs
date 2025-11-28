using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject coin;
    [SerializeField] GameObject player;
    [SerializeField] float coinFrequency = 2f;
    [SerializeField] GameObject enemy1;
    [SerializeField] GameObject enemy2;
    [SerializeField] float enemyFrequency = 5f;
    private float coinTime;
    private float enemyTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(player, new Vector3(0, 1, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

        coinTime += Time.deltaTime;
        enemyTime += Time.deltaTime;

        if (coinTime >= coinFrequency)
        {
            for (int i = 0; i < 5; i++)
            {
                Instantiate(coin, new Vector3(Random.Range(-9f, 9f), 1f, Random.Range(-9f, 9f)), Quaternion.Euler(0f, 0f, 90f));
            }

            coinTime = 0f;
        }

        if (enemyTime >= enemyFrequency)
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject prefabToSpawn = Random.Range(0, 2) == 0 ? enemy1 : enemy2;

                Instantiate(prefabToSpawn, new Vector3(Random.Range(-2f, 2f), 1f, Random.Range(-2f, 2f)), Quaternion.identity);
            }

            enemyTime = 0f;
        }
    }
}
