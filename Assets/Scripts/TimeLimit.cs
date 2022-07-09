using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimeLimit : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeLimit = 20f;
    public GameObject timeCounter;
    void Start()
    {
        // timeCounter = GameObject.FindGameObjectWithTag("Count");
    }

    // Update is called once per frame
    void Update()
    {
        timeLimit-=Time.deltaTime;
        if (timeLimit<=5.9) {
            if (timeCounter.activeSelf == false) timeCounter.SetActive(true);
            timeCounter.GetComponent<TMP_Text>().text = ((int)timeLimit).ToString();
        }
        if (timeLimit<=0){
            transform.gameObject.SetActive(false);
            timeCounter.GetComponent<TMP_Text>().text = "Game Over";
        }
    }
}
