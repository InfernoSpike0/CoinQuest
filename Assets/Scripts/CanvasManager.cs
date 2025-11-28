using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    PlayerManager playerManager;
    GameObject player;

    void Update()
    {
        if (playerManager == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                playerManager = player.GetComponent<PlayerManager>();
            }
        }
        scoreText.text = $"Score: {playerManager.score:0}";
    }
}
