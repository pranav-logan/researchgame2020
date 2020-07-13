using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// HOLDS RAYCAST FUNCTIONALITY AND DATA TRANSFER
public class DataTransfer : MonoBehaviour
{

    RaycastHit hit;
    bool startSequence = false;
    public PointerBehavior pointer;
    public int directionIndex = 0;
    public CoreData coreData;
    public Vector3[] listOfDirections = new Vector3[5];
    public bool lockDataTransfer = false;
    public bool preventDoubleAction = false;
    public GameObject wire;
    public int[] directionsUnableToBeUsed = new int[10];
    int directionsUnableToBeUsedIndex = 0;
    bool firstMoveFlag = false;
   //Used to check if computation has been done, safegaurds against multiple raycasts

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 10; i++){
            directionsUnableToBeUsed[i] = -1;
        }

        listOfDirections[0] = Vector3.forward;
        listOfDirections[1] = Vector3.right;
        listOfDirections[2] = Vector3.left;
        listOfDirections[3] = Vector3.back;
        listOfDirections[4] = Vector3.down;

        for(int startIndex = 0; startIndex < 5; startIndex++)
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(listOfDirections[startIndex]), out hit, 1000))
            {   
                if(hit.transform.tag == "Core" || hit.transform.tag == "Reciever")
                {
                    GameObject newWire = Instantiate(wire, gameObject.transform.position + listOfDirections[startIndex] * 0.68f, Quaternion.Euler(new Vector3(0,0,0)));
                    newWire.transform.localScale = new Vector3 (pointer.quaterionArray[startIndex].x * 0.9f, pointer.quaterionArray[startIndex].y * 0.9f, pointer.quaterionArray[startIndex].z * 0.9f);
                }
                
            }
            else{
                directionsUnableToBeUsed[directionsUnableToBeUsedIndex] = startIndex;
                directionsUnableToBeUsedIndex++;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //Change Direction of Raycast
        if (Input.GetMouseButtonDown(0)) {
            changeDirection(startSequence);
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            moveData();
        }
    }

    void LateUpdate(){
        preventDoubleAction = false;
    }

    void moveData(){
        //Transfer data if raycast hits another core
        if(!lockDataTransfer){
            startSequence = true;
            pointer.pointerMat.color = Color.black;
            lockDataTransfer = true;
            return;
        }

        if(firstMoveFlag == false){
            return;
        }
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(listOfDirections[directionIndex]), out hit, Mathf.Infinity))
        {   
            if(hit.transform.tag == "Core"){
                if(coreData.returnValue != 0){
                    if(preventDoubleAction == false){
                        pointer.moveIndicator();
                        Debug.DrawRay(transform.position, transform.TransformDirection(listOfDirections[directionIndex]) * hit.distance, Color.yellow);
                        hit.transform.SendMessageUpwards("stopTransfer", SendMessageOptions.DontRequireReceiver);
                        hit.transform.SendMessageUpwards("callAction", coreData.returnValue, SendMessageOptions.DontRequireReceiver);
                        coreData.returnValue = 0;
                        coreData.input1 = 0;
                        coreData.input2 = 0;
                        coreData.input1 = coreData.storage;
                        coreData.input2 = coreData.storage2;
                        if(coreData.input2 != 0)
                            coreData.returnValue = coreData.input1 + coreData.input2;
                        if(coreData.returnValue == 0)
                            this.GetComponent<Renderer>().material = coreData.finishedCoreMat;
                        else{
                            this.GetComponent<Renderer>().material = coreData.coreMat;
                        }
                        coreData.storage = 0;
                        coreData.storage2 = 0;
                    }
                    else{
                        preventDoubleAction = false;
                    }
                }
                else{
                    preventDoubleAction = false;
                }
            }
            if(hit.transform.tag == "Reciever"){
                if(coreData.returnValue != 0){
                    if(preventDoubleAction == false){
                        pointer.moveIndicator();
                        Debug.DrawRay(transform.position, transform.TransformDirection(listOfDirections[directionIndex]) * hit.distance, Color.yellow);
                        print("Reciever hit"); 
                        hit.transform.SendMessageUpwards("checkCompletion", coreData.returnValue, SendMessageOptions.DontRequireReceiver);
                        coreData.returnValue = 0;
                        coreData.input1 = 0;
                        coreData.input2 = 0;
                        this.GetComponent<Renderer>().material = coreData.finishedCoreMat;
                    }
                    else{
                        preventDoubleAction = false;
                    }
                }
            }

        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(listOfDirections[directionIndex]) * 1000, Color.white);
        }
    }

    void changeDirection(bool start){
        
        if(startSequence){
            return;
        }
        
        RaycastHit  hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                  
        if (Physics.Raycast(ray, out hit)) {
            if (hit.transform.tag == "Core" && hit.collider.gameObject == this.gameObject)
            {
                if(firstMoveFlag == false)
                    firstMoveFlag = true;

                directionIndex++;

                for(int i = 0; i < directionsUnableToBeUsed.Length; i++){
                    if(directionIndex == directionsUnableToBeUsed[i]){
                        directionIndex++;
                        i = 0;
                    }
                }

                if(directionIndex >= 5){
                    directionIndex = 0;

                    for(int i = 0; i < directionsUnableToBeUsed.Length; i++){
                        if(directionIndex == directionsUnableToBeUsed[i]){
                            directionIndex++;
                            i = 0;
                        }
                    }

                }
                pointer.move();
            }
        }
    }

    public void stopTransfer(){
        if(preventDoubleAction == true){
            preventDoubleAction = false;
        }
        else if(coreData.input1 != 0 && coreData.input2 == 0 && coreData.returnValue == 0){
            preventDoubleAction = true;
        }
        else{
            preventDoubleAction = false;
        }
       
    }
}
