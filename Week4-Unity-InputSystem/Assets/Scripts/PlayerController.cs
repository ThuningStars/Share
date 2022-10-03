//Should you still use the old Input Manager now that the new Input System is available?
//The Input Manager has its benefits. It’s simple to use and quick to set up, making it easy to add basic controls quickly.
//However?there are some drawbacks to using the old system.
//For example, it’s not possible to rebind controls at runtime and the splash screen that used to let you change controls before starting the game has since been removed.
//There also appears to be limited support for some newer devices. For example, I was only able to get my Switch Pro Controller partially working and, even then, the axis mapping was different to Xbox and PlayStation controllers, which both share similar mappings.


using UnityEngine.Rendering.VirtualTexturing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 20.0f;

    //step1: once you are done with this line, select the player in the inspector, go to the food prefab and drag it to the "Projectile Prefab" in the inspector
    public GameObject projectilePrefab;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        //step2
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    //Launch a projectile from the player
        //    Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        //}

        //Step3
        //Go to Project Settings, and use the Input Manager to create a Virtual Input called Fire1, which is triggered by the Spacebar,
        //and then listen for the Fire1 virtual input, and not the Spacebar
        //Note: that I used Get Button Down, and not GetKeyDown, which would have returned true for every frame that the button was pressed for.
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    //Launch a projectile from the player
        //    Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        //}

        //step4
        //https://docs.unity3d.com/Packages/com.unity.inputsystem@1.4/manual/Installation.html
        //https://gamedevbeginner.com/input-in-unity-made-easy-complete-guide-to-the-new-system/#input_action_assets
        //https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/manual/QuickStartGuide.html
        //install the new Input System
        //You’ll need to make sure you’re using Unity 2019.1 or newer.
        //You can then download and install the Input System using the Package Manager.

        Vector2 mousePosition = Mouse.current.position.ReadValue();
        if (Keyboard.current.anyKey.wasPressedThisFrame)
        {
            //Debug.Log("A key was pressed");
        }
        //if (Gamepad.current.aButton.wasPressedThisFrame)
        //{
        //    //Debug.Log("A button was pressed");
        //}


        // Using KeyControl property directly.
        //Keyboard.current.spaceKey.isPressed
        //Keyboard.current.aKey.isPressed // etc.

        // Using Key enum.
        //Keyboard.current[Key.Space].isPressed

        // Using key name.
        //((KeyControl)Keyboard.current["space"]).isPressed
        
        if (Keyboard.current[Key.Space].isPressed)
        {
            //Launch a projectile from the player
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
