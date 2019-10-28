using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    public void LoadNextScene()
    {
        int currentScene  = SceneManager.GetActiveScene().buildIndex;
        int nextScene     = currentScene + 1;
        int totNumOfScene = SceneManager.sceneCountInBuildSettings;

        if (nextScene < totNumOfScene)
            SceneManager.LoadScene(currentScene + 1);
        else
            SceneManager.LoadScene(0);
    }

}
