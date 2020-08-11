using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

// Script in charge of scene (level) loading and visibility toggles

public class GameManagerBehavior : MonoBehaviour
{

    string currentLevelName;
    public float raycastDelay = 0f;
    public int buildIndex = 0;
    public bool wireEnable = false;
    public List<GameObject> arrayOfObj = new List<GameObject>();
    DisableBlockBehavior[] disabledCores;
    bool disabledCoresFlag = false;
    bool disablePreventionFlag = false;
    DataTransfer[] allCores;
    
    // Gets all cores and level name upon scene start-up
    void Start()
    {
        currentLevelName = SceneManager.GetActiveScene().name;
        disabledCores = FindObjectsOfType<DisableBlockBehavior>();
        allCores = FindObjectsOfType<DataTransfer>();
    }

    // Update that checks if user clicks a toggle key 
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            disablePreventionFlag = true;
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

    // Reloads level
    public void resetLevel(){
        CoreData[] cores = FindObjectsOfType<CoreData>();
        foreach(CoreData core in cores){
            core.resetColors();
        }
        foreach(DisableBlockBehavior core in disabledCores){
            core.gameObject.SetActive(true);
        }
        SceneManager.LoadScene(currentLevelName);
    }

    public void addDelay(){
        raycastDelay += 0.01f;
        print("Delay added, current time: " + raycastDelay);
    }

    // Scene (level) loading functions
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

    // Hides wires from scene view
    public void hideWires(){
        for(int i = 0; i < arrayOfObj.Count; i++){
                arrayOfObj[i].SetActive(wireEnable);
        }

        if(wireEnable)
            wireEnable = false;
        else
            wireEnable = true;
    }

}
