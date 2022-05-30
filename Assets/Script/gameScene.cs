using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameScene : MonoBehaviour
{
    public void gameMenuEnable(){
        GameObject.Find("Canvas/Panel/menu").SetActive(true);
    }

    public void gameMenuDisable(){
        GameObject.Find("Canvas/Panel/menu").SetActive(false);
    }

    public void returnToStart(){
        SceneManager.LoadScene(0);
    }

}