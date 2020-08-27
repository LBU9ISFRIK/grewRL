using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        float cos = Mathf.Cos(90 * Mathf.Deg2Rad);
        float acos = Mathf.Acos(cos);
        print(cos);
        print(acos * Mathf.Rad2Deg);
    }

    // Update is called once per frame
    void Update()
    {
        //print(string.Format("{0}, {1}, {2}", transform.position.x, transform.position.y, transform.position.z));
    }
}
