using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maximumSpeed;
    public Transform cameraTransform;
    public CharacterController controller;
    public float rotationSpeed;
    public Canvas pauseMenu;

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            pauseMenu.enabled = true;

        }
        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        float speed = inputMagnitude * maximumSpeed;
        movementDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;
        movementDirection.Normalize();
        controller.Move(movementDirection * speed * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            //Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            //transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
