using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    //step1
    public float speed = 40.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //step2
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        //step3
        //Rotate all animals on the Y axis by 180 degrees to face down
        //Select all three animals in the hierarchy and Add Component > Move Forward
        //Edit their speed values and test to see how it looks
        //Drag all three animals into the Prefabs folder, choosing “Original Prefab”
        //Test by dragging prefabs into scene view during gameplay
    }
}
