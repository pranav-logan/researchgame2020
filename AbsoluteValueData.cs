﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script used to give a core the absolute value behavior once it gets one input

public class AbsoluteValueData : MonoBehaviour
{
    
    public CoreData coreData;
    public DataTransfer dataTransfer;

    // Checks if the user clicks space and then fires if the core is ready to send inputs
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1)){
            
        }
        else if(Input.GetKeyDown(KeyCode.Space) && coreData.input2 != 0 && coreData.input1 != 0){
            callAction(0);
        }
    }

    // Updates the core's info (Text object)
    void LateUpdate(){
        coreData.coreInfo.text = "Object: " + this.gameObject.name + "\n" +  "Return Value: " + coreData.returnValue + "\n";
    }
   
   // Coroutine that checks for input validity (in case two or more inputs are received at once) 
    public IEnumerator callAction(int val){
        yield return StartCoroutine("wait");
        if(coreData.returnValue != 0){
            print("Return value hasn't been reset yet!");
            coreData.storage = 2 * Mathf.Abs(val);
            coreData.storage2 = Mathf.Abs(val) * -1;
        }
        else{
            coreData.returnValue = Mathf.Abs(val);
            this.GetComponent<Renderer>().material = coreData.coreMat;
        }
        
    }

    // Time delay for coroutine 
    IEnumerator wait(){
        yield return new WaitForSeconds(0.01f);
        print("waiting...");
    }
}
