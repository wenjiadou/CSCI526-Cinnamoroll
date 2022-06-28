using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;

    public GameObject box1;
    private GameObject player;
    private TutorialDetector detector;
    public GameObject bomb;
    private Inventory inventory;
    private float timer = 0f;
    // private float timer2 = 0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        detector = player.GetComponent<TutorialDetector>();
        inventory = player.GetComponent<Inventory>();
    }

    void Update()
    {
        for(int i = 0; i < popUps.Length; i++)
        {
            if(i == popUpIndex)
            {
                popUps[i].SetActive(true);
                if(i == 1) {
                    // Boxes change Color
                    box1.GetComponent<ChangeColor>().active = true;
                    // Debug.Log("active change color.");
                } else if(inventory.isFull[0] == false && i == 4) {
                    // Bomb Animator active
                    bomb.GetComponent<Animator>().enabled = true;
                }
            } else {
                popUps[i].SetActive(false);
            }
        }

        if(popUpIndex == 0) {
            if(Input.GetKeyDown(KeyCode.D))
            {
                popUpIndex++;
            }
        } else if(popUpIndex == 1) {
            if(detector.detect1 == true)
            {
                popUpIndex++;
                box1.GetComponent<ChangeColor>().active = false;
            }
        } else if(popUpIndex == 2) {
            if(detector.detect2 == true)
            {
                popUpIndex++;
            }
        } else if(popUpIndex == 3) {
            timer += Time.deltaTime;
            if(timer >= 2f)
            {
                popUpIndex++;
            }
        } else if(popUpIndex == 4) {
            if(inventory.isFull[0] == true)
            {
                popUpIndex++;
            }
        } else if(popUpIndex == 5) {
            // timer2 += Time.deltaTime;
            // if(timer2 >= 2f)
            if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                popUpIndex++;
            }
        } else if(popUpIndex == 6) {
            if(inventory.isFull[0] == false)
            {
                popUpIndex++;
            }
        }
    }
}
