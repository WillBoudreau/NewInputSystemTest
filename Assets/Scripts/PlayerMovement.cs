using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody sphererigid;
    public InputAction playerInput;
    Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        sphererigid = GetComponent<Rigidbody>();
    }
    void update()
    {
        movement = playerInput.ReadValue<Vector3>();
    }
    void FixedUpdate()
    {
        sphererigid.velocity = new Vector3(movement.x, sphererigid.velocity.y, movement.z);
    }
    // private void OnEnable()
    // {
    //     playerInput.Enable();
    //     playerInput.performed += Move;
    //     playerInput.canceled += Move;
    // }

    // private void OnDisable()
    // {
    //     playerInput.Disable();
    //     playerInput.performed -= Move;
    //     playerInput.canceled -= Move;
    // }
    public void Move(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Debug.Log("Move" + context.phase);
            sphererigid.AddForce(Vector3.forward * 5f, ForceMode.Impulse);
        }
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
