using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for borders that allow for recievers to disable/enable them (ease of access)

public class BorderBehavior : MonoBehaviour
{
    // Adds the border to a list of all borders upon object awakening 
    void Awake(){
        RecieverData recieverData = FindObjectOfType<RecieverData>();
        recieverData.borderList.Add(this.gameObject);
        print(gameObject.name);
    }
}
