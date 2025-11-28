using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public static GameManager game;
    public List<GameObject> coins = new List<GameObject>();
    [SerializeField] PlayerManager playerManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        game = this;
    }

    public void SpawnedCoin(GameObject coin)
    {
        coins.Add(coin);
        Debug.Log("Coin spawned. Total coins: " + coins.Count);
    }

    public void DestroyedCoin(GameObject coin)
    {
        coins.Remove(coin);
        Debug.Log("Coin collected. Coins left: " + coins.Count);
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);
        Debug.Log("Coins left: " + coins.Count);
    }

    public void Lose()
    {
        SceneManager.LoadScene("LoseScene");
    }
}
