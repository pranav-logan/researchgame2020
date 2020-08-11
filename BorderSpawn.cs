using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script that spwans borders (markers) on all cores on a certain level when a specific core is clicked
// Only used for densely packed levels

public class BorderSpawn : MonoBehaviour
{

    public GameObject border;
    public List<Vector3> vectorList = new List<Vector3>();
    public List<Vector3> sizeList = new List<Vector3>();
    public int layerIndex;

    // Gets user input
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            spawnBorder();
        }
    }

    // Spawns a border depending on what core the user clicked on
    void spawnBorder()
    {
        RaycastHit  hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                  
        if (Physics.Raycast(ray, out hit)) 
        {
            if (hit.transform.tag == "Core" && hit.collider.gameObject == this.gameObject)
            {
                Destroy(GameObject.FindGameObjectWithTag("Border"));
                GameObject borderObj =  Instantiate(border, vectorList[layerIndex], gameObject.transform.rotation);
                borderObj.transform.localScale = sizeList[layerIndex];
            }
        }

    }
}