using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement2 : MonoBehaviour
{


    //This script for C# events



    private TestProjectForInput2 playerInputActions;
    private InputAction movement;

    private Rigidbody rb;  


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInputActions = new TestProjectForInput2(); 
    }
    void OnEnable()
    {
        movement = playerInputActions.Player.Move;
        movement.Enable();
        playerInputActions.Player.Jump.Enable();
        movement.performed += MovementInput;
        playerInputActions.Player.Jump.performed += DoJump;
    }
    void DoJump(InputAction.CallbackContext context)
    {
        Debug.Log("Jump" + context.phase);
        if(context.performed)
        {
           rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
    }
    void OnDisable()
    {
        movement.Disable();
        playerInputActions.Player.Jump.Disable();
    }
    void FixedUpdate()
    {
        
    }
    void MovementInput(InputAction.CallbackContext context)
    {
        Debug.Log("Movement " + context.phase);
        if(context.performed)
        {
            Debug.Log("Movement " + context.phase);
            Vector2 inputVector = context.ReadValue<Vector2>();
            Vector3 movementVector = new Vector3(inputVector.x, 0, inputVector.y);
            transform.Translate(movementVector * 100f * Time.deltaTime);
        }
        // if(context.performed)
        // {
        //     Debug.Log("Move" + context.phase);
        //     Vector2 inputVector = context.ReadValue<Vector2>();
        //     Vector3 movementVector = new Vector3(inputVector.x, 0, inputVector.y);
        //     transform.Translate(movementVector * 100f * Time.deltaTime);
        //     //rb.velocity = new Vector3(movementVector.x * 5f, rb.velocity.y, movementVector.z * 5f);
        // }
    }
}
