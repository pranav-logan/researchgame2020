using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCoreBehavior : MonoBehaviour
{

    public GameObject changeIndicator;
    public GameObject newCoreType;
    public GameObject oldCoreType;
    GameObject indicator;
    CoreData data;
    // Start is called before the first frame update
    void Start()
    {
        indicator = Instantiate(changeIndicator, this.gameObject.transform.position, gameObject.transform.rotation);
    }
    void Awake(){
        data = this.gameObject.GetComponent<CoreData>();
    }

    // Update is called once per frame
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

    void LateUpdate(){
        data.coreInfo.text += "Changes to: " + newCoreType.name;
    }

    public void changeBehavior(){
       GameObject newCore = Instantiate(newCoreType, gameObject.transform.position, gameObject.transform.rotation);
       ChangeCoreBehavior coreBehav = newCore.AddComponent(typeof(ChangeCoreBehavior)) as ChangeCoreBehavior;
       coreBehav.oldCoreType = newCoreType;
       coreBehav.newCoreType = oldCoreType;
       coreBehav.changeIndicator = changeIndicator;
       CoreData data = newCore.GetComponent<CoreData>();
       Destroy(indicator);
       Destroy(this.gameObject);       
    }

}
