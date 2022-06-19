using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;

    private GameObject player;
    private Inventory inventory;
    private HeartSystem heartSystem;
    private PlayerController playerController;

    private float timer1;
    private float timer2;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        inventory = player.GetComponent<Inventory>();
        heartSystem = player.GetComponent<HeartSystem>();
        playerController = player.GetComponent<PlayerController>();
        timer1 = 0f;
        timer2 = 0f;
    }

    void Update()
    {
        for(int i = 0; i < popUps.Length; i++)
        {
            if(i == popUpIndex)
            {
                popUps[i].SetActive(true);
            } else {
                popUps[i].SetActive(false);
            }
        }

        if(popUpIndex == 0)
        {
            if(Input.GetKeyDown(KeyCode.D))
            {
                popUpIndex++;
            }
        } else if(popUpIndex == 1) {
            if(inventory.isFull[0] == true)
            {
                popUpIndex++;
            }
        } else if(popUpIndex == 2) 
        {
            timer1 += Time.deltaTime;
            if(inventory.isFull[0] == false || timer1 >= 3f)
            {
                popUpIndex++;
            }
        } else if(popUpIndex == 3) {
            timer2 += Time.deltaTime;
            if(timer2 >= 3f)
            {
                popUpIndex++;
            }

            // Player died
            if(heartSystem.life < 1)
            {
                popUpIndex = 5;
            }

            // Player get the destination
            if(playerController.playVictoryAnimation)
            {
                popUpIndex = 6;
            }
        } else if(popUpIndex == 4) {
            // Player died
            if(heartSystem.life < 1)
            {
                popUpIndex = 5;
            }

            // Player get the destination
            if(playerController.playVictoryAnimation)
            {
                popUpIndex = 6;
            }
        }
    }
}
