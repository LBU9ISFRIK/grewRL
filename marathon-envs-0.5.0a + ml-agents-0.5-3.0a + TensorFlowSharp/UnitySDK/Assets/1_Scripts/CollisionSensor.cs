using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSensor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isCollision;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Terrain")
            isCollision = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.name == "Terrain")
            isCollision = false;
    }
}
