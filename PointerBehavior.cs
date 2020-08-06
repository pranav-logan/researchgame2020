using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MOVES CORE's POINTER CHILD OBJECT
public class PointerBehavior : MonoBehaviour
{

    public DataTransfer transfer;
    public Material pointerMat;
    public Vector3[] quaterionArray = new Vector3[5];
    int quaterionIndex = 0;
    public GameObject indicator;
    public ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 rot = this.gameObject.transform.rotation.eulerAngles;
        pointerMat.color = Color.white;
        quaterionArray[0] = new Vector3(0.2f,0.2f,1.5f);
        quaterionArray[1] = new Vector3(1.5f,0.2f,0.2f);
        quaterionArray[2] = new Vector3(1.5f,0.2f,0.2f);
        quaterionArray[3] = new Vector3(0.2f,0.2f,1.5f);
        quaterionArray[4] = new Vector3(0.2f,1.5f,0.2f);
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void move(){

        if(quaterionIndex != transfer.directionIndex)
        particle.Play();
        
        quaterionIndex = transfer.directionIndex;
        if(quaterionIndex > 4)
        quaterionIndex = 0;
        
        this.gameObject.transform.localPosition = Vector3.zero;
        this.gameObject.transform.Translate(0.68f * transfer.listOfDirections[transfer.directionIndex]);
        this.gameObject.transform.localScale = quaterionArray[quaterionIndex];
        
    }

    public void moveIndicator(){

        Vector3 rotation = new Vector3(0,0,0);

        switch(transfer.directionIndex){
            
            case 0:
            rotation = new Vector3(0,-90,0);
            print("Case 0");
            break;

            case 1:
            rotation = new Vector3(0,0,0);
            print("Case 1");
            break;

            case 2:
            rotation = new Vector3(0,0,180);
            print("Case 2");
            break;

            case 3:
            rotation = new Vector3(0,90,0);
            print("Case 3");
            break;

            case 4:
            rotation = new Vector3(0,0,-90);
            print("Case 4");
            break;

            default:
            print("Default hit");
            break;
        }

        GameObject tempIndicator;
        int data = this.gameObject.GetComponentInParent<CoreData>().returnValue;
        tempIndicator = Instantiate(indicator, this.gameObject.transform.position, Quaternion.Euler(rotation));
        tempIndicator.SendMessageUpwards("setNum", data);
        Transform child = tempIndicator.GetComponentInChildren<Transform>();
        child.position = gameObject.transform.position;
        
    }

}
