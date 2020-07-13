using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerBehavior : MonoBehaviour
{

    string currentLevelName;
    public float raycastDelay = 0f;

    public int buildIndex = 0;
    bool wireEnable = false;
    GameObject[] arrayOfObj;
    // Start is called before the first frame update
    void Start()
    {
        currentLevelName = SceneManager.GetActiveScene().name;
        arrayOfObj =  GameObject.FindGameObjectsWithTag("Wire");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)){
            
            for(int i = 0; i < arrayOfObj.Length; i++){
                arrayOfObj[i].SetActive(wireEnable);
            }

            if(wireEnable)
                wireEnable = false;
            else
                wireEnable = true; 
        }
    }

    public void resetLevel(){
        CoreData[] cores = FindObjectsOfType<CoreData>();
        foreach(CoreData core in cores){
            core.resetColors();
        }
        SceneManager.LoadScene(currentLevelName);
    }

    public void addDelay(){
        raycastDelay += 0.01f;
        print("Delay added, current time: " + raycastDelay);
    }

    public void loadNextLevel(){
        buildIndex++;
        SceneManager.LoadScene(buildIndex);
    }
}
