using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaTutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;

    private GameObject player;
    private HaTutorialDetect detector;
    private PlayerController playerController;

    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        detector = player.GetComponent<HaTutorialDetect>();
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
            if (detector.detect1 == true)
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 1)
        {
            timer += Time.deltaTime;
            playerController.isMoving = true;
            if (timer >= 1f && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)))
            {
                playerController.isMoving = false;
                popUpIndex++;
                timer = 0f;
            }
        }
        else if (popUpIndex == 2)
        {
            if (detector.detect2 == true)
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 3)
        {
            timer += Time.deltaTime;
            playerController.isMoving = true;
            if (timer >= 1f && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)))
            {
                playerController.isMoving = false;
                popUpIndex++;
            }
        }
    }
}
