using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 100f;
    Transform player;
    private float xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        player = transform.parent;
    }
    private void Update()
    {
        CameraRotation();
    }

    void CameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime * 5;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime * 5;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 80f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
    }
}
