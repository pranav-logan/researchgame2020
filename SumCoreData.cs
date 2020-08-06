using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// SUM COMPUTATION FUNCTIONALITY

public class SumCoreData : MonoBehaviour
{
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
        if(Input.GetKeyDown(KeyCode.Space) && coreData.input2 != 0 && coreData.input1 != 0){
            callAction(0);
        }
    }

    public void callAction(int val){
        if (coreData.input1 == 0){
            coreData.input1 = val;
        }
        else if (coreData.input2 == 0){
            coreData.input2 = val;
            this.GetComponent<Renderer>().material = coreData.coreMat;
            coreData.returnValue = coreData.input1 + coreData.input2;
        }
        else if(coreData.storage == 0){
            print("Storage used by " + gameObject.name + " Value: " + val);
            coreData.storage = val;
        } 
        else{
            print("Storage2 used by " + gameObject.name + " Value: " + val);
            coreData.storage2 = val;
        }
    }

}
