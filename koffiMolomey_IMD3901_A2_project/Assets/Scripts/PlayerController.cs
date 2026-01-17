using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 2f;

    public CharacterController controller;

    public Transform cameraTransform;

    float xRotation = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log("Scene has started!");  
        Cursor.lockState = CursorLockMode.Locked;//locks cursor to screen
        Cursor.visible = false;//hides cursor
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Scene has been updated!");
        //--------------- Moving Character --------------
        Vector2 moveInput = Keyboard.current != null ? new Vector2
            (
            (Keyboard.current.aKey.isPressed ? -1 : 0) + (Keyboard.current.dKey.isPressed ? 1 : 0),
            (Keyboard.current.sKey.isPressed ? -1 : 0) + (Keyboard.current.wKey.isPressed ? 1 : 0)//? is comparing two values
            ): Vector2.zero;

       
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        controller.Move( move * speed * Time.deltaTime);

        // ---------------- Moving camera----------------------------
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();
        float mouseX = mouseDelta.x * mouseSensitivity * Time.deltaTime;
        float mouseY = mouseDelta.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;//restricts camera so it doesnt flip on itself
        xRotation = Mathf.Clamp( xRotation, -80f, 80f );

        cameraTransform.localRotation = Quaternion.Euler( xRotation, 0f, 0f );
        transform.Rotate(Vector3.up * mouseX);

    }
}
