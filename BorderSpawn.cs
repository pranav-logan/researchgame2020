using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderSpawn : MonoBehaviour
{

    public GameObject border;
    public List<Vector3> vectorList = new List<Vector3>();
    public List<Vector3> sizeList = new List<Vector3>();
    public int layerIndex;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            spawnBorder();
        }
    }

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
