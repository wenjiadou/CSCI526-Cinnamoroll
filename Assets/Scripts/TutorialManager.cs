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

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        inventory = player.GetComponent<Inventory>();
        heartSystem = player.GetComponent<HeartSystem>();
        playerController = player.GetComponent<PlayerController>();
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
        } else if(popUpIndex == 2) {
            if (inventory.isFull[0] == false)
            {
                popUpIndex++;
            }

            // Player died
            if(heartSystem.life < 1)
            {
                popUpIndex = 4;
            }

            // Player get the destination
            if(playerController.playVictoryAnimation)
            {
                popUpIndex = 5;
            }
        } else if(popUpIndex == 3) {
            // Player died
            if(heartSystem.life < 1)
            {
                popUpIndex = 4;
            }

            // Player get the destination
            if(playerController.playVictoryAnimation)
            {
                popUpIndex = 5;
            }
        }
    }
}
