using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingleLevel : MonoBehaviour
{
    public GameObject[] passInfo;
    private int passIndex;
    public GameObject restart;
    public GameObject menu;
    
    private int currentStarsNum = 0;
    public int levelIndex;
    private GameObject player;
    private HeartSystem heartSystem;
    private PlayerController playerController;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        heartSystem = player.GetComponent<HeartSystem>();
        playerController = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        StarRecord();
        for (int i = 0; i < passInfo.Length; i++)
        {
            if (i == passIndex)
            {
                passInfo[i].SetActive(true);
            }
            else
            {
                passInfo[i].SetActive(false);
            }
        }
        
        
    }

    public void BackButton()
    {
        SceneManager.LoadScene("Level Selection");
    }

    public void RestartButton(string _LevelName)
    {
        SceneManager.LoadScene(_LevelName);
    }
    //public void PressStarsButton(int _starsNum)
    // {
    //     currentStarsNum = _starsNum;

    //     if (currentStarsNum > PlayerPrefs.GetInt("Lv" + levelIndex))
    //     {
    //         PlayerPrefs.SetInt("Lv" + levelIndex, _starsNum);
    //     }

    //     //BackButton();
    //     //MARKER Each level has saved their own stars number
    //     //CORE PLayerPrefs.getInt("KEY", "VALUE"); We can use the KEY to find Our VALUE
    //     Debug.Log(PlayerPrefs.GetInt("Lv" + levelIndex, _starsNum));

    //     // BackButton();
    // }

    public void StarRecord()
    {
        // Player get the destination
        if (playerController.playVictoryAnimation)
        {   
            restart.SetActive(true);
            menu.SetActive(true);
            if (heartSystem.life == 1)
            {
                currentStarsNum = 1;
                passIndex = 1; //1 star pass
            }
            else if (heartSystem.life == 2)
            {
                currentStarsNum = 2;
                passIndex = 2;  //2 star pass
            }
            else if (heartSystem.life == 3)
            {
                currentStarsNum = 3;
                passIndex = 3;  //3 star pass
            }


            if (currentStarsNum > PlayerPrefs.GetInt("Lv" + levelIndex))
            {
                PlayerPrefs.SetInt("Lv" + levelIndex, currentStarsNum);
            }

            Debug.Log(PlayerPrefs.GetInt("Lv" + levelIndex, currentStarsNum));

            

        }
        
    }
    

    



}