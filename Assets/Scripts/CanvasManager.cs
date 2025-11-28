using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text hpText;
    PlayerManager playerManager;
    GameObject player;
    GameManager gameManager;
    GameObject canvas;

    void Update()
    {
        // Score
        if (gameManager == null)
        {
            canvas = GameObject.FindGameObjectWithTag("GameController");
            if (canvas != null)
            {
                gameManager = canvas.GetComponent<GameManager>();
            }
        }
        scoreText.text = $"Score: {gameManager.score:0}";

        // HP
        if (playerManager == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                playerManager = player.GetComponent<PlayerManager>();
            }
        }
        hpText.text = $"HP: {playerManager.hp:100}";
    }
}
