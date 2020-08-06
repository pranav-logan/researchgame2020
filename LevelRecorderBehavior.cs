using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelRecorderBehavior : MonoBehaviour
{
    public int currentHighestLevelIndex = 0;

    // Start is called before the first frame update
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

    public void ResumeToLastLevel()
    {
        SceneManager.LoadScene(currentHighestLevelIndex);
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex > currentHighestLevelIndex && SceneManager.GetActiveScene().name[0] != 'I' && SceneManager.GetActiveScene().name[0] != 'C')
        {
            currentHighestLevelIndex = SceneManager.GetActiveScene().buildIndex;
        }
    }
    
}
