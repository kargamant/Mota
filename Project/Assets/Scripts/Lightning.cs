using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    //public GameObject light;

    // Start is called before the first frame update 
    void Start()
    {
        //light.GetComponent<Light>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Light>().enabled = true;
            //other.gameobject = light; 
        other.gameObject.GetComponent<Light>().color = Color.green;
    }

    private void OnTriggerStay(Collider Sign)
    {
        int distance = (int)System.Math.Sqrt(System.Math.Pow(Sign.gameObject.transform.position.x - transform.position.x, 2) + System.Math.Pow(Sign.gameObject.transform.position.y - transform.position.y, 2) + System.Math.Pow(Sign.gameObject.transform.position.z - transform.position.z, 2));
        //Sign.gameObject.GetComponent<Light>().color = Color.green;
        if (distance<20) Sign.gameObject.GetComponent<Light>().color = Color.yellow;
        else if(distance<10) Sign.gameObject.GetComponent<Light>().color = Color.red;
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<Light>().enabled = false;
        //other.gameobject = light; 
    }
}
