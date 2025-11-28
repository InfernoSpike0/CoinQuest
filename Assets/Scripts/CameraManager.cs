using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{
    Transform player;
    [SerializeField] Vector3 offSet = new Vector3(0f, 9.5f, 0f);

    private void Start()
    {
        
    }

    void LateUpdate()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        transform.position = player.transform.position + offSet;
    }
}
