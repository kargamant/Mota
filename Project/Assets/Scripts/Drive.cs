using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    [SerializeField] WheelCollider FL;
    [SerializeField] WheelCollider FR;
    [SerializeField] WheelCollider BL;
    [SerializeField] WheelCollider BR;
    public GameObject FLw;
    public GameObject FRw;
    public GameObject BLw;
    public GameObject BRw;
    public GameObject steerWheel;
    public bool isActiveCam = true;
    public GameObject fp;
    public TextMesh speed_ind;
    public Rigidbody car;

    public float Acceleration=300f;
    public float BrakeForce=500f;
    public float MaxTurnAngle = 10f;
    private Vector3 steerAx;

    private float CurAcceleration = 0f;
    private float CurBrakeForce = 0f;
    private float CurTurnAngle = 0f;

    void Update()
    {
        if (Input.GetKey("c"))
        {
            fp.SetActive(!isActiveCam);
            isActiveCam = !isActiveCam;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        speed_ind.text = (int)System.Math.Sqrt(car.velocity.x* car.velocity.x + car.velocity.y * car.velocity.y + car.velocity.z * car.velocity.z)*5 + " km/h";
        CurAcceleration = Acceleration * Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space))
        {
            CurBrakeForce = BrakeForce;
        }
        else
        {
            CurBrakeForce = 0f;
        }

        FL.motorTorque = CurAcceleration;
        FL.brakeTorque=CurBrakeForce;

        FR.motorTorque = CurAcceleration;
        FR.brakeTorque=CurBrakeForce;

        BR.motorTorque = CurAcceleration;
        BR.brakeTorque = CurBrakeForce;

        BL.motorTorque = CurAcceleration;
        BL.brakeTorque = CurBrakeForce;

        CurTurnAngle = MaxTurnAngle * Input.GetAxis("Horizontal");

        //Vector3 pos;
        //Quaternion rot;
        //FL.GetWorldPose(out pos, out rot);
        //steerWheel.transform.rotation = rot;

        FLw.transform.rotation = Quaternion.Euler(0, CurTurnAngle+90, 0);
        FRw.transform.rotation = Quaternion.Euler(0, CurTurnAngle-90, 0);
        FL.steerAngle = CurTurnAngle;
        FR.steerAngle = CurTurnAngle;

        /*Wheel(FL, FLw.transform);
        Wheel(FR, FRw.transform);
        Wheel(BL, BLw.transform);
        Wheel(BR, BRw.transform);*/
        

    }

    /*void Wheel(WheelCollider collider, Transform wheel)
    {
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);
        wheel.position = position;
        wheel.rotation = rotation;
    }*/
}
