using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 velocity;
    //public Quaternion cam_rotate;
    public GameObject fp;
    public float speed_inc = 10f;
    public bool isActiveCam = true;
    public GameObject wheel_FL;
    public GameObject wheel_FR;
    public GameObject wheel_RL;
    public GameObject wheel_RR;
    // Start is called before the first frame update
    void Start()
    {
        //velocity.x = 0;
        //velocity.y = 0;
        //velocity.z = 0;
        /*cam_rotate.x = 0f;
        cam_rotate.y = 0f;
        cam_rotate.z = 0f;*/
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*if (Input.GetKey("w")) velocity.x +=speed_inc;
        if (Input.GetKey("s")) velocity.x-=speed_inc;
        if (Input.GetKey("a")) velocity.y += speed_inc;
        if (Input.GetKey("d")) velocity.y -= speed_inc;
        if (Input.GetKey("b")) velocity.x = 0;*/
        if (Input.GetKey("c"))
        {
            fp.SetActive(!isActiveCam);
            isActiveCam = !isActiveCam;
        }
        /*if (velocity.x != 0 && velocity.y != 0 && velocity.z != 0)
        {
            wheel_FL.transform.Rotate(10f, 0, 0);
            wheel_FR.transform.Rotate(10f, 0, 0);
            wheel_RL.transform.Rotate(10f, 0, 0);
            wheel_RR.transform.Rotate(10f, 0, 0);
        }*/
        //rb.velocity = velocity;
        /*cam_rotate.x= 10*Input.GetAxis("Mouse X");
        cam_rotate.y= 10*Input.GetAxis("Mouse Y");
        cam_rotate.z= 10*Input.GetAxis("Mouse Z");*/
        //transform.Rotate(10f * Input.GetAxis("Mouse X"), 10f * Input.GetAxis("Mouse Y"), 10f * Input.GetAxis("Mouse Z"));
    }
}
