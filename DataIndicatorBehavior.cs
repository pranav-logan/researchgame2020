using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Script that tells indicators (orange blocks that travel along wires) how to function

public class DataIndicatorBehavior : MonoBehaviour
{
    public Animator animator;
    string dataNum = "0";
    public TextMesh indicatorText;
    Camera gameCamera;

    // Prepare for object deletion upon reaching end of animation
    void Start()
    {
        animator.Play(0);
        Invoke("DestroyObject", 0.4f);
        indicatorText.text = dataNum;
        gameCamera = FindObjectOfType<Camera>(); 
    }

    // Calibrate object orientation based on game camera
    void Update()
    {
        indicatorText.transform.LookAt(gameCamera.transform);
        indicatorText.transform.rotation = gameCamera.transform.rotation;
    }

    // Deletes object
    void DestroyObject(){
        Destroy(gameObject);
        print("Object destroyed");
    }

    // Set number displayed on the indicator
    public void setNum(int num){
        dataNum =  num.ToString();
    }
    
}
