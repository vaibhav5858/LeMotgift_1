using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseControll : MonoBehaviour
{

    
    


    public float mouseSensitivity = 50f;
    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
        if (playerBody == null)
        {
            Debug.LogError("PlayerBody is not assigned in the Inspector.");
        }
        // Lock cursor to center of screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        Debug.Log($"Mouse X: {mouseX}, Mouse Y: {mouseY}");

        // Apply vertical rotation to camera
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -55f, 50f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Apply horizontal rotation to PlayerBody
        if (playerBody != null)
        {
            playerBody.Rotate(Vector3.up * mouseX);
            Debug.Log($"PlayerBody rotation: {playerBody.rotation.eulerAngles}");
        }
    }
}

    



