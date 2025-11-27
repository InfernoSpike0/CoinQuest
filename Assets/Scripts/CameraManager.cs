using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 offSet = new Vector3(0f, 9.5f, 0f);

    void LateUpdate()
    {
        transform.position = player.transform.position + offSet;
    }
}
