using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    //Coins gain types:
    /*
        1. Perfect Speed bump +5 coins
        2. Stop sign +5 coins
        3. Perfect stop +10 coins
        4. Let the pedestrian walk +3 coins
        5. Perfect parking +10 coins
        6. Constangt speed +1coin/second
    */

    //Coins lose:
    /*
        1. Collide with pedestrian -10 coins
        2. Speed bump on more than 40 km/h -5 coins
        3. Collide with other car -20 coins
        4. Speed limit -5 coins
     */

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter3D(Collider trig)
    {

    }
}
