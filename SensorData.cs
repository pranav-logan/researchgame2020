﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 
using UnityEngine;

public class SensorData : MonoBehaviour
{

    public int[] arrayOfInts = new int[20];
    int index = 0;
    public Vector3 directionOfRay;
    RaycastHit hit;
    public Text sensorInfo;

    public GameObject indicator;
    // Start is called before the first frame update
    void Start()
    {
        directionOfRay = Vector3.down;
        this.sensorInfo.text = "Object: " + this.gameObject.name + "\n" + "Inputs Left: " + printArray(arrayOfInts) +"\n";
        sensorInfo.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {        
        if(Input.GetKeyDown(KeyCode.Space)){
            if (Physics.Raycast(transform.position, transform.TransformDirection(directionOfRay), out hit, Mathf.Infinity))
            {   
                if(hit.transform.tag == "Core"){
                    if(arrayOfInts[index] != 0){
                        showIndicator();
                        Debug.DrawRay(transform.position, transform.TransformDirection(directionOfRay) * hit.distance, Color.yellow);
                        hit.transform.SendMessageUpwards("stopTransfer", SendMessageOptions.DontRequireReceiver);
                        hit.transform.SendMessageUpwards("callAction", arrayOfInts[index], SendMessageOptions.DontRequireReceiver);
                        arrayOfInts[index] = 0;
                        index++;
                        this.sensorInfo.text = "Object: " + this.gameObject.name + "\n" + "Inputs Left: " + printArray(arrayOfInts) +"\n";
                    }
                }

            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(directionOfRay) * 1000, Color.white);
            }
        }
        else if(Input.GetKeyDown(KeyCode.Mouse1)){
            //updateSensorText(sensorInfo); (Legacy Function) => used for changing sensor ui visibility 
        }
    }

    string printArray(int[] array){
        
        string result = "";

        for(int i = 0; i < array.Length; i++){
            if(array[i] != 0)
            result += array[i] + " ";
        }

        return result;
    }

    void showIndicator(){
        GameObject tempIndicator;
        tempIndicator = Instantiate(indicator, this.gameObject.transform.position + new Vector3(-0.05f,-1f,-0.25f), Quaternion.Euler(new Vector3(0,0,-90)));
        tempIndicator.SendMessageUpwards("setNum", arrayOfInts[index]);
    }

    void updateSensorText(Text sensorData){ // Legacy Function
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        LayerMask mask = LayerMask.GetMask("Ignore Raycast"); 

        if (Physics.Raycast(ray, out hit,Mathf.Infinity)) {
            if (hit.transform.tag == "Sensor" /*&& hit.collider.gameObject == this.gameObject*/)
            {
                print("sensor hit");
                print(hit.transform.gameObject.GetComponentInParent<SensorData>().sensorInfo.IsActive());
                if(hit.transform.gameObject.GetComponentInParent<SensorData>().sensorInfo.IsActive() ==  false)
                    hit.transform.gameObject.GetComponentInParent<SensorData>().sensorInfo.enabled = true;
                else
                    hit.transform.gameObject.GetComponentInParent<SensorData>().sensorInfo.enabled = false;
            }
        }
    }

}
