using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataIndicatorBehavior : MonoBehaviour
{
    

    public Animator animator;

    string dataNum = "0";
    public TextMesh indicatorText;

    Camera gameCamera;
    void Start()
    {
        animator.Play(0);
        Invoke("DestroyObject", 0.4f);
        indicatorText.text = dataNum;
        gameCamera = FindObjectOfType<Camera>(); 
    }

    void Update()
    {
        indicatorText.transform.LookAt(gameCamera.transform);
        indicatorText.transform.rotation = gameCamera.transform.rotation;
    }

    void DestroyObject(){
        Destroy(gameObject);
        print("Object destroyed");
    }

    public void setNum(int num){
        dataNum =  num.ToString();
    }
    
}
