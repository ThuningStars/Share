using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingInputSystem : MonoBehaviour
{
    //step1: make sure that you add a rigidbody to the player (or any gameobject that you are attaching this script to
    private Rigidbody playerRigidBody;



    //step4 if you want to use a "Invoke C# Event" instead of "Invoke Unity Event" in the "Behavior" attribute in the "Player Input" component
    //then change your behavior to "Invoke C# Events"
    //and do step 4,5,6
    private PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
    }

    //step2
    //Start is called on the frame when a script is enabled just before any of the Update methods are called the first time.
    //Like the Awake function, Start is called exactly once in the lifetime of the script.
    //However, Awake is called when the script object is initialised, regardless of whether or not the script is enabled.
    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody>();

        //step5: subscribe your playerInput
        playerInput = GetComponent<PlayerInput>();
        playerInput.onActionTriggered += PlayerInput_onActionTriggered;
    }

    //step6: this is called for any action
    private void PlayerInput_onActionTriggered(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        //throw new System.NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //step3
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Jump" + context.phase);
            playerRigidBody.AddForce(Vector3.up * 2.0f, ForceMode.Impulse);
        }

    }
}
