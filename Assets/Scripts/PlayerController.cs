using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 12f;
    private Vector3 velocity;
    public float gravity = -10;

    private CharacterController characterController;

    public Transform groundCheck;
    public LayerMask groundMask;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
     void Update()
    {
        PlayerMove();
        CheckGround();
    }

    void PlayerMove()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(motion:move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);

    }

    private void CheckGround()
    {
        RaycastHit hit;

        if(Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down), out hit, 0.4f, groundMask))
        {
            string terraingTag = hit.collider.gameObject.tag;

            switch (terraingTag)
            {
                default:
                    speed = 12;
                    break;

                case "Low":
                    speed = 3;
                    break;
                case "High":
                    speed = 20;
                    break;
            }
                
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "PickUp")
        {
            hit.gameObject.GetComponent<PickUp>().Picked();
        }
    }
}
