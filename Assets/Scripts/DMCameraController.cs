using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DMCameraController : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public float speed = 20f;
    private float xRotation = 0f;
    private float yRotation = 0f;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // handles mouse look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        xRotation -= mouseY;
        yRotation += mouseX;
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);

        // handles first person movement
        Vector3 currentDirection = transform.forward;
        currentDirection.y = 0;
        currentDirection = currentDirection.normalized;
        Vector3 a = new Vector3(currentDirection.z, 0, -currentDirection.x);

        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.localPosition += a * moveX;
        transform.localPosition += currentDirection * moveZ;

        if (Input.GetKey(KeyCode.Space))
        {
            transform.localPosition += new Vector3(0, speed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.localPosition -= new Vector3(0, speed * Time.deltaTime, 0);
        }
    }
}
