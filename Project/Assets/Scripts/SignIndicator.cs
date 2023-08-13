using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignIndicator : MonoBehaviour
{
    public Sprite Stop;
    public Sprite SpeedLimit100;
    public Sprite SpeedLimit50;
    public Sprite SpeedLimit25;
    public GameObject SignInd;
    public GameObject Distance;
    public GameObject Quark;
    public GameObject Count;
    public GameObject Coins;
    public AudioSource km100;
    public AudioSource km50;
    public AudioSource km25;
    public AudioSource speedbump;
    public AudioSource mota;
    public AudioSource stop;
    public AudioSource plus5;
    public AudioSource minus5;
    public AudioSource walker;
    public AudioSource atom;
    public AudioSource heal;
    
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public Material Redg;
    public Material Yellowg;
    public Material Greeng;
    public Material Nong;

    private bool iscorr;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        Coins.GetComponent<TextMesh>().text = score + "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void on_off()
    {
        panel1.GetComponent<Light>().enabled = !panel1.GetComponent<Light>().enabled;
        panel2.GetComponent<Light>().enabled = !panel2.GetComponent<Light>().enabled;
        panel3.GetComponent<Light>().enabled = !panel3.GetComponent<Light>().enabled;
    }

    void clr(Color color, Material material)
    {
        

        panel1.GetComponent<Light>().color = color;
        panel2.GetComponent<Light>().color = color;
        panel3.GetComponent<Light>().color = color;

        panel1.GetComponent<MeshRenderer>().material = material;
        panel2.GetComponent<MeshRenderer>().material = material;
        panel3.GetComponent<MeshRenderer>().material = material;
    }


    void OnTriggerEnter(Collider Sign)
    {
        on_off();
        //GetComponent<Light>().enabled = true;
        //GetComponent<Light>().color = Color.green;
        clr(Color.green, Greeng);

        if (Sign.CompareTag("Stop"))
        {
            SignInd.GetComponent<SpriteRenderer>().enabled = true;
            stop.mute = false;
            stop.Play();
            SignInd.GetComponent<SpriteRenderer>().sprite = Stop;
            
        }
        else if (Sign.CompareTag("25km"))
        {
            SignInd.GetComponent<SpriteRenderer>().enabled = true;
            km25.mute = false;
            km25.Play();
            SignInd.GetComponent<SpriteRenderer>().sprite = SpeedLimit25;
            
        }
        else if (Sign.CompareTag("50km"))
        {
            SignInd.GetComponent<SpriteRenderer>().enabled = true;
            km50.mute = false;
            km50.Play();
            SignInd.GetComponent<SpriteRenderer>().sprite = SpeedLimit50;
            
        }
        else if (Sign.CompareTag("100km"))
        {
            SignInd.GetComponent<SpriteRenderer>().enabled = true;
            km100.mute = false;
            km100.Play();
            SignInd.GetComponent<SpriteRenderer>().sprite = SpeedLimit100;
            
        }
        else if (Sign.CompareTag("mota"))
        {
            mota.mute = false;
            mota.Play();
            //голосовое сообщение(ну и ну, вы обидели моту)
            //iscorr = false;
            
        }
        else if(Sign.CompareTag("bump"))
        {
            speedbump.mute = false;
            speedbump.Play();
            
        }
        else if(Sign.CompareTag("walker") && Sign.gameObject.name!= "Street 8 Prefab (20)")
        {
            walker.mute = false;
            walker.Play();
        }
        else if (Sign.CompareTag("atom"))
        {
            atom.mute = false;
            atom.Play();
        }

        double distance = System.Math.Sqrt(System.Math.Pow(Sign.gameObject.transform.position.x - transform.position.x, 2) + System.Math.Pow(Sign.gameObject.transform.position.y - transform.position.y, 2) + System.Math.Pow(Sign.gameObject.transform.position.z - transform.position.z, 2));
        Distance.GetComponent<MeshRenderer>().enabled = true;
        Distance.GetComponent<TextMesh>().text = (int)distance + "m";
    }

    void OnTriggerStay(Collider Sign)
    {
        double distance = System.Math.Sqrt(System.Math.Pow(Sign.gameObject.transform.position.x - transform.position.x, 2) + System.Math.Pow(Sign.gameObject.transform.position.y - transform.position.y, 2) + System.Math.Pow(Sign.gameObject.transform.position.z - transform.position.z, 2));
        Distance.GetComponent<TextMesh>().text = (int)distance + "m";

        if ((int)distance < 20) clr(Color.yellow, Yellowg);
        if ((int)distance < 10) clr(Color.red, Redg);
        int velocity = (int)System.Math.Sqrt(GetComponent<Rigidbody>().velocity.x * GetComponent<Rigidbody>().velocity.x + GetComponent<Rigidbody>().velocity.y * GetComponent<Rigidbody>().velocity.y + GetComponent<Rigidbody>().velocity.z * GetComponent<Rigidbody>().velocity.z) * 5;
        if (Sign.CompareTag("Stop") && velocity == 0) iscorr = true;
        else if (Sign.CompareTag("25km") && velocity > 25) iscorr = false;
        else if (Sign.CompareTag("50km") && velocity > 50) iscorr = false;
        else if (Sign.CompareTag("100km") && velocity > 100) iscorr = false;
        else if (Sign.CompareTag("bump")) iscorr = true;
        else if (Sign.CompareTag("atom")) iscorr = true;
        else if (Sign.CompareTag("mota")) iscorr = false;
        //else if (Sign.CompareTag("100km") && velocity > 100) iscorr = false;

        //velocity==0 - +5coins stop
    }

    void OnTriggerExit(Collider Sign)
    {
        on_off();
        clr(Color.grey, Nong);
        //GetComponent<Light>().enabled = false;
        SignInd.GetComponent<SpriteRenderer>().enabled = false;
        Distance.GetComponent<MeshRenderer>().enabled = false;

        //Debug.Log("score: " + score);
        //int old_score = score;
        if(Sign.CompareTag("walker"))
        {
            goto trig_end;
        }
        Count.GetComponent<MeshRenderer>().enabled = true;
        if (iscorr)
        {
            plus5.mute = false;
            plus5.Play();
            Count.GetComponent<TextMesh>().color = Color.green;
            if(Sign.CompareTag("Stop"))
            {
                Count.GetComponent<TextMesh>().text = "Mr. stop\n+5 quarks";
                score += 5;
            }
            else if(Sign.CompareTag("25km"))
            {
                Count.GetComponent<TextMesh>().text = "Speed master\n+7 quarks";
                score += 7;
            }
            else if(Sign.CompareTag("50km"))
            {
                Count.GetComponent<TextMesh>().text = "Perfect speed\n+5 quarks";
                score += 5;
            }
            if(Sign.CompareTag("100km"))
            {
                Count.GetComponent<TextMesh>().text = "Not a racer\n+3 quarks";
                score += 3;
            }
            else if(Sign.CompareTag("bump"))
            {
                Count.GetComponent<TextMesh>().text = "Bump the wheels\n+2 quarks";
                score += 2;
            }
            else if(Sign.CompareTag("atom"))
            {
                Count.GetComponent<TextMesh>().text = "Find a friend\n+10 quarks";
                score += 10;
            }
            
        }
        else
        {
            
            if (Sign.CompareTag("mota"))
            {
                minus5.mute = false;
                minus5.Play();
                Count.GetComponent<TextMesh>().color = Color.red;
                Count.GetComponent<TextMesh>().text = "Upset Mota\n-50 quarks";
                score -= 50;
            }
            else if(Sign.CompareTag("Stop"))
            {
                minus5.mute = false;
                minus5.Play();
                Count.GetComponent<TextMesh>().color = Color.red;
                Count.GetComponent<TextMesh>().text = "I never stop\n-5 quarks";
                score -= 5;
            }
            else if(Sign.CompareTag("25km"))
            {
                minus5.mute = false;
                minus5.Play();
                Count.GetComponent<TextMesh>().color = Color.red;
                Count.GetComponent<TextMesh>().text = "Sorry officer\n-3 quarks";
                score -= 3;
            }
            else if(Sign.CompareTag("50km"))
            {
                minus5.mute = false;
                minus5.Play();
                Count.GetComponent<TextMesh>().color = Color.red;
                Count.GetComponent<TextMesh>().text = "Fast and furious\n-5 quarks";
                score -= 5;
            }
            else if(Sign.CompareTag("100km"))
            {
                minus5.mute = false;
                minus5.Play();
                Count.GetComponent<TextMesh>().color = Color.red;
                Count.GetComponent<TextMesh>().text = "What is a speed\n-7 quarks";
                score -= 7;
            }
            if (score < 300)
            {
                heal.mute = false;
                heal.Play();
                Count.GetComponent<TextMesh>().color = Color.yellow;
                Count.GetComponent<TextMesh>().text = "quarks refilled";
                score = 300;
                iscorr = true;
            }
        }
        Coins.GetComponent<TextMesh>().text = score + "";

        trig_end:
            Invoke("disable_count", 3);
        //iscorr action - coins
    }

    void disable_count()
    {
        Count.GetComponent<MeshRenderer>().enabled = false;
    }
}
