using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    public GameObject Red1;
    public GameObject Red2;
    public GameObject Yellow1;
    public GameObject Yellow2;
    public GameObject Green1;
    public GameObject Green2;


    public Material Redg;
    public Material Yellowg;
    public Material Greeng;
    public Material Red;
    public Material Yellow;
    public Material Green;

    private float t1 = 0f;
    private float t2 = 0f;
    public float period = 15f;
    public float yellow_delay = 2f;
    private bool state = true;

    // Start is called before the first frame update
    void Start()
    {
        Color(Green1, Greeng);
        Color(Red2, Redg);
        state = true;
        t1 = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        t2 = Time.time;
        if((t2-t1)>period)
        {
            if (state)
            {
                StartCoroutine(RedToGreen(Red2, Yellow2, Green2, Red, Yellow, Yellowg, Greeng, yellow_delay));
                StartCoroutine(GreenToRed(Red1, Yellow1, Green1, Redg, Yellow, Yellowg, Green, yellow_delay));
            }
            else
            {
                StartCoroutine(GreenToRed(Red2, Yellow2, Green2, Redg, Yellow, Yellowg, Green, yellow_delay));
                StartCoroutine(RedToGreen(Red1, Yellow1, Green1, Red, Yellow, Yellowg, Greeng, yellow_delay));
            }
            state = !state;
            t1 = t2;
        }
    }

    void Color(GameObject obj, Material color)
    {
        obj.GetComponent<MeshRenderer>().material = color;
    }

    IEnumerator RedToGreen(GameObject R, GameObject Y, GameObject G, Material Red, Material Yellow, Material Yellowg, Material Greeng, float yd)
    {
        Color(R, Red);
        Color(Y, Yellowg);
        yield return new WaitForSeconds(yd);
        //System.Threading.Thread.Sleep(10000);
        Color(Y, Yellow);
        Color(G, Greeng);
    }
    IEnumerator GreenToRed(GameObject R, GameObject Y, GameObject G, Material Redg, Material Yellow, Material Yellowg, Material Green, float yd)
    {
        Color(G, Green);
        Color(Y, Yellowg);
        yield return new WaitForSeconds(yd);
        //System.Threading.Thread.Sleep(10000);
        Color(Y, Yellow);
        Color(R, Redg);
    }
}
