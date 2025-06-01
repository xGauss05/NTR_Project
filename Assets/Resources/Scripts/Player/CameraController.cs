using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector2 sensitivity;

    float xRotation;
    float yRotation;

    [SerializeField] Transform camTransform;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivity.x;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivity.y;

        xRotation -= mouseY;
        yRotation += mouseX;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        camTransform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.localRotation = Quaternion.Euler(0, yRotation, 0);
    }
}
