using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    GameManager gameManager;
    GameObject canvas;

    void Update()
    {
        if (gameManager == null)
        {
            canvas = GameObject.FindGameObjectWithTag("");
            if (canvas != null)
            {
                gameManager = canvas.GetComponent<GameManager>();
            }
        }
        scoreText.text = $"Score: {gameManager.score:0}";
    }
}
