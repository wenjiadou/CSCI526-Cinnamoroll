using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EleDown : MonoBehaviour
{
    // Start is called before the first frame update
    private RaycastHit hit;
    private GameObject player;
    // bool isUp = false;
    bool isDown = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDown){
            if(Vector3.Distance(player.transform.position, transform.position)<=1.1 && player.transform.position.y - transform.position.y == 1)
            {
                if (player.GetComponent<PlayerController>().isMoving == false){
                    transform.Translate(Vector3.down);
                    player.transform.Translate(Vector3.down);
                    // player.transform.Translate(Vector3.up);
                    isDown=true;
                }
            }
        }
        if (isDown && Vector3.Distance(player.transform.position, transform.position)>1.5){
            if (player.GetComponent<PlayerController>().isMoving == false){
                transform.Translate(Vector3.up);
                // player.transform.Translate(Vector3.up);
                isDown=false;
            }
        }
    }
}
