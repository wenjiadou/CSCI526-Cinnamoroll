using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startSceneBehave : MonoBehaviour
{
    // tigger: start btn
    // load game
    // 1 = game scene
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    // tigger: nemu btn
    // load menu
    // 2 = menu scene
    public void EnterMenu()
    {
        SceneManager.LoadScene(2);
    }

    // tigger: quit btn
    // quit game
    public void QuitGame(){
        Application.Quit();
    }
}
