using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] PlayerManager playerManager; 

    void Update()
    {
        scoreText.text = $"Score: {playerManager.score:0}";
    }
}
