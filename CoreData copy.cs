using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// HOLDS CORE'S DATA (INPUT & OUTPUT)
public class CoreData : MonoBehaviour
{
    public int input1;
    public int input2;
    public int returnValue;
    public int storage;
    public int storage2;
    public Material coreMat;
    public Material finishedCoreMat;
    public Text coreInfo;
    Color coreMatOrig;
    Color finishedCoreMatOrig; 
    float coreMatAlpha;
    float finishedCoreMatAlpha;
    bool transparencyFlag = false;
    public Color defaultColor;
    public Color opaqueColor; 
    
    // Start is called before the first frame update
    void Start()
    {
        Text[] listOfText = FindObjectsOfType<Text>();
        foreach(Text texts in listOfText){
            if(texts.tag == "LevelUI" || texts.tag == "SensorUI"){
                // Use to modify non-core texts
            }
            else{
                texts.enabled = false;
            }
        }

        defaultColor = gameObject.GetComponent<Renderer>().material.color;
        opaqueColor = new Color(defaultColor.r * 2, defaultColor.g * 2, defaultColor.b * 2, 1);

        coreMatOrig = coreMat.color;
        coreMatAlpha = coreMatOrig.a;
        finishedCoreMatOrig = finishedCoreMat.color;
        finishedCoreMatAlpha = finishedCoreMatOrig.a;
    }

    // Update is called once per frame
    void Update()
    {

        this.coreInfo.text = "Object: " + this.gameObject.name + "\n" + "Input 1: " + input1 + "\n" + "Input 2: " + input2 + "\n" + "Return Value: " + returnValue + "\n";

        if(Input.GetKeyDown(KeyCode.Mouse1)){
            changeText(coreInfo);
        }

        if(input1 == 0 && input2 == 0 && storage != 0){
            Invoke("resetStorage", 0.1f);
        }

        if(Input.GetKeyDown(KeyCode.Tab)){
            if(transparencyFlag == false){
                coreMatOrig.a = 0f;
                finishedCoreMatOrig.a = 0f;
                coreMat.color = coreMatOrig;
                finishedCoreMat.color = finishedCoreMatOrig;
                transparencyFlag = true;
            }
            else{
                resetColors();
            }
            
        }
        
    }

    void OnApplicationQuit(){
        resetColors();
    }

    public void changeText(Text coreInfo){
        Text[] listOfText = FindObjectsOfType<Text>();
        RaycastHit  hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    
        if (Physics.Raycast(ray, out hit)) {
            if (hit.transform.tag == "Core" && hit.collider.gameObject == this.gameObject)
            {
                foreach(Text texts in listOfText){
                    if(texts.tag == "LevelUI" || texts.tag == "SensorUI"){
                        // Use to modify non-core texts
                    }
                    else{
                        texts.enabled = false;
                        texts.GetComponentInParent<Renderer>().material.color = texts.GetComponentInParent<CoreData>().defaultColor;
                    }
                }

                //gameObject.GetComponent<Renderer>().material.SetColor(Shader.PropertyToID("_Color"), opaqueColor);
                gameObject.GetComponent<Renderer>().material.color = opaqueColor;

                if(this.coreInfo.enabled == true){
                    this.coreInfo.enabled = false;
                    Debug.Log("Disabled element");
                }
                else{
                    this.coreInfo.enabled = true;
                    Debug.Log("Enabled element");
                }
            }
        }

    }

    public void printAllData(){
        print("Object: " + this.gameObject.name + "\n");
        print("Input 1: " + input1 + "\n");
        print("Input 2: " + input2 + "\n");
        print("Return Value: " + returnValue + "\n");
    }

    void resetStorage(){
        // Functionality has been added in Data Transfer (move Data func)
        //input1 = storage;
        //input2 = storage2;
        //storage = 0;
    }

    public void resetColors(){
        coreMatOrig.a = coreMatAlpha;
        finishedCoreMatOrig.a = finishedCoreMatAlpha;
        coreMat.color = coreMatOrig;
        finishedCoreMat.color = finishedCoreMatOrig;
        transparencyFlag = false;
    }
}
