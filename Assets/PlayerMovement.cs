using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody sphererigid;
    private PlayerInput playerInput;
    // Start is called before the first frame update
    void Start()
    {
        sphererigid = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
    }
    // Update is called once per frame
    void Update()
    {
        
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
