using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public Vector2 rotation;
    // Start is called before the first frame update
    void Start()
    {
        rotation.x = 0f;
        rotation.y = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        rotation.x = Input.GetAxis("Mouse X");
        rotation.y = Input.GetAxis("Mouse Y");
        transform.Rotate(-rotation.y, rotation.x, 0);
    }
}
