using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    
    
    
    //This Script for Unity Events


    public Rigidbody sphererigid;
    public PlayerInputActions playerInputActions;
    Vector2 movement;
    // Start is called before the first frame update
    void Awake()
    {
        sphererigid = GetComponent<Rigidbody>();

        playerInputActions = new PlayerInputActions();

        playerInputActions.Player.Jump.performed += Jump;
        playerInputActions.Player.Move.performed += Move;
    }
    void FixedUpdate()
    {
        Vector3 movementVector = new Vector3(movement.x,sphererigid.velocity.y,movement.y);
        sphererigid.velocity = movementVector;
    }
    private void OnEnable()
    {
        playerInputActions.Player.Enable();
    }

    private void OnDisable()
    {
        playerInputActions.Player.Disable();
    }
    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
        Debug.Log("Movement" + context.phase);

    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Debug.Log("Jump" + context.phase);
            sphererigid.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
    }
}
