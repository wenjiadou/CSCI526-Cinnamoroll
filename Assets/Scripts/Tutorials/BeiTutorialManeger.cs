using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeiTutorialManeger : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;

    private GameObject player;
    private PlayerController playerController;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUps[i].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }

        if (popUpIndex == 0)
        {
            timer += Time.deltaTime;
            playerController.isMoving = true;
            if (timer >= 2f && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S)))
                // if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S))
            {
                playerController.isMoving = false;
                popUpIndex++;
            }
        }
    }
}
