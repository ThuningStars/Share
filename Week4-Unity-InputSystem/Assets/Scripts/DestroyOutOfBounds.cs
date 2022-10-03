using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//@note: make sure that you do override the prefabs!
//Select food pizza, select override, apply all!
public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBound = 30.0f;
    public float lowerBound = -10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > topBound)
        {
            //current gameObject (our projectile/pizza)
            Destroy(gameObject);
        } else if (transform.position.z < lowerBound)
        {
            //current gameObject (our animals)
            Destroy(gameObject);
        }
    }
}
