using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevate : MonoBehaviour
{
    private RaycastHit hit;
    private GameObject player;
    bool isUp = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isUp&&player.GetComponent<PlayerController>().isMoving == false){
            // Debug.Log("test");
            // if(Vector3.Distance(player.transform.position,transform.position + new Vector3(0,1,0))<0.1){
            //     Debug.Log("player");
            // }
            if (Physics.Raycast(transform.position, Vector3.up, out hit, 1.2f) && hit.collider.CompareTag("Player")){
                // elavete up
                
                transform.Translate(Vector3.up);
                hit.collider.transform.Translate(Vector3.up);
                isUp = true;
            }
            
        }
    }
}