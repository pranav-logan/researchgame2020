using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to manage all wires and compile a list of all of them for game manager functions

public class WireBehavior : MonoBehaviour
{

    void Awake()
    {
        GameManagerBehavior gm = FindObjectOfType<GameManagerBehavior>();
        gm.arrayOfObj.Add(gameObject);
    }

    void Update()
    {
        
    }
}
