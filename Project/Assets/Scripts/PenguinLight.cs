using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinLight : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider obj)
    {
        //GetComponent<Animator>().enabled = false;
        //print("penguin\n");
        if(obj.gameObject.tag=="walker")
        {
            GetComponent<Light>().enabled = true;
        }
    }

    void OnTriggerExit(Collider obj)
    {
        if (obj.gameObject.tag=="walker")
        {
            GetComponent<Light>().enabled = false;
        }
    }
}
