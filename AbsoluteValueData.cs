﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsoluteValueData : MonoBehaviour
{
    // Start is called before the first frame update
    public CoreData coreData;
    public DataTransfer dataTransfer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1)){
            //showInfo();
        }
        else if(Input.GetKeyDown(KeyCode.Space) && coreData.input2 != 0 && coreData.input1 != 0){
            callAction(0);
        }
    }

    void LateUpdate(){
        coreData.coreInfo.text = "Object: " + this.gameObject.name + "\n" +  "Return Value: " + coreData.returnValue + "\n";
    }
   
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

    IEnumerator wait(){
        yield return new WaitForSeconds(0.01f);
        print("waiting...");
    }
}
