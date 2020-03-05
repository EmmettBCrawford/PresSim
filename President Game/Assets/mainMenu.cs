using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public Scene loadScene;
   public void newGame()
    {

        SceneManager.LoadScene(2);
    }
    public void loadGame()
    {
        // Add load game functionality 
        // SceneManager.LoadScene(loadScene);
        Debug.Log("LoadGame");
    }
}
