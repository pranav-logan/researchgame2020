using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRotate : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform levelCenter;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown){

            Vector3 rot = levelCenter.rotation.eulerAngles;

            if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)){
                rot = new Vector3(rot.x,rot.y + 45,rot.z);
            }
            if(Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.W)){
                //rot = new Vector3(rot.x + 45,rot.y,rot.z); Add Functionality if levels become too complex
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
