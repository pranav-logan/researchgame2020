using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script in charge of allowing camera rotation functionality 

public class LevelRotate : MonoBehaviour
{
    public Transform levelCenter;
    void Start()
    {

    }

    // Checks for user input and changes camera rotation based off it
    void Update()
    {
        if(Input.anyKeyDown){

            Vector3 rot = levelCenter.rotation.eulerAngles;

            if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)){
                rot = new Vector3(rot.x,rot.y + 45,rot.z);
            }
            if(Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.W)){
                //rot = new Vector3(rot.x + 45,rot.y,rot.z); Add Functionality if levels become too complex (vertical camera movement)
            }
            if(Input.GetKeyDown(KeyCode.RightArrow)|| Input.GetKeyDown(KeyCode.D)){
                rot = new Vector3(rot.x,rot.y - 45,rot.z);
            }
            if(Input.GetKeyDown(KeyCode.DownArrow)|| Input.GetKeyDown(KeyCode.S)){
                //rot = new Vector3(rot.x - 45,rot.y,rot.z);            
            }

            levelCenter.rotation = Quaternion.Euler(rot);
        }
    }
}
