using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    /*
     * This will be the input system that allows the player to look around and move
     * the components needed to access are the Camera and the Character Controller
     */

    [SerializeField] Camera playerCamera;
    [SerializeField] CharacterController playerController;
    [SerializeField] Transform cameraTransform;

    //Variables needed to control the camera and player

    //Camera variables
    [SerializeField] float mouseSensitivity = 100f;

    private Vector2 rotation;
    Vector2 cameraLook;

    //Movement variables
    [SerializeField] float speed;

    private Vector3 playerMovementInput()
    {
        Vector3 movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        movementDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;
        movementDirection.Normalize();
        return movementDirection;
    }

    void PlayerMove()
    {
        playerController.Move(playerMovementInput() * speed * Time.deltaTime);
    }
    private float ClampCameraAngle(float angle)
    {
        return Mathf.Clamp(angle, -45, 45);
    }

    private Vector2 GetMouseInput()
    {
       cameraLook =  new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

       return cameraLook;
    }
    void PlayerLook()
    {
        Vector2 wantedVelocity = GetMouseInput() * mouseSensitivity;
        rotation += wantedVelocity * Time.deltaTime;
        rotation.y = ClampCameraAngle(rotation.y);
        playerCamera.transform.localEulerAngles = new Vector3(-rotation.y, rotation.x, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerLook();
        
    }

    
}
