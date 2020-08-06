using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake(){
        GameManagerBehavior gm = FindObjectOfType<GameManagerBehavior>();
        gm.arrayOfObj.Add(gameObject);
        //print("Awake called on wire");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
