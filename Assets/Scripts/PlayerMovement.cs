using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController player;
    [SerializeField] float speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        player.Move(move * Time.fixedDeltaTime * 5f);
    }
}
