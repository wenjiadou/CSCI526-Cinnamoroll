using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class SingleLevel : MonoBehaviour
{
    public GameObject[] passInfo;
    private int passIndex;
    public GameObject restart;
    public GameObject menu;
    public GameObject deadInfo;

    private int currentStarsNum = 0;
    public int levelIndex;
    private GameObject player;
    private HeartSystem heartSystem;
    private PlayerController playerController;

    public float durationSessoin;
    float timeSpent;
    int stars;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        heartSystem = player.GetComponent<HeartSystem>();
        playerController = player.GetComponent<PlayerController>();

        TimerController.instance.BeginTimer();
        timeSpent = FindObjectOfType<TimerController>().elapsedTime;
        stars = FindObjectOfType<Inventory>().stars;

        playerController.currentLevel = levelIndex;
        AnalyticsResult levelResult =  Analytics.CustomEvent("repeatLevel", new Dictionary<string, object>{{"Level", levelIndex}});
        Debug.Log("level analytics "+levelResult);
    }

    void Update()
    {
        durationSessoin += Time.deltaTime * durationSessoin;

        StarRecord();

        if(heartSystem.dead)
        {
            deadInfo.SetActive(true);
            restart.SetActive(true);
            menu.SetActive(true);
        }

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

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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

    bool onetime;

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

            // Debug.Log(PlayerPrefs.GetInt("Lv" + levelIndex, currentStarsNum));

            if (!onetime)
            {
                // level win and how many starts
                AnalyticsResult analyticsResult =  Analytics.CustomEvent("LevelWin_" + levelIndex, new Dictionary<string, object>{
                {"Stars", stars}
                });
                Debug.Log("AnalyticsResult"+ analyticsResult);
                Debug.Log(PlayerPrefs.GetInt("LevelWin" + levelIndex, currentStarsNum));
                // time spent in Level
                Analytics.CustomEvent("time_spent_Level" + levelIndex, new Dictionary<string, object>{
                {"time_spent", timeSpent}
                });
                onetime = true;
            }

        }

    }

    public void PlayerDied()
    {
        if (!onetime)
        {
            AnalyticsResult analyticsResult = Analytics.CustomEvent("PlayerDied" + levelIndex);
            Debug.Log("AnalyticsResult" + analyticsResult);
            Debug.Log(PlayerPrefs.GetInt("PlayerDied" + levelIndex, currentStarsNum));
            onetime = true;
        }
    }

}
