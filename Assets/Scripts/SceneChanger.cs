using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeMain()
    {
        SceneManager.LoadScene("MainScene");
    }
}
