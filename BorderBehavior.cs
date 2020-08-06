using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake(){
        RecieverData recieverData = FindObjectOfType<RecieverData>();
        recieverData.borderList.Add(this.gameObject);
        print(gameObject.name);
    }
}
