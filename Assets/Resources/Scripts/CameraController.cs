using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector2 sensitivity;

    float xRotation;
    float yRotation;

    [SerializeField] Transform camPivot;
    [SerializeField] Transform camera;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivity.x;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivity.y;

        yRotation += mouseX;

        //xRotation -= PlayerPrefs.GetInt("masterInvertY") == 0 ? mouseY : -mouseY;
        //xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        xRotation = Mathf.Clamp(mouseY, -90f, 90f);

        camPivot.localRotation = Quaternion.Euler(xRotation, 0, 0);
        camera.localRotation = Quaternion.Euler(0, yRotation, 0);
    }
}
