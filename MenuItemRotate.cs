using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script used to rotate objects continously (used in main menu and instructions)

public class MenuItemRotate : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotateSpeedOfObject = 2.5f;
    public Vector3 itemRotateDirection = new Vector3 (1,0,0);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.rotation = Quaternion.Euler(itemRotateDirection * rotateSpeedOfObject);
        rotateSpeedOfObject += 0.1f;
    }
}
