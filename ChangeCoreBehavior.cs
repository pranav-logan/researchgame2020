using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script added on top of cores to give them the ability to switch behaviors (P key)

public class ChangeCoreBehavior : MonoBehaviour
{

    public GameObject changeIndicator;
    public GameObject newCoreType;
    public GameObject oldCoreType;
    GameObject indicator;
    CoreData data;
    
    // Spawn marker to notify user that core can be changed
    void Start()
    {
        indicator = Instantiate(changeIndicator, this.gameObject.transform.position, gameObject.transform.rotation);
    }
    void Awake(){
        data = this.gameObject.GetComponent<CoreData>();
    }

    // Changes core type once 'P' key is clicked on it
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            RaycastHit  hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);      
            if (Physics.Raycast(ray, out hit)) {
                if (hit.transform.tag == "Core" && hit.collider.gameObject == this.gameObject)
                {
                    DataTransfer dataTransfer = GetComponent<DataTransfer>();
                    if(dataTransfer.lockDataTransfer == false)  
                    changeBehavior();
                }
            }
        }
    }

    // Updates the core's text with info about what it can change to
    void LateUpdate(){
        data.coreInfo.text += "Changes to: " + newCoreType.name;
    }

    // Function that does the physical swaping of the cores (invoked by update)
    public void changeBehavior(){
       GameObject newCore = Instantiate(newCoreType, gameObject.transform.position, gameObject.transform.rotation);
       newCore.name = newCoreType.name;
       ChangeCoreBehavior coreBehav = newCore.AddComponent(typeof(ChangeCoreBehavior)) as ChangeCoreBehavior;
       coreBehav.oldCoreType = newCoreType;
       coreBehav.newCoreType = oldCoreType;
       coreBehav.changeIndicator = changeIndicator;
       Destroy(indicator);
       Destroy(this.gameObject);       
    }

}
