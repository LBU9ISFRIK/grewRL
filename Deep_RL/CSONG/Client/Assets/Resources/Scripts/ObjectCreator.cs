using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreator : MonoBehaviour
{

    GameObject newObject;
    
    // Start is called before the first frame update
    void Start()
    {
        newObject = (GameObject)Resources.Load("Prefabs/Wolf", typeof(GameObject));
        newObject.AddComponent<Rigidbody>();
        newObject.AddComponent<BoxCollider>();
        newObject.transform.position = new Vector3(4f, 0.5f, 4f);


        Instantiate(newObject);

       
        
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            /*GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(4f, 0.5f, 7f);
            //cube.AddComponent<Light>();*/

                    }
        if (Input.GetMouseButtonDown(1))
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = new Vector3(6f, 3f, 2f);
            sphere.AddComponent<Camera>();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject sphere2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere2.transform.position = new Vector3(1f, 3f, 2f);
            sphere2.AddComponent<Rigidbody>();
            
        }

        



    }
}
