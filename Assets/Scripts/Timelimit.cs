using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timelimit : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer = 5f;
    public GameObject player;
    private bool isDead = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead){
            timer -= Time.deltaTime;
            if (timer<=0) {
                player.SetActive(false);
                isDead = true;
            }
        }
    }
}
