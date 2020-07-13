using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecieverData : MonoBehaviour
{

    public int requiredNum;
    public Text levelCompleteText;
    public Animation anim;
    public GameManagerBehavior gameManagerBehavior;

    public Text recieverText;

    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animation>();
        recieverText.text = "Goal: " + requiredNum;
        levelCompleteText.enabled = false;
    }

    // Function used for level completion check
    public void checkCompletion(int num){
        if(requiredNum == num){
            print("Level Complete!");
            levelCompleteText.enabled = true;
            Animation animation = levelCompleteText.GetComponent<Animation>();
            animation.Play();
            CoreData[] cores = FindObjectsOfType<CoreData>();
            foreach(CoreData core in cores){
                core.resetColors();
            }
            Invoke("finishLevel", 2f);            
        }
        else{
            print("Level Failed.");
        }
    }

    void finishLevel(){
        gameManagerBehavior.loadNextLevel();
    }
}
