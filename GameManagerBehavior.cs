using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameManagerBehavior : MonoBehaviour
{

    string currentLevelName;
    public float raycastDelay = 0f;
    public int buildIndex = 0;
    public bool wireEnable = false;
    public List<GameObject> arrayOfObj = new List<GameObject>();
    DisableBlockBehavior[] disabledCores;
    //GameObject[] disableIndicators;
    bool disabledCoresFlag = false;
    bool disablePreventionFlag = false;
    //GameObject emptyCore;
    DataTransfer[] allCores;
    //bool replaceFlag = true;
    //List<GameObject> arrayOfWire = new List<GameObject>(); 
    // Start is called before the first frame update
    void Start()
    {
        currentLevelName = SceneManager.GetActiveScene().name;
        //arrayOfObj =  GameObject.FindGameObjectsWithTag("Wire");

        /*
        foreach(WireBehavior wire in Resources.FindObjectsOfTypeAll(typeof(WireBehavior)) as WireBehavior[]){
            arrayOfWire.Add(wire.gameObject);
        } 
        */

        disabledCores = FindObjectsOfType<DisableBlockBehavior>();
        allCores = FindObjectsOfType<DataTransfer>();
        //disableIndicators = GameObject.FindGameObjectsWithTag("Indicator");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            disablePreventionFlag = true;
            //foreach(DisableBlockBehavior core in disabledCores){
                //core.gameObject.SetActive(true);
            //}
            //replaceCores(replaceFlag); 
            
        }

        if(Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)){
            hideWires();
        }

        if(Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)){
            if(disablePreventionFlag == false){
                foreach(DisableBlockBehavior core in disabledCores){
                    if(core.gameObject.GetComponent<DataTransfer>().firstMoveFlag == false){
                        core.gameObject.SetActive(disabledCoresFlag);
                    }
                }

                if(disabledCoresFlag)
                    disabledCoresFlag = false;
                else
                {
                    disabledCoresFlag = true;
                }
            }
        }
        
    }

    public void resetLevel(){
        CoreData[] cores = FindObjectsOfType<CoreData>();
        foreach(CoreData core in cores){
            core.resetColors();
        }
        foreach(DisableBlockBehavior core in disabledCores){
            core.gameObject.SetActive(true);
        }
        /*
        for(int i = 0; i < arrayOfWire.Count; i ++){
            Destroy(arrayOfWire[i].GetComponent<MeshRenderer>());
        }
        */
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
    public void loadFirstLevel(){
        SceneManager.LoadScene("Level 1");
    }
    public void loadInstructionsCore(){
        SceneManager.LoadScene("Instructions");
    }
    public void loadInstructionsSensor(){
        SceneManager.LoadScene("Instructions (Sensor)");
    }
    public void loadInstructionsReciever(){
        SceneManager.LoadScene("Instructions (Reciever)");
    }
    public void loadInstructionsTutorial(){
        SceneManager.LoadScene("Instructions (Tutorial)");
    }
    public void loadInstructionsMisc(){
        SceneManager.LoadScene("Instructions (Misc)");
    } 
    public void loadInstructionsMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    public void loadInstructionsCredits(){
        SceneManager.LoadScene("Credits");
    }
    public void hideWires(){
        for(int i = 0; i < arrayOfObj.Count; i++){
                arrayOfObj[i].SetActive(wireEnable);
                //print("Wire was enabled: " + wireEnable + " Name: " + arrayOfObj[i].name);
        }

        if(wireEnable)
            wireEnable = false;
        else
            wireEnable = true;
    }

    /*
    void replaceCores(bool flag){
        if(flag == true){
            foreach(DataTransfer data in allCores){
                if(data.firstMoveFlag == false){
                    Instantiate(emptyCore, data.gameObject.transform.position, data.gameObject.transform.rotation);
                    data.gameObject.SetActive(false);
                }
            }
            
        }
        replaceFlag = false;
    }
    */
}
