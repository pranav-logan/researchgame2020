using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script in charge of recording the user's progress in the game

public class LevelRecorderBehavior : MonoBehaviour
{
    public int currentHighestLevelIndex = 0;

    // Checks for duplicate recorders
    void Start()
    {
        LevelRecorderBehavior[] recorders = FindObjectsOfType<LevelRecorderBehavior>();

        if(recorders.Length > 1)
        {   
            recorders[1].currentHighestLevelIndex = recorders[0].currentHighestLevelIndex; 
            Destroy(recorders[0].gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        
    }

    // Uses recorder to go back to highest level reached
    public void ResumeToLastLevel()
    {
        SceneManager.LoadScene(currentHighestLevelIndex);
    }

    // Checks if new level is higher than previous record
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex > currentHighestLevelIndex && SceneManager.GetActiveScene().name[0] != 'I' && SceneManager.GetActiveScene().name[0] != 'C')
        {
            currentHighestLevelIndex = SceneManager.GetActiveScene().buildIndex;
        }
    }
    
}
